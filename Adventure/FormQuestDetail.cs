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

        public FormQuestDetail()
        {
            InitializeComponent();
        }

        public FormQuestDetail(Quest q) : this()
        {
            PopulateValues(q);
        }

        private void FormQuestDetail_Load(object sender, EventArgs e)
        {
            // Center the form
            this.CenterToScreen();
        }

        private void PopulateValues(Quest q)
        {
            lblQuestName.Text = q.Name;
            lblDescription.Text = q.Description;

            // Check if this is a new quest
            CheckForNewQuest(q);

            PopulateRewards(q);
        }

        private void PopulateRewards(Quest q)
        {
            QuestReward reward = API.questrewardsList.Find(x => x.UniqueID == q.QuestRewardID);
            lblEXPValue.Text = q.ExpAwarded.ToString();

            if (reward != null)
            {
                lblGoldValue.Text = reward.Gold.ToString();

                if (reward.ItemID != 0)
                {
                    Item item = API.itemsList.Find(x => x.UniqueID == reward.ItemID);
                    lblRewardValue.Text = item.DisplayName;
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

        private void CheckForNewQuest(Quest q)
        {
            IsNewQuest = GameController.questLogList.Contains(q);

            if (IsNewQuest)
            {
                btnMakeActive.Text = "Make Active";
                btnRejectQuest.Visible = false;
            }
            else
            {
                btnMakeActive.Text = "Accept Quest";
                btnRejectQuest.Visible = true;
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

        private void BtnRejectQuest_Click(object sender, EventArgs e)
        {
            // Right now we don't do anything else with a rejected quest
            // TODO: Log reject quest
            BtnClose_Click(this, EventArgs.Empty);
        }
    }
}
