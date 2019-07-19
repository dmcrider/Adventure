using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adventure
{
    public partial class FormLogin : Form
    {
        Player loggedInPlayer;

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
            string username = txtUsername.Text;
            string pwd = txtPassword.Text;

            if(ValidateLogin(username, pwd))
            {
                this.Close();
            }
            else
            {
                ClearForm();
                AlertInvalidLogin();
            }
        }

        private void ClearForm()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;

            txtUsername.Focus();
        }

        private void AlertInvalidLogin()
        {
            // Add the label to the form
            invalidLoginLabel.Width = this.Width;
            Controls.Add(invalidLoginLabel);
        }

        private bool ValidateLogin(string u, string p)
        {
            bool isValidLogin = false;
            loggedInPlayer = new Player(u, p);
            int id = 0;

            using (WebClient wc = new WebClient())
            {
                string response = wc.DownloadString(Properties.Settings.Default.APIBaseAddress + Properties.Settings.Default.ReadAPI);
                // Get the ID for the username entered so we can verify the password
                string[] responseJSON = response.Split('}');
                foreach(string obj in responseJSON)
                {
                    if(obj.Length > 2 && obj[2] == 'I')
                    {
                        string output = obj + "}";
                        JObject convertedJSON = JObject.Parse(output);
                        foreach (var item in convertedJSON)
                        {
                            if (item.Key == "ID")
                            {
                                id = (int)item.Value;
                            }
                            if (item.Key == "Username")
                            {
                                if((string)item.Value == u && id != 0)
                                {
                                    loggedInPlayer.uniqueID = id;
                                    isValidLogin = VerifyPassword();
                                }
                            }
                        }
                    }
                }
                
            }

            return isValidLogin;
        }

        private bool VerifyPassword()
        {
            bool isValidPassword = false;
            string apiJSON = $"{{\"Username\":\"{loggedInPlayer.username}\",\"Password\":\"{loggedInPlayer.password}\",\"ID\":\"{loggedInPlayer.uniqueID}\"}}";

            using (WebClient wc = new WebClient())
            {
                string response = wc.UploadString(Properties.Settings.Default.APIBaseAddress + Properties.Settings.Default.LoginAPI, apiJSON);
                JObject convertedJSON = JObject.Parse(response);

                foreach(var item in convertedJSON)
                {
                    if(item.Key == "login_success")
                    {
                        if((int)item.Value == 1)
                        {
                            isValidPassword = true;
                        }
                    }
                }
            }

            return isValidPassword;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            // Clear any error messages so they don't show when the user comes back
            if (invalidLoginLabel.Text != string.Empty)
            {
                invalidLoginLabel.Text = string.Empty;
            }

            FormRegister frmRegister = new FormRegister();

            frmRegister.ShowDialog();
        }

        public Player GetLoggedInPlayer()
        {
            if(loggedInPlayer != null)
            {
                return loggedInPlayer;
            }

            return null;
        }
    }
}
