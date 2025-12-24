using Car_Rental_Management_System.Forms;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Configuration;


namespace Car_Rental_Management_System
{

    public partial class Dashboard : Form
    {
        private readonly ApiClient _apiClient;

        // Active form inside panelDesktop
        private Form? activeForm = null;

        // Active button
        private IconButton? activeButton = null;

        // Default colors
        private Color defaultButtonColor = Color.FromArgb(108, 92, 231);
        private Color defaultButtonText = Color.White;
        private Color defaultTitleBarColor;

        // For draggable form
        private bool dragging = false;
        private Point dragStartPoint;



        public Dashboard(ApiClient apiClient, object apiClient1)
        {
            InitializeComponent();
            _apiClient = apiClient;

            // Set user info
            lblWelcome.Text = $"{_apiClient.CurrentUser?.FullName ?? "User"}({_apiClient.CurrentUser?.Role})";

            // Show/hide buttons based on role
            ConfigureRoleBasedUI();
        }

        private void ConfigureRoleBasedUI()
        {
            bool isAdmin = _apiClient.IsAdmin;

            // Show all buttons for Admin
            btnVehicles.Visible = isAdmin;
            btnReports.Visible = isAdmin;
            btnUsersMgmt.Visible = isAdmin;



            // Always show for both Admin and Staff
           
            btnMaintenances.Visible = true;


        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            defaultTitleBarColor = panelTitleBar.BackColor;

            // Set up draggable functionality for panel2
            panel2.MouseDown += Panel2_MouseDown;
            panel2.MouseMove += Panel2_MouseMove;
            panel2.MouseUp += Panel2_MouseUp;

            // Open home by default
            OpenChildForm(new Home());
            ActivateButton(btnDashboard);
        }

        // Draggable functionality for panel2
        private void Panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                dragStartPoint = e.Location;
            }
        }

        private void Panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point screenPoint = PointToScreen(e.Location);
                Location = new Point(screenPoint.X - dragStartPoint.X, screenPoint.Y - dragStartPoint.Y);
            }
        }

        private void Panel2_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }



        private void ActivateButton(IconButton btn)
        {
            if (btn == null) return;

            // Reset previous button
            if (activeButton != null)
            {
                activeButton.BackColor = defaultButtonColor;
                activeButton.ForeColor = defaultButtonText;
            }

            // Set new active button
            activeButton = btn;

            Color highlightColor = Color.FromArgb(0, 90, 158);

            activeButton.BackColor = highlightColor;
            activeButton.ForeColor = Color.Black;

            // Update title bar
            lblTitle.Text = btn.Text;


        }



        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelDesktop.Controls.Clear();
            panelDesktop.Controls.Add(childForm);
            childForm.Show();
        }



        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Home());
            ActivateButton(btnDashboard);
        }

        private void btnVehicles_Click(object sender, EventArgs e)
        {
            OpenChildForm(new VehiclesForm(_apiClient));
            ActivateButton(btnVehicles);
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CustomersForm(_apiClient));
            ActivateButton(btnCustomers);
        }

        private void btnRentals_Click(object sender, EventArgs e)
        {
            OpenChildForm(new RentalsForm(_apiClient));
            ActivateButton(btnRentals);
        }

     

        private void btnReports_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ReportsForm());
            ActivateButton(btnReports);
        }

        private void btnMaintenances_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MaintenanceForm(_apiClient));
            ActivateButton(btnMaintenances);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

            // Show confirmation dialog
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2); // Default to "No" for safety

            // If user clicks "No", cancel the logout
            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                // Logout from API client
                if (_apiClient != null)
                {
                    _apiClient.Logout();
                }

                // Clear application settings
                ClearUserSettings();


                // Return to login form
                Application.Restart();
            }
            catch (Exception ex)
            {
                // Handle any errors during logout
                MessageBox.Show(
                    $"Error during logout: {ex.Message}",
                    "Logout Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void ClearUserSettings()
        {
            try
            {
                // Clear from ConfigurationManager (App.config)
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                // Clear each setting safely (check if key exists)
                if (config.AppSettings.Settings["UserToken"] != null)
                    config.AppSettings.Settings["UserToken"].Value = "";

                if (config.AppSettings.Settings["UserRole"] != null)
                    config.AppSettings.Settings["UserRole"].Value = "";

                if (config.AppSettings.Settings["UserName"] != null)
                    config.AppSettings.Settings["UserName"].Value = "";

                if (config.AppSettings.Settings["FullName"] != null)
                    config.AppSettings.Settings["FullName"].Value = "";

                // Also clear any session-specific settings
                if (config.AppSettings.Settings["LastLogin"] != null)
                    config.AppSettings.Settings["LastLogin"].Value = "";

                if (config.AppSettings.Settings["RememberMe"] != null)
                    config.AppSettings.Settings["RememberMe"].Value = "false";

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");



            }
            catch (ConfigurationErrorsException ex)
            {
                // Handle configuration errors specifically
                MessageBox.Show(
                    $"Configuration error: {ex.Message}\nSettings may not have been cleared completely.",
                    "Configuration Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Handle any other errors
                MessageBox.Show(
                    $"Error clearing settings: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblCarrental_Click(object sender, EventArgs e)
        {


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {

        }

        private void BtnUsersMgmt_Click(object sender, EventArgs e)
        {

        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelTitleBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelDesktop_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }

        private void btnUsersMgmt_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new UsersForm());
            ActivateButton(btnUsersMgmt);
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}