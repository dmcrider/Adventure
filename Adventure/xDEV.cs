using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Adventure
{
    public partial class xDEV : UserControl
    {
        static readonly Random rand = new Random();

        public xDEV()
        {
            InitializeComponent();
            this.Name = "panelDev";
            txtDamage.Text = rand.Next(1, 21).ToString();
        }

        private void BtnReduceHP_Click(object sender, EventArgs e)
        {
            Instances.GameController.Damage(Instances.Character.CurrentHP, int.Parse(txtDamage.Text), GameController.HP);
        }

        private void BtnReduceMagic_Click(object sender, EventArgs e)
        {
            Instances.GameController.Damage(Instances.Character.CurrentMagic, int.Parse(txtDamage.Text), GameController.MAGIC);
        }

        private void BtnNewQuest_Click(object sender, EventArgs e)
        {
            DialogResult r = new FormQuestDetail(API.questsList[1]).ShowDialog();

            if(r == DialogResult.Yes)
            {
                GameController.AddAcceptedQuest(API.questsList[1], State.NEW);
            }
        }

        private void BtnOpenShop_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Yet Implemented", "NYI");
        }

        private void BtnCompleteQuest_Click(object sender, EventArgs e)
        {
            LogWriter.Write("xDEV", MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Debug, "Setting active quest to be completed.");
            Panel panelQuest = (Panel)Instances.FormMain.Controls["panelQuest"];
            TabControl tabQuests = (TabControl)panelQuest.Controls["tabQuests"];
            TabPage activePage = (TabPage)tabQuests.Controls["active"];
            ControlActiveQuest ctrlQuest = (ControlActiveQuest)activePage.Controls["questCtrl"];

            ctrlQuest.Quest.GetQuestLog().StateID = State.CAN_COMPLETE;
        }
    }
}
