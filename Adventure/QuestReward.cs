using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public class QuestReward
    {
        private int uniqueID;
        private int isItem;
        private int itemID;
        private int gold;

        public QuestReward(int uniqueID, int isItem, int itemID, int gold)
        {
            UniqueID = uniqueID;
            IsItem = isItem;
            ItemID = itemID;
            Gold = gold;
        }

        public QuestReward() { }

        public int UniqueID { get => uniqueID; set => uniqueID = value; }
        public int IsItem { get => isItem; set => isItem = value; }
        public int ItemID { get => itemID; set => itemID = value; }
        public int Gold { get => gold; set => gold = value; }
    }
}
