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
    public class Quest
    {
        public Quest(int uniqueID, string name, int expAwarded, int questRewardID, int minCharLevel, int maxCharLevel, int npcID, string description)
        {
            UniqueID = uniqueID;
            Name = name;
            ExpAwarded = expAwarded;
            QuestRewardID = questRewardID;
            MinCharLevel = minCharLevel;
            MaxCharLevel = maxCharLevel;
            NpcID = npcID;
            Description = description;
        }

        #region Instance Variables
        public int UniqueID { get; set; }
        public string Name { get; set; }
        public int ExpAwarded { get; set; }
        public int QuestRewardID { get; set; }
        public int MinCharLevel { get; set; }
        public int MaxCharLevel { get; set; }
        public int NpcID { get; set; }
        public string Description { get; set; }
        #endregion

        #region Static Variables
        public static List<Quest> Quests;
        #endregion

        /// <summary>
        /// Return the QuestLog associated with this Quest
        /// </summary>
        /// <returns></returns>
        public QuestLog GetQuestLog()
        {
            return GameController.questLog.Find(x => x.QuestID == this.UniqueID);
        }

        /// <summary>
        /// Loads all quests from the local file into the Quests list.
        /// </summary>
        /// <returns>Returns an APIStatusCode that indicates if the method was successful or not.</returns>
        public static APIStatusCode LoadFromFile()
        {
            try
            {
                Quests = new List<Quest>();
                string path = API.storageLocation + "quests.json";

                using (StreamReader inputFile = File.OpenText(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    JArray response = (JArray)serializer.Deserialize(inputFile, typeof(JObject));

                    foreach (JObject obj in response)
                    {
                        Quests.Add((Quest)obj.ToObject(typeof(Quest)));
                    }
                }

                if (Quests.Count() > 0)
                {
                    LogWriter.Write(typeof(Item).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "Quests loaded successfully");
                    return APIStatusCode.SUCCESS;
                }
                LogWriter.Write(typeof(Item).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Warning, "No Quests to load");
                return APIStatusCode.FAIL;
            }
            catch (Exception ex)
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
            Quests = new List<Quest>();
            string api = Properties.Settings.Default.APIBaseAddress + Properties.Settings.Default.QuestReadAPI;

            try
            {
                string response = client.DownloadString(api);
                JObject convertedJSON = JObject.Parse(response);

                foreach (var obj in convertedJSON)
                {
                    foreach (var item in obj.Value)
                    {
                        Quests.Add(new Quest((int)item.SelectToken("UniqueID"), (string)item.SelectToken("Name"), (int)item.SelectToken("ExpAwarded"), (int)item.SelectToken("QuestRewardID"), (int)item.SelectToken("MinCharacterLevel"), (int)item.SelectToken("MaxCharacterLevel"), (int)item.SelectToken("NPC_ID"), (string)item.SelectToken("Description")));
                    }
                }
                LogWriter.Write(typeof(Item).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "Quests successfully updated from database");
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
                string json = JsonConvert.SerializeObject(Quests);

                // Make sure the path exists before we try to save there
                if (!Directory.Exists(API.storageLocation))
                {
                    Directory.CreateDirectory(API.storageLocation);
                }

                File.WriteAllText(API.storageLocation + "quests.json", json);

                LogWriter.Write(typeof(Item).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "Quests successfully saved locally");
            }
            catch (Exception ex)
            {
                LogWriter.Write(typeof(Item).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, ex.Message + "\n\t" + ex.StackTrace);
            }
        }
    }
}
