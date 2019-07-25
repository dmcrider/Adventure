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
using System.Windows.Forms;

namespace Adventure
{
    public partial class FormCharacterCreation : Form
    {
        private int selectedRace;
        private int selectedWeapon1;
        private int selectedWeapon2;
        private int selectedGold;

        private Player player;

        public void LoggedInPlayer(ref Player player)
        {
            this.player = player;
        }

        public FormCharacterCreation()
        {
            InitializeComponent();
        }

        private void FormCharacterCreation_Load(object sender, EventArgs e)
        {
            // Center the form
            this.CenterToScreen();

            // Set the defaults
            radioRaceHuman.Checked = true;
            radioEquipExplorer.Checked = true;
        }

        private void RadioButtonEquipment_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RadioButton tmpRadio = (RadioButton)sender;

                if(tmpRadio.Tag.Equals("explorer"))
                {
                    // Set the explorer defaults
                    selectedWeapon1 = 2; // Short Sword
                    selectedWeapon2 = 0; // Null
                    selectedGold = 40;
                }
                else if (tmpRadio.Tag.Equals("adventurer"))
                {
                    // Set the explorer defaults
                    selectedWeapon1 = 2; // Short Sword
                    selectedWeapon2 = 1; // Shield
                    selectedGold = 25;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Something that wasn't a RadioButton called the RadioButtonChanged function.\n\t" + exception);
                return;
            }
        }

        private void RadioButtonRace_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RadioButton tmpRadio = (RadioButton)sender;


                int raceID = int.Parse(tmpRadio.Tag.ToString());
                raceID -= 1; // List indices start at 0, but our values start at 1

                txtSTR.Text = Race.GetStrength(raceID).ToString();
                txtINT.Text = Race.GetIntelligence(raceID).ToString();
                txtCON.Text = Race.GetConstitution(raceID).ToString();

                selectedRace = raceID;
            }
            catch(Exception exception)
            {
                Console.WriteLine("Something that wasn't a RadioButton called the RadioButtonChanged function.\n\t" + exception);
                return;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Create and save the character
            Character newCharacter = new Character(player.uniqueID,txtCharacterName.Text,selectedRace);
            if (!API.CreateCharacter(ref newCharacter, newCharacter.UserID))
            {
                // There was a problem
                MessageBox.Show(Properties.Resources.ErrorGeneral, "Error");
            }
            // Create and save the inventory
            if(selectedWeapon1 != 0)
            {
                API.AddInventoryItem(newCharacter.UniqueID,selectedWeapon1);
            }

            if (selectedWeapon2 != 0)
            {
                API.AddInventoryItem(newCharacter.UniqueID, selectedWeapon2);
            }
        }
    }
}
