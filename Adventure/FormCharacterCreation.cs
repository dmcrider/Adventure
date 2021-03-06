﻿using Newtonsoft.Json.Linq;
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
using System.Reflection;

namespace Adventure
{
    public partial class FormCharacterCreation : Form
    {
        private int selectedRace;
        private int selectedGender;
        private int selectedWeapon1;
        private int selectedWeapon2;
        private int selectedGold;

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
            radioGenderMale.Checked = true;
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
                    selectedGold = int.Parse(txtEquipExplorerGold.Text);
                }
                else if (tmpRadio.Tag.Equals("adventurer"))
                {
                    // Set the explorer defaults
                    selectedWeapon1 = 2; // Short Sword
                    selectedWeapon2 = 1; // Shield
                    selectedGold = int.Parse(txtEquipAdventureGold.Text);
                }
            }
            catch (Exception ex)
            {
                LogWriter.Write(this.GetType().Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, ex.Message);
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
            catch(Exception ex)
            {
                LogWriter.Write(this.GetType().Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, ex.Message);
                return;
            }
        }

        private void RadioButtonGender_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RadioButton tmpRadio = (RadioButton)sender;

                selectedGender = int.Parse(tmpRadio.Tag.ToString());
            }
            catch (Exception ex)
            {
                LogWriter.Write(this.GetType().Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, ex.Message);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Create and save the character
            Instances.Character = new Character(Instances.Player.UniqueID, txtCharacterName.Text, selectedRace)
            {
                Gold = selectedGold,
                Gender = selectedGender
            };
            bool creationSuccess = false;
            try
            {
                creationSuccess = API.IsSuccess(Character.GetUniqueID());
            }
            catch (Exception ex)
            {
                LogWriter.Write(this.GetType().Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, ex.Message);
            }

            if (!creationSuccess)
            {
                // There was a problem
                MessageBox.Show(Properties.Resources.ErrorGeneral, "Error");
            }
            else
            {
                // Character saved successfully - we have a UniqueID we can use now
                // Create and save the inventory
                if (selectedWeapon1 != 0)
                {
                    Inventory.AddInventoryItem(selectedWeapon1);
                }

                if (selectedWeapon2 != 0)
                {
                    Inventory.AddInventoryItem(selectedWeapon2);
                }

                // Load the inventory
                Inventory.LoadInventory();
            }
        }
    }
}
