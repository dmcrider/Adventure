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
        private Player currentPlayer;
        private Character currentCharacter;
        private FormMain frmMain;
        private PictureBox pboxLeft;
        private PictureBox pboxRight;
        public ControllerGame(FormMain m, Player player)
        {
            this.currentPlayer = player;
            currentCharacter = player.character;
            frmMain = m;
        }

        public void PopulateInitialData()
        {
            // Populate Player data
            if(currentPlayer != null)
            {
                frmMain.MainMenuStrip.Items["playerToolStripMenuItem"].Text = currentPlayer.username;
                Panel panelCharacter = (Panel)frmMain.Controls["panelCharacter"];

                panelCharacter.Controls["lblCharacterName"].Text = currentCharacter.Name;

                panelCharacter.Controls["lblHPValue"].Text = $"{currentCharacter.CurrentHP}/{currentCharacter.MaxHP}";
                panelCharacter.Controls["lblMagicValue"].Text = $"{currentCharacter.CurrentMagic}/{currentCharacter.MaxMagic}";

                panelCharacter.Controls["txtSTRValue"].Text = currentCharacter.Strength.ToString();
                panelCharacter.Controls["txtINTValue"].Text = currentCharacter.Intelligence.ToString();
                panelCharacter.Controls["txtCONValue"].Text = currentCharacter.Constitution.ToString();

                pboxLeft = (PictureBox)panelCharacter.Controls["picLeftHand"];
                pboxRight = (PictureBox)panelCharacter.Controls["picRightHand"];

                if(currentCharacter.LeftHand == "Shield")
                {
                    pboxLeft.Image = Properties.Resources.Item_Shield;
                    pboxLeft.Update();
                }
            }
        }
    }
}
