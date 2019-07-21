using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public class Character
    {
        // UniqueID, UserID, Name, MaxHP, CurrentHP, MaxMagic, CurrentMagic
        // Strength, Intelligence, Constitution, RightHand, LeftHand, Gold
        // Level, ExperiencePoints, IsActive
        private int uniqueID;
        private int userID;
        private string name;
        private int maxHP;
        private int currentHP;
        private int maxMagic;
        private int currentMagic;
        private int strength;
        private int intelligence;
        private int constitution;
        private int rightHand;
        private int leftHand;
        private int gold;
        private int level;
        private int expPoints;
        private int active;
        private Item rightItem;
        private Item leftItem;

        public int UniqueID { get => uniqueID; set => uniqueID = value; }
        public int UserID { get => userID; set => userID = value; }
        public string Name { get => name; set => name = value; }
        public int MaxHP { get => maxHP; set => maxHP = value; }
        public int CurrentHP { get => currentHP; set => currentHP = value; }
        public int MaxMagic { get => maxMagic; set => maxMagic = value; }
        public int CurrentMagic { get => currentMagic; set => currentMagic = value; }
        public int Strength { get => strength; set => strength = value; }
        public int Intelligence { get => intelligence; set => intelligence = value; }
        public int Constitution { get => constitution; set => constitution = value; }
        public int RightHand { get => rightHand; set => rightHand = value; }
        public int LeftHand { get => leftHand; set => leftHand = value; }
        public int Gold { get => gold; set => gold = value; }
        public int Level { get => level; set => level = value; }
        public int ExpPoints { get => expPoints; set => expPoints = value; }
        public int Active { get => active; set => active = value; }
        internal Item RightItem { get => rightItem; set => rightItem = value; }
        internal Item LeftItem { get => leftItem; set => leftItem = value; }

        private const int DEFAULT_RIGHTHAND = 0;
        private const int DEFAULT_LEFTHAND = 0;
        private const int DEFAULT_GOLD = 0;
        private const int DEFAULT_LEVEL = 1;
        private const int DEFAULT_EXPPOINTS = 0;
        private const int DEFAULT_ACTIVE = 1;

        public Character(int userID, string name, int maxHP, int maxMagic, int strength, int intelligence, int constitution)
        {
            UserID = userID;
            Name = name;

            MaxHP = maxHP;
            CurrentHP = maxHP;

            MaxMagic = maxMagic;
            CurrentMagic = maxMagic;

            Strength = strength;
            Intelligence = intelligence;
            Constitution = constitution;

            RightHand = DEFAULT_RIGHTHAND;
            LeftHand = DEFAULT_LEFTHAND;

            Gold = DEFAULT_GOLD;
            Level = DEFAULT_LEVEL;
            ExpPoints = DEFAULT_EXPPOINTS;
            Active = DEFAULT_ACTIVE;
        }
        public Character(int unique, int user, string name, int maxHP, int currentHP, int maxMagic, int currentMagic, int strength, int intel, int con, int rightHand, int leftHand, int gold, int level, int expPoints, int active)
        {
            UniqueID = unique;
            UserID = user;
            Name = name;
            MaxHP = maxHP;
            CurrentHP = currentHP;
            MaxMagic = maxMagic;
            CurrentMagic = currentMagic;
            Strength = strength;
            Intelligence = intel;
            Constitution = con;
            RightHand = rightHand;
            LeftHand = leftHand;
            Gold = gold;
            Level = level;
            ExpPoints = expPoints;
            Active = active;
        }
    }
}
