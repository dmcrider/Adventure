using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;

//LogWriter.Write(this.GetType().Name, MethodBase.GetCurrentMethod().Name, "message");

namespace Adventure
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        public static void InventoryFullMessageBox()
        {
            MessageBox.Show("You need to make some space in your inventory first.", "Inventory Full");
        }

        public void Save_Click(object sender, EventArgs e)
        {
            API.SaveProgress(Instances.Player);
        }

        public void Logout_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show(Properties.Resources.ConfirmNoSaveMessage, Properties.Resources.ConfirmNoSaveTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Nullify the current user
                Instances.Player = null;

                // "Reload" the application by calling the methods we need
                FormMain_Load(this, EventArgs.Empty);
                FormMain_Shown(this, EventArgs.Empty);
            }
            else
            {
                return;
            }
        }

        public void SaveAndExit_Click(object sender, EventArgs e)
        {
            Save_Click(this, EventArgs.Empty);
            ExitApplication();
        }

        public void SaveAndLogout_Click(object sender, EventArgs e)
        {
            Save_Click(this, EventArgs.Empty);
            Logout_Click(this, EventArgs.Empty);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // Load some basic instances
            Instances.FormWelcome = new FormWelcome();
            Instances.FormLogin = new FormLogin();

            // Center to screen
            this.CenterToScreen();

            // Hide Panels until user logs in
            panelCharacter.Visible = false;
            panelInventory.Visible = false;
            panelQuest.Visible = false;
            panelGame.Visible = false;
            panelSpells.Visible = false;

            // Clear defaults
            lblCharacterName.Text = string.Empty;

            // Throw this in a Thread so we can still let the user login
            Thread apiThread = new Thread(new ThreadStart(APIChecks));
            apiThread.Start();
        }

        private void SetInstances()
        {
            Instances.FormMain = this;
            Instances.FormShop = new FormShop();
            Instances.FormManageInventory = new FormManageInventory();
            Instances.FormSupport = new FormSupport();
            Instances.FormCharacterCreation = new FormCharacterCreation();
            Instances.GameController = new GameController();
        }

        private void APIChecks()
        {
            string response = new WebClient().DownloadString(Properties.Settings.Default.APIBaseAddress + Properties.Settings.Default.VersionAPI);
            JObject convertedJSON = JObject.Parse(response);

            // Check the current version
            if (!API.CheckVersion(convertedJSON))
            {
                // Load remote data
                LogWriter.Write(this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Loading remote data");
                API.UpdateFromDatabase();
            }
            else
            {
                // Load local data
                LogWriter.Write(this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Loading local data");
                API.LoadData();
            }

            LogWriter.Write(this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Success - everything is loaded");
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            SetInstances();

            // Disable the main form until the user has sucesfully logged in
            this.Enabled = false;

            // Show the welcome screen
            Instances.FormWelcome.ShowDialog();

            // Show the login screen
            Instances.FormLogin.ShowDialog();

            if (CheckForNullPlayer())
            {
                // Player is valid
                this.Enabled = true;

                // Check if the have a character
                if (!HasCharacter())
                {
                    // Does not yet have a character
                    // Show the character creation screen
                    LogWriter.Write(this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Error - Player must create Character");
                    Instances.FormCharacterCreation.ShowDialog();

                    if (Instances.Player.character == null)
                    {
                        LogWriter.Write(this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Error - Player closed creation screen without saving");
                        MessageBox.Show(Properties.Resources.ErrorGeneral);
                        Application.Exit();
                        return;
                    }
                }
                else
                {
                    // Already has a character
                    // Load the inventory
                    API.LoadInventory(Instances.Character.UniqueID);
                }

                // Start the game
                LogWriter.Write(this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Starting the game");
                Instances.GameController.PopulateInitialData();
            }
        }

        private bool HasCharacter()
        {
            bool hasCharacter = false;

            // See if there's a character associated with the player
            // Verify the player has an ID - it's necessary for the API call
            if(Instances.Player != null && Instances.Player.uniqueID != 0)
            {
                Character character = API.GetCharacter(Instances.Player.uniqueID);

                if(character != null)
                {
                    hasCharacter = true;
                    Instances.Character = character;
                }
            }

            return hasCharacter;
        }

        private bool CheckForNullPlayer()
        {
            if (Instances.Player == null)
            {
                MessageBox.Show(Properties.Resources.ErrorGeneral);
                ExitApplication();
            }

            return true;
        }

        private void AboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Show the welcome message
            Instances.FormWelcome.ShowDialog();
        }

        private void SupportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the support window
            Instances.FormSupport.ShowDialog();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ExitNoSaveConfirm();
        }

        private void ExitNoSaveConfirm()
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

        private void BtnManageInventory_Click(object sender, EventArgs e)
        {
            LogWriter.Write(this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Attempting to manage inventory");
            Instances.FormManageInventory.ShowDialog();
        }

        private void BtnOpenShop_Click(object sender, EventArgs e)
        {
            try
            {
                LogWriter.Write(this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Attempting to load Shop");
                Instances.FormShop.ShowDialog();
            }
            catch(Exception ex)
            {
                LogWriter.Write(this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Error: " + ex);
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
#if !DEBUG
            if(e.CloseReason != CloseReason.ApplicationExitCall)
            {
                ExitNoSaveConfirm();
            }
#endif
        }
    }
}
