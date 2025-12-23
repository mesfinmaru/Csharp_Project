using CRM_API.Models;
using System.Net.Http.Json;
using System.Windows.Forms;
using System.Configuration;

namespace Car_Rental_Management_System
{
    public partial class Login : Form
    {
        private readonly ApiClient _apiClient;
        public Login()
        {
            InitializeComponent();
            _apiClient = new ApiClient();
        }


        private void Login_Load(object sender, EventArgs e)
        {

            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
        }



        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void lblMessage_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblWelcome_Click_1(object sender, EventArgs e)
        {

        }






        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }


        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtbUsername.Text.Trim();
            string password = txtbPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Disable controls during login
            btnLogin.Enabled = false;
            btnLogin.Text = "Login";
            lblStatus.Text = "Please wait...";

            try
            {
                var result = await _apiClient.Login(username, password);

                if (result?.Success == true)
                {
                    // Store user info for later use
                    ConfigurationManager.AppSettings["UserToken"] = result.Token;
                    ConfigurationManager.AppSettings["UserRole"] = result.User.Role;
                    ConfigurationManager.AppSettings["UserName"] = result.User.Username;
                    ConfigurationManager.AppSettings["FullName"] = result.User.FullName;

                    MessageBox.Show($"Welcome {result.User.FullName}!", "Login Successful");


                    // Navigate to main dashboard
                    OpenDashboard();

                }
                else
                {
                    MessageBox.Show(result?.Message ?? "Login failed", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                lblStatus.Text = "";
            }
        }
        private void OpenDashboard()
        {
            // Create Dashboard instance and pass the ApiClient and a second argument (use null or appropriate value)
            var dashboard = new Dashboard(_apiClient, null);

            // Optional: Set dashboard as main form
            dashboard.FormClosed += (s, args) => this.Close();

            // Show dashboard and hide login form
            dashboard.Show();
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}

