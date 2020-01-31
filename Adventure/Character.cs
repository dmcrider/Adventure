using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public class Character
    {
        private int gold;
        private int expPoints;

        private const int DEFAULT_HP = 20;
        private const int DEFAULT_MAGIC = 20;
        private const int DEFAULT_GOLD = 0;
        private const int DEFAULT_LEVEL = 1;
        private const int DEFAULT_EXPPOINTS = 0;
        private const int DEFAULT_ACTIVE = 1;

        // For characters that we get from the database, or a local file
        public Character(int uniqueID, int userID, string name, int raceID, int maxHP, int currentHP, int maxMagic, int currentMagic, int strength, int intelligence, int constitution, int gold, int level, int expPoints, int active)
        {
            UniqueID = uniqueID;
            UserID = userID;
            Name = name;
            RaceID = raceID;
            MaxHP = maxHP;
            CurrentHP = currentHP;
            MaxMagic = maxMagic;
            CurrentMagic = currentMagic;
            Strength = strength;
            Intelligence = intelligence;
            Constitution = constitution;
            Gold = gold;
            Level = level;
            ExpPoints = expPoints;
            Active = active;
        }

        // For characters created from within the program
        public Character(int userID, string name, int raceID)
        {
            UserID = userID;
            Name = name;
            RaceID = raceID;
            MaxHP = CurrentHP = DEFAULT_HP;
            MaxMagic = CurrentMagic = DEFAULT_MAGIC;
            Strength = Race.GetStrength(raceID);
            Intelligence = Race.GetIntelligence(raceID);
            Constitution = Race.GetConstitution(raceID);
            Gold = DEFAULT_GOLD;
            Level = DEFAULT_LEVEL;
            ExpPoints = DEFAULT_EXPPOINTS;
            Active = DEFAULT_ACTIVE;
        }

        public int UniqueID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public int RaceID { get; set; }
        public int MaxHP { get; set; }
        public int CurrentHP { get; set; }
        public int MaxMagic { get; set; }
        public int CurrentMagic { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Constitution { get; set; }
        public int Active { get; set; }
        public int Gender { get; set; }
        public int Level { get; set; }
        public int Gold
        {
            get => gold;
            set
            {
                LogWriter.Write(typeof(Character).Name, "Gold", LogWriter.LogType.GamePlay, $"Gold changed from {gold} to {value}");
                gold = value;

                Instances.FormMain.UpdatePlayerInfoUI();
            }
        }
        public int ExpPoints
        {
            get => expPoints;
            set
            {
                LogWriter.Write(typeof(Character).Name, "ExpPoints", LogWriter.LogType.GamePlay, $"EXP increased from {expPoints} to {value}");
                expPoints = value;

                if(CharacterLevel.CharacterLevels.Count() > 0 && Instances.Character != null)
                {
                    CharacterLevel level = CharacterLevel.CharacterLevels.Find(x => x.UniqueID == Instances.Character.Level);

                    if (expPoints >= level.ExpNeeded)
                    {
                        LogWriter.Write(typeof(Character).Name, "ExpPoints", LogWriter.LogType.GamePlay, "LEVEL UP!");
                        expPoints -= level.ExpNeeded;
                        new FormLevelUp(level).ShowDialog();
                        // Save after level up
                        Save();
                    }
                    Instances.FormMain.UpdatePlayerInfoUI();
                }
            }
        }
        public List<Inventory> Inventory {
            get => GameController.inventoryList;
        }

        /// <summary>
        /// Fully heal HP and Magic
        /// </summary>
        public void RestoreHPAndMagic()
        {
            CurrentHP = MaxHP;
            CurrentMagic = MaxMagic;
        }

        public void Save()
        {
            WebClient client = new WebClient();
            try
            {
                string charValues = $"{{\"UniqueID\":\"{UniqueID}\",\"UserID\":\"{Instances.Player.uniqueID}\",\"Name\":\"{Name}\",\"RaceID\":\"{RaceID}\",\"Gender\":\"{Gender}\",\"MaxHP\":\"{MaxHP}\",\"CurrentHP\":\"{CurrentHP}\",\"MaxMagic\":\"{MaxMagic}\",\"CurrentMagic\":\"{CurrentMagic}\",\"Strength\":\"{Strength}\",\"Intelligence\":\"{Intelligence}\",\"Constitution\":\"{Constitution}\",\"Gold\":\"{Gold}\",\"Level\":\"{Level}\",\"ExpPoints\":\"{ExpPoints}\",\"IsActive\":\"{Active}\"}}";
                string response = client.UploadString(Properties.Settings.Default.APIBaseAddress + Properties.Settings.Default.CharacterUpdateAPI, charValues);
                JObject convertedJSON = JObject.Parse(response);

                foreach (var obj in convertedJSON)
                {
                    if (obj.Key == "success")
                    {
                        LogWriter.Write(typeof(Character).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Success, "Updating character: " + this.Name);
                    }
                    else if (obj.Key == "error")
                    {
                        LogWriter.Write(typeof(Character).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, "Updating character: " + obj.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                LogWriter.Write(typeof(Character).Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, ex.Message);
            }
        }
    }
}
