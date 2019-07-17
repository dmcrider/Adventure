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
    public partial class FormRegister : Form
    {
        // Create an alert label
        Label invalidRegisterLabel = new Label
        {
            Location = new Point(0, 0),
            ForeColor = Color.Red,
            Text = Properties.Resources.InvalidRegisterMessage
        };
        public FormRegister()
        {
            InitializeComponent();
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string pwd = txtPassword.Text;
            string pwd2 = txtConfirmPwd.Text;

            if (pwd.Equals(pwd2))
            {
                // Check if the user already exists
                if (CheckNewUser(username))
                {
                    // Save the name & pwd and let the user login
                    int uniqueMax = (int)Properties.Settings.Default["MaxUsers"];

                    for (int i = 0; i <= uniqueMax; i++)
                    {
                        if (Properties.Settings.Default[$"Username{i}"].Equals(string.Empty))
                        {
                            SaveValidCredentials(username, pwd, i);
                            break;
                        }

                        if(i == 3)
                        {
                            MessageBox.Show("No more users can play here. Sorry!");
                        }
                        
                    }

                    // Close this form so users can login
                    this.Close();
                }
                else
                {
                    // Already Registered
                    AlertAlreadyRegistered();
                }
            }
            else
            {
                // Passwords don't match
                AlertInvalidRegister();
            }
        }

        private void AlertAlreadyRegistered()
        {
            invalidRegisterLabel.Text = Properties.Resources.InvalidRegisterMessage2;
            invalidRegisterLabel.Width = this.Width;
            if(this.Controls.IndexOf(invalidRegisterLabel) == -1)
            {
                this.Controls.Add(invalidRegisterLabel);
            }

            txtUsername.Text = String.Empty;
            txtUsername.Focus();
        }

        private bool CheckNewUser(string u)
        {
            bool returnValue = true;

            if (Properties.Settings.Default[$"id_{u}"] == null)
            {
                // TODO: Create user in database and populate
                Properties.Settings.Default[$"id_{u}"] = "x";

                Properties.Settings.Default.Save();
            }

            return returnValue;
        }

        private void AlertInvalidRegister()
        {
            invalidRegisterLabel.Width = this.Width;
            // Add the label to the form
            this.Controls.Add(invalidRegisterLabel);
        }

        private void SaveValidCredentials(string u, string p, int uniqueID)
        {
            Properties.Settings.Default[$"Username{uniqueID}"] = u;
            Properties.Settings.Default[$"Password{uniqueID}"] = p;

            Properties.Settings.Default.Save();

            MessageBox.Show("You have been successfully registered. Please login.");
        }
    }
}
