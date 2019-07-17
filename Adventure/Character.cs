using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public class Character
    {
        public string name;
        public string race;
        public string classType;

        private int str;
        private int intel;
        private int con;
        public int maxHP;
        public int currentHP;

        public int Str { get => str; set => str = value; }
        public int Intel { get => intel; set => intel = value; }
        public int Con { get => con; set => con = value; }

        public Character()
        {
            // Set the defaults
            Str = 10;
            Intel = 10;
            Con = 10;
            maxHP = 20;
            currentHP = maxHP;
            name = "test";
            race = "test";
            classType = "test";
        }

        public Character(string name, string race, string classType)
        {
            // Set the defaults
            Str = 10;
            Intel = 10;
            Con = 10;
            maxHP = 20;
            currentHP = maxHP;

            // Set the params
            this.name = name;
            this.race = race;
            this.classType = classType;
        }

        public Character(string name, string race, string classType, int str, int intel, int con)
        {
            this.name = name;
            this.race = race;
            this.classType = classType;
            this.Str = str;
            this.Intel = intel;
            this.Con = con;
        }

        public void TakeHPDamage(int dmg)
        {
            this.currentHP -= dmg;
        }

        public void HealHP(int amt)
        {
            this.currentHP += amt;
        }
    }
}
