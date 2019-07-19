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
    public partial class FormMain : Form
    {
        // Create an instance of the Welcome Window
        readonly FormWelcome frmWelcome = new FormWelcome();
        readonly FormLogin frmLogin = new FormLogin();
        readonly FormSupport frmSupport = new FormSupport();
        Player player;
        Character currentCharacter;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // Center to screen
            this.CenterToScreen();

            // Hide Panels until user logs in
            panelCharacter.Visible = false;

            // Clear defaults
            lblCharacterName.Text = string.Empty;
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            // Disable the main form until the user has sucesfully logged in
            this.Enabled = false;

            // Show the welcome screen
            frmWelcome.ShowDialog();

            // Show the login screen
            frmLogin.ShowDialog();
            player = frmLogin.GetLoggedInPlayer();

            if (CheckForNullPlayer())
            {
                // Player is valid
                this.Enabled = true;

                // Check if the have a character
                if (HasCharacter())
                {
                    panelCharacter.Visible = true;
                    ControllerGame ctrlGame = new ControllerGame(player, currentCharacter);
                    ctrlGame.PopulateInitialData(playerToolStripMenuItem, panelCharacter);
                }
            }
        }

        private bool HasCharacter()
        {
            return true;
        }

        private bool CheckForNullPlayer()
        {
            if (player == null)
            {
                MessageBox.Show(Properties.Resources.ErrorGeneral);
                ExitApplication();
            }

            return true;
        }

        private void AboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Show the welcome message
            frmWelcome.ShowDialog();
        }

        private void SupportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the support window
            frmSupport.ShowDialog();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show(Properties.Resources.ConfirmNoSaveMessage, Properties.Resources.ConfirmNoSaveTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // User does not want to save
                ExitApplication();
            }
            else
            {
                return;
            }
        }

        private void ExitApplication()
        {
            if (Application.MessageLoop)
            {
                Application.Exit();
            }
            else
            {
                Environment.Exit(1);
            }
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            panelHP.Width -= 1;
        }
    }
}
