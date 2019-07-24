using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    class Spell
    {

        private int uniqueID;
        private string name;
        private int healAmount;
        private int damageAmount;
        private int bonus;
        private int magicCost;
        private int minLevel;

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

        public int UniqueID { get => uniqueID; set => uniqueID = value; }
        public string Name { get => name; set => name = value; }
        public int HealAmount { get => healAmount; set => healAmount = value; }
        public int DamageAmount { get => damageAmount; set => damageAmount = value; }
        public int Bonus { get => bonus; set => bonus = value; }
        public int MagicCost { get => magicCost; set => magicCost = value; }
        public int MinLevel { get => minLevel; set => minLevel = value; }
    }
}
