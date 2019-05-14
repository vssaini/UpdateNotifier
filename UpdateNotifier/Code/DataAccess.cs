/****************************** Module SingleInstance ******************************\
* Module Name:  DataAccess.cs
* Project:      UpdateNotifier
* Date:         22 July, 2013
* Copyright (c) Vikram Singh Saini       
* 
* Provide way for connecting to database and retrieving values.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace UpdateNotifier.Code
{
    class DataAccess
    {
        public static DataTable GetData()
        {
            var table = new DataTable();
            var conString = ConfigurationManager.ConnectionStrings["conSTring"].ConnectionString;

            try
            {
                var dataAdapter = new SqlDataAdapter("SELECT * FROM AppsData", conString);
                dataAdapter.Fill(table);
            }
            catch (Exception)
            {
               table = null;
            }
               
            return table;
        }
    }
}
