using System.Net.Http.Json;

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

        private async void btnLogin_Click(object sender, EventArgs e)
        {
        }
        private async void btnLogin_Click_1(object sender, EventArgs e)
        {
            

            // Use this Handler to bypass SSL certificate errors locally
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

            using (HttpClient client = new HttpClient(handler))
            {
                try
                {
                    // Make sure this port matches your Swagger page (7209)
                    string apiUrl = $"https://localhost:7209/api/Auth/login?username={txtbUsername.Text}&password={txtbPassword.Text}";

                    var response = await client.PostAsync(apiUrl, null);

                    if (response.IsSuccessStatusCode)
                    {
                       

                        // Open Dashboard
                        Dashboard dash = new Dashboard();
                        dash.Show();
                        this.Hide();
                    }
                    else
                    {
                        // This happens if username/password is wrong (401 error)
                        MessageBox.Show("Invalid Username or Password.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection Failed: " + ex.Message);
                }
            }
        }
    }
    }



