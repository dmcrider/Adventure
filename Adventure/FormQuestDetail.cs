using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adventure
{
    public partial class FormQuestDetail : Form
    {
        private bool IsNewQuest;
        private readonly Quest CurrentQuest;
        private QuestReward CurrentReward;
        private Item CurrentItem;

        public FormQuestDetail()
        {
            InitializeComponent();
        }

        public FormQuestDetail(Quest q) : this()
        {
            CurrentQuest = q;
            PopulateValues();
        }

        private void FormQuestDetail_Load(object sender, EventArgs e)
        {
            // Center the form
            this.CenterToScreen();
        }

        private void PopulateValues()
        {
            lblQuestName.Text = CurrentQuest.Name;
            lblDescription.Text = CurrentQuest.Description;

            // Check if this is a new quest
            CheckForNewQuest();

            SetButtons();

            PopulateDetails();
        }

        private void SetButtons()
        {
            if (IsNewQuest)
            {
                btnMakeActive.Text = "Accept Quest";
                btnClose.Text = "Reject Quest";
                btnReward.Visible = false;
            }
            else
            {
                if(CurrentQuest.GetQuestLog().StateID == State.COMPLETE_REWARD_AVAIL)
                {
                    btnMakeActive.Visible = false;
                    btnClose.Text = "Close";
                    btnReward.Visible = true;
                }
                else
                {
                    btnMakeActive.Text = "Make Active";
                    btnClose.Text = "Close";
                    btnReward.Visible = false;
                }
            }

            
        }

        private void PopulateDetails()
        {
            CurrentReward = API.questrewardsList.Find(x => x.UniqueID == CurrentQuest.QuestRewardID);
            lblEXPValue.Text = CurrentQuest.ExpAwarded.ToString();

            if (CurrentReward != null)
            {
                lblGoldValue.Text = CurrentReward.Gold.ToString();

                if (CurrentReward.ItemID != 0)
                {
                    CurrentItem = API.itemsList.Find(x => x.UniqueID == CurrentReward.ItemID);
                    lblRewardValue.Text = CurrentItem.DisplayName;
                }
                else
                {
                    lblRewardValue.Text = "None";
                }
            }
            else
            {
                lblGoldValue.Text = "0";
            }
        }

        private void CheckForNewQuest()
        {
            // If the questLogList does NOT contain the Quest,
            // then the parameter is a new quest and
            // IsNewQuest should be set to TRUE
            IsNewQuest = !GameController.questLogList.Contains(CurrentQuest);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnMakeActive_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void BtnReward_Click(object sender, EventArgs e)
        {
            if(ClaimRewardGold() && ClaimRewardEXP())
            {
                if(CurrentReward.IsItem == 1)
                {
                    if (ClaimRewardItem())
                    {
                        // Update the questlog to show to reward has been claimed
                        CurrentQuest.GetQuestLog().StateID = State.COMPLETE_NO_REWARD;
                        API.UpdateQuestLog(CurrentQuest.GetQuestLog());
                    }
                    else
                    {
                        // Item not claimed, but don't claim gold/exp again
                        CurrentQuest.GetQuestLog().StateID = State.COMPLETE_ONLY_ITEM;
                        API.UpdateQuestLog(CurrentQuest.GetQuestLog());
                    }
                }
                else
                {
                    // No item to claim, only gold/exp
                    CurrentQuest.GetQuestLog().StateID = State.COMPLETE_NO_REWARD;
                    API.UpdateQuestLog(CurrentQuest.GetQuestLog());
                }
            }
            // else, do nothing - gold and exp should never throw an error
        }

        private bool ClaimRewardGold()
        {
            Instances.Character.Gold += CurrentReward.Gold;
            return true;
        }

        private bool ClaimRewardEXP()
        {
            Instances.Character.ExpPoints += CurrentQuest.ExpAwarded;
            return true;
        }

        private bool ClaimRewardItem()
        {
            APIStatusCode code = API.AddInventoryItem(Instances.Character, CurrentReward.ItemID);
            string message = "Reward(s) ";
            bool status = false;

            if (code == APIStatusCode.SECONDARY_SUCCESS)
            {
                // Item Succesfully added AND inventory has been refreshed
                message += "successfully added to inventory.";
                status = true;
            }
            else if(code == APIStatusCode.SECONDARY_FAIL)
            {
                // Inventory was not refreshed from database
                message += " were added, but there was an error saving. Please save the game or risk losing your reward(s).";
                status = true;
            }
            else if(code == APIStatusCode.OUT_OF_SPACE)
            {
                // Something needs to be deleted
                // User was alerted, so show inventory manage form
                Instances.FormManageInventory.ShowDialog();
            }
            else
            {
                // Something went wrong adding item to inventory at the database transaction
                message += "not added. Please try again later.";
            }

            MessageBox.Show(message, "Quest Complete");
            return status;
        }
    }
}
