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
    public class Enemy
    {
        public Enemy() { }

        public Enemy(int uniqueID, string name, string race, int currentHP, int maxHP, int currentMagic, int maxMagic, int attackDamage, int expAwarded, int active)
        {
            UniqueID = uniqueID;
            Name = name;
            Race = race;
            CurrentHP = currentHP;
            MaxHP = maxHP;
            CurrentMagic = currentMagic;
            MaxMagic = maxMagic;
            AttackDamage = attackDamage;
            ExpAwarded = expAwarded;
            IsActive = active;
        }

        #region Instance Variables
        public int UniqueID { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public int CurrentHP { get; set; }
        public int MaxHP { get; set; }
        public int CurrentMagic { get; set; }
        public int MaxMagic { get; set; }
        public int AttackDamage { get; set; }
        public int ExpAwarded { get; set; }
        public int Gold { get; set; }
        public int IsActive { get; set; }
        public List<Item> Loot { get; set; }
        #endregion

        #region Static Variables
        public static List<Enemy> Enemies;
        #endregion

        /// <summary>
        /// Loads all quests from the local file into the Quests list.
        /// </summary>
        /// <returns>Returns an APIStatusCode that indicates if the method was successful or not.</returns>
        public static APIStatusCode LoadFromFile()
        {
            try
            {
                Enemies = new List<Enemy>();
                string path = API.storageLocation + "enemies.json";

                using (StreamReader inputFile = File.OpenText(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    JArray response = (JArray)serializer.Deserialize(inputFile, typeof(JObject));

                    foreach (JObject obj in response)
                    {
                        Enemies.Add((Enemy)obj.ToObject(typeof(Enemy)));
                    }
                }

                if (Enemies.Count() > 0)
                {
                    LogWriter.Write(typeof(Item).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "Enemies loaded successfully");
                    return APIStatusCode.SUCCESS;
                }
                LogWriter.Write(typeof(Item).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Warning, "No Enemies to load");
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
            Enemies = new List<Enemy>();
            string api = Properties.Settings.Default.APIBaseAddress + Properties.Settings.Default.EnemyReadAPI;

            try
            {
                string response = client.DownloadString(api);
                JObject convertedJSON = JObject.Parse(response);

                foreach (var obj in convertedJSON)
                {
                    foreach (var item in obj.Value)
                    {
                        Enemies.Add(new Enemy((int)item.SelectToken("UniqueID"), (string)item.SelectToken("Name"), (string)item.SelectToken("Race"), (int)item.SelectToken("CurrentHP"), (int)item.SelectToken("MaxHP"), (int)item.SelectToken("CurrentMagic"), (int)item.SelectToken("MaxMagic"), (int)item.SelectToken("AttackDamage"), (int)item.SelectToken("ExpAwarded"), (int)item.SelectToken("IsActive")));
                    }
                }
                LogWriter.Write(typeof(Item).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "Enemies successfully updated from database");
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
                string json = JsonConvert.SerializeObject(Enemies);

                // Make sure the path exists before we try to save there
                if (!Directory.Exists(API.storageLocation))
                {
                    Directory.CreateDirectory(API.storageLocation);
                }

                File.WriteAllText(API.storageLocation + "enemies.json", json);

                LogWriter.Write(typeof(Item).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "Enemies successfully saved locally");
            }
            catch (Exception ex)
            {
                LogWriter.Write(typeof(Item).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, ex.Message + "\n\t" + ex.StackTrace);
            }
        }
    }
}
