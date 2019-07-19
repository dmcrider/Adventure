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
                if (IsNewUser(username))
                {
                    // Save the name & pwd and let the user login
                    SaveValidCredentials(username, pwd);

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

        private bool IsNewUser(string u)
        {
            bool isNew = true;

            // Connect to database and check if username already exists
            using (WebClient wc = new WebClient())
            {
                string response = wc.DownloadString(Properties.Settings.Default.APIBaseAddress + Properties.Settings.Default.ReadAPI);
                // Get the ID for the username entered so we can verify the password
                string[] responseJSON = response.Split('}');
                foreach (string obj in responseJSON)
                {
                    if (obj.Length > 2 && obj[2] == 'I')
                    {
                        string output = obj + "}";
                        JObject convertedJSON = JObject.Parse(output);
                        foreach (var item in convertedJSON)
                        {
                            if (item.Key == "Username")
                            {
                                if((string)item.Value == u)
                                {
                                    isNew = false;
                                }
                            }
                        }
                    }
                }
            }

            return isNew;
        }

        private void AlertInvalidRegister()
        {
            invalidRegisterLabel.Width = this.Width;
            // Add the label to the form
            this.Controls.Add(invalidRegisterLabel);
        }

        private void SaveValidCredentials(string u, string p)
        {
            string apiJSON = $"{{\"Username\":\"{u}\",\"Password\":\"{p}\"}}";

            using (WebClient wc = new WebClient())
            {
                string response = wc.UploadString(Properties.Settings.Default.APIBaseAddress + Properties.Settings.Default.RegisterAPI, apiJSON);
                JObject convertedJSON = JObject.Parse(response);

                foreach (var item in convertedJSON)
                {
                    if((string)item.Value == Properties.Resources.APIRegisterSuccess)
                    {
                        MessageBox.Show(Properties.Resources.RegisterSuccessMessage);
                    }
                }
            }
        }
    }
}
