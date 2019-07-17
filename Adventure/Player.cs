using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public class Player
    {
        public string username;
        public Character character;
        public int uniqueID;

        public Player(string username, Character character, int id)
        {
            this.username = username;
            this.character = character;
            this.uniqueID = id;
        }

        public Player(string username, int id)
        {
            this.username = username;
            this.uniqueID = id;
        }
    }
}
