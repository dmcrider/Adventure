﻿using Newtonsoft.Json;
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
using System.Reflection;

namespace Adventure
{
    public partial class FormLogin : Form
    {
        // Create an alert label
        Label invalidLoginLabel = new Label
        {
            Location = new Point(0, 0),
            ForeColor = Color.Red,
            Text = Properties.Resources.InvalidLoginMessage,
            Height = 40
        };
        public FormLogin()
        {
            InitializeComponent();
#if DEBUG
            txtUsername.Text = "test1";
            txtPassword.Text = "test1";
#endif
        }
        
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string pwd = txtPassword.Text;

            Instances.Player = new Player(username, pwd);

            if (API.IsSuccess(API.Login(Instances.Player)))
            {
                // Successful login
                this.Close();
            }
            else
            {
                // Bad credentials
                Instances.Player = null;
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
            this.AcceptButton = btnLogin;
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
    }
}
