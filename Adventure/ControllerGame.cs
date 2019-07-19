using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adventure
{
    public class ControllerGame
    {
        private Player player;
        private Character character;
        public ControllerGame(Player player, Character character)
        {
            this.player = player;
            this.character = character;
        }

        public void PopulateInitialData(ToolStripMenuItem menuName, Panel charaterPanel)
        {
            // Populate Player data
            if(player != null)
            {
                menuName.Text = player.username;

                // Populate Character data
                //if (!Properties.Settings.Default[$"Character{player.uniqueID}"].Equals(string.Empty))
                //{
                //    // Get the character
                //    //character = Properties.Settings.Default[$"Character{player.uniqueID}"];
                //}
            }
        }
    }
}
