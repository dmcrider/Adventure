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

            QuestReward reward = API.questrewardsList.Find(x => x.UniqueID == q.QuestRewardID);
            lblEXPValue.Text = q.ExpAwarded.ToString();

            if(reward != null)
            {
                lblGoldValue.Text = reward.Gold.ToString();

                if(reward.ItemID != 0)
                {
                    Item item = API.itemsList.Find(x => x.UniqueID == reward.ItemID);
                    lblRewardValue.Text = item.DisplayName;
                }
            }
            else
            {
                lblGoldValue.Text = "0";
                lblRewardValue.Text = "None";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnMakeActive_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
    }
}
