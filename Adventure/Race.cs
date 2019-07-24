using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    class Race
    {
        private int uniqueID;
        private string name;
        private int baseSTR;
        private int baseINT;
        private int baseCON;
        private int isActive;

        public Race(int uniqueID, string name, int baseSTR, int baseINT, int baseCON, int isActive)
        {
            UniqueID = uniqueID;
            Name = name;
            BaseSTR = baseSTR;
            BaseINT = baseINT;
            BaseCON = baseCON;
            IsActive = isActive;
        }

        public int UniqueID { get => uniqueID; set => uniqueID = value; }
        public string Name { get => name; set => name = value; }
        public int BaseSTR { get => baseSTR; set => baseSTR = value; }
        public int BaseINT { get => baseINT; set => baseINT = value; }
        public int BaseCON { get => baseCON; set => baseCON = value; }
        public int IsActive { get => isActive; set => isActive = value; }
    }
}
