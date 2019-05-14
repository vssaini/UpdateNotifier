/****************************** Module SingleInstance ******************************\
* Module Name:  SingleInstance.cs
* Project:      UpdateNotifier
* Date:         22 July, 2013
* Copyright (c) Vikram Singh Saini       
* 
* Provide way for creating single instance of application.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;

namespace UpdateNotifier.Code
{
    internal class SingleInstanceApp : WindowsFormsApplicationBase
    {
        public SingleInstanceApp()
        {
            IsSingleInstance = true;
            StartupNextInstance += StartNextInstance;
        }

        protected override void OnCreateMainForm()
        {
            MainForm = new FrmMain();
        }

        // Handler when attemping to start another instance of this application 
        private void StartNextInstance(object sender, StartupNextInstanceEventArgs e)
        {
            var mainForm = MainForm as FrmMain;
            if (mainForm == null) return;
            
            mainForm.Activate();
            mainForm.Show();
            mainForm.UpdaterNotifyIcon.ShowBalloonTip(1000, "Update Notifier", "Already running here!", ToolTipIcon.Info);
        }
    }
}