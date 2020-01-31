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
    public class Stat
    {
        public Stat(int uniqueID, string name)
        {
            UniqueID = uniqueID;
            Name = name;
        }

        #region Instance Variables
        public int UniqueID { get; set; }
        public string Name { get; set; }
        #endregion

        #region Static Variables
        public static List<Stat> Stats;
        #endregion

        /// <summary>
        /// Loads all quests from the local file into the Quests list.
        /// </summary>
        public static void LoadFromFile()
        {
            try
            {
                LogWriter.Write(typeof(Stat).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Info, "Loading Stats from file");
                Stats = new List<Stat>();
                string path = API.storageLocation + "stats.json";

                using (StreamReader inputFile = File.OpenText(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    JArray response = (JArray)serializer.Deserialize(inputFile, typeof(JObject));

                    foreach (JObject obj in response)
                    {
                        Stats.Add((Stat)obj.ToObject(typeof(Stat)));
                    }
                }

                if (Stats.Count() > 0)
                {
                    LogWriter.Write(typeof(Stat).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "Stats loaded successfully");
                }
                LogWriter.Write(typeof(Stat).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Warning, "No Stats to load");
            }
            catch (Exception ex)
            {
                LogWriter.Write(typeof(Stat).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, ex.Message + "\n\t" + ex.StackTrace);
            }
        }

        /// <summary>
        /// Loads all items from the database into the Items list.
        /// </summary>
        public static void LoadFromDatabase()
        {
            WebClient client = new WebClient();
            Stats = new List<Stat>();
            string api = Properties.Settings.Default.APIBaseAddress + Properties.Settings.Default.StatReadAPI;

            try
            {
                LogWriter.Write(typeof(Stat).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Info, "Loading Stats from database");
                string response = client.DownloadString(api);
                JObject convertedJSON = JObject.Parse(response);

                foreach (var obj in convertedJSON)
                {
                    foreach (var item in obj.Value)
                    {
                        Stats.Add(new Stat((int)item.SelectToken("UniqueID"), (string)item.SelectToken("Name")));
                    }
                }
                LogWriter.Write(typeof(Stat).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "Stats successfully updated from database");
                Save();
            }
            catch (Exception ex)
            {
                LogWriter.Write(typeof(Stat).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, ex.Message + "\n\t" + ex.StackTrace);
            }
        }

        /// <summary>
        /// Saves the list of items to a local file.
        /// </summary>
        private static void Save()
        {
            try
            {
                string json = JsonConvert.SerializeObject(Stats);

                // Make sure the path exists before we try to save there
                if (!Directory.Exists(API.storageLocation))
                {
                    Directory.CreateDirectory(API.storageLocation);
                }

                File.WriteAllText(API.storageLocation + "stats.json", json);

                LogWriter.Write(typeof(Stat).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "Stats successfully saved locally");
            }
            catch (Exception ex)
            {
                LogWriter.Write(typeof(Stat).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, ex.Message + "\n\t" + ex.StackTrace);
            }
        }
    }
}
