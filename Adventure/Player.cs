using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    class Player
    {
        public string username;
        public Character character;

        public Player(string username, Character character)
        {
            this.username = username;
            this.character = character;
        }
    }
}
