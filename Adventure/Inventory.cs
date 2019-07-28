using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public class Inventory
    {
        private int uniqueID;
        private int characterID;
        private int itemID;
        private int quantity;
        private int isUsing;
        private int hand;
        private int isActive;

        public Inventory(int uniqueID, int characterID, int itemID, int quantity, int isUsing, int hand, int isActive)
        {
            UniqueID = uniqueID;
            CharacterID = characterID;
            ItemID = itemID;
            Quantity = quantity;
            IsUsing = isUsing;
            Hand = hand;
            IsActive = isActive;
        }

        public int UniqueID { get => uniqueID; set => uniqueID = value; }
        public int CharacterID { get => characterID; set => characterID = value; }
        public int ItemID { get => itemID; set => itemID = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int IsUsing { get => isUsing; set => isUsing = value; }
        public int Hand { get => hand; set => hand = value; }
        public int IsActive { get => isActive; set => isActive = value; }
    }
}
