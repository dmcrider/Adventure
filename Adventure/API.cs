using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public static class API
    {
        private static WebClient client = new WebClient();

        public static bool CheckVersion(JObject convertedJSON)
        {
            try
            {
                foreach (var obj in convertedJSON)
                {
                    if (obj.Key == "api_version")
                    {
                        double cloudVersion = (double)obj.Value;
                        double localVersion = Double.Parse(Properties.Settings.Default.Version);

                        if (localVersion != cloudVersion)
                        {
                            // Update the locally stored version number
                            Properties.Settings.Default["Version"] = cloudVersion;
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
                Console.WriteLine("Error checking the database version\n\t" + e);
                return false;
            }

            return false;
            
        }

        public static void LoadData(List<Item>itemsList, List<Quest>questsList, List<Spell>spellsList, List<Stat>statsList, List<Race>racesList, List<State> statesList, List<Npc>npcsList, List<QuestReward>questrewardsList)
        {
            try
            {
                string[] filesArray = {"items.json","quests.json","spells.json","stats.json","races.json","states.json","npcs.json","questrewards.json"};
                

                foreach (string file in filesArray)
                {
                    string path = Environment.SpecialFolder.ApplicationData.ToString() + file;
                    string type = file.Split('.')[0];
                    // Read the file in and add an appropriate object to the arrays we got from the main class
                    using(System.IO.StreamReader inputFile = System.IO.File.OpenText(path))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        JObject response = (JObject)serializer.Deserialize(inputFile, typeof(JObject));

                        foreach(var obj in response)
                        {
                            foreach(var input in obj.Value)
                            {
                                JObject jsonInput = (JObject)input;
                                switch (type)
                                {
                                    case "items":
                                        itemsList.Add((Item)jsonInput.ToObject(typeof(Item)));
                                        break;
                                    case "quests":
                                        questsList.Add((Quest)jsonInput.ToObject(typeof(Quest)));
                                        break;
                                    case "spells":
                                        spellsList.Add((Spell)jsonInput.ToObject(typeof(Spell)));
                                        break;
                                    case "stats":
                                        statsList.Add((Stat)jsonInput.ToObject(typeof(Stat)));
                                        break;
                                    case "races":
                                        racesList.Add((Race)jsonInput.ToObject(typeof(Race)));
                                        break;
                                    case "states":
                                        statesList.Add((State)jsonInput.ToObject(typeof(State)));
                                        break;
                                    case "npcs":
                                        npcsList.Add((Npc)jsonInput.ToObject(typeof(Npc)));
                                        break;
                                    case "questrewards":
                                        questrewardsList.Add((QuestReward)jsonInput.ToObject(typeof(QuestReward)));
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }
            }catch(Exception e)
            {
                Console.WriteLine("Error loading local data\n\t" + e);
                return;
            }
        }

        private static bool PlayerExistsLocally(Player player)
        {
            string path = Environment.SpecialFolder.ApplicationData.ToString() + "player.json";

            if (System.IO.File.Exists(path))
            {
                using (System.IO.StreamReader inputFile = System.IO.File.OpenText(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    JObject response = (JObject)serializer.Deserialize(inputFile, typeof(JObject));

                    foreach (var obj in response)
                    {
                        foreach (var input in obj.Value)
                        {
                            JObject jsonInput = (JObject)input;
                            player = (Player)jsonInput.ToObject(typeof(Player));
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static int Login(Player player)
        {
            string credentials;
            if (player.HasID())
            {
                credentials = $"{{\"Username\":\"{player.username}\",\"Password\":\"{player.password}\",\"ID\":\"{player.uniqueID}\"}}";
            }
            else
            {
                if (PlayerExistsLocally(player))
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
                if(obj.Key == "fail")
                {
                    return 0; // Bad login attempt
                }
                else if (obj.Key == "success")
                {
                    return 1;
                }
            }

            return 0; // Bad login attempt
        }

        public static void UpdateFromDatabase(List<Item> itemsList, List<Quest> questsList, List<Spell> spellsList, List<Stat> statsList, List<Race> racesList, List<State> statesList, List<Npc> npcsList, List<QuestReward> questrewardsList)
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

            foreach(string apiName in apiStrings)
            {
                string fullAPI = Properties.Settings.Default.APIBaseAddress + apiName;
                string response = client.DownloadString(fullAPI);
                JObject convertedJSON = JObject.Parse(response);

                foreach(var obj in convertedJSON)
                {
                    foreach(var item in obj.Value)
                    {
                        switch (Array.IndexOf(apiStrings,apiName))
                        {
                            case 0: // Items
                                itemsList.Add(new Item((int)item.SelectToken("UniqueID"), (string)item.SelectToken("DisplayName"), (string)item.SelectToken("AssetName"), (int)item.SelectToken("AttackBonus"), (int)item.SelectToken("DefenseBonus"), (int)item.SelectToken("HPHealed"), (int)item.SelectToken("MagicHealed"), (int)item.SelectToken("MaxStackQuantity"), (int)item.SelectToken("ValueInGold"), (int)item.SelectToken("CanBuySell"), (int)item.SelectToken("IsActive")));
                                break;
                            case 1: // Quests
                                questsList.Add(new Quest((int)item.SelectToken("UniqueID"),(string)item.SelectToken("Name"), (int)item.SelectToken("ExpAwarded"), (int)item.SelectToken("QuestRewardID"), (int)item.SelectToken("MinCharacterLevel"), (int)item.SelectToken("MaxCharacterID"), (int)item.SelectToken("NPC_ID"), (string)item.SelectToken("Description")));
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
                            case 5: // States
                                statesList.Add(new State((int)item.SelectToken("UniqueID"), (string)item.SelectToken("Name")));
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

            SaveData(itemsList,questsList,spellsList,statsList,racesList,statesList,npcsList,questrewardsList);
        }

        private static void SaveData(List<Item> items, List<Quest> quests, List<Spell> spells, List<Stat> stats, List<Race> races, List<State> states, List<Npc> npcs, List<QuestReward> questRewards)
        {
            // Convert each List to a JSON Object so we can save it
            string itemsJSON = JsonConvert.SerializeObject(items);
            string questsJSON = JsonConvert.SerializeObject(quests);
            string spellsJSON = JsonConvert.SerializeObject(spells);
            string statsJSON = JsonConvert.SerializeObject(stats);
            string racesJSON = JsonConvert.SerializeObject(races);
            string statesJSON = JsonConvert.SerializeObject(states);
            string npcsJSON = JsonConvert.SerializeObject(npcs);
            string questRewardsJSON = JsonConvert.SerializeObject(questRewards);

            // Save each converted json string
            // WriteAllText overwrites any existing data, if the file exists
            System.IO.File.WriteAllText(Environment.SpecialFolder.ApplicationData.ToString() + "items.json",itemsJSON);
            System.IO.File.WriteAllText(Environment.SpecialFolder.ApplicationData.ToString() + "quests.json",questsJSON);
            System.IO.File.WriteAllText(Environment.SpecialFolder.ApplicationData.ToString() + "spells.json",spellsJSON);
            System.IO.File.WriteAllText(Environment.SpecialFolder.ApplicationData.ToString() + "stats.json",statsJSON);
            System.IO.File.WriteAllText(Environment.SpecialFolder.ApplicationData.ToString() + "races.json",racesJSON);
            System.IO.File.WriteAllText(Environment.SpecialFolder.ApplicationData.ToString() + "states.json",statesJSON);
            System.IO.File.WriteAllText(Environment.SpecialFolder.ApplicationData.ToString() + "npcs.json",npcsJSON);
            System.IO.File.WriteAllText(Environment.SpecialFolder.ApplicationData.ToString() + "questrewards.json",questRewardsJSON);
        }
    }
}
