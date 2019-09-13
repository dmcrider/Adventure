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
        public const int HP = 1;
        public const int MAGIC = 2;
        // Lists that the rest of the application can access
        public static List<Inventory> inventoryList = new List<Inventory>();
        public static List<Item> shopItems = new List<Item>();
        public static List<QuestLog> questLog = new List<QuestLog>();
        // Private variables
        private PictureBox pboxLeft;
        private PictureBox pboxRight;
        // Panels
        private Panel panelCharacter;
        private Panel panelInventory;
        private Panel panelQuest;
        private Panel panelGame;
        private Panel panelSpells;

        public GameController()
        {
            
        }

        public void PopulateInitialData()
        {
            // Populate Player data
            if(Instances.Player != null)
            {
                // Access the Character Panel and the Inventory Panel
                Instances.FormMain.MainMenuStrip.Items["playerToolStripMenuItem"].Text = Instances.Player.username;
                panelCharacter = (Panel)Instances.FormMain.Controls["panelCharacter"];
                panelInventory = (Panel)Instances.FormMain.Controls["panelInventory"];
                panelQuest = (Panel)Instances.FormMain.Controls["panelQuest"];
                panelGame = (Panel)Instances.FormMain.Controls["panelGame"];
                panelSpells = (Panel)Instances.FormMain.Controls["panelSpells"];

                ShowPanels();

                // Set the Character's name
                panelCharacter.Controls["lblCharacterName"].Text = Instances.Character.Name;

                // Set their current HP and Magic levels
                panelCharacter.Controls["lblHPValue"].Text = $"{Instances.Character.CurrentHP}/{Instances.Character.MaxHP}";
                panelCharacter.Controls["lblMagicValue"].Text = $"{Instances.Character.CurrentMagic}/{Instances.Character.MaxMagic}";

                // Set their STR, INT, and CON levels
                panelCharacter.Controls["txtSTRValue"].Text = Instances.Character.Strength.ToString();
                panelCharacter.Controls["txtINTValue"].Text = Instances.Character.Intelligence.ToString();
                panelCharacter.Controls["txtCONValue"].Text = Instances.Character.Constitution.ToString();

                // Set their gold
                panelCharacter.Controls["txtInventoryGold"].Text = Instances.Character.Gold.ToString();

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

        /// <summary>
        /// Restore up to the maximum value of the character's HP or Magic
        /// </summary>
        /// <param name="current">The character's current value</param>
        /// <param name="max">The character's maximum value</param>
        /// <param name="healAmount">The amount to restore by</param>
        /// <returns></returns>
        public void Heal(int current, int max, int healAmount, int type)
        {
            Label lblValue;
            current += healAmount;

            if (current > max)
            {
                current = max;
            }

            if (type == HP)
            {
                lblValue = (Label)panelCharacter.Controls["lblHPValue"];
                lblValue.Text = current.ToString();
                Instances.Character.CurrentHP = current;
            }
            else if(type == MAGIC)
            {
                lblValue = (Label)panelCharacter.Controls["lblMagicValue"];
                lblValue.Text = current.ToString();
                Instances.Character.CurrentMagic = current;
            }
        }

        /// <summary>
        /// Reduce the amount of the character's HP or Magic
        /// </summary>
        /// <param name="current">The character's current value</param>
        /// <param name="damageAmount">The amount to reduce by</param>
        public void Damage(int current, int damageAmount, int type)
        {
            Label lblValue;
            current -= damageAmount;

            if (current <= 0)
            {
                current = 0; // Player is dead
            }

            if (type == HP)
            {
                // Update the values
                lblValue = (Label)panelCharacter.Controls["lblHPValue"];
                lblValue.Text = $"{current.ToString()}/{Instances.Character.MaxHP.ToString()}";
                Instances.Character.CurrentHP = current;

                // Update the box
                Panel panelHP = (Panel)panelCharacter.Controls["panelHP"];
                double maxWidth = double.Parse(panelHP.Tag.ToString());

                double percentReduce = current / (double)Instances.Character.MaxHP;
                double reduceWidthBy = panelHP.Width - (maxWidth * percentReduce);
                panelHP.Width -= Convert.ToInt32(reduceWidthBy);
            }
            else if (type == MAGIC)
            {
                // Update the values
                lblValue = (Label)panelCharacter.Controls["lblMagicValue"];
                lblValue.Text = $"{current.ToString()}/{Instances.Character.MaxMagic.ToString()}";
                Instances.Character.CurrentMagic = current;

                // Update the box
                Panel panelMagic = (Panel)panelCharacter.Controls["panelMagic"];
                double maxWidth = double.Parse(panelMagic.Tag.ToString());

                double percentReduce = current / (double)Instances.Character.MaxMagic;
                double reduceWidthBy = panelMagic.Width - (maxWidth * percentReduce);
                panelMagic.Width -= Convert.ToInt32(reduceWidthBy);
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
            if (Instances.Character != null)
            {
                // Always show these panels
                panelGame.Visible = true;
                panelCharacter.Visible = true;
                panelInventory.Visible = true;

#if DEBUG
                Instances.PanelDev = new xDEV();
                panelGame.Controls.Add(Instances.PanelDev);
#endif

                // Only show these panels if applicable
                if (API.LoadQuestLog(Instances.Character.UniqueID))
                {
                    panelQuest.Visible = true;
                    PopulateQuestsPanel();
                }
                //else, no questlogs for this player

                if (API.HasSpellbook(Instances.Character.UniqueID))
                {
                    panelSpells.Visible = true;
                    PopulateSpellsPanel();
                }
                // else no spellbook for this player
            }
        }

        private void PopulateQuestsPanel()
        {
            TabControl tabQuests = (TabControl)Instances.FormMain.Controls["tabQuests"];
            ListView listViewComplete = new ListView();
            ListView listViewActive = new ListView();

            listViewComplete.Columns.Add("QuestID").Width = 0;
            listViewComplete.Columns.Add("Quest Name");
            listViewComplete.Columns.Add("Description");
            listViewComplete.Columns.Add("Reward");
            listViewComplete.Columns.Add("Gold");

            listViewActive.Columns.Add("QuestID").Width = 0;
            listViewActive.Columns.Add("Quest Name");
            listViewActive.Columns.Add("Description");
            listViewActive.Columns.Add("Reward");
            listViewActive.Columns.Add("Gold");

            // Create the tab pages
            TabPage currentQuest = new TabPage
            {
                Name = "current",
                Text = "Current"
            };
            TabPage activeQuests = new TabPage
            {
                Name = "active",
                Text = "Active"
            };
            TabPage completedQuests = new TabPage
            {
                Name = "completed",
                Text = "Completed"
            };

            // Load Quests
            foreach(QuestLog log in questLog)
            {
                if (log.IsActive == 1)
                {
                    Quest tempQuest = API.questsList.Find(x => x.UniqueID == log.QuestID);
                    QuestReward tempReward = new QuestReward();
                    Item rewardItem = new Item();

                    if (log.StateID == State.IN_PROGRESS) // Only one active quest at a time
                    {
                        ControlActiveQuest ctrlActive = new ControlActiveQuest();
                        ctrlActive.Controls["lblQuestName"].Text = tempQuest.Name;
                        ctrlActive.Controls["txtDescription"].Text = tempQuest.Description;

                        // Get the reward(s)
                        tempReward = API.questrewardsList.Find(y => y.UniqueID == tempQuest.QuestRewardID);
                        if (tempReward.IsItem == 1)
                        {
                            // Show the item
                            rewardItem = API.itemsList.Find(z => z.UniqueID == tempReward.ItemID);
                            ctrlActive.Controls["txtRewardItem"].Text = rewardItem.DisplayName;
                        }
                        else
                        {
                            // Hide item fields since we won't have anything to show
                            ctrlActive.Controls["lblReward"].Visible = false;
                            ctrlActive.Controls["txtRewardItem"].Visible = false;
                        }

                        // Add the gold
                        ctrlActive.Controls["txtGoldReward"].Text = tempReward.Gold.ToString();

                        // Add the control to the tabpage
                        currentQuest.Controls.Add(ctrlActive);
                    }
                    else if (log.StateID == State.NEW) // New quests not yet started
                    {
                        tempReward = API.questrewardsList.Find(x => x.UniqueID == tempQuest.QuestRewardID);
                        rewardItem = API.itemsList.Find(y => y.UniqueID == tempReward.ItemID);
                        string[] rowBuilder = { tempQuest.UniqueID.ToString(), tempQuest.Name, tempQuest.Description, rewardItem.DisplayName, tempReward.Gold.ToString() };
                        ListViewItem row = new ListViewItem(rowBuilder);
                        listViewActive.Items.Add(row);

                        completedQuests.Controls.Add(listViewActive);
                    }
                    else if(log.StateID == State.COMPLETE_NO_REWARD || log.StateID == State.COMPLETE_REWARD_AVAIL) // completed quests
                    {
                        tempReward = API.questrewardsList.Find(x => x.UniqueID == tempQuest.QuestRewardID);
                        rewardItem = API.itemsList.Find(y => y.UniqueID == tempReward.ItemID);
                        string[] rowBuilder = {tempQuest.UniqueID.ToString(), tempQuest.Name, tempQuest.Description, rewardItem.DisplayName, tempReward.Gold.ToString()};
                        ListViewItem row = new ListViewItem();
                        if(log.StateID == State.COMPLETE_REWARD_AVAIL)
                        {
                            row = new ListViewItem(rowBuilder)
                            {
                                Font = new Font(listViewComplete.Font, FontStyle.Bold)
                            };
                        }
                        else
                        {
                            row = new ListViewItem(rowBuilder);
                        }
                        listViewComplete.Items.Add(row);

                        completedQuests.Controls.Add(listViewComplete);
                    }
                }
                
            }

            // Add the tab pages to the tab control
            tabQuests.TabPages.Add(currentQuest);
            tabQuests.TabPages.Add(activeQuests);
            tabQuests.TabPages.Add(completedQuests);
        }

        private void PopulateSpellsPanel()
        {

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
