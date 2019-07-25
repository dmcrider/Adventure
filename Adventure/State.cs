using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public class State
    {
        private int uniqueID;
        private string name;

        public State(int uniqueID, string name)
        {
            UniqueID = uniqueID;
            Name = name;
        }

        public int UniqueID { get => uniqueID; set => uniqueID = value; }
        public string Name { get => name; set => name = value; }
    }
}
