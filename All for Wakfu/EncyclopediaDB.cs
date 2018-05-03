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
using System.Net;
using System.IO;
using System.Drawing.Imaging;

namespace All_for_Wakfu
{
    public class EncyclopediaDB
    {
        private SqlConnection _dbConnection;
        #region url
        private const string ARMORS_URL = "https://www.wakfu.com/fr/mmorpg/encyclopedie/armures?page=";
        private const string ACCESSORIES_URL = "https://www.wakfu.com/fr/mmorpg/encyclopedie/accessoires?page=";
        private const string PETS_URL = "https://www.wakfu.com/fr/mmorpg/encyclopedie/familiers?page=";
        private const string MOUNTS_URL = "https://www.wakfu.com/fr/mmorpg/encyclopedie/montures?page=";
        #endregion url
        #region className
        private const string TABLE_DATA_CLASS_NAME = "ak-table ak-responsivetable";
        private const string ITEM_CLASS_NAME_ODD = "ak-bg-odd";
        private const string ITEM_CLASS_NAME_EVEN = "ak-bg-even";
        private const string ITEM_RARITY_CLASS_NAME = "ak-icon-small";
        private const string ITEM_TYPE_CLASS_NAME = "item-type";
        private const string ITEM_LVL_CLASS_NAME = "item-level";
        private const string ITEM_ALL_CARACTERISTICS_CLASS_NAME = "item-caracteristics";
        private const string ITEM_CARACTERISTIC_CLASS_NAME = "ak-list-element";
        private const string ITEM_VALUE_CARACTERISTIC_CLASS_NAME = "ak-title";
        #endregion className

        private WebBrowser _browser;
        private int _pageActual = 1;
        private List<Item> _listItem;
        private Dictionary<int, string> _typeItemsDictionnary;
        
        public EncyclopediaDB()
        {
            OpenConnection();
            ListItem = new List<Item>();
        }

        public SqlConnection DbConnection { get => _dbConnection; set => _dbConnection = value; }
        public WebBrowser Browser { get => _browser; set => _browser = value; }
        private int PageActual { get => _pageActual; set => _pageActual = value; }
        private List<Item> ListItem { get => _listItem; set => _listItem = value; }
        /// <summary>
        /// Key = id of the type of item
        /// <para>Value = the label of the type of item</para>
        /// </summary>
        public Dictionary<int, string> TypeItemsDictionnary { get => _typeItemsDictionnary; set => _typeItemsDictionnary = value; }

        /// <summary>
        /// Open the SQL connection with the local SQLite database
        /// </summary>
        private void OpenConnection()
        {
            string exePath = System.Reflection.Assembly.GetEntryAssembly().Location;
            string currentDirectory = Path.GetDirectoryName(exePath);
            string attachDbFilename = currentDirectory + @"\AllForWakfuDB.mdf";
            DbConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + attachDbFilename + ";Integrated Security=True") ;
            DbConnection.Open();
        }

        /// <summary>
        /// Start the update of the databse
        /// </summary>
        public void StartUpdateDB()
        {
            CreateTypeItemsDictionnary();
            CreateNewBrowser();
        }


        #region WebBrowser Methods
        /// <summary>
        /// Delete the Browser existant and create a new Browser (necessary for the redirection)
        /// </summary>
        private void CreateNewBrowser()
        {
            Browser = new WebBrowser
            {
                ScriptErrorsSuppressed = true,
            };
            Browser.Navigating += Browser_Navigating;
            Browser.Navigate(new Uri(ARMORS_URL + PageActual));
        }

        /// <summary>
        /// Recovers data of items from the siteweb when the WebBrowser is going to navigate to a new browser document.
        /// </summary>
        private void Browser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (Browser.DocumentText != "")
            {
                var tableItems = Browser.Document.GetElementsByTagName("table");

                if (tableItems.Count > 0 && PageActual <= 3) // we recup data from the 3 first page for the time being
                {
                    foreach (HtmlElement table in tableItems)
                    {
                        if (table.GetAttribute("className") == TABLE_DATA_CLASS_NAME)
                        {
                            // <table> who contains all items
                            var trItems = table.GetElementsByTagName("tr");

                            foreach (HtmlElement tr in trItems)
                            {
                                if (tr.GetAttribute("className") == ITEM_CLASS_NAME_ODD || tr.GetAttribute("className") == ITEM_CLASS_NAME_EVEN)
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

                                    var spanTags = tr.GetElementsByTagName("span");
                                    var tdTags = tr.GetElementsByTagName("td");

                                    foreach (HtmlElement span in spanTags)
                                    {
                                        try
                                        {
                                            // first child -> <a>, "second" child -> <img>
                                            if (span.FirstChild.FirstChild.GetAttribute("alt") != "" && span.FirstChild.FirstChild != null)
                                            {
                                                // this span need to have two child (<a> & <img>) to get url, image and name of the item
                                                nameItem = span.FirstChild.FirstChild.GetAttribute("alt");
                                                urlItem = span.FirstChild.GetAttribute("href");
                                                // the id is stocked like this : .../24120-nameItem, so we ned to split it
                                                idItem = Convert.ToInt32(urlItem.Split('/').Last().Split('-').First());

                                                string urlImg = span.FirstChild.FirstChild.GetAttribute("src");
                                                // Create an image from the url
                                                using (WebClient wc = new WebClient())
                                                {
                                                    using (MemoryStream ms = new MemoryStream(wc.DownloadData(urlImg)))
                                                    {
                                                        imgItem = Image.FromStream(ms);
                                                    }
                                                }
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            // their is no "second" child, so we do nothing
                                        }

                                        if (span.GetAttribute("className").Split(' ')[0] == ITEM_RARITY_CLASS_NAME)
                                        {
                                            // the rarity is stocked like this : ak-icon-small ak-rarity-6, so we need to split it
                                            rarityItem = Convert.ToInt32(span.GetAttribute("className").Split('-').Last());
                                        }
                                    }

                                    foreach (HtmlElement td in tdTags)
                                    {
                                        if (td.GetAttribute("className") == ITEM_TYPE_CLASS_NAME)
                                        {
                                            typeItem = td.FirstChild.GetAttribute("title");
                                        }

                                        if (td.GetAttribute("className") == ITEM_LVL_CLASS_NAME && td.InnerText != null)
                                        {
                                            // The lvl is stocked like this : Niv. 200, so we need this split it
                                            lvlItem = Convert.ToInt32(td.InnerText.Split(' ').Last());
                                        }

                                        if (td.GetAttribute("className") == ITEM_ALL_CARACTERISTICS_CLASS_NAME)
                                        {
                                            foreach (HtmlElement div in td.GetElementsByTagName("div"))
                                            {
                                                if (div.GetAttribute("className") == ITEM_CARACTERISTIC_CLASS_NAME)
                                                {
                                                    foreach (HtmlElement divWithValue in div.GetElementsByTagName("div"))
                                                    {
                                                        if (divWithValue.GetAttribute("className") == ITEM_VALUE_CARACTERISTIC_CLASS_NAME)
                                                        {
                                                            // we have to remplace to delete the char '%' and then trim the text of stats for spliting it correctly
                                                            string[] stats = divWithValue.InnerText.Replace("%", "").Trim().Split(' ');

                                                            try
                                                            {
                                                                int valueStat = Convert.ToInt32(stats[0]);
                                                                string typeStats = "";

                                                                for (int i = 1; i < stats.Count(); i++)
                                                                {
                                                                    typeStats += stats[i] + " ";
                                                                }
                                                                statsItem.Add(typeStats.Trim(), valueStat);
                                                            }
                                                            catch (Exception)
                                                            {
                                                                // An exception can occurs with special caracteristics
                                                                statsItem.Add(divWithValue.InnerText.Trim(), -1);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    ListItem.Add(new Item(idItem, nameItem, imgItem, typeItem, rarityItem, lvlItem, urlItem, statsItem));
                                }
                            }
                        }
                    }
                    PageActual++;
                    CreateNewBrowser(); // We have to create a new browser for navigating to the next page correctly
                }
                else
                {
                    UpdateDataFromDatabase();
                    e.Cancel = true;
                }
            }
        }
        #endregion WebBrowser Methods

        #region Database Methods
        /// <summary>
        /// Execute the queries for updating the database
        /// </summary>
        private void UpdateDataFromDatabase()
        {
            using (SqlCommand command = new SqlCommand())
            {
                try
                {
                    command.Connection = DbConnection;
                    
                    foreach (Item item in ListItem)
                    {
                        byte[] blobItemImage = ConvertImageToByteArray(item.Img);
                        int typeItem = TypeItemsDictionnary.FirstOrDefault(x => x.Value == item.TypeItem).Key; // we need the id of the item type

                        string itemData = string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}", "@id" + item.Id, "@name" + item.Id, "@lvl" + item.Id, "@image" + item.Id, "@url" + item.Id, "@type" + item.Id, "@rarity" + item.Id);
                        command.CommandText += string.Format("INSERT INTO Items (Id, name, level, image, url, idType, idRarity) VALUES ({0});", itemData);
                        command.Parameters.AddWithValue("@id" + item.Id, item.Id);
                        command.Parameters.AddWithValue("@name" + item.Id, item.Name);
                        command.Parameters.AddWithValue("@lvl" + item.Id, item.Lvl);
                        command.Parameters.AddWithValue("@image" + item.Id, blobItemImage);
                        command.Parameters.AddWithValue("@url" + item.Id, item.Url);
                        command.Parameters.AddWithValue("@type" + item.Id, typeItem);
                        command.Parameters.AddWithValue("@rarity" + item.Id, item.Rarity);
                    }
                    command.ExecuteNonQuery();
                    // TODO: Add stats of items to the table Stats and ITems_Have_Stats
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
        /// <summary>
        /// Delete the data of each items of the database
        /// </summary>
        public void DeleteAllItemsData()
        {
            using (SqlCommand command = new SqlCommand())
            {
                try
                {
                    command.Connection = DbConnection;
                    command.CommandText = "DELETE FROM Items; DELETE FROM Items_Have_Stats; DELETE FROM Stats";
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        /// <summary>
        /// Convert an image to a byte array
        /// </summary>
        /// <param name="img">The image to convert</param>
        /// <returns>A byte array of the image</returns>
        private byte[] ConvertImageToByteArray(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Png);
                byte[] byteArray = ms.ToArray();
                return byteArray;
            }
        }

        /// <summary>
        /// Create the dictionnary of the differents type of items
        /// </summary>
        private void CreateTypeItemsDictionnary()
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = DbConnection;
                command.CommandText = string.Format("SELECT * FROM Type_Items ORDER BY Id ASC");

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    TypeItemsDictionnary = new Dictionary<int, string>();
                    while (reader.Read())
                    {
                        TypeItemsDictionnary.Add(reader.GetInt32(0), reader.GetString(1));
                    }
                }
            }
        }

        #endregion DatabaseMethods
    }
}
