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

            loggedInPlayer = new Player(username, pwd);

            int loginType = API.Login(loggedInPlayer);

            if (loginType == 1)
            {
                // Successful login
                this.Close();
            }
            else if(loginType == 0)
            {
                // Bad credentials
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
