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
    public class CharacterLevel
    {
        public CharacterLevel(int uniqueID, int expNeeded, int numberOfSpells, int sTRIncrease, int iNTIncrease, int cONIncrease, int hPIncrease, int magicIncrease)
        {
            UniqueID = uniqueID;
            ExpNeeded = expNeeded;
            NumberOfSpells = numberOfSpells;
            STRIncrease = sTRIncrease;
            INTIncrease = iNTIncrease;
            CONIncrease = cONIncrease;
            HPIncrease = hPIncrease;
            MagicIncrease = magicIncrease;
        }

        #region Instance Variables
        public int UniqueID { get; set; }
        public int ExpNeeded { get; set; }
        public int NumberOfSpells { get; set; }
        public int STRIncrease { get; set; }
        public int INTIncrease { get; set; }
        public int CONIncrease { get; set; }
        public int HPIncrease { get; set; }
        public int MagicIncrease { get; set; }
        #endregion

        #region Static Variables
        public static List<CharacterLevel> CharacterLevels;
        #endregion

        /// <summary>
        /// Loads all quests from the local file into the Quests list.
        /// </summary>
        /// <returns>Returns an APIStatusCode that indicates if the method was successful or not.</returns>
        public static APIStatusCode LoadFromFile()
        {
            try
            {
                CharacterLevels = new List<CharacterLevel>();
                string path = API.storageLocation + "levels.json";

                using (StreamReader inputFile = File.OpenText(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    JArray response = (JArray)serializer.Deserialize(inputFile, typeof(JObject));

                    foreach (JObject obj in response)
                    {
                        CharacterLevels.Add((CharacterLevel)obj.ToObject(typeof(CharacterLevel)));
                    }
                }

                if (CharacterLevels.Count() > 0)
                {
                    LogWriter.Write(typeof(Item).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "Levels loaded successfully");
                    return APIStatusCode.SUCCESS;
                }
                LogWriter.Write(typeof(Item).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Warning, "No Levels to load");
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
            CharacterLevels = new List<CharacterLevel>();
            string api = Properties.Settings.Default.APIBaseAddress + Properties.Settings.Default.LevelReadAPI;

            try
            {
                string response = client.DownloadString(api);
                JObject convertedJSON = JObject.Parse(response);

                foreach (var obj in convertedJSON)
                {
                    foreach (var item in obj.Value)
                    {
                        CharacterLevels.Add(new CharacterLevel((int)item.SelectToken("UniqueID"), (int)item.SelectToken("ExpNeeded"), (int)item.SelectToken("NumberOfSpells"), (int)item.SelectToken("STRIncrease"), (int)item.SelectToken("INTIncrease"), (int)item.SelectToken("CONIncrease"), (int)item.SelectToken("HPIncrease"), (int)item.SelectToken("MagicIncrease")));
                    }
                }
                LogWriter.Write(typeof(Item).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "Levels successfully updated from database");
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
                string json = JsonConvert.SerializeObject(CharacterLevels);

                // Make sure the path exists before we try to save there
                if (!Directory.Exists(API.storageLocation))
                {
                    Directory.CreateDirectory(API.storageLocation);
                }

                File.WriteAllText(API.storageLocation + "levels.json", json);

                LogWriter.Write(typeof(Item).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "Levels successfully saved locally");
            }
            catch (Exception ex)
            {
                LogWriter.Write(typeof(Item).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, ex.Message + "\n\t" + ex.StackTrace);
            }
        }
    }
}
