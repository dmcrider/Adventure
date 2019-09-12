using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;

namespace Adventure
{
    public class GameController
    {
        // Constants
        private const int MAX_INVENTORY_SIZE = 10;
        public const int PLAYER = 1;
        public const int SHOP = 2;
        public const int SPECIAL = 3;
        public const string SHOP_GOLD = "100";
        // Lists that the rest of the application can access
        public static List<Inventory> inventoryList = new List<Inventory>();
        public static List<Item> shopItems = new List<Item>();
        // Private variables
        private Player currentPlayer;
        private Character currentCharacter;
        private FormMain frmMain;
        private PictureBox pboxLeft;
        private PictureBox pboxRight;
        // Panels
        private Panel panelCharacter;
        private Panel panelInventory;
        private Panel panelQuest;
        private Panel panelGame;
        private Panel panelSpells;

        public GameController(FormMain m, Player player)
        {
            this.currentPlayer = player;
            currentCharacter = player.character;
            frmMain = m;
            API.LoadInventory(player.character.UniqueID);
        }

        public void PopulateInitialData()
        {
            // Populate Player data
            if(currentPlayer != null)
            {
                // Access the Character Panel and the Inventory Panel
                frmMain.MainMenuStrip.Items["playerToolStripMenuItem"].Text = currentPlayer.username;
                panelCharacter = (Panel)frmMain.Controls["panelCharacter"];
                panelInventory = (Panel)frmMain.Controls["panelInventory"];
                panelQuest = (Panel)frmMain.Controls["panelQuest"];
                panelGame = (Panel)frmMain.Controls["panelGame"];
                panelSpells = (Panel)frmMain.Controls["panelSpells"];

                ShowPanels();

                // Set the Character's name
                panelCharacter.Controls["lblCharacterName"].Text = currentCharacter.Name;

                // Set their current HP and Magic levels
                panelCharacter.Controls["lblHPValue"].Text = $"{currentCharacter.CurrentHP}/{currentCharacter.MaxHP}";
                panelCharacter.Controls["lblMagicValue"].Text = $"{currentCharacter.CurrentMagic}/{currentCharacter.MaxMagic}";

                // Set their STR, INT, and CON levels
                panelCharacter.Controls["txtSTRValue"].Text = currentCharacter.Strength.ToString();
                panelCharacter.Controls["txtINTValue"].Text = currentCharacter.Intelligence.ToString();
                panelCharacter.Controls["txtCONValue"].Text = currentCharacter.Constitution.ToString();

                // Set their gold
                panelCharacter.Controls["txtInventoryGold"].Text = currentCharacter.Gold.ToString();

                pboxLeft = (PictureBox)panelCharacter.Controls["picLeftHand"];
                pboxRight = (PictureBox)panelCharacter.Controls["picRightHand"];

                // Show any items the character is holding
                int inventoryCount = 1;
                if(inventoryList.Count > 0)
                {
                    foreach(Inventory item in inventoryList)
                    {
                        if (item.IsUsing == 1)
                        {
                            // Determine which hand
                            if(item.Hand == 1)
                            {
                                // Left Hand
                                pboxLeft.Image = (Image)Properties.Resources.ResourceManager.GetObject(GetAssetName(item.UniqueID));
                                pboxLeft.Refresh();
                            }
                            else if(item.Hand == 2)
                            {
                                // Right hand
                                pboxRight.Image = (Image)Properties.Resources.ResourceManager.GetObject(GetAssetName(item.UniqueID));
                                pboxRight.Refresh();
                            }
                        }
                        else if(item.IsUsing == 0)
                        {
                            // Add the item to the inventory panel
                            PictureBox tempPicBox = (PictureBox)panelInventory.Controls["picboxInventory" + inventoryCount];
                            tempPicBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(GetAssetName(item.ItemID));
                            tempPicBox.Refresh();

                            inventoryCount++;
                        }
                    }
                }
            }
        }

        public static int Heal(int current, int max, int healAmount)
        {
            current += healAmount;

            if (current > max)
            {
                return max;
            }
            else
            {
                return current;
            }
        }



        /// <summary>
        /// Determines if the Character has at least one empty slot in their inventory
        /// </summary>
        /// <returns>True if at least one slot is available, false otherwise</returns>
        public static bool HasInventorySpace()
        {
            try
            {
                LogWriter.Write("ControllerGame", MethodBase.GetCurrentMethod().Name, "Current inventory size: " + inventoryList.Count);

                if (inventoryList.Count < MAX_INVENTORY_SIZE)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogWriter.Write("ControllerGame", MethodBase.GetCurrentMethod().Name, "Error checking inventory space: " + ex);
                return false;
            }
        }

        /// <summary>
        /// Display relevant Panels
        /// </summary>
        private void ShowPanels()
        {
            if (currentCharacter != null)
            {
                // Always show these panels
                panelGame.Visible = true;
                panelCharacter.Visible = true;
                panelInventory.Visible = true;

                // Only show these panels if applicable
                if (API.HasQuestLog(currentCharacter.UniqueID))
                {
                    panelQuest.Visible = true;
                }

                if (API.HasSpellbook(currentCharacter.UniqueID))
                {
                    panelSpells.Visible = true;
                }
            }
        }

        /// <summary>
        /// Get the name of the image for the item
        /// </summary>
        /// <param name="itemID">ID of the item we need an image for</param>
        /// <returns>Path to image</returns>
        private string GetAssetName(int itemID)
        {
            string assetName = "Item_";

            foreach (Item item in API.itemsList)
            {
                if (item.UniqueID == itemID)
                {
                    assetName += item.AssetName;
                    return assetName;
                }
            }

            return assetName;
        }
    }
}
