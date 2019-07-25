using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public class Npc
    {
        private int uniqueID;
        private string name;

        public Npc(int uniqueID, string name)
        {
            UniqueID = uniqueID;
            Name = name;
        }

        public int UniqueID { get => uniqueID; set => uniqueID = value; }
        public string Name { get => name; set => name = value; }
    }
}
