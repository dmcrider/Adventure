using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    class Character
    {
        public string name;
        public string race;
        public string classType;

        public int str;
        public int intel;
        public int con;

        public Character(string name, string race, string classType, int str, int intel, int con)
        {
            this.name = name;
            this.race = race;
            this.classType = classType;
            this.str = str;
            this.intel = intel;
            this.con = con;
        }
    }
}
