using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public class Character
    {
        // UniqueID, UserID, Name, RaceID, MaxHP, CurrentHP, MaxMagic, CurrentMagic
        // Strength, Intelligence, Constitution, Gold, Level, ExperiencePoints, IsActive
        private int uniqueID;
        private int userID;
        private string name;
        private int raceID;
        private int gender;
        private int maxHP;
        private int currentHP;
        private int maxMagic;
        private int currentMagic;
        private int strength;
        private int intelligence;
        private int constitution;
        private int gold;
        private int level;
        private int expPoints;
        private int active;

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

        public int UniqueID { get => uniqueID; set => uniqueID = value; }
        public int UserID { get => userID; set => userID = value; }
        public string Name { get => name; set => name = value; }
        public int RaceID { get => raceID; set => raceID = value; }
        public int MaxHP { get => maxHP; set => maxHP = value; }
        public int CurrentHP { get => currentHP; set => currentHP = value; }
        public int MaxMagic { get => maxMagic; set => maxMagic = value; }
        public int CurrentMagic { get => currentMagic; set => currentMagic = value; }
        public int Strength { get => strength; set => strength = value; }
        public int Intelligence { get => intelligence; set => intelligence = value; }
        public int Constitution { get => constitution; set => constitution = value; }
        public int Gold { get => gold; set => gold = value; }
        public int Level { get => level; set => level = value; }
        public int ExpPoints { get => expPoints; set => expPoints = value; }
        public int Active { get => active; set => active = value; }
        public int Gender { get => gender; set => gender = value; }

        public string GetGold()
        {
            return Gold.ToString();
        }

        public List<Inventory> Inventory
        {
            get => GameController.inventoryList;
        }
    }
}
