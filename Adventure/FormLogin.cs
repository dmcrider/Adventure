using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adventure
{
    public partial class FormLogin : Form
    {
        // Create an alert label
        Label invalidLoginLabel = new Label
        {
            Location = new Point(0, 0),
            ForeColor = Color.Red,
            Text = Properties.Resources.InvalidLoginMessage
        };
        public FormLogin()
        {
            InitializeComponent();
        }
        
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            // Check the local storage first
            string username = txtUsername.Text;
            string pwd = txtPassword.Text;

            if(username.Length != 0 && pwd.Length != 0 && ValidateLogin(username, pwd))
            {
                MessageBox.Show("Yay! Now we can play!");
            }
            else
            {
                ClearForm();
                AlertInvalidLogin();
            }
        }

        private void ClearForm()
        {
            txtUsername.Text = String.Empty;
            txtPassword.Text = String.Empty;

            txtUsername.Focus();
        }

        private void AlertInvalidLogin()
        {
            // Add the label to the form
            invalidLoginLabel.Width = this.Width;
            this.Controls.Add(invalidLoginLabel);
        }

        private bool ValidateLogin(string u, string p)
        {
            bool returnValue = false;
            int uniqueMax = (int)Properties.Settings.Default["MaxUsers"];

            for (int i = 0; i < uniqueMax; i++)
            {
                // Check if the username is a match
                if (u.Equals(Properties.Settings.Default[$"Username{i}"]))
                {
                    // Check if the password matches
                    if (p.Equals(Properties.Settings.Default[$"Password{i}"]))
                    {
                        returnValue = true;
                    }
                }
            }
            return returnValue;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            // Clear any error messages so they don't show when the user comes back
            if (invalidLoginLabel.Text != String.Empty)
            {
                invalidLoginLabel.Text = String.Empty;
            }

            FormRegister frmRegister = new FormRegister();

            frmRegister.ShowDialog();
        }
    }
}
