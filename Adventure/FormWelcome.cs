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
    public partial class FormWelcome : Form
    {
        public FormWelcome()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Close this form
            this.Close();
        }

        private void FormWelcome_Load(object sender, EventArgs e)
        {
            // Center the form
            this.CenterToScreen();

            // Populate the text
            PopulateWelcomeText();
        }

        /// <summary>
        /// Set the height, width, text alignment, and text of lblWelcomeText
        /// </summary>
        private void PopulateWelcomeText()
        {
            lblWelcomeText.Location = new Point(0, 50);
            lblWelcomeText.Width = lblWelcomeText.Parent.Width;
            lblWelcomeText.Height = lblWelcomeText.Parent.Height;
            lblWelcomeText.TextAlign = ContentAlignment.MiddleCenter;
            lblWelcomeText.MaximumSize = new Size(lblWelcomeText.Parent.Width - 10, lblWelcomeText.Parent.Height);
            lblWelcomeText.AutoSize = true;
            lblWelcomeText.Text = Properties.Resources.WelcomeMessage + "\n\n" +
                string.Format(Properties.Resources.VersionText, Properties.Settings.Default["Version"]) + "\n\n" +
                Properties.Resources.SecurityDisclaimer;
        }
    }
}
