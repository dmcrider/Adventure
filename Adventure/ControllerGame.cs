using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

                /*
                if(currentCharacter.LeftHand != 0)
                {
                    LoadImage(currentCharacter.LeftHand, pboxLeft, 'a');
                    pboxLeft.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(currentCharacter.LeftItem.AssetName);
                    pboxLeft.Update();
                }

                if (currentCharacter.RightHand != 0)
                {
                    LoadImage(currentCharacter.RightHand, pboxRight, 'b');
                    pboxRight.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(currentCharacter.RightItem.AssetName);
                    pboxRight.Update();
                }
                */
            }
        }
        /*
        public void LoadImage(int imageIndex, PictureBox pbox, Char hand)
        {
            using (WebClient wc = new WebClient())
            {
                string response = wc.DownloadString(Properties.Settings.Default.APIBaseAddress + Properties.Settings.Default.ItemReadAPI);

                JObject convertedJSON = JObject.Parse(response);

                foreach (var item in convertedJSON)
                {
                    foreach (JObject obj in item.Value)
                    {
                        // Create an item object so we can reference it later if needed
                        Item tmpItem = new Item((int)obj.GetValue("UniqueID"),(string)obj.GetValue("DisplayName"),(string)obj.GetValue("AssetName"),(int)obj.GetValue("Hand"),(int)obj.GetValue("AttackBonus"), (int)obj.GetValue("DefenseBonus"), (int)obj.GetValue("HPHealed"), (int)obj.GetValue("MagicHealed"), (int)obj.GetValue("IsActive"));
                        if(hand == 'a' && imageIndex == tmpItem.UniqueID)
                        {
                            currentCharacter.LeftItem = tmpItem;
                            return;
                        }else if(hand == 'b' && imageIndex == tmpItem.UniqueID)
                        {
                            currentCharacter.RightItem = tmpItem;
                            return;
                        }
                    }
                }
            }
        }*/
    }
}
