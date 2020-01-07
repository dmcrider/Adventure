using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public class QuestLog
    {
        private int uniqueID;
        private int characterID;
        private int questID;
        private State stateID;
        private int isActive;

        public QuestLog(int uniqueID, int characterID, int questID, State stateID, int isActive)
        {
            UniqueID = uniqueID;
            CharacterID = characterID;
            QuestID = questID;
            StateID = stateID;
            IsActive = isActive;
        }

        public int UniqueID { get => uniqueID; set => uniqueID = value; }
        public int CharacterID { get => characterID; set => characterID = value; }
        public int QuestID { get => questID; set => questID = value; }
        public State StateID { get => stateID; set => stateID = value; }
        public int IsActive { get => isActive; set => isActive = value; }
    }
}
