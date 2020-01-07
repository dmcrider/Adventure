using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public class LevelUp
    {
        public LevelUp(int uniqueID, int expNeeded, int numberOfSpells, int sTRIncrease, int iNTIncrease, int cONIncrease, int hPIncrease, int magicIncrease)
        {
            UniqueID = uniqueID;
            ExpNeeded = expNeeded;
            NumberOfSpells = numberOfSpells;
            STRIncrease = sTRIncrease;
            INTIncrease = iNTIncrease;
            CONIncrease = cONIncrease;
            HPIncrease = hPIncrease;
            MagicIncrease = magicIncrease;
        }

        public int UniqueID { get; set; }
        public int ExpNeeded { get; set; }
        public int NumberOfSpells { get; set; }
        public int STRIncrease { get; set; }
        public int INTIncrease { get; set; }
        public int CONIncrease { get; set; }
        public int HPIncrease { get; set; }
        public int MagicIncrease { get; set; }
    }
}
