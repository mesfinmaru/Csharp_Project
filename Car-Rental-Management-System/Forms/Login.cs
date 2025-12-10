using System.Net.Http.Json;
using System.Windows.Forms;

namespace Car_Rental_Management_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
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
        private readonly ApiClient apiClient = new ApiClient();

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var request = new CRM_API.Models.AuthVMs.LoginRequest
                {
                    Username = txtbUsername.Text,
                    Password = txtbPassword.Text
                };

                var result = await apiClient.Login(request);

                if (result.Success)
                {
                    Dashboard dash = new Dashboard();
                    dash.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login failed: " + result.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }
}





