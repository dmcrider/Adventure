using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public class Inventory
    {
        public Inventory(int uniqueID, int characterID, int itemID, int quantity, int isUsing, int hand, int isActive)
        {
            UniqueID = uniqueID;
            CharacterID = characterID;
            ItemID = itemID;
            Quantity = quantity;
            IsUsing = isUsing;
            Hand = hand;
            IsActive = isActive;
        }

        #region Instance Variables
        public int UniqueID { get; set; }
        public int CharacterID { get; set; }
        public int ItemID { get; set; }
        public int Quantity { get; set; }
        public int IsUsing { get; set; }
        public int Hand { get; set; }
        public int IsActive { get; set; }
        #endregion

        #region Static Variables
        public static List<Inventory> InventoryList = new List<Inventory>();
        private static readonly int MAX_INVENTORY_SIZE = GetMaxInventorySize();
        #endregion

        /// <summary>
        /// Gets all inventory items for the associated Character
        /// </summary>
        public static void LoadInventory()
        {
            WebClient client = new WebClient();
            try
            {
                string dataString = $"{{\"CharacterID\":{Instances.Character.UniqueID}}}";
                string response = client.UploadString(Properties.Settings.Default.APIBaseAddress + Properties.Settings.Default.InventoryReadAPI, dataString);
                JObject convertedJSON = JObject.Parse(response);

                foreach (var obj in convertedJSON)
                {
                    foreach (JObject item in obj.Value)
                    {
                        InventoryList.Add((Inventory)item.ToObject(typeof(Inventory)));
                    }
                }
                LogWriter.Write(typeof(Inventory).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "Inventory successfully loaded. Item Count: " + InventoryList.Count);
            }
            catch (Exception ex)
            {
                LogWriter.Write(typeof(Inventory).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, ex.Message);
            }
        }

        /// <summary>
        /// Adds an Item to the character's inventory
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="quantity"></param>
        public static APIStatusCode AddInventoryItem(int itemID, int quantity = 1)
        {
            try
            {
                WebClient client = new WebClient();
                // Check that the character has space left
                if (HasSpace())
                {
                    string dataString = $"{{\"CharacterID\":{Instances.Character.UniqueID},\"ItemID\":{itemID},\"Quantity\":{quantity}}}";
                    string response = client.UploadString(Properties.Settings.Default.APIBaseAddress + Properties.Settings.Default.InventoryAddAPI, dataString);
                    JObject convertedJSON = JObject.Parse(response);

                    foreach (var obj in convertedJSON)
                    {
                        if (obj.Key == "success")
                        {
                            LogWriter.Write(typeof(Inventory).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, $"Item {convertedJSON.GetValue("DisplayName")} added to inventory successfully.");
                            LoadInventory();
                        }
                        else if (obj.Key == "fail")
                        {
                            LogWriter.Write(typeof(Inventory).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, "" + convertedJSON.GetValue("fail"));
                            return APIStatusCode.FAIL;
                        }
                    }
                }
                else
                {
                    LogWriter.Write(typeof(Inventory).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, "Inventory full for Character");
                    FormMain.InventoryFullMessageBox();
                    return APIStatusCode.OUT_OF_SPACE;
                }

                return APIStatusCode.FAIL;
            }
            catch(Exception ex)
            {
                LogWriter.Write(typeof(Inventory).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, ex.Message);
                return APIStatusCode.FAIL;
            }
        }

        /// <summary>
        /// Pushes local updates to a player's inventory to the database
        /// </summary>
        public static APIStatusCode UpdateInventory()
        {
            WebClient client = new WebClient();
            try
            {
                foreach (Inventory invItem in InventoryList)
                {
                    string dataString = $"{{\"CharacterID\":{Instances.Character.UniqueID},\"ItemID\":{invItem.ItemID},\"Quantity\":{invItem.Quantity},\"IsUsing\":{invItem.IsUsing},\"Hand\":{invItem.Hand},\"IsActive\":{invItem.IsActive}}}";
                    string response = client.UploadString(Properties.Settings.Default.APIBaseAddress + Properties.Settings.Default.InventoryUpdateAPI, dataString);
                    JObject convertedJSON = JObject.Parse(response);

                    foreach (var obj in convertedJSON)
                    {
                        if (obj.Key == "success")
                        {
                            LogWriter.Write(typeof(Inventory).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "Updating Inventory");
                            return APIStatusCode.SUCCESS;
                        }
                        else
                        {
                            LogWriter.Write(typeof(Inventory).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, obj.Value.ToString());
                            return APIStatusCode.FAIL;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogWriter.Write(typeof(Inventory).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, ex.Message);
                return APIStatusCode.FAIL;
            }

            return APIStatusCode.FAIL;
        }

        /// <summary>
        /// Determines if the Character has at least one empty slot in their inventory
        /// </summary>
        /// <returns>True if at least one slot is available, false otherwise</returns>
        public static bool HasSpace()
        {
            try
            {
                LogWriter.Write(typeof(Inventory).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.GamePlay, "Current inventory size: " + InventoryList.Count);
                return InventoryList.Count < MAX_INVENTORY_SIZE;
            }
            catch (Exception ex)
            {
                LogWriter.Write(typeof(Inventory).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, ex.Message);
                return false;
            }
        }

        private static int GetMaxInventorySize()
        {
            WebClient client = new WebClient();
            int defaultSize = 10;

            try
            {
                string response = client.DownloadString(Properties.Settings.Default.APIBaseAddress + Properties.Settings.Default.VersionAPI);
                JObject convertedJSON = JObject.Parse(response);

                foreach (var item in convertedJSON)
                {
                    foreach (JObject obj in item.Value)
                    {
                        LogWriter.Write(typeof(Inventory).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "Max Inventory Size: " + obj.GetValue("max_size").ToString());
                        return int.Parse(obj.GetValue("max_size").ToString());
                    }
                }
                return defaultSize;
            }
            catch (Exception ex)
            {
                LogWriter.Write(typeof(Inventory).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, ex.Message);
                return defaultSize;
            }
        }
    }
}
