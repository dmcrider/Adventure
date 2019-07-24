using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    class Quest
    {

        private int uniqueID;
        private string name;
        private int expAwarded;
        private int questRewardID;
        private int minCharLevel;
        private int maxCharLevel;
        private int npcID;
        private string description;

        public Quest(int uniqueID, string name, int expAwarded, int questRewardID, int minCharLevel, int maxCharLevel, int npcID, string description)
        {
            UniqueID = uniqueID;
            Name = name;
            ExpAwarded = expAwarded;
            QuestRewardID = questRewardID;
            MinCharLevel = minCharLevel;
            MaxCharLevel = maxCharLevel;
            NpcID = npcID;
            Description = description;
        }

        public int UniqueID { get => uniqueID; set => uniqueID = value; }
        public string Name { get => name; set => name = value; }
        public int ExpAwarded { get => expAwarded; set => expAwarded = value; }
        public int QuestRewardID { get => questRewardID; set => questRewardID = value; }
        public int MinCharLevel { get => minCharLevel; set => minCharLevel = value; }
        public int MaxCharLevel { get => maxCharLevel; set => maxCharLevel = value; }
        public int NpcID { get => npcID; set => npcID = value; }
        public string Description { get => description; set => description = value; }
    }
}
