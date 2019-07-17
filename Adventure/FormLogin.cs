using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        HttpClient client = new HttpClient();

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

            ValidateLogin(username, pwd);
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

        private async void ValidateLogin(string u, string p)
        {
            loggedInPlayer = new Player(u, p);

            client.BaseAddress = new Uri(Properties.Settings.Default.APIBaseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.PostAsJsonAsync(Properties.Settings.Default.ReadAPI,"");

            if (response.IsSuccessStatusCode)
            {
                // Read the JSON and get the id
                //Console.WriteLine(response.Content.ReadAsStringAsync());
            }
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
