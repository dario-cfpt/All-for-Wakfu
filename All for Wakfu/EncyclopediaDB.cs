﻿/* Project : All for Wakfu
 * Description : Builder for Wakfu
 * Date : 15.03.2018
 * Author : GENGA Dario
 * © 2018
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace All_for_Wakfu
{
    public class EncyclopediaDB
    {
        private SqlConnection _dbConnection;
        #region url
        private const string ARMORS_URL = "https://www.wakfu.com/fr/mmorpg/encyclopedie/armures";
        private const string ACCESSORIES_URL = "https://www.wakfu.com/fr/mmorpg/encyclopedie/accessoires";
        private const string PETS_URL = "https://www.wakfu.com/fr/mmorpg/encyclopedie/familiers";
        private const string MOUNTS_URL = "https://www.wakfu.com/fr/mmorpg/encyclopedie/montures";
        #endregion url
        private WebBrowser _browser;
        private string _browserDocumentText;


        public EncyclopediaDB()
        {
            OpenConnection();
        }

        public SqlConnection DbConnection { get => _dbConnection; set => _dbConnection = value; }
        public WebBrowser Browser { get => _browser; set => _browser = value; }
        private string BrowserDocumentText { get => _browserDocumentText; set => _browserDocumentText = value; }
        
        private void OpenConnection()
        {
            DbConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\AllForWakfuDB.mdf;Integrated Security=True"); // TODO : Verify this later
            DbConnection.Open();
        }

        public void UpdateDB()
        {
            Browser = new WebBrowser
            {
                ScriptErrorsSuppressed = true,
            };
            Browser.Navigating += Browser_Navigating;
            Browser.Navigate(new Uri(ARMORS_URL));

            
        }

        private void Browser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            BrowserDocumentText = Browser.DocumentText;

            if (BrowserDocumentText != "")
            {
                var tableItems = Browser.Document.GetElementsByTagName("table");

                foreach (HtmlElement table in tableItems)
                {
                    if (table.GetAttribute("className") == "ak-table ak-responsivetable")
                    {
                        // <table> who contains all items
                        var trItems = table.Document.GetElementsByTagName("tr");

                        foreach (HtmlElement tr in trItems)
                        {
                            if (tr.GetAttribute("className") == "ak-bg-odd" || tr.GetAttribute("className") == "ak-bg-even")
                            {
                                // <tr> who contains stats from an item
                                Console.Write("noice");
                            }
                        }
                    }

                }
                Browser.Stop();
            }
        }
    }
}