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

namespace Adventure
{
    public partial class FormMain : Form
    {
        // Create an instance of the Welcome Window
        readonly FormWelcome frmWelcome = new FormWelcome();
        readonly FormLogin frmLogin = new FormLogin();
        readonly FormSupport frmSupport = new FormSupport();
        readonly FormCharacterCreation frmCharacterCreation = new FormCharacterCreation();
        Player player;
        public List<Item> itemsList = new List<Item>();
        public List<Quest> questsList = new List<Quest>();
        public List<Spell> spellsList = new List<Spell>();
        public List<Stat> statsList = new List<Stat>();
        public List<Race> racesList = new List<Race>();
        public List<State> statesList = new List<State>();
        public List<Npc> npcsList = new List<Npc>();
        public List<QuestReward> questrewardsList = new List<QuestReward>();

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

            // Throw this in a Thread so we can still let the user login
            Thread apiThread = new Thread(new ThreadStart(APIChecks));
            apiThread.Start();
        }

        private void APIChecks()
        {
            string response = new WebClient().DownloadString(Properties.Settings.Default.APIBaseAddress + Properties.Settings.Default.VersionAPI);
            JObject convertedJSON = JObject.Parse(response);

            // Check the current version
            if (!API.CheckVersion(convertedJSON))
            {
                API.UpdateFromDatabase(itemsList, questsList, spellsList, statsList, racesList, statesList, npcsList, questrewardsList);
            }
            else
            {
                // Load the data
                API.LoadData(itemsList, questsList, spellsList, statsList, racesList, statesList, npcsList, questrewardsList);
            }
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
                    ControllerGame ctrlGame = new ControllerGame(this, player);
                    ctrlGame.PopulateInitialData();
                }
                else
                {
                    // Show the character creation screen
                    frmCharacterCreation.player = player;
                    frmCharacterCreation.ShowDialog();
                }
            }
        }

        private bool HasCharacter()
        {
            bool hasCharacter = false;

            // See if there's a character associated with the player
            // Verify the player has an ID - it's necessary for the API call
            if(player.uniqueID != 0)
            {
                // Call the API to read the characters
                using (WebClient wc = new WebClient())
                {
                    string response = wc.DownloadString(Properties.Settings.Default.APIBaseAddress + Properties.Settings.Default.CharacterReadAPI);

                    JObject convertedJSON = JObject.Parse(response);

                    foreach(var item in convertedJSON)
                    {
                        foreach(JObject character in item.Value)
                        {
                            if(player.uniqueID == (int)character.SelectToken("UserID"))
                            {
                                hasCharacter = true;
                                player.character = new Character((int)character.GetValue("UniqueID"), (int)character.GetValue("UserID"), (string)character.GetValue("Name"), (int)character.GetValue("MaxHP"), (int)character.GetValue("CurrentHP"), (int)character.GetValue("MaxMagic"), (int)character.GetValue("CurrentMagic"), (int)character.GetValue("Strength"), (int)character.GetValue("Intelligence"), (int)character.GetValue("Constitution"), (int)character.GetValue("RightHand"), (int)character.GetValue("LeftHand"), (int)character.GetValue("Gold"), (int)character.GetValue("Level"), (int)character.GetValue("ExpPoints"), (int)character.GetValue("IsActive"));
                            }
                        }
                    }
                }
            }

            return hasCharacter;
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
