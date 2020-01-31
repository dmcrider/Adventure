using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public class Enemy
    {
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

        public Enemy() { }

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
    }
}
