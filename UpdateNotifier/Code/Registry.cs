/****************************** Module SingleInstance ******************************\
* Module Name:  Registry.cs
* Project:      UpdateNotifier
* Date:         23 July, 2013
* Copyright (c) Vikram Singh Saini       
* 
* Provide way for checking registry key existence.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System.Windows.Forms;
using Microsoft.Win32;

namespace UpdateNotifier.Code
{
    class MyRegistry
    {
        private const string SubKeyUninstall = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
        private const string SubKeyRun = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

        public static bool CheckKeyExistence(string keyName)
        {
            var check = false;
            var baseRegistryKey = Registry.LocalMachine;
            var uninstallKey = baseRegistryKey.OpenSubKey(SubKeyUninstall);

            // Name of all subkeys
            if (uninstallKey != null)
            {
                var subKeys = uninstallKey.GetSubKeyNames();

                foreach (var skey in subKeys)
                {
                    if (keyName.Equals(skey))
                        check = true;
                }
            }

            return check;
        }

        public static void AddToStartup()
        {
            var runKey = Registry.LocalMachine.OpenSubKey(SubKeyRun, true);
            if (runKey != null) 
                runKey.SetValue("Update Notifier", Application.ExecutablePath);
        }
    }
}
