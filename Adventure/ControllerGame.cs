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
        private List<Inventory> inventory;

        public ControllerGame(FormMain m, Player player)
        {
            this.currentPlayer = player;
            currentCharacter = player.character;
            frmMain = m;
            try
            {
                inventory = API.LoadInventory(player.character.UniqueID);
            }
            catch (Exception e)
            {
                LogWriter.Write("ControllerGame Constructor | Could not load inventory:\n\t" + e);
            }
            
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

                // Show any items the character is holding
                if(inventory.Count > 0)
                {
                    foreach(Inventory item in inventory)
                    {
                        if (item.IsUsing == 1)
                        {
                            // Determine which hand
                            if(item.Hand == 1)
                            {
                                // Left Hand
                                pboxLeft.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(GetAssetName(item.UniqueID));
                                pboxLeft.Update();
                            }
                            else if(item.Hand == 2)
                            {
                                // Right hand
                                pboxRight.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(GetAssetName(item.UniqueID));
                                pboxRight.Update();
                            }
                        }
                        else if(item.IsUsing == 0)
                        {
                            // Add the item to the inventory panel
                            
                        }
                    }
                }
            }
        }

        private string GetAssetName(int itemID)
        {
            string assetName = "item_";

            foreach(Item item in API.itemsList)
            {
                if(item.UniqueID == itemID)
                {
                    assetName += item.AssetName;
                    return assetName;
                }
            }

            return assetName;
        }
    }
}
