/* Project : All for Wakfu
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
using System.Drawing;

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
                List<Item> listItem = new List<Item>();

                var tableItems = Browser.Document.GetElementsByTagName("table");

                foreach (HtmlElement table in tableItems)
                {
                    if (table.GetAttribute("className") == "ak-table ak-responsivetable")
                    {
                        // <table> who contains all items
                        var trItems = table.GetElementsByTagName("tr");

                        foreach (HtmlElement tr in trItems)
                        {
                            if (tr.GetAttribute("className") == "ak-bg-odd" || tr.GetAttribute("className") == "ak-bg-even")
                            {
                                // <tr> who contains stats from an item
                                int idItem = -1;
                                string nameItem = "";
                                Image imgItem = null;
                                string typeItem = "";
                                int rarityItem = -1;
                                int lvlItem = -1;
                                string urlItem = "";
                                Dictionary<string, int> statsItem = new Dictionary<string, int>();

                                Dictionary<string, HtmlElement> ItemTagsData = new Dictionary<string, HtmlElement>();
                                
                                var spanTags = tr.GetElementsByTagName("span");
                                var tdTags = tr.GetElementsByTagName("td");
                                
                                foreach (HtmlElement span in spanTags)
                                {
                                    try
                                    {
                                        if (span.FirstChild.FirstChild.GetAttribute("alt") != "" && span.FirstChild.FirstChild != null)
                                        {

                                            ItemTagsData.Add("url_img_name", span.FirstChild); // item url, image, name
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        // span don't have two child
                                    }

                                    if (span.GetAttribute("title") != "")
                                    {
                                        ItemTagsData.Add("rarity", span);
                                    }
                                }

                                foreach (HtmlElement td in tdTags)
                                {
                                    if (td.GetAttribute("className") == "item-type")
                                    {
                                        ItemTagsData.Add("type_item", td);
                                    }
                                }
    
                            }
                        }
                    }

                }
                Browser.Stop();
            }
        }
    }
}
