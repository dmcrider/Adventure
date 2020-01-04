using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adventure
{
    public partial class xDEV : UserControl
    {
        static Random rand = new Random();
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
                GameController.AddActiveQuest(API.questsList[1], State.NEW);
            }
        }

        private void BtnOpenShop_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Yet Implemented", "NYI");
        }
    }
}
