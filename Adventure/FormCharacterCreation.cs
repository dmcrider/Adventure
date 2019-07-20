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

        private const int DWARF_CON = 12;
        private const int DWARF_INT = 8;

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
        }

        private void RadioButtonChanged(object sender, EventArgs e)
        {
            try
            {
                RadioButton tmpRadio = (RadioButton)sender;

                if (tmpRadio.Text == "Human")
                {
                    txtSTR.Text = DEFAULT_STR.ToString();
                    txtINT.Text = DEFAULT_INT.ToString();
                    txtCON.Text = DEFAULT_CON.ToString();
                }
                else if (tmpRadio.Text == "Elf")
                {
                    txtSTR.Text = ELF_STR.ToString();
                    txtINT.Text = ELF_INT.ToString();
                    txtCON.Text = DEFAULT_CON.ToString();
                }
                else if (tmpRadio.Text == "Dwarf")
                {
                    txtSTR.Text = DEFAULT_STR.ToString();
                    txtINT.Text = DWARF_INT.ToString();
                    txtCON.Text = DWARF_CON.ToString();
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
            // API call to save the character
            return;
        }
    }
}
