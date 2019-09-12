using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public class Item
    {
        private const double SHOP_VALUE = 1.25;
        private const double SPECIAL_VALUE = 1.0;
        private const double PLAYER_VALUE = 0.75;

        private int uniqueID;
        private string displayName;
        private string assetName;
        private int attackBonus;
        private int defenseBonus;
        private int hpHealed;
        private int magicHealed;
        private int maxStackQunatity;
        private int valueInGold;
        private int canBuySell;
        private int minPlayerLevel;
        private int active;

        public Item() { }

        public Item(int uniqueID, string displayName, string assetName, int attackBonus, int defenseBonus, int hpHealed, int magicHealed, int maxStackQunatity, int valueInGold, int canBuySell, int minplayerlvl, int active)
        {
            UniqueID = uniqueID;
            DisplayName = displayName;
            AssetName = assetName;
            AttackBonus = attackBonus;
            DefenseBonus = defenseBonus;
            HpHealed = hpHealed;
            MagicHealed = magicHealed;
            MaxStackQunatity = maxStackQunatity;
            ValueInGold = valueInGold;
            CanBuySell = canBuySell;
            MinPlayerLevel = minplayerlvl;
            Active = active;
        }

        public int UniqueID { get => uniqueID; set => uniqueID = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public string AssetName { get => assetName; set => assetName = value; }
        public int AttackBonus { get => attackBonus; set => attackBonus = value; }
        public int DefenseBonus { get => defenseBonus; set => defenseBonus = value; }
        public int HpHealed { get => hpHealed; set => hpHealed = value; }
        public int MagicHealed { get => magicHealed; set => magicHealed = value; }
        public int MaxStackQunatity { get => maxStackQunatity; set => maxStackQunatity = value; }
        public int ValueInGold { get => valueInGold; set => valueInGold = value; }
        public int CanBuySell { get => canBuySell; set => canBuySell = value; }
        public int MinPlayerLevel { get => minPlayerLevel; set => minPlayerLevel = value; }
        public int Active { get => active; set => active = value; }

        /// <summary>
        /// Populate a listview with item details
        /// </summary>
        /// <param name="who">Shops sell at higher prices and buy at lower prices</param>
        /// <returns>ListViewItem containing the DisplayName and Value of the item</returns>
        public System.Windows.Forms.ListViewItem ShopDetails(int who)
        {
            double value = this.ValueInGold;
            int outValue = -1;

            if(who == GameController.SHOP)
            {
                outValue = (int)Math.Round(value * SHOP_VALUE);
            }

            if(who == GameController.PLAYER)
            {
                outValue = (int)Math.Round(value * PLAYER_VALUE);
            }

            if(who == GameController.SPECIAL)
            {
                outValue = (int)Math.Round(value * SPECIAL_VALUE);
            }

            string[] retValue = { DisplayName, outValue.ToString(), UniqueID.ToString() };
            return new System.Windows.Forms.ListViewItem(retValue);
        }
    }
}
