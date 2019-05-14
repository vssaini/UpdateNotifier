using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using UpdateNotifier.Code;
using System.Drawing;

namespace UpdateNotifier
{
    public partial class FrmMain : Form
    {
        #region Form related

        public FrmMain()
        {
            InitializeComponent();

            // Form initial settings
            ShowInTaskbar = false;
            Visible = false;

            // Add app to Startup
            if (Properties.Settings.Default.AddedToStartup) return;
            MyRegistry.AddToStartup();
            Properties.Settings.Default.AddedToStartup = true;

            // Error handling for application
            var currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += CrashHandler;
            Application.ThreadException += CrashHandler_thread;
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            if (DataAccess.GetData() != null)
            {
                lblUpdater.Text = "Please wait! Retrieving data...";
                lblUpdater.Image = Properties.Resources.BlueLoader;
                bgWorker.RunWorkerAsync();

                //ReadData();
                //if (!gridView1.Columns.Contains("OpenDirectory"))
                //    Invoke((MethodInvoker)AddGridViewColumns);
                //HideRows();
            }
            else
            {
                lblNotice.Visible = true;
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdaterNotifyIcon.Dispose();
        }

        #endregion

        #region Crash handler implementation

        private static void CrashHandler(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Program Error:" + e);
        }

        private static void CrashHandler_thread(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show("Thread Error: " + e);
        }

        #endregion

        #region Click events

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (DataAccess.GetData() == null)
            {
                if (gridView1.DataSource != null)
                {
                    gridView1.DataSource = null;
                }
                else
                {
                    gridView1.Rows.Clear();
                }

                if (gridView1.Columns["OpenDirectory"] != null)
                    gridView1.Columns.Remove("OpenDirectory");

                lblNotice.Visible = true;
                UpdaterNotifyIcon.Icon = Properties.Resources.AppIco;
                UpdaterNotifyIcon.Text = "No new updates";

            }
            else
            {
                btnRefresh.Enabled = false;
                lblUpdater.Text = "Please wait! Retrieving data...";
                lblUpdater.Image = Properties.Resources.BlueLoader;

                lblNotice.Visible = false;
                UpdaterNotifyIcon.Icon = Properties.Resources.IcoUpdateReady;
                UpdaterNotifyIcon.Text = " Updates available!";

                Application.DoEvents();
                bgWorker.RunWorkerAsync();
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            Visible = false;
        }

        private void UpdaterNotifyIcon_Click(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            Visible = true;
            Activate();

            Application.DoEvents();

            // Hide rows again because of form enabling disabled buttons
            if (gridView1.Rows.Count > 0)
                HideRows();
        }

        private void gridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var directoryColumn = gridView1.Columns["OpenDirectory"];
            if (directoryColumn == null || (e.ColumnIndex != directoryColumn.Index || e.RowIndex < 0)) return;

            var buttonText = gridView1.Rows[e.RowIndex].Cells["OpenDirectory"].Value.ToString();
            var path = gridView1.Rows[e.RowIndex].Cells["InstallationFolder"].Value.ToString();

            if (Directory.Exists(path) && buttonText.Equals("Open"))
                System.Diagnostics.Process.Start(path);
        }

        #endregion

        #region Threading : Initiate datagridview filling

        private void bgWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Invoke((MethodInvoker)ReadData);

            if (!gridView1.Columns.Contains("OpenDirectory"))
                Invoke((MethodInvoker)AddGridViewColumns);

            Invoke((MethodInvoker)HideRows);
        }

        private void bgWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            lblUpdater.Dispose();
            btnRefresh.Enabled = true;
        }

        #region DataGridView data filling

        private void ReadData()
        {
            gridView1.DataSource = DataAccess.GetData();

            var appColumn = gridView1.Columns["Application"];
            var dateColumn = gridView1.Columns["DeployDate"];

            if (appColumn != null)
                appColumn.SortMode = DataGridViewColumnSortMode.NotSortable;

            if (dateColumn == null) return;
            dateColumn.HeaderText = "Deployment Date";
            dateColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            dateColumn.DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        public void AddGridViewColumns()
        {
            var directoryColumn = gridView1.Columns["InstallationFolder"];
            if (directoryColumn != null) directoryColumn.Visible = false;

            var registryColumn = gridView1.Columns["RegistryKey"];
            if (registryColumn != null) registryColumn.Visible = false;

            var openColumn = new DataGridViewDisableButtonColumn
                {
                    HeaderText = "Installation Folder",
                    Name = "OpenDirectory",
                    UseColumnTextForButtonValue = true,
                    Text = "Open",
                    SortMode = DataGridViewColumnSortMode.NotSortable
                };


            gridView1.Columns.Add(openColumn);
            gridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void HideRows()
        {
            if (gridView1.Rows.Count <= 0)return;

            var isUpdateAvailable = false;

            // Row associated with the currency manager's position cannot be made invisible
            var currencyManager = (CurrencyManager)BindingContext[gridView1.DataSource];
            currencyManager.SuspendBinding();

            foreach (DataGridViewRow row in gridView1.Rows)
            {
                // Make row invisible whose folder not exists
                if (Directory.Exists(Convert.ToString(row.Cells["InstallationFolder"].Value)))
                {
                    row.Visible = true;

                    #region Toggle button enabling as per key availability

                    if (MyRegistry.CheckKeyExistence(row.Cells["RegistryKey"].Value.ToString())) //Key exist true
                    {
                        var button = (DataGridViewDisableButtonCell)row.Cells["OpenDirectory"];

                        if (button.Enabled)
                        {
                            button.Enabled = false;
                            button.ReadOnly = true;
                            button.UseColumnTextForButtonValue = false;
                            button.Value = "Already installed";
                        }

                        UpdaterNotifyIcon.Text = "No new updates";
                        UpdaterNotifyIcon.Icon = Properties.Resources.AppIco;
                    }
                    else
                    {
                        var button = (DataGridViewDisableButtonCell)row.Cells["OpenDirectory"];
                        if (!button.Enabled)
                        {
                            button.Enabled = true;
                            button.UseColumnTextForButtonValue = false;
                            button.Value = "Open";
                        }

                        isUpdateAvailable = true;
                        UpdaterNotifyIcon.Text = "Updates available!";
                        UpdaterNotifyIcon.Icon = Properties.Resources.IcoUpdateReady;
                    }

                    #endregion
                }
                else
                {
                    row.Visible = false;
                    if(!isUpdateAvailable)
                    {
                        UpdaterNotifyIcon.Text = "No new updates";
                        UpdaterNotifyIcon.Icon = Properties.Resources.AppIco;
                    }
                }
            }

            currencyManager.ResumeBinding();
        }

        #endregion

        #endregion

        #region OVERRIDDEN CLASSES: DataGridViewDisableButtonColumn AND DataGridViewDisableButtonCell

        public class DataGridViewDisableButtonColumn : DataGridViewButtonColumn
        {
            public DataGridViewDisableButtonColumn()
            {
                CellTemplate = new DataGridViewDisableButtonCell();
            }

            public override sealed DataGridViewCell CellTemplate
            {
                get { return base.CellTemplate; }
                set { base.CellTemplate = value; }
            }
        }

        public class DataGridViewDisableButtonCell : DataGridViewButtonCell
        {
            private bool _enabledValue;

            public bool Enabled
            {
                get { return _enabledValue; }
                set { _enabledValue = value; }
            }

            // Override the Clone method so that the Enabled property is copied. 
            public override object Clone()
            {
                var cell = (DataGridViewDisableButtonCell)base.Clone();
                cell.Enabled = Enabled;
                return cell;
            }

            // By default, enable the button cell. 
            public DataGridViewDisableButtonCell()
            {
                _enabledValue = true;
            }

            protected override void Paint(Graphics graphics,
                                          Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
                                          DataGridViewElementStates elementState, object value,
                                          object formattedValue, string errorText,
                                          DataGridViewCellStyle cellStyle,
                                          DataGridViewAdvancedBorderStyle advancedBorderStyle,
                                          DataGridViewPaintParts paintParts)
            {
                // The button cell is disabled, so paint the border,   
                // background, and disabled button for the cell. 
                if (!_enabledValue)
                {
                    // Draw the cell background, if specified. 
                    if ((paintParts & DataGridViewPaintParts.Background) ==
                        DataGridViewPaintParts.Background)
                    {
                        var cellBackground = new SolidBrush(cellStyle.BackColor);
                        graphics.FillRectangle(cellBackground, cellBounds);
                        cellBackground.Dispose();
                    }

                    // Draw the cell borders, if specified. 
                    if ((paintParts & DataGridViewPaintParts.Border) ==
                        DataGridViewPaintParts.Border)
                    {
                        PaintBorder(graphics, clipBounds, cellBounds, cellStyle,
                                    advancedBorderStyle);
                    }

                    // Calculate the area in which to draw the button.
                    var buttonArea = cellBounds;
                    var buttonAdjustment = BorderWidths(advancedBorderStyle);
                    buttonArea.X += buttonAdjustment.X;
                    buttonArea.Y += buttonAdjustment.Y;
                    buttonArea.Height -= buttonAdjustment.Height;
                    buttonArea.Width -= buttonAdjustment.Width;

                    // Draw the disabled button.                
                    ButtonRenderer.DrawButton(graphics, buttonArea,
                                              PushButtonState.Disabled);

                    // Draw the disabled button text.  
                    if (!(FormattedValue is String)) return;
                    TextRenderer.DrawText(graphics,
                                          (string)FormattedValue,
                                          DataGridView.Font,
                                          buttonArea, SystemColors.GrayText);
                }
                else
                {
                    // The button cell is enabled, so let the base class  
                    // handle the painting. 
                    base.Paint(graphics, clipBounds, cellBounds, rowIndex,
                               elementState, value, formattedValue, errorText,
                               cellStyle, advancedBorderStyle, paintParts);
                }
            }
        }

        #endregion

    }
}
