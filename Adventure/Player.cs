using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public class Player
    {
        public Player(string username, Character character, int id)
        {
            Username = username;
            LinkedCharacter = character;
            UniqueID = id;
        }
        public Player(string username, int id)
        {
            Username = username;
            UniqueID = id;
        }
        public Player(string username, string password)
        {
            Username = username;
            Password = password;
        }

        #region Instance Variables
        public string Username { get; set; }
        public string Password { get; set; }
        public Character LinkedCharacter { get; set; }
        public int UniqueID { get; set; }
        #endregion

        public bool HasID()
        {
            return UniqueID != 0;
        }
    }
}
