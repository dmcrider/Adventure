using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace Adventure
{
    public class Item
    {
        private const double SHOP_VALUE = 1.25;
        private const double SPECIAL_VALUE = 1.0;
        private const double PLAYER_VALUE = 0.75;

        #region Static Variables
        public static List<Item> Items;
        #endregion

        #region Instance Variables
        public int UniqueID { get; set; }
        public string DisplayName { get; set; }
        public string AssetName { get; set; }
        public int AttackBonus { get; set; }
        public int DefenseBonus { get; set; }
        public int HpHealed { get; set; }
        public int MagicHealed { get; set; }
        public int MaxStackQunatity { get; set; }
        public int ValueInGold { get; set; }
        public int CanBuySell { get; set; }
        public int MinPlayerLevel { get; set; }
        public int Active { get; set; }
        #endregion

        public Item() { }

        public Item(int uniqueID, string displayName, string assetName, int attackBonus, int defenseBonus, int hpHealed, int magicHealed, int maxStackQunatity, int valueInGold, int canBuySell, int minplayerlvl, int active)
        {
            UniqueID = uniqueID;
            DisplayName = displayName;
            AssetName = assetName;
            AttackBonus = attackBonus;
            DefenseBonus = defenseBonus;
            HpHealed = hpHealed;
            MagicHealed = magicHealed;
            MaxStackQunatity = maxStackQunatity;
            ValueInGold = valueInGold;
            CanBuySell = canBuySell;
            MinPlayerLevel = minplayerlvl;
            Active = active;
        }

        /// <summary>
        /// Populate a listview with item details
        /// </summary>
        /// <param name="who">Shops sell at higher prices and buy at lower prices</param>
        /// <returns>ListViewItem containing the DisplayName and Value of the item</returns>
        public System.Windows.Forms.ListViewItem ShopDetails(int who)
        {
            double value = this.ValueInGold;
            int outValue = -1;

            if(who == GameController.SHOP)
            {
                outValue = (int)Math.Round(value * SHOP_VALUE);
            }

            if(who == GameController.PLAYER)
            {
                outValue = (int)Math.Round(value * PLAYER_VALUE);
            }

            if(who == GameController.SPECIAL)
            {
                outValue = (int)Math.Round(value * SPECIAL_VALUE);
            }

            string[] retValue = { DisplayName, outValue.ToString(), UniqueID.ToString() };
            return new System.Windows.Forms.ListViewItem(retValue);
        }

        /// <summary>
        /// Loads all items from the local file into the Items list.
        /// </summary>
        /// <returns>Returns an APIStatusCode that indicates if the method was successful or not.</returns>
        public static APIStatusCode LoadFromFile()
        {
            try
            {
                Items = new List<Item>();
                string path = API.storageLocation + "items.json";

                using (StreamReader inputFile = File.OpenText(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    JArray response = (JArray)serializer.Deserialize(inputFile, typeof(JObject));

                    foreach (JObject obj in response)
                    {
                        Items.Add((Item)obj.ToObject(typeof(Item)));
                    }
                }

                if(Items.Count() > 0)
                {
                    LogWriter.Write(typeof(Item).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "Items loaded successfully");
                    return APIStatusCode.SUCCESS;
                }
                LogWriter.Write(typeof(Item).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Warning, "No Items to load");
                return APIStatusCode.FAIL;
            }
            catch(Exception ex)
            {
                LogWriter.Write(typeof(Item).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, ex.Message + "\n\t" + ex.StackTrace);
                return APIStatusCode.FAIL;
            }
        }

        /// <summary>
        /// Loads all items from the database into the Items list.
        /// </summary>
        /// <returns>Returns an APIStatusCode that indicates if the method was successful or not.</returns>
        public static APIStatusCode LoadFromDatabase()
        {
            WebClient client = new WebClient();
            string api = Properties.Settings.Default.APIBaseAddress + Properties.Settings.Default.ItemReadAPI;

            try
            {
                string response = client.DownloadString(api);
                JObject convertedJSON = JObject.Parse(response);

                foreach (var obj in convertedJSON)
                {
                    foreach (var item in obj.Value)
                    {
                        Items.Add(new Item((int)item.SelectToken("UniqueID"), (string)item.SelectToken("DisplayName"), (string)item.SelectToken("AssetName"), (int)item.SelectToken("AttackBonus"), (int)item.SelectToken("DefenseBonus"), (int)item.SelectToken("HPHealed"), (int)item.SelectToken("MagicHealed"), (int)item.SelectToken("MaxStackQuantity"), (int)item.SelectToken("ValueInGold"), (int)item.SelectToken("CanBuySell"), (int)item.SelectToken("MinPlayerLevel"), (int)item.SelectToken("IsActive")));
                    }
                }
                LogWriter.Write(typeof(Item).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "Items successfully updated from database");
                Save();
                return APIStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                LogWriter.Write(typeof(Item).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, ex.Message + "\n\t" + ex.StackTrace);
                return APIStatusCode.FAIL;
            }
        }

        /// <summary>
        /// Saves the list of items to a local file.
        /// </summary>
        private static void Save()
        {
            try
            {
                string itemsJSON = JsonConvert.SerializeObject(Items);

                // Make sure the path exists before we try to save there
                if (!Directory.Exists(API.storageLocation))
                {
                    Directory.CreateDirectory(API.storageLocation);
                }

                File.WriteAllText(API.storageLocation + "items.json", itemsJSON);

                LogWriter.Write(typeof(Item).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "Items successfully saved locally");
            }
            catch(Exception ex)
            {
                LogWriter.Write(typeof(Item).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, ex.Message + "\n\t" + ex.StackTrace);
            }
        }
    }
}
