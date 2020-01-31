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
using System.Threading;

namespace Adventure
{
    public static class API
    {
        // TODO: Encrypt passwords sent
        // TODO: Decrypt passwords received

        // Single WebClient used throughout this class
        private static readonly WebClient client = new WebClient();
        public static readonly string storageLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Adventure\\";

        /// <summary>
        /// Determines if an APIStatusCode is a successful code
        /// </summary>
        /// <param name="code">APIStatusCode to validate</param>
        /// <returns>TRUE if code is one of the success values</returns>
        public static bool IsSuccess(APIStatusCode code)
        {
            return code == APIStatusCode.SUCCESS || code == APIStatusCode.SECONDARY_SUCCESS;
        }

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
        public static APIStatusCode LoadLocalData()
        {
            try
            {
                // Instantiate each thread
                Thread statThread = new Thread(new ThreadStart(Stat.LoadFromFile));
                Thread spellThread = new Thread(new ThreadStart(Spell.LoadFromFile));
                Thread raceThread = new Thread(new ThreadStart(Race.LoadFromFile));
                Thread questRewardThread = new Thread(new ThreadStart(QuestReward.LoadFromFile));
                Thread questThread = new Thread(new ThreadStart(Quest.LoadFromFile));
                Thread npcThread = new Thread(new ThreadStart(Npc.LoadFromFile));
                Thread itemThread = new Thread(new ThreadStart(Item.LoadFromFile));
                Thread enemyThread = new Thread(new ThreadStart(Enemy.LoadFromFile));
                Thread characterLevelThread = new Thread(new ThreadStart(CharacterLevel.LoadFromFile));

                // Start each thread after the previous one has ended
                statThread.Start();
                statThread.Join();

                spellThread.Start();
                spellThread.Join();

                raceThread.Start();
                raceThread.Join();

                questRewardThread.Start();
                questRewardThread.Join();

                questThread.Start();
                questThread.Join();

                npcThread.Start();
                npcThread.Join();

                itemThread.Start();
                itemThread.Join();

                enemyThread.Start();
                enemyThread.Join();

                characterLevelThread.Start();
                characterLevelThread.Join();

                // Now that all threads have completed, return success
                LogWriter.Write(typeof(API).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "All threads completed");
                return APIStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                LogWriter.Write(typeof(API).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, "Loading local data: " + ex);
                return APIStatusCode.FAIL;
            }
        }

        /// <summary>
        /// Connects to the cloud database to verrify login credentials.
        /// </summary>
        /// <param name="player"></param>
        /// <returns>Returns 1 if login was successful, 0 if login failed</returns>
        public static APIStatusCode Login(Player player)
        {
            string credentials;
            if (player.HasID())
            {
                credentials = $"{{\"Username\":\"{player.username}\",\"Password\":\"{player.password}\",\"ID\":\"{player.uniqueID}\"}}";
            }
            else
            {
                APIStatusCode playerExists = PlayerExistsLocally(ref player);
                if (playerExists != APIStatusCode.FAIL && playerExists != APIStatusCode.SECONDARY_FAIL)
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
                    return APIStatusCode.SUCCESS;
                }
                else if (obj.Key == "fail" || obj.Key == "error")
                {
                    return APIStatusCode.FAIL;
                }
            }

            return APIStatusCode.FAIL;
        }

        /// <summary>
        /// Registers a new user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <returns>Returns true if registration was successful, false otherwise</returns>
        public static APIStatusCode Register(string username, string pwd)
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
                    return APIStatusCode.SUCCESS;
                }
            }
            // Database transaction failed
            return APIStatusCode.FAIL;
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
                        //LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Debug, character.ToString());
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
        public static APIStatusCode CreateCharacter(Character character, int playerID)
        {
            try
            {
                string charValues = $"{{\"UserID\":\"{playerID}\",\"Name\":\"{character.Name}\",\"RaceID\":\"{character.RaceID}\",\"Gender\":\"{character.Gender}\",\"MaxHP\":\"{character.MaxHP}\",\"CurrentHP\":\"{character.CurrentHP}\",\"MaxMagic\":\"{character.MaxMagic}\",\"CurrentMagic\":\"{character.CurrentMagic}\",\"Strength\":\"{character.Strength}\",\"Intelligence\":\"{character.Intelligence}\",\"Constitution\":\"{character.Constitution}\",\"Gold\":\"{character.Gold}\",\"Level\":\"{character.Level}\",\"ExpPoints\":\"{character.ExpPoints}\"}}";
                string response = client.UploadString(Properties.Settings.Default.APIBaseAddress + Properties.Settings.Default.CharacterCreateAPI, charValues);
                JObject convertedJSON = JObject.Parse(response);

                foreach (var obj in convertedJSON)
                {
                    if (obj.Key == "success")
                    {
                        character.UniqueID = (int)convertedJSON.GetValue("UniqueID");
                        return APIStatusCode.SUCCESS;
                    }
                    else if (obj.Key == "error")
                    {
                        LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, "Creating character: " + obj.Value);
                        return APIStatusCode.FAIL;
                    }
                }
                return APIStatusCode.FAIL;
            }
            catch (Exception ex)
            {
                LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, ex.Message);
                return APIStatusCode.FAIL;
            }
        }

        /// <summary>
        /// Adds an Item to the character's inventory
        /// </summary>
        /// <param name="character"></param>
        /// <param name="itemID"></param>
        /// <param name="quantity"></param>
        public static APIStatusCode AddInventoryItem(Character character, int itemID, int quantity=1)
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
                        LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, $"Item {convertedJSON.GetValue("DisplayName")} added to inventory successfully.");
                        return LoadInventory(character.UniqueID);
                    }
                    else if(obj.Key == "fail")
                    {
                        LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, "Failed to add item to inventory: " + convertedJSON.GetValue("fail"));
                        return APIStatusCode.FAIL;
                    }
                }
            }
            else
            {
                LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, "Inventory full for character with ID " + character.UniqueID);
                FormMain.InventoryFullMessageBox();
                return APIStatusCode.OUT_OF_SPACE;
            }

            return APIStatusCode.FAIL;
        }

        /// <summary>
        /// Gets all inventory items for the associated Character
        /// </summary>
        /// <param name="characterID"></param>
        /// <returns>Returns a List of Items</returns>
        public static APIStatusCode LoadInventory(int characterID)
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
                return APIStatusCode.SECONDARY_SUCCESS;
            }
            catch(Exception e)
            {
                LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, e.Message);
                return APIStatusCode.SECONDARY_FAIL;
            }
        }

        /// <summary>
        /// Pushes local updates to a player's inventory to the database
        /// </summary>
        /// <param name="characterID">The ID of a Character</param>
        /// <returns></returns>
        public static APIStatusCode UpdateInventory(int characterID)
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
                            LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "Updating Inventory");
                            return APIStatusCode.SUCCESS;
                        }
                        else
                        {
                            LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, "Updating Inventory");
                            return APIStatusCode.FAIL;
                        }
                    }
                }
            }
            catch(Exception e)
            {
                LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, "Updating inventory: " + e);
                return APIStatusCode.FAIL;
            }

            return APIStatusCode.FAIL;
        }

        /// <summary>
        /// Connects to the cloud database to update the appropriate list
        /// </summary>
        public static APIStatusCode UpdateFromDatabase()
        {
            try
            {
                // Instantiate each thread
                Thread statThread = new Thread(new ThreadStart(Stat.LoadFromDatabase));
                Thread spellThread = new Thread(new ThreadStart(Spell.LoadFromDatabase));
                Thread raceThread = new Thread(new ThreadStart(Race.LoadFromDatabase));
                Thread questRewardThread = new Thread(new ThreadStart(QuestReward.LoadFromDatabase));
                Thread questThread = new Thread(new ThreadStart(Quest.LoadFromDatabase));
                Thread npcThread = new Thread(new ThreadStart(Npc.LoadFromDatabase));
                Thread itemThread = new Thread(new ThreadStart(Item.LoadFromDatabase));
                Thread enemyThread = new Thread(new ThreadStart(Enemy.LoadFromDatabase));
                Thread characterLevelThread = new Thread(new ThreadStart(CharacterLevel.LoadFromDatabase));

                // Start each thread after the previous one has ended
                statThread.Start();
                statThread.Join();

                spellThread.Start();
                spellThread.Join();

                raceThread.Start();
                raceThread.Join();

                questRewardThread.Start();
                questRewardThread.Join();

                questThread.Start();
                questThread.Join();

                npcThread.Start();
                npcThread.Join();

                itemThread.Start();
                itemThread.Join();

                enemyThread.Start();
                enemyThread.Join();

                characterLevelThread.Start();
                characterLevelThread.Join();

                // Now that all threads have completed, return success
                LogWriter.Write(typeof(API).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "All threads completed");
                return APIStatusCode.SUCCESS;
            }
            catch (Exception e)
            {
                LogWriter.Write(typeof(API).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, "Updating from database: " + e);
                return APIStatusCode.FAIL;
            }
        }

        /// <summary>
        /// Determines if the Character has any quests
        /// </summary>
        /// <param name="characterID">The ID of a Character</param>
        /// <returns>True if the Character has Quests, false otherwise</returns>
        public static APIStatusCode LoadQuestLog(int characterID)
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
                        return APIStatusCode.FAIL; // No questlogs for this player
                    }
                }
                LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "QuestLog successfully loaded");
                return APIStatusCode.SUCCESS;
            }
            catch(Exception ex)
            {
                LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, "Reading questlog: " + ex);
                return APIStatusCode.FAIL;
            }
        }

        /// <summary>
        /// Update the StateID of the QuestLog parameter
        /// </summary>
        /// <param name="ql">QuestLog to update</param>
        /// <returns>Enum of APIStatusCode that determines success or failure</returns>
        public static APIStatusCode UpdateQuestLog(QuestLog ql)
        {
            try
            {
                string dataString = $"{{\"UniqueID\":{ql.UniqueID},\"StateID\":{(int)ql.StateID}}}";
                string response = client.UploadString(Properties.Settings.Default.APIBaseAddress + Properties.Settings.Default.QuestLogUpdateAPI, dataString);
                JObject convertedJSON = JObject.Parse(response);

                foreach(var obj in convertedJSON)
                {
                    if (obj.Key == "success")
                    {
                        LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "Updating QuestLog");
                        return APIStatusCode.SUCCESS;
                    }
                    else
                    {
                        LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, "Updating QuestLog");
                        return APIStatusCode.FAIL;
                    }
                }
            }
            catch(Exception ex)
            {
                LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, ex.Message);
                return APIStatusCode.FAIL;
            }

            // This should never get hit
            return APIStatusCode.FAIL;
        }

        /// <summary>
        /// Creates a QuestLog entry in the database
        /// </summary>
        /// <param name="ql">QuestLog to save to the database</param>
        /// <returns>Enum of APIStatusCode that indicates success/failure</returns>
        public static APIStatusCode CreateQuestLog(QuestLog ql)
        {
            try
            {
                string dataString = $"{{\"CharacterID\":{Instances.Character.UniqueID},\"QuestID\":{ql.QuestID},\"StateID\":{(int)ql.StateID},\"IsActive\":{ql.IsActive}}}";
                string response = client.UploadString(Properties.Settings.Default.APIBaseAddress + Properties.Settings.Default.QuestLogCreateAPI, dataString);
                JObject convertedJSON = JObject.Parse(response);

                foreach (var obj in convertedJSON)
                {
                    if (obj.Key == "success")
                    {
                        LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "Creating QuestLog");
                        int.TryParse(convertedJSON.GetValue("UniqueID").ToString(), out int uniqueID);
                        ql.UniqueID = uniqueID;
                        GameController.questLog.Add(ql);
                        return APIStatusCode.SUCCESS;
                    }
                    else
                    {
                        LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, "Creating QuestLog");
                        return APIStatusCode.FAIL;
                    }
                }
            }
            catch (Exception ex)
            {
                LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, ex.Message);
                return APIStatusCode.FAIL;
            }

            // This should never get hit
            return APIStatusCode.FAIL;
        }

        /// <summary>
        /// Determines if the Character has access to Spells
        /// </summary>
        /// <param name="characterID">The ID of a Character</param>
        /// <returns>True if the Character has Spells, false otherwise</returns>
        public static APIStatusCode HasSpellbook(int characterID)
        {
            // Need to add API functionality on server first!!
            LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.NotYetImplemented, $"NOT YET IMPLEMENTED - {characterID}");
            return APIStatusCode.FAIL;
        }

        /// <summary>
        /// Save a Player's settings and Character progress
        /// </summary>
        /// <param name="player">A Player object referencing the current user</param>
        public static APIStatusCode SaveProgress(Player player)
        {
            return UpdateCharacter(player.character, player.uniqueID);
        }

        /// <summary>
        /// Update a Character's database entry
        /// </summary>
        /// <param name="character">A Character object referencing the Character to be saved</param>
        /// <param name="playerID">The ID of the Player associated with the Character</param>
        private static APIStatusCode UpdateCharacter(Character character, int playerID)
        {
            try
            {
                string charValues = $"{{\"UniqueID\":\"{Instances.Character.UniqueID}\",\"UserID\":\"{playerID}\",\"Name\":\"{character.Name}\",\"RaceID\":\"{character.RaceID}\",\"Gender\":\"{character.Gender}\",\"MaxHP\":\"{character.MaxHP}\",\"CurrentHP\":\"{character.CurrentHP}\",\"MaxMagic\":\"{character.MaxMagic}\",\"CurrentMagic\":\"{character.CurrentMagic}\",\"Strength\":\"{character.Strength}\",\"Intelligence\":\"{character.Intelligence}\",\"Constitution\":\"{character.Constitution}\",\"Gold\":\"{character.Gold}\",\"Level\":\"{character.Level}\",\"ExpPoints\":\"{character.ExpPoints}\",\"IsActive\":\"{character.Active}\"}}";
                string response = client.UploadString(Properties.Settings.Default.APIBaseAddress + Properties.Settings.Default.CharacterUpdateAPI, charValues);
                JObject convertedJSON = JObject.Parse(response);
                //LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Debug, charValues);

                foreach (var obj in convertedJSON)
                {
                    if (obj.Key == "success")
                    {
                        LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "Updating character: " + character.Name);
                        return APIStatusCode.SECONDARY_SUCCESS;
                    }
                    else if (obj.Key == "error")
                    {
                        LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, "Updating character: " + obj.Value);
                        return APIStatusCode.SECONDARY_FAIL;
                    }
                }
            }
            catch(Exception ex)
            {
                LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, ex.Message);
                return APIStatusCode.SECONDARY_FAIL;
            }

            return APIStatusCode.SECONDARY_FAIL;
        }

        /// <summary>
        /// Check if the player information is stored locally and load it if it exists
        /// </summary>
        /// <param name="player"></param>
        /// <returns>Returns true if player information was found, false otherwise</returns>
        private static APIStatusCode PlayerExistsLocally(ref Player player)
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
                                    LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "Loaded Player data");
                                    return APIStatusCode.SECONDARY_SUCCESS;
                                }
                            }
                            catch (Exception e)
                            {
                                LogWriter.Write("API", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, "Parsing JSON: " + e);
                                return APIStatusCode.SECONDARY_FAIL;
                            }
                        }
                    }
                }
            }
            return APIStatusCode.FAIL;
        }
    }

    public enum APIStatusCode
    {
        SUCCESS = 100,
        SECONDARY_SUCCESS = 105,
        FAIL = 200,
        SECONDARY_FAIL = 205,
        OUT_OF_SPACE = 210,
        NOT_YET_IMPLEMENTED = 404
    }
}
