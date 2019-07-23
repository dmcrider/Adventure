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
        private const int DEFAULT_STR = 10;
        private const int DEFAULT_INT = 10;
        private const int DEFAULT_CON = 10;

        private const int ELF_STR = 8;
        private const int ELF_INT = 12;

        private const int DWARF_STR = 12;
        private const int DWARF_INT = 8;

        private string selectedRace;
        private int selectedSTR;
        private int selectedINT;
        private int selectedCON;
        private int selectedWeapon1;
        private int selectedWeapon2;
        private int selectedGold;

        public Player player;

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

                if (tmpRadio.Text == "Human")
                {
                    txtSTR.Text = DEFAULT_STR.ToString();
                    txtINT.Text = DEFAULT_INT.ToString();
                    txtCON.Text = DEFAULT_CON.ToString();

                    selectedRace = "Human";
                    selectedSTR = DEFAULT_STR;
                    selectedINT = DEFAULT_INT;
                    selectedCON = DEFAULT_CON;
                }
                else if (tmpRadio.Text == "Elf")
                {
                    txtSTR.Text = ELF_STR.ToString();
                    txtINT.Text = ELF_INT.ToString();
                    txtCON.Text = DEFAULT_CON.ToString();

                    selectedRace = "Elf";
                    selectedSTR = ELF_STR;
                    selectedINT = ELF_INT;
                    selectedCON = DEFAULT_CON;
                }
                else if (tmpRadio.Text == "Dwarf")
                {
                    txtSTR.Text = DWARF_STR.ToString();
                    txtINT.Text = DWARF_INT.ToString();
                    txtCON.Text = DEFAULT_CON.ToString();

                    selectedRace = "Dwarf";

                    selectedSTR = DWARF_STR;
                    selectedINT = DWARF_INT;
                    selectedCON = DEFAULT_CON;
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine("Something that wasn't a RadioButton called the RadioButtonChanged function.\n\t" + exception);
                return;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //`UserID`, `Name`, `Race`, `MaxHP`, `CurrentHP`, `MaxMagic`, `CurrentMagic`, `Strength`, `Intelligence`, `Constitution`, `RightHand`, `LeftHand`, `Gold`, `Level`, `ExperiencePoints`
            //string apiJSON = $"{{\"Username\":\"{u}\",\"Password\":\"{p}\"}}";

            string apiJSON = $"{{\"UserID\":{player.uniqueID},\"Name\":\"{txtCharacterName.Text}\",\"Race\":\"{selectedRace}\",\"MaxHP\":20,\"CurrentHP\":20,\"MaxMagic\":20,\"CurrentMagic\":20,\"Strength\":{selectedSTR},\"Intelligence\":{selectedINT},\"Constitution\":{selectedCON},\"RightHand\":{selectedWeapon1},\"LeftHand\":{selectedWeapon2},\"Gold\":{selectedGold},\"Level\":1,\"ExperiencePoints\":0}}";

            // API call to save the character
            using (WebClient wc = new WebClient())
            {
                string response = wc.UploadString(Properties.Settings.Default.APIBaseAddress + Properties.Settings.Default.CharacterCreateAPI, apiJSON);
                JObject convertedJSON = JObject.Parse(response);

                foreach (var item in convertedJSON)
                {
                    if ((string)item.Value == Properties.Resources.APIRegisterSuccess)
                    {
                        MessageBox.Show(Properties.Resources.RegisterSuccessMessage);
                    }
                }
            }
        }
    }
}
