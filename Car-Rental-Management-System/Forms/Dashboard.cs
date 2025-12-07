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


namespace Car_Rental_Management_System
{

    public partial class Dashboard : Form
    {
        // Active form inside panelDesktop
        private Form? activeForm = null;

        // Active button
        private IconButton? activeButton = null;

        // Default colors
        private Color defaultButtonColor = Color.FromArgb(108, 92, 231);
        private Color defaultButtonText = Color.White;
        private Color defaultTitleBarColor;




        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            defaultTitleBarColor = panelTitleBar.BackColor;

            // Open home by default
            OpenChildForm(new Home());
            ActivateButton(btnDashboard);
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
            OpenChildForm(new VehiclesForm());
            ActivateButton(btnVehicles);
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CustomersForm());
            ActivateButton(btnCustomers);
        }

        private void btnRentals_Click(object sender, EventArgs e)
        {
            OpenChildForm(new RentalsForm());
            ActivateButton(btnRentals);
        }

        private void btnReturns_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ReturnsForm());
            ActivateButton(btnReturns);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ReportsForm());
            ActivateButton(btnReports);
        }

        private void btnMaintenances_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MaintenanceForm());
            ActivateButton(btnMaintenances);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
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

        private void btnUsersMgmt_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UsersForm());
            ActivateButton(btnUsersMgmt);
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

