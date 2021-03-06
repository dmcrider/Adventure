﻿using Newtonsoft.Json.Linq;
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
        private const string LOG_NAME = "ControllerGame";
        public const int PLAYER = 1;
        public const int SHOP = 2;
        public const int SPECIAL = 3;
        public const string SHOP_GOLD = "100";
        public const int HP = 1;
        public const int MAGIC = 2;
        // Lists that the rest of the application can access
        public static List<Item> shopItems = new List<Item>();
        public static List<QuestLog> questLog = new List<QuestLog>();
        public static List<Quest> questLogList = new List<Quest>();
        public static ListView listViewCompletedQuests = new ListView();
        public static ListView listViewAcceptedQuests = new ListView();
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
            // Do nothing on instantiation for now
        }

        public void PopulateInitialData()
        {
            // Populate Player data
            if(Instances.Player != null)
            {
                // Access the Character Panel and the Inventory Panel
                Instances.FormMain.MainMenuStrip.Items["playerToolStripMenuItem"].Text = Instances.Player.Username;
                panelCharacter = (Panel)Instances.FormMain.Controls["panelCharacter"];
                panelInventory = (Panel)Instances.FormMain.Controls["panelInventory"];
                panelQuest = (Panel)Instances.FormMain.Controls["panelQuest"];
                panelGame = (Panel)Instances.FormMain.Controls["panelGame"];
                panelSpells = (Panel)Instances.FormMain.Controls["panelSpells"];

                ShowPanels();

                SetPlayerInfo();

                SetInventory();
            }
        }

        private void SetPlayerInfo()
        {
            LogWriter.Write(LOG_NAME, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.GamePlay, "Setting Player Info");
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
        }

        private void SetInventory()
        {
            LogWriter.Write(LOG_NAME, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.GamePlay, "Setting Player Inventory");
            // Show any items the character is holding
            int inventoryCount = 1;
            if (Inventory.InventoryList.Count > 0)
            {
                foreach (Inventory item in Inventory.InventoryList)
                {
                    if (item.IsUsing == 1)
                    {
                        // Determine which hand
                        if (item.Hand == 1)
                        {
                            // Left Hand
                            pboxLeft.Image = (Image)Properties.Resources.ResourceManager.GetObject(GetAssetName(item.UniqueID));
                            pboxLeft.Refresh();
                        }
                        else if (item.Hand == 2)
                        {
                            // Right hand
                            pboxRight.Image = (Image)Properties.Resources.ResourceManager.GetObject(GetAssetName(item.UniqueID));
                            pboxRight.Refresh();
                        }
                    }
                    else if (item.IsUsing == 0)
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

        /// <summary>
        /// Restore up to the maximum value of the character's HP or Magic
        /// </summary>
        /// <param name="current">The character's current value</param>
        /// <param name="max">The character's maximum value</param>
        /// <param name="healAmount">The amount to restore by</param>
        /// <returns></returns>
        public void Heal(int current, int max, int healAmount, int type)
        {
            string typeName = type == HP ? "HP" : "Magic";
            LogWriter.Write(LOG_NAME, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.GamePlay, $"Healing {typeName} for {healAmount} points");
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
            string typeName = type == HP ? "HP" : "Magic";
            LogWriter.Write(LOG_NAME, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.GamePlay, $"Damaging {typeName} for {damageAmount} points");
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

        

        public static void AddAcceptedQuest(Quest q, State state)
        {
            try
            {
                LogWriter.Write(LOG_NAME, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.GamePlay, "Player accepted Quest: " + q.Name);

                // Create a questlog entry
                QuestLog questLog = new QuestLog(-1,Instances.Character.UniqueID, q.UniqueID, state, 1);
                if (API.IsSuccess(API.CreateQuestLog(questLog)))
                {
                    string[] rowBuilder = { q.Name, q.UniqueID.ToString() };
                    listViewAcceptedQuests.Items.Add(new ListViewItem(rowBuilder));
                    listViewAcceptedQuests.Columns[0].Width = -1; // Resize

                    questLogList.Add(q);
                }
            }
            catch(Exception ex)
            {
                LogWriter.Write(LOG_NAME, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.GamePlay, ex.Message);
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
                LogWriter.Write(LOG_NAME, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Debug, "Loading Debug panel");
                Instances.PanelDev = new xDEV();
                panelGame.Controls.Add(Instances.PanelDev);
#endif

                // Only show these panels if applicable
                if (API.IsSuccess(API.LoadQuestLog(Instances.Character.UniqueID)))
                {
                    LogWriter.Write(LOG_NAME, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.GamePlay, "Loading QuestLog panel");
                    panelQuest.Visible = true;
                    PopulateQuestsPanel();
                }
                //else, no questlogs for this player

                if (API.IsSuccess(API.HasSpellbook(Instances.Character.UniqueID)))
                {
                    LogWriter.Write(LOG_NAME, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.GamePlay, "Loading Spellbook panel");
                    panelSpells.Visible = true;
                    PopulateSpellsPanel();
                }
                // else no spellbook for this player
            }
        }

        /// <summary>
        /// Populate a searchable list of Quests from the QuestLog
        /// </summary>
        private void ExtrapolateQuestList()
        {
            foreach(QuestLog ql in questLog)
            {
                questLogList.Add(Quest.Quests.Find(x => x.UniqueID == ql.QuestID));
            }
        }

        private void PopulateQuestsPanel()
        {
            LogWriter.Write(LOG_NAME, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.GamePlay, "Populating quests");
            ExtrapolateQuestList();
            Panel panelQuest = (Panel)Instances.FormMain.Controls["panelQuest"];
            TabControl tabQuests = (TabControl)panelQuest.Controls["tabQuests"];
            tabQuests.TabPages.Clear(); // delete default tabs that we don't want

            listViewCompletedQuests.View = View.Details;
            listViewCompletedQuests.Width = tabQuests.Width;
            listViewCompletedQuests.Height = tabQuests.Height;

            listViewAcceptedQuests.View = View.Details;
            listViewAcceptedQuests.Width = tabQuests.Width;
            listViewAcceptedQuests.Height = tabQuests.Height;

            listViewCompletedQuests.Click += ListViewComplete_Click;
            listViewAcceptedQuests.Click += ListViewAccepted_Click;


            listViewCompletedQuests.Columns.Add("Quest Name");
            listViewCompletedQuests.Columns.Add("QuestID").Width = 0;


            listViewAcceptedQuests.Columns.Add("Quest Name");
            listViewAcceptedQuests.Columns.Add("QuestID").Width = 0;

            // Create the tab pages
            TabPage activeQuest = new TabPage
            {
                Name = "active",
                Text = "Active",
                Width = tabQuests.Width
            };
            TabPage acceptedQuests = new TabPage
            {
                Name = "accepted",
                Text = "Accepted",
                Width = tabQuests.Width
            };
            TabPage completedQuests = new TabPage
            {
                Name = "completed",
                Text = "Completed",
                Width = tabQuests.Width
            };

            // Load Quests
            foreach(QuestLog log in questLog)
            {
                if (log.IsActive == 1)
                {
                    Quest tempQuest = Quest.Quests.Find(x => x.UniqueID == log.QuestID);
                    QuestReward tempReward = new QuestReward();
                    Item rewardItem = new Item();

                    if (log.StateID == State.IN_PROGRESS) // Only one active quest at a time
                    {
                        activeQuest.Controls.Add(SetActiveQuest(log));
                        AddActiveQuestButtons(activeQuest);
                    }
                    else if (log.StateID == State.ACCEPTED) // New quests not yet started
                    {
                        string[] rowBuilder = { tempQuest.Name, tempQuest.UniqueID.ToString() };

                        listViewAcceptedQuests.Items.Add(new ListViewItem(rowBuilder));
                        listViewAcceptedQuests.Columns[0].Width = -1;
                    }
                    else if(log.StateID == State.COMPLETE_NO_REWARD || log.StateID == State.COMPLETE_REWARD_AVAIL) // completed quests
                    {
                        tempReward = QuestReward.QuestRewards.Find(x => x.UniqueID == tempQuest.QuestRewardID);
                        rewardItem = Item.Items.Find(y => y.UniqueID == tempReward.ItemID);
                        string[] rowBuilder = {tempQuest.Name, tempQuest.UniqueID.ToString() };
                        ListViewItem row = new ListViewItem();

                        if(log.StateID == State.COMPLETE_REWARD_AVAIL)
                        {
                            row = new ListViewItem(rowBuilder)
                            {
                                Font = new Font(listViewCompletedQuests.Font, FontStyle.Bold)
                            };
                        }
                        else
                        {
                            row = new ListViewItem(rowBuilder);
                        }

                        listViewCompletedQuests.Items.Add(row);
                        listViewCompletedQuests.Columns[0].Width = -1;
                    }
                }
                
            }
            // Add the control to the tabpage
            acceptedQuests.Controls.Add(listViewAcceptedQuests);
            completedQuests.Controls.Add(listViewCompletedQuests);

            // Add the tab pages to the tab control
            tabQuests.TabPages.Add(activeQuest);
            tabQuests.TabPages.Add(acceptedQuests);
            tabQuests.TabPages.Add(completedQuests);
        }

        private void AddActiveQuestButtons(TabPage active)
        {
            Point location = new Point(active.Controls["questCtrl"].Location.X, active.Controls["questCtrl"].Location.Y + active.Controls["questCtrl"].Height);
            Button btnDetails = new Button
            {
                Name = "btnDetails",
                Text = "Show Details",
                Location = location,
                Height = 30,
                Width = 125
            };

            btnDetails.Click += BtnDetails_Click;

            active.Controls.Add(btnDetails);
        }

        private void BtnDetails_Click(object sender, EventArgs e)
        {
            Panel panelQuest = (Panel)Instances.FormMain.Controls["panelQuest"];
            TabControl tabQuests = (TabControl)panelQuest.Controls["tabQuests"];
            TabPage activePage = (TabPage)tabQuests.Controls["active"];
            ControlActiveQuest ctrlQuest = (ControlActiveQuest)activePage.Controls["questCtrl"];

            // Valid responses are OK and No
            DialogResult makeActive = new FormQuestDetail(ctrlQuest.Quest).ShowDialog();

            if(makeActive == DialogResult.OK)
            {
                // Reward was claimed, quest set to complete
                // Move it to the correct tab
                listViewCompletedQuests.Items.Add(new ListViewItem(new string[] { ctrlQuest.Quest.Name, ctrlQuest.Quest.UniqueID.ToString() }));
                listViewCompletedQuests.Columns[0].Width = -1; // Resize the columns just in case

                activePage.Controls.Clear(); // Remove the active quest and the button
                tabQuests.SelectedTab = tabQuests.TabPages[1]; // Select the accepted quests page
            }
        }

        private ControlActiveQuest SetActiveQuest(QuestLog log)
        {
            Quest tempQuest = Quest.Quests.Find(x => x.UniqueID == log.QuestID);
            QuestReward tempReward = new QuestReward();
            Item rewardItem = new Item();

            ControlActiveQuest ctrlActive = new ControlActiveQuest
            {
                Quest = tempQuest,
                Name = "questCtrl"
            };

            ctrlActive.Controls["lblQuestName"].Text = tempQuest.Name;
            ctrlActive.Controls["lblDescription"].Text = tempQuest.Description;

            // Get the reward(s)
            tempReward = QuestReward.QuestRewards.Find(y => y.UniqueID == tempQuest.QuestRewardID);
            if (tempReward.IsItem == 1)
            {
                // Show the item
                rewardItem = Item.Items.Find(z => z.UniqueID == tempReward.ItemID);
                ctrlActive.Controls["lblRewardItem"].Text = rewardItem.DisplayName;
            }
            else
            {
                // Hide item fields since we won't have anything to show
                ctrlActive.Controls["lblReward"].Visible = false;
                ctrlActive.Controls["lblRewardItem"].Visible = false;
            }

            // Add the gold and exp
            ctrlActive.Controls["lblGoldReward"].Text = tempReward.Gold.ToString();
            ctrlActive.Controls["lblEXPValue"].Text = tempQuest.ExpAwarded.ToString();

            return ctrlActive;
        }

        private void ListViewAccepted_Click(object sender, EventArgs e)
        {
            try
            {
                ListView listView = (ListView)sender;
                ListViewItem item = listView.SelectedItems[0];
                string questIDstring = item.SubItems[1].Text;
                int.TryParse(questIDstring, out int questID);
                Quest quest = Quest.Quests.Find(x => x.UniqueID == questID);

                LogWriter.Write(LOG_NAME, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Info, "Displaying Quest Details for " + quest.Name);

                DialogResult makeActive = new FormQuestDetail(quest).ShowDialog();

                if (makeActive == DialogResult.Yes)
                {
                    LogWriter.Write(LOG_NAME, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.GamePlay, $"Setting Quest {quest.Name} as the active Quest.");

                    QuestLog ql = quest.GetQuestLog();
                    ql.StateID = State.ACCEPTED;

                    if (API.IsSuccess(API.UpdateQuestLog(ql)))
                    {
                        LogWriter.Write(LOG_NAME, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.GamePlay, "Quest successfully activated.");
                        // Remove quest from acceptedList
                        listView.Items.Remove(item);

                        Panel panelQuest = (Panel)Instances.FormMain.Controls["panelQuest"];
                        TabControl tabQuests = (TabControl)panelQuest.Controls["tabQuests"];
                        tabQuests.TabPages[0].Controls.Clear(); // Remove the pervious quest, if any
                        tabQuests.TabPages[0].Controls.Add(SetActiveQuest(ql)); // Set the new quest

                        // Show the Active Quest tab
                        tabQuests.SelectedTab = tabQuests.TabPages[0];
                        AddActiveQuestButtons(tabQuests.TabPages[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                LogWriter.Write(LOG_NAME, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, ex.Message);
            }
        }

        private void ListViewComplete_Click(object sender, EventArgs e)
        {
            try
            {
                ListView listView = (ListView)sender;
                string questIDstring = listView.SelectedItems[0].SubItems[1].Text;
                int.TryParse(questIDstring, out int questID);
                Quest quest = Quest.Quests.Find(x => x.UniqueID == questID);

                LogWriter.Write(LOG_NAME, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Info, "Displaying Quest Details for " + quest.Name);

                DialogResult makeActive = new FormQuestDetail(quest).ShowDialog();

                if (makeActive == DialogResult.Yes)
                {
                    LogWriter.Write(LOG_NAME, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.GamePlay, $"Setting Quest {quest.Name} as the active Quest.");

                    QuestLog ql = quest.GetQuestLog();
                    ql.StateID = State.ACCEPTED;

                    if (API.IsSuccess(API.UpdateQuestLog(ql)))
                    {
                        LogWriter.Write(LOG_NAME, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.GamePlay, "Quest successfully activated.");
                        Panel panelQuest = (Panel)Instances.FormMain.Controls["panelQuest"];
                        TabControl tabQuests = (TabControl)panelQuest.Controls["tabQuests"];
                        tabQuests.TabPages[0].Controls.Clear(); // Remove the pervious quest, if any
                        tabQuests.TabPages[0].Controls.Add(SetActiveQuest(ql)); // Set the new quest

                        // Show the Active Quest tab
                        tabQuests.SelectedTab = tabQuests.TabPages[0];
                    }
                }
            }
            catch (Exception ex)
            {
                LogWriter.Write(LOG_NAME, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, ex.Message);
            }
        }

        private void PopulateSpellsPanel()
        {
            // TODO: Add method for PopulateSpellsPanel
        }

        /// <summary>
        /// Get the name of the image for the item
        /// </summary>
        /// <param name="itemID">ID of the item we need an image for</param>
        /// <returns>Path to image</returns>
        private string GetAssetName(int itemID)
        {
            try
            {
                string assetName = "Item_";

                foreach (Item item in Item.Items)
                {
                    if (item.UniqueID == itemID)
                    {
                        assetName += item.AssetName;
                        return assetName;
                    }
                }

                return assetName;
            }
            catch(Exception ex)
            {
                LogWriter.Write(LOG_NAME, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Critical, ex.Message);
                return null;
            }
        }
    }
}
