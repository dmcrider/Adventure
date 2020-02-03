using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public class QuestReward
    {
        public QuestReward() { }

        public QuestReward(int uniqueID, int isItem, int itemID, int gold)
        {
            UniqueID = uniqueID;
            IsItem = isItem;
            ItemID = itemID;
            Gold = gold;
        }

        #region Instance Variables
        public int UniqueID { get; set; }
        public int IsItem { get; set; }
        public int ItemID { get; set; }
        public int Gold { get; set; }
        #endregion

        #region Static Variables
        public static List<QuestReward> QuestRewards;
        #endregion

        /// <summary>
        /// Loads all quests from the local file into the Quests list.
        /// </summary>
        public static void LoadFromFile()
        {
            try
            {
                LogWriter.Write(typeof(QuestReward).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Info, "Loading QuestRewards from file");
                QuestRewards = new List<QuestReward>();
                string path = API.storageLocation + "questrewards.json";

                using (StreamReader inputFile = File.OpenText(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    JArray response = (JArray)serializer.Deserialize(inputFile, typeof(JObject));

                    foreach (JObject obj in response)
                    {
                        QuestRewards.Add((QuestReward)obj.ToObject(typeof(QuestReward)));
                    }
                }

                if (QuestRewards.Count() > 0)
                {
                    LogWriter.Write(typeof(QuestReward).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "QuestRewards loaded successfully");
                }
                LogWriter.Write(typeof(QuestReward).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Warning, "No QuestRewards to load");
            }
            catch (Exception ex)
            {
                LogWriter.Write(typeof(QuestReward).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, ex.Message + "\n\t" + ex.StackTrace);
            }
        }

        /// <summary>
        /// Loads all items from the database into the Items list.
        /// </summary>
        public static void LoadFromDatabase()
        {
            WebClient client = new WebClient();
            QuestRewards = new List<QuestReward>();
            string api = Properties.Settings.Default.APIBaseAddress + Properties.Settings.Default.QuestRewardReadAPI;

            try
            {
                LogWriter.Write(typeof(QuestReward).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Info, "Loading QuestRewards from database");
                string response = client.DownloadString(api);
                JObject convertedJSON = JObject.Parse(response);

                foreach (var obj in convertedJSON)
                {
                    foreach (var item in obj.Value)
                    {
                        QuestRewards.Add(new QuestReward((int)item.SelectToken("UniqueID"), (int)item.SelectToken("IsItem"), (int)item.SelectToken("ItemID"), (int)item.SelectToken("Gold")));
                    }
                }
                LogWriter.Write(typeof(QuestReward).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "QuestRewards successfully updated from database");
                Save();
            }
            catch (Exception ex)
            {
                LogWriter.Write(typeof(QuestReward).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, ex.Message + "\n\t" + ex.StackTrace);
            }
        }

        /// <summary>
        /// Saves the list of items to a local file.
        /// </summary>
        private static void Save()
        {
            try
            {
                string json = JsonConvert.SerializeObject(QuestRewards);

                // Make sure the path exists before we try to save there
                if (!Directory.Exists(API.storageLocation))
                {
                    Directory.CreateDirectory(API.storageLocation);
                }

                File.WriteAllText(API.storageLocation + "questrewards.json", json);

                LogWriter.Write(typeof(QuestReward).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "QuestRewards successfully saved locally");
            }
            catch (Exception ex)
            {
                LogWriter.Write(typeof(QuestReward).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, ex.Message + "\n\t" + ex.StackTrace);
            }
        }
    }
}
