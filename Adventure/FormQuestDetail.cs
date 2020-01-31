using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adventure
{
    public partial class FormQuestDetail : Form
    {
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

            SetButtons();

            PopulateDetails();
        }

        private void SetButtons()
        {
            State state = CurrentQuest.GetQuestLog().StateID;
            switch (state)
            {
                case State.NEW:
                    btnMakeActive.Text = "Accept Quest";
                    btnReward.Visible = false;
                    btnClose.Text = "Reject Quest";
                    break;
                case State.CAN_COMPLETE:
                    btnMakeActive.Visible = false;
                    btnReward.Visible = true;
                    btnClose.Text = "Close";
                    break;
                case State.ACCEPTED:
                    btnMakeActive.Text = "Make Active";
                    btnReward.Visible = false;
                    btnClose.Text = "Close";
                    break;
                default:
                    btnMakeActive.Visible = false;
                    btnReward.Visible = false;
                    btnClose.Text = "Close";
                    break;
            }
        }

        private void PopulateDetails()
        {
            CurrentReward = QuestReward.QuestRewards.Find(x => x.UniqueID == CurrentQuest.QuestRewardID);
            lblEXPValue.Text = CurrentQuest.ExpAwarded.ToString();

            if (CurrentReward != null)
            {
                lblGoldValue.Text = CurrentReward.Gold.ToString();

                if (CurrentReward.ItemID != 0)
                {
                    CurrentItem = Item.Items.Find(x => x.UniqueID == CurrentReward.ItemID);
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
            LogWriter.Write("FormQuestDetail",MethodBase.GetCurrentMethod().Name, LogWriter.LogType.GamePlay, "Claiming reward for Quest " + CurrentQuest.Name);
            if(ClaimRewardGold() && ClaimRewardEXP())
            {
                if(CurrentReward.IsItem == 1)
                {
                    if (ClaimRewardItem())
                    {
                        // Update the questlog to show to reward has been claimed
                        CurrentQuest.GetQuestLog().StateID = State.COMPLETE_NO_REWARD;
                        if (API.IsSuccess(API.UpdateQuestLog(CurrentQuest.GetQuestLog())))
                        {
                            this.DialogResult = DialogResult.OK;
                            return;
                        }

                        this.DialogResult = DialogResult.No;
                        return;
                    }
                    else
                    {
                        // Item not claimed, but don't claim gold/exp again
                        CurrentQuest.GetQuestLog().StateID = State.COMPLETE_ONLY_ITEM;
                        if (API.IsSuccess(API.UpdateQuestLog(CurrentQuest.GetQuestLog())))
                        {
                            this.DialogResult = DialogResult.OK;
                            return;
                        }

                        this.DialogResult = DialogResult.No;
                        return;
                    }
                }
                else
                {
                    // No item to claim, only gold/exp
                    CurrentQuest.GetQuestLog().StateID = State.COMPLETE_NO_REWARD;
                    if (API.IsSuccess(API.UpdateQuestLog(CurrentQuest.GetQuestLog())))
                    {
                        this.DialogResult = DialogResult.OK;
                        return;
                    }

                    this.DialogResult = DialogResult.No;
                    return;
                }
            }
            // Save the updates
            Instances.Character.Save();
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
