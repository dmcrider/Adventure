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
    public class Npc
    {
        public Npc(int uniqueID, string name)
        {
            UniqueID = uniqueID;
            Name = name;
        }

        #region Instance Variables
        public int UniqueID { get; set; }
        public string Name { get; set; }
        #endregion

        #region Static Variables
        public static List<Npc> Npcs;
        #endregion

        /// <summary>
        /// Loads all quests from the local file into the Quests list.
        /// </summary>
        public static void LoadFromFile()
        {
            try
            {
                LogWriter.Write(typeof(Npc).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Info, "Loading Npcs from file");
                Npcs = new List<Npc>();
                string path = API.storageLocation + "npcs.json";

                using (StreamReader inputFile = File.OpenText(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    JArray response = (JArray)serializer.Deserialize(inputFile, typeof(JObject));

                    foreach (JObject obj in response)
                    {
                        Npcs.Add((Npc)obj.ToObject(typeof(Npc)));
                    }
                }

                if (Npcs.Count() > 0)
                {
                    LogWriter.Write(typeof(Npc).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "NPCs loaded successfully");
                }
                LogWriter.Write(typeof(Npc).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Warning, "No NPCs to load");
            }
            catch (Exception ex)
            {
                LogWriter.Write(typeof(Npc).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, ex.Message + "\n\t" + ex.StackTrace);
            }
        }

        /// <summary>
        /// Loads all items from the database into the Items list.
        /// </summary>
        public static void LoadFromDatabase()
        {
            WebClient client = new WebClient();
            Npcs = new List<Npc>();
            string api = Properties.Settings.Default.APIBaseAddress + Properties.Settings.Default.NPCReadAPI;

            try
            {
                LogWriter.Write(typeof(Npc).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Info, "Loading Npcs from database");
                string response = client.DownloadString(api);
                JObject convertedJSON = JObject.Parse(response);

                foreach (var obj in convertedJSON)
                {
                    foreach (var item in obj.Value)
                    {
                        Npcs.Add(new Npc((int)item.SelectToken("UniqueID"), (string)item.SelectToken("Name")));
                    }
                }
                LogWriter.Write(typeof(Npc).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "NPCs successfully updated from database");
                Save();
            }
            catch (Exception ex)
            {
                LogWriter.Write(typeof(Npc).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, ex.Message + "\n\t" + ex.StackTrace);
            }
        }

        /// <summary>
        /// Saves the list of items to a local file.
        /// </summary>
        private static void Save()
        {
            try
            {
                string json = JsonConvert.SerializeObject(Npcs);

                // Make sure the path exists before we try to save there
                if (!Directory.Exists(API.storageLocation))
                {
                    Directory.CreateDirectory(API.storageLocation);
                }

                File.WriteAllText(API.storageLocation + "npcs.json", json);

                LogWriter.Write(typeof(Npc).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "NPCs successfully saved locally");
            }
            catch (Exception ex)
            {
                LogWriter.Write(typeof(Npc).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, ex.Message + "\n\t" + ex.StackTrace);
            }
        }
    }
}
