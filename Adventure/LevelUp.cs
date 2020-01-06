using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public class LevelUp
    {
        public LevelUp(int uniqueID, int expNeeded, int numberOfSpells)
        {
            UniqueID = uniqueID;
            ExpNeeded = expNeeded;
            NumberOfSpells = numberOfSpells;
        }

        public int UniqueID { get; set; }
        public int ExpNeeded { get; set; }
        public int NumberOfSpells { get; set; }
    }
}
