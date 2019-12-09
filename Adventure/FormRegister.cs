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
using System.Reflection;

namespace Adventure
{
    public partial class FormRegister : Form
    {
        // Create an alert label
        readonly Label invalidRegisterLabel = new Label
        {
            Location = new Point(0, 0),
            ForeColor = Color.Red,
            Text = Properties.Resources.InvalidRegisterPasswordNoMatch
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
                if (API.Register(username, pwd))
                {
                    // Close the form so user can login
                    this.Close();
                }
                else
                {
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
            invalidRegisterLabel.Text = Properties.Resources.InvalidRegisterUsernameTaken;
            invalidRegisterLabel.Width = this.Width;
            if(this.Controls.IndexOf(invalidRegisterLabel) == -1)
            {
                this.Controls.Add(invalidRegisterLabel);
            }

            txtUsername.Text = String.Empty;
            txtUsername.Focus();
            LogWriter.Write(this.GetType().Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Warning, "Player is already registered");
        }

        private void AlertInvalidRegister()
        {
            invalidRegisterLabel.Width = this.Width;
            // Add the label to the form
            this.Controls.Add(invalidRegisterLabel);
            LogWriter.Write(this.GetType().Name, MethodBase.GetCurrentMethod().Name, LogWriter.LogType.Error, "Invalid registration");
        }
    }
}
