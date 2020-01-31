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
    public partial class FormLevelUp : Form
    {
        private readonly CharacterLevel NewStats;

        public FormLevelUp()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        public FormLevelUp(CharacterLevel level) : this()
        {
            NewStats = level;
        }

        private void FormLevelUp_Load(object sender, EventArgs e)
        {
            // Make the arrow prettier than (->) by using an actual unicode arrow (→)
            lblLevelArrow.Text = lblSTRArrow.Text = 
                lblINTArrow.Text = lblCONArrow.Text =
                lblHPArrow.Text = lblMagicArrow.Text = char.ConvertFromUtf32(0x2192);

            // Set Previous Values
            SetValues(true);
            // Level up and heal/recover
            IncreaseLevel();
            // Set the new values
            SetValues(false);
        }

        private void SetValues(bool isPrev)
        {
            Character character = Instances.Character;
            int lvl = character.Level;
            int str = character.Strength;
            int intel = character.Intelligence;
            int con = character.Constitution;
            int hp = character.MaxHP;
            int magic = character.MaxMagic;

            if (isPrev)
            {
                lblLevelPrev.Text = lvl.ToString();
                lblSTRPrev.Text = str.ToString();
                lblINTPrev.Text = intel.ToString();
                lblCONPrev.Text = con.ToString();
                lblHPPrev.Text = hp.ToString();
                lblMagicPrev.Text = magic.ToString();
            }
            else
            {
                lblLevelNext.Text = lvl.ToString();
                lblSTRNext.Text = str.ToString();
                lblINTNext.Text = intel.ToString();
                lblCONNext.Text = con.ToString();
                lblHPNext.Text = hp.ToString();
                lblMagicNext.Text = magic.ToString();
            }
        }

        private void IncreaseLevel()
        {
            Instances.Character.Level++;
            Instances.Character.Strength += NewStats.STRIncrease;
            Instances.Character.Intelligence += NewStats.INTIncrease;
            Instances.Character.Constitution += NewStats.CONIncrease;
            Instances.Character.MaxHP += NewStats.HPIncrease;
            Instances.Character.MaxMagic += NewStats.MagicIncrease;

            Instances.Character.RestoreHPAndMagic();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
