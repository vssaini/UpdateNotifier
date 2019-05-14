using System.Drawing;
using System.Windows.Forms;

namespace UpdateNotifier
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridView1 = new System.Windows.Forms.DataGridView();
            this.lblUpdater = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.UpdaterNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblNotice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::UpdateNotifier.Properties.Resources.ImgBanner;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(639, 82);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.groupBox1.Controls.Add(this.lblNotice);
            this.groupBox1.Controls.Add(this.gridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(613, 247);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Available Application Updates";
            // 
            // gridView1
            // 
            this.gridView1.AllowUserToAddRows = false;
            this.gridView1.AllowUserToDeleteRows = false;
            this.gridView1.AllowUserToResizeColumns = false;
            this.gridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.gridView1.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridView1.DefaultCellStyle = dataGridViewCellStyle8;
            this.gridView1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Location = new System.Drawing.Point(12, 32);
            this.gridView1.Name = "gridView1";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gridView1.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.gridView1.Size = new System.Drawing.Size(590, 205);
            this.gridView1.TabIndex = 0;
            this.gridView1.Text = "GridView1";
            this.gridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridView1_CellClick);
            // 
            // lblUpdater
            // 
            this.lblUpdater.AutoEllipsis = true;
            this.lblUpdater.BackColor = System.Drawing.Color.Transparent;
            this.lblUpdater.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUpdater.Location = new System.Drawing.Point(12, 358);
            this.lblUpdater.Name = "lblUpdater";
            this.lblUpdater.Size = new System.Drawing.Size(177, 27);
            this.lblUpdater.TabIndex = 1;
            this.lblUpdater.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(447, 359);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(86, 24);
            this.btnHelp.TabIndex = 6;
            this.btnHelp.Text = "Help";
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(539, 359);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(86, 24);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Location = new System.Drawing.Point(0, 392);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(637, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "StatusStrip1";
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "Ready";
            this.label2.AccessibleName = "Ready";
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ready";
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "Ready";
            this.label1.AccessibleName = "Ready";
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ready";
            // 
            // UpdaterNotifyIcon
            // 
            this.UpdaterNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("UpdaterNotifyIcon.Icon")));
            this.UpdaterNotifyIcon.Text = "No new updates";
            this.UpdaterNotifyIcon.Visible = true;
            this.UpdaterNotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UpdaterNotifyIcon_Click);
            this.UpdaterNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.UpdaterNotifyIcon_Click);
            // 
            // bgWorker
            // 
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(355, 359);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(86, 24);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblNotice
            // 
            this.lblNotice.AutoEllipsis = true;
            this.lblNotice.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblNotice.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotice.ForeColor = System.Drawing.Color.White;
            this.lblNotice.Location = new System.Drawing.Point(78, 49);
            this.lblNotice.Name = "lblNotice";
            this.lblNotice.Size = new System.Drawing.Size(470, 22);
            this.lblNotice.TabIndex = 1;
            this.lblNotice.Text = "The connection to the \'Update Notifier\' database is not available!\r\n";
            this.lblNotice.Visible = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(637, 414);
            this.Controls.Add(this.lblUpdater);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(645, 448);
            this.MinimumSize = new System.Drawing.Size(645, 448);
            this.Name = "FrmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Notifier";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private GroupBox groupBox1;
        private DataGridView gridView1;
        private Button btnHelp;
        private Button btnExit;
        private StatusStrip statusStrip1;
        private Label label1;
        private Label label2;
        public NotifyIcon UpdaterNotifyIcon;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private Label lblUpdater;
        private Button btnRefresh;
        private Label lblNotice;
    }
}

