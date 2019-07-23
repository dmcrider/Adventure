using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    class Item
    {
        private int uniqueID;
        private string displayName;
        private string assetName;
        private int hand;
        private int attackBonus;
        private int defenseBonus;
        private int hpHealed;
        private int magicHealed;
        private int active;

        public Item(int uniqueID, string displayName, string assetName, int hand, int attackBonus, int defenseBonus, int hpHealed, int magicHealed, int active)
        {
            UniqueID = uniqueID;
            DisplayName = displayName;
            AssetName = assetName;
            Hand = hand;
            AttackBonus = attackBonus;
            DefenseBonus = defenseBonus;
            HpHealed = hpHealed;
            MagicHealed = magicHealed;
            Active = active;
        }

        public int UniqueID { get => uniqueID; set => uniqueID = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public string AssetName { get => assetName; set => assetName = value; }
        public int Hand { get => hand; set => hand = value; }
        public int AttackBonus { get => attackBonus; set => attackBonus = value; }
        public int DefenseBonus { get => defenseBonus; set => defenseBonus = value; }
        public int HpHealed { get => hpHealed; set => hpHealed = value; }
        public int MagicHealed { get => magicHealed; set => magicHealed = value; }
        public int Active { get => active; set => active = value; }

        
    }
}
