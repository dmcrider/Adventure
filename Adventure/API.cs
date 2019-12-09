﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Adventure
{
    public static class API
    {

        // Lists that the rest of the application can access
        public static List<Item> itemsList = new List<Item>();
        public static List<Quest> questsList = new List<Quest>();
        public static List<Spell> spellsList = new List<Spell>();
        public static List<Stat> statsList = new List<Stat>();
        public static List<Race> racesList = new List<Race>();
        public static List<Npc> npcsList = new List<Npc>();
        public static List<QuestReward> questrewardsList = new List<QuestReward>();

        // Single WebClient used throughout this class
        private static WebClient client = new WebClient();
        private static string storageLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Adventure\\";

        /// <summary>
        /// Checks the local version against the cloud version
        /// </summary>
        /// <param name="convertedJSON"></param>
        /// <returns>Returns true if versions are the same, false otherwise</returns>
        public static bool CheckVersion(JObject convertedJSON)
        {
            try
            {
                foreach (var obj in convertedJSON)
                {
                    if (obj.Key == "api_version")
                    {
                        double cloudVersion = (double)obj.Value;
                        double localVersion = Properties.Settings.Default.Version;

                        if (localVersion != cloudVersion)
                        {
                            // Update the locally stored version number
                            LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Info, $"Cloud Version: {cloudVersion} | Local Version: {localVersion}");
                            Properties.Settings.Default.Version = cloudVersion;
                            Properties.Settings.Default.Save();

                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, "Checking database version: " + e);
                return false;
            }

            return false;
            
        }

        /// <summary>
        /// Loads local data into the appropriate list
        /// </summary>
        public static void LoadData()
        {
            try
            {
                string[] filesArray = {"items.json","quests.json","spells.json","stats.json","races.json","npcs.json","questrewards.json"};
                

                foreach (string file in filesArray)
                {
                    string path = storageLocation + file;
                    string type = file.Split('.')[0];
                    // Read the file in and add an appropriate object to the arrays we got from the main class
                    using(StreamReader inputFile = File.OpenText(path))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        JArray response = (JArray)serializer.Deserialize(inputFile, typeof(JObject));

                        foreach(JObject obj in response)
                        {
                            switch (type)
                            {
                                case "items":
                                    itemsList.Add((Item)obj.ToObject(typeof(Item)));
                                    break;
                                case "quests":
                                    questsList.Add((Quest)obj.ToObject(typeof(Quest)));
                                    break;
                                case "spells":
                                    spellsList.Add((Spell)obj.ToObject(typeof(Spell)));
                                    break;
                                case "stats":
                                    statsList.Add((Stat)obj.ToObject(typeof(Stat)));
                                    break;
                                case "races":
                                    racesList.Add((Race)obj.ToObject(typeof(Race)));
                                    break;
                                case "npcs":
                                    npcsList.Add((Npc)obj.ToObject(typeof(Npc)));
                                    break;
                                case "questrewards":
                                    questrewardsList.Add((QuestReward)obj.ToObject(typeof(QuestReward)));
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
                return;
            }
            catch (Exception e)
            {
                LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, "Loading local data: " + e);
                return;
            }
        }

        /// <summary>
        /// Connects to the cloud database to verrify login credentials.
        /// </summary>
        /// <param name="player"></param>
        /// <returns>Returns 1 if login was successful, 0 if login failed</returns>
        public static int Login(Player player)
        {
            string credentials = "";
            if (player.HasID())
            {
                credentials = $"{{\"Username\":\"{player.username}\",\"Password\":\"{player.password}\",\"ID\":\"{player.uniqueID}\"}}";
            }
            else
            {
                if (PlayerExistsLocally(ref player))
                {
                    credentials = $"{{\"Username\":\"{player.username}\",\"Password\":\"{player.password}\",\"ID\":\"{player.uniqueID}\"}}";
                }
                else
                {
                    credentials = $"{{\"Username\":\"{player.username}\",\"Password\":\"{player.password}\"}}";
                }
            }
            
            string response = client.UploadString(Properties.Settings.Default.APIBaseAddress + Properties.Settings.Default.LoginAPI, credentials);
            JObject convertedJSON = JObject.Parse(response);

            foreach(var obj in convertedJSON)
            {
                if(obj.Key == "success")
                {
                    player.uniqueID = (int)convertedJSON.GetValue("UniqueID");
                    return 1; // Login was successful
                }
                else if (obj.Key == "fail" || obj.Key == "error")
                {
                    return 0; // Bad login attempt
                }
            }

            return 0; // Bad login attempt
        }

        /// <summary>
        /// Registers a new user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <returns>Returns true if registration was successful, false otherwise</returns>
        public static bool Register(string username, string pwd)
        {
            string credentials = $"{{\"Username\":\"{username}\",\"Password\":\"{pwd}\"}}";
            string response = client.UploadString(Properties.Settings.Default.APIBaseAddress + Properties.Settings.Default.RegisterAPI,credentials);
            JObject convertedJSON = JObject.Parse(response);

            foreach(var obj in convertedJSON)
            {
                if(obj.Key == "success")
                {
                    try
                    {
                        List<Player> playerList = new List<Player>();
                        // Save the newly registered player locally to reduce network data usage
                        Player player = new Player(username, (int)convertedJSON.GetValue("UniqueID"));

                        // Check if the file exists - we want to save all players who login with this instance
                        string fullPath = storageLocation + "player.json";
                        if (File.Exists(fullPath))
                        {
                            using (StreamReader inputFile = File.OpenText(fullPath))
                            {
                                // Get out all the current info
                                JsonSerializer serializer = new JsonSerializer();
                                JObject currentPlayerData = (JObject)serializer.Deserialize(inputFile, typeof(JObject));

                                foreach (var nestedObj in currentPlayerData)
                                {
                                    foreach (var input in nestedObj.Value)
                                    {
                                        try
                                        {
                                            JObject jsonInput = (JObject)input;
                                            playerList.Add((Player)jsonInput.ToObject(typeof(Player)));
                                        }
                                        catch (Exception e)
                                        {
                                            LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, "Getting local player data: " + e);
                                        }
                                    }
                                }
                            }

                            // Add the newly registered player
                            playerList.Add(player);

                            try
                            {
                                // Now write to the file with all the data
                                string playersJSON = JsonConvert.SerializeObject(playerList);
                                File.WriteAllText(fullPath, playersJSON);
                            }
                            catch (Exception e)
                            {
                                LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, "Saving players to file: " + e);
                            }
                        }
                        else
                        {
                            // No players currently exist, so create the file and save the newly registered user
                            string playerJSON = JsonConvert.SerializeObject(player);
                            File.WriteAllText(fullPath, playerJSON);
                        }
                    }
                    catch (Exception e)
                    {
                        LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, "Saving player locally: " + e);
                    }
                    // Return true because the database transaction was successful
                    // Even if saving the player locally wasn't - we can just get it from the database
                    return true;
                }
            }
            // Database transaction failed
            return false;
        }

        /// <summary>
        /// Gets the Character associated with the parameter from the database
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>Returns a Character object if one is found, null otherwise</returns>
        public static Character GetCharacter(int userID)
        {
            string response = client.DownloadString(Properties.Settings.Default.APIBaseAddress + Properties.Settings.Default.CharacterReadAPI);
            JObject convertedJSON = JObject.Parse(response);

            foreach (var item in convertedJSON)
            {
                foreach (JObject character in item.Value)
                {
                    if (userID == (int)character.SelectToken("UserID"))
                    {
                        return new Character((int)character.GetValue("UniqueID"), (int)character.GetValue("UserID"), (string)character.GetValue("Name"), (int)character.GetValue("RaceID"), (int)character.GetValue("MaxHP"), (int)character.GetValue("CurrentHP"), (int)character.GetValue("MaxMagic"), (int)character.GetValue("CurrentMagic"), (int)character.GetValue("Strength"), (int)character.GetValue("Intelligence"), (int)character.GetValue("Constitution"), (int)character.GetValue("Gold"), (int)character.GetValue("Level"), (int)character.GetValue("ExpPoints"), (int)character.GetValue("IsActive"));
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Saves the character to the database
        /// </summary>
        /// <param name="character"></param>
        /// <param name="playerID"></param>
        /// <returns>Returns true if database transaction was successful, false otherwise</returns>
        public static bool CreateCharacter(Character character, int playerID)
        {
            string charValues = $"{{\"UserID\":\"{playerID}\",\"Name\":\"{character.Name}\",\"RaceID\":\"{character.RaceID}\",\"Gender\":\"{character.Gender}\",\"MaxHP\":\"{character.MaxHP}\",\"CurrentHP\":\"{character.CurrentHP}\",\"MaxMagic\":\"{character.MaxMagic}\",\"CurrentMagic\":\"{character.CurrentMagic}\",\"Strength\":\"{character.Strength}\",\"Intelligence\":\"{character.Intelligence}\",\"Constitution\":\"{character.Constitution}\",\"Gold\":\"{character.Gold}\",\"Level\":\"{character.Level}\",\"ExpPoints\":\"{character.ExpPoints}\"}}";
            string response = client.UploadString(Properties.Settings.Default.APIBaseAddress + Properties.Settings.Default.CharacterCreateAPI, charValues);
            JObject convertedJSON = JObject.Parse(response);

            foreach(var obj in convertedJSON)
            {
                //LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, "Response from API: " + response);
                if (obj.Key == "success")
                {
                    character.UniqueID = (int)convertedJSON.GetValue("UniqueID");
                    return true;
                }else if(obj.Key == "error")
                {
                    LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, "Creating character: " + obj.Value);
                }
            }
            return false;
        }

        /// <summary>
        /// Adds an Item to the character's inventory
        /// </summary>
        /// <param name="character"></param>
        /// <param name="itemID"></param>
        /// <param name="quantity"></param>
        public static void AddInventoryItem(Character character, int itemID, int quantity=1)
        {
            // Check that the character has space left
            if (GameController.HasInventorySpace())
            {
                string dataString = $"{{\"CharacterID\":{character.UniqueID},\"ItemID\":{itemID},\"Quantity\":{quantity}}}";
                string response = client.UploadString(Properties.Settings.Default.APIBaseAddress + Properties.Settings.Default.InventoryAddAPI, dataString);
                JObject convertedJSON = JObject.Parse(response);

                foreach (var obj in convertedJSON)
                {
                    if (obj.Key == "success")
                    {
                        int inventoryID = (int)convertedJSON.GetValue("UniqueID");
                        LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, $"Item {convertedJSON.GetValue("DisplayName")} added to inventory successfully.");
                        LoadInventory(character.UniqueID);
                    }
                }
            }
            else
            {
                LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, "Inventory full for character with ID " + character.UniqueID);
                FormMain.InventoryFullMessageBox();
            }
        }

        /// <summary>
        /// Gets all inventory items for the associated Character
        /// </summary>
        /// <param name="characterID"></param>
        /// <returns>Returns a List of Items</returns>
        public static void LoadInventory(int characterID)
        {
            try
            {
                string dataString = $"{{\"CharacterID\":{characterID}}}";
                string response = client.UploadString(Properties.Settings.Default.APIBaseAddress + Properties.Settings.Default.InventoryReadAPI, dataString);
                JObject convertedJSON = JObject.Parse(response);

                foreach (var obj in convertedJSON)
                {
                    foreach (JObject item in obj.Value)
                    {
                        GameController.inventoryList.Add((Inventory)item.ToObject(typeof(Inventory)));
                    }
                }
                LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "Inventory successfully loaded. Item Count: " + GameController.inventoryList.Count);
            }
            catch(Exception e)
            {
                LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, e.Message);
            }
        }

        /// <summary>
        /// Pushes local updates to a player's inventory to the database
        /// </summary>
        /// <param name="characterID">The ID of a Character</param>
        /// <returns></returns>
        public static bool UpdateInventory(int characterID)
        {
            try
            {
                foreach (Inventory invItem in GameController.inventoryList)
                {
                    string dataString = $"{{\"CharacterID\":{characterID},\"ItemID\":{invItem.ItemID},\"Quantity\":{invItem.Quantity},\"IsUsing\":{invItem.IsUsing},\"Hand\":{invItem.Hand},\"IsActive\":{invItem.IsActive}}}";
                    string response = client.UploadString(Properties.Settings.Default.APIBaseAddress + Properties.Settings.Default.InventoryUpdateAPI, dataString);
                    JObject convertedJSON = JObject.Parse(response);

                    foreach(var obj in convertedJSON)
                    {
                        if(obj.Key == "success")
                        {
                            LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "Inventory Updated successfully.");
                            return true;
                        }
                        else
                        {
                            LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, "Failed to update inventory");
                            return false;
                        }
                    }
                }
            }
            catch(Exception e)
            {
                LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, "Updating inventory: " + e);
                return false;
            }

            // Something went massively wrong if this is the one getting returned
            return false;
        }

        /// <summary>
        /// Connects to the cloud database to update the appropriate list
        /// </summary>
        public static void UpdateFromDatabase()
        {

            string[] apiStrings = new string[8];
            apiStrings[0] = Properties.Settings.Default.ItemReadAPI;
            apiStrings[1] = Properties.Settings.Default.QuestReadAPI;
            apiStrings[2] = Properties.Settings.Default.SpellReadAPI;
            apiStrings[3] = Properties.Settings.Default.StatReadAPI;
            apiStrings[4] = Properties.Settings.Default.RaceReadAPI;
            apiStrings[5] = Properties.Settings.Default.StateReadAPI;
            apiStrings[6] = Properties.Settings.Default.NPCReadAPI;
            apiStrings[7] = Properties.Settings.Default.QuestRewardReadAPI;

            try
            {
                foreach (string apiName in apiStrings)
                {
                    string fullAPI = Properties.Settings.Default.APIBaseAddress + apiName;
                    string response = client.DownloadString(fullAPI);
                    JObject convertedJSON = JObject.Parse(response);

                    foreach (var obj in convertedJSON)
                    {
                        foreach (var item in obj.Value)
                        {
                            switch (Array.IndexOf(apiStrings, apiName))
                            {
                                case 0: // Items
                                    itemsList.Add(new Item((int)item.SelectToken("UniqueID"), (string)item.SelectToken("DisplayName"), (string)item.SelectToken("AssetName"), (int)item.SelectToken("AttackBonus"), (int)item.SelectToken("DefenseBonus"), (int)item.SelectToken("HPHealed"), (int)item.SelectToken("MagicHealed"), (int)item.SelectToken("MaxStackQuantity"), (int)item.SelectToken("ValueInGold"), (int)item.SelectToken("CanBuySell"), (int)item.SelectToken("MinPlayerLevel"), (int)item.SelectToken("IsActive")));
                                    break;
                                case 1: // Quests
                                    questsList.Add(new Quest((int)item.SelectToken("UniqueID"), (string)item.SelectToken("Name"), (int)item.SelectToken("ExpAwarded"), (int)item.SelectToken("QuestRewardID"), (int)item.SelectToken("MinCharacterLevel"), (int)item.SelectToken("MaxCharacterLevel"), (int)item.SelectToken("NPC_ID"), (string)item.SelectToken("Description")));
                                    break;
                                case 2: // Spells
                                    spellsList.Add(new Spell((int)item.SelectToken("UniqueID"), (string)item.SelectToken("Name"), (int)item.SelectToken("HealAmount"), (int)item.SelectToken("DamageAmount"), (int)item.SelectToken("Bonus"), (int)item.SelectToken("MagicCost"), (int)item.SelectToken("MinLevel")));
                                    break;
                                case 3: // Stats
                                    statsList.Add(new Stat((int)item.SelectToken("UniqueID"), (string)item.SelectToken("Name")));
                                    break;
                                case 4: // Races
                                    racesList.Add(new Race((int)item.SelectToken("UniqueID"), (string)item.SelectToken("Name"), (int)item.SelectToken("BaseSTR"), (int)item.SelectToken("BaseINT"), (int)item.SelectToken("BaseCON"), (int)item.SelectToken("IsActive")));
                                    break;
                                case 6: // NPCs
                                    npcsList.Add(new Npc((int)item.SelectToken("UniqueID"), (string)item.SelectToken("Name")));
                                    break;
                                case 7: // QuestRewards
                                    questrewardsList.Add(new QuestReward((int)item.SelectToken("UniqueID"), (int)item.SelectToken("IsItem"), (int)item.SelectToken("ItemID"), (int)item.SelectToken("Gold")));
                                    break;
                                default: // Shouldn't ever happen
                                    break;
                            }
                        }
                    }
                }

                SaveData();
            }
            catch (Exception e)
            {
                LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, "Updating from database: " + e);
            }
        }

        /// <summary>
        /// Determines if the Character has any quests
        /// </summary>
        /// <param name="characterID">The ID of a Character</param>
        /// <returns>True if the Character has Quests, false otherwise</returns>
        public static bool LoadQuestLog(int characterID)
        {
            try
            {
                string dataString = $"{{\"CharacterID\":{characterID}}}";
                string response = client.UploadString(Properties.Settings.Default.APIBaseAddress + Properties.Settings.Default.QuestLogReadAPI, dataString);
                JObject convertedJSON = JObject.Parse(response);

                foreach (var obj in convertedJSON)
                {
                    if(obj.Key != "error")
                    {
                        foreach (JObject item in obj.Value)
                        {
                            GameController.questLog.Add((QuestLog)item.ToObject(typeof(QuestLog)));
                        }
                    }
                    else
                    {
                        LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.GamePlay, "No questlog entries for this character.");
                        return false; // No questlogs for this player
                    }
                }
                LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "QuestLog successfully loaded");
                return true;
            }
            catch(Exception ex)
            {
                LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, "Reading questlog: " + ex);
                return false;
            }
        }

        /// <summary>
        /// Determines if the Character has access to Spells
        /// </summary>
        /// <param name="characterID">The ID of a Character</param>
        /// <returns>True if the Character has Spells, false otherwise</returns>
        public static bool HasSpellbook(int characterID)
        {
            // Need to add API functionality on server first!!
            LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.NotYetImplemented, "NOT YET IMPLEMENTED");
            return false;
        }

        /// <summary>
        /// Save a Player's settings and Character progress
        /// </summary>
        /// <param name="player">A Player object referencing the current user</param>
        public static void SaveProgress(Player player)
        {
            // UpdateSettings();
            UpdateCharacter(player.character, player.uniqueID);
        }

        /// <summary>
        /// Update a Character's database entry
        /// </summary>
        /// <param name="character">A Character object referencing the Character to be saved</param>
        /// <param name="playerID">The ID of the Player associated with the Character</param>
        private static void UpdateCharacter(Character character, int playerID)
        {
            string charValues = $"{{\"UserID\":\"{playerID}\",\"Name\":\"{character.Name}\",\"RaceID\":\"{character.RaceID}\",\"Gender\":\"{character.Gender}\",\"MaxHP\":\"{character.MaxHP}\",\"CurrentHP\":\"{character.CurrentHP}\",\"MaxMagic\":\"{character.MaxMagic}\",\"CurrentMagic\":\"{character.CurrentMagic}\",\"Strength\":\"{character.Strength}\",\"Intelligence\":\"{character.Intelligence}\",\"Constitution\":\"{character.Constitution}\",\"Gold\":\"{character.Gold}\",\"Level\":\"{character.Level}\",\"ExpPoints\":\"{character.ExpPoints}\"}}";
            string response = client.UploadString(Properties.Settings.Default.APIBaseAddress + Properties.Settings.Default.CharacterUpdateAPI, charValues);
            JObject convertedJSON = JObject.Parse(response);

            foreach (var obj in convertedJSON)
            {
                //LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, "Response from API: " + response);
                if (obj.Key == "success")
                {
                    LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "Updating character: " + character.Name);
                    return;
                }
                else if (obj.Key == "error")
                {
                    LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, "Updating character: " + obj.Value);
                }
            }
        }

        /// <summary>
        /// Saves each list locally as a json file
        /// </summary>
        private static void SaveData()
        {
            try
            {
                // Convert each List to a JSON Object so we can save it
                string itemsJSON = JsonConvert.SerializeObject(itemsList);
                string questsJSON = JsonConvert.SerializeObject(questsList);
                string spellsJSON = JsonConvert.SerializeObject(spellsList);
                string statsJSON = JsonConvert.SerializeObject(statsList);
                string racesJSON = JsonConvert.SerializeObject(racesList);
                string npcsJSON = JsonConvert.SerializeObject(npcsList);
                string questRewardsJSON = JsonConvert.SerializeObject(questrewardsList);

                // Make sure the path exists before we try to save there
                if (!Directory.Exists(storageLocation))
                {
                    Directory.CreateDirectory(storageLocation);
                }

                // Save each converted json string
                // WriteAllText overwrites any existing data, if the file exists
                File.WriteAllText(storageLocation + "items.json", itemsJSON);
                File.WriteAllText(storageLocation + "quests.json", questsJSON);
                File.WriteAllText(storageLocation + "spells.json", spellsJSON);
                File.WriteAllText(storageLocation + "stats.json", statsJSON);
                File.WriteAllText(storageLocation + "races.json", racesJSON);
                File.WriteAllText(storageLocation + "npcs.json", npcsJSON);
                File.WriteAllText(storageLocation + "questrewards.json", questRewardsJSON);
            }
            catch(Exception ex)
            {
                LogWriter.Write("API",MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Critical, "Cannot convert data to be saved: " + ex.Message);
            }
        }

        /// <summary>
        /// Check if the player information is stored locally and load it if it exists
        /// </summary>
        /// <param name="player"></param>
        /// <returns>Returns true if player information was found, false otherwise</returns>
        private static bool PlayerExistsLocally(ref Player player)
        {
            string path = storageLocation + "player.json";

            if (File.Exists(path))
            {
                using (StreamReader inputFile = File.OpenText(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    JObject response = (JObject)serializer.Deserialize(inputFile, typeof(JObject));

                    foreach (var obj in response)
                    {
                        foreach (var input in obj.Value)
                        {
                            try
                            {
                                JObject jsonInput = (JObject)input;
                                Player tempPlayer = (Player)jsonInput.ToObject(typeof(Player));
                                if (tempPlayer.username == player.username)
                                {
                                    return true;
                                }
                            }
                            catch (Exception e)
                            {
                                LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, "Parsing JSON: " + e);
                                return false;
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}
