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
    public class Spell
    {
        public Spell(int uniqueID, string name, int healAmount, int damageAmount, int bonus, int magicCost, int minLevel)
        {
            UniqueID = uniqueID;
            Name = name;
            HealAmount = healAmount;
            DamageAmount = damageAmount;
            Bonus = bonus;
            MagicCost = magicCost;
            MinLevel = minLevel;
        }

        #region Instance Variables
        public int UniqueID { get; set; }
        public string Name { get; set; }
        public int HealAmount { get; set; }
        public int DamageAmount { get; set; }
        public int Bonus { get; set; }
        public int MagicCost { get; set; }
        public int MinLevel { get; set; }
        #endregion

        #region Static Variables
        public static List<Spell> Spells;
        #endregion

        /// <summary>
        /// Loads all quests from the local file into the Quests list.
        /// </summary>
        /// <returns>Returns an APIStatusCode that indicates if the method was successful or not.</returns>
        public static APIStatusCode LoadFromFile()
        {
            try
            {
                Spells = new List<Spell>();
                string path = API.storageLocation + "spells.json";

                using (StreamReader inputFile = File.OpenText(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    JArray response = (JArray)serializer.Deserialize(inputFile, typeof(JObject));

                    foreach (JObject obj in response)
                    {
                        Spells.Add((Spell)obj.ToObject(typeof(Spell)));
                    }
                }

                if (Spells.Count() > 0)
                {
                    LogWriter.Write(typeof(Item).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "Spells loaded successfully");
                    return APIStatusCode.SUCCESS;
                }
                LogWriter.Write(typeof(Item).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Warning, "No Spells to load");
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
            Spells = new List<Spell>();
            string api = Properties.Settings.Default.APIBaseAddress + Properties.Settings.Default.ItemReadAPI;

            try
            {
                string response = client.DownloadString(api);
                JObject convertedJSON = JObject.Parse(response);

                foreach (var obj in convertedJSON)
                {
                    foreach (var item in obj.Value)
                    {
                        Spells.Add(new Spell((int)item.SelectToken("UniqueID"), (string)item.SelectToken("Name"), (int)item.SelectToken("HealAmount"), (int)item.SelectToken("DamageAmount"), (int)item.SelectToken("Bonus"), (int)item.SelectToken("MagicCost"), (int)item.SelectToken("MinLevel")));
                    }
                }
                LogWriter.Write(typeof(Item).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "Spells successfully updated from database");
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
                string json = JsonConvert.SerializeObject(Spells);

                // Make sure the path exists before we try to save there
                if (!Directory.Exists(API.storageLocation))
                {
                    Directory.CreateDirectory(API.storageLocation);
                }

                File.WriteAllText(API.storageLocation + "spells.json", json);

                LogWriter.Write(typeof(Item).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "Spells successfully saved locally");
            }
            catch (Exception ex)
            {
                LogWriter.Write(typeof(Item).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, ex.Message + "\n\t" + ex.StackTrace);
            }
        }
    }
}
