namespace Car_Rental_Management_System
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            panelMenu = new Panel();
            btnUsersMgmt = new FontAwesome.Sharp.IconButton();
            btnLogout = new FontAwesome.Sharp.IconButton();
            btnReports = new FontAwesome.Sharp.IconButton();
            btnMaintenances = new FontAwesome.Sharp.IconButton();
            btnReturns = new FontAwesome.Sharp.IconButton();
            btnRentals = new FontAwesome.Sharp.IconButton();
            btnCustomers = new FontAwesome.Sharp.IconButton();
            btnVehicles = new FontAwesome.Sharp.IconButton();
            btnDashboard = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            lblWelcome = new Label();
            pictureBoxStaff = new PictureBox();
            panelTitleBar = new Panel();
            panel2 = new Panel();
            btnMin = new FontAwesome.Sharp.IconButton();
            btnMax = new FontAwesome.Sharp.IconButton();
            lblCarrental = new Label();
            btnClose = new FontAwesome.Sharp.IconButton();
            lblTitle = new Label();
            panelDesktop = new Panel();
            fileSystemWatcher1 = new FileSystemWatcher();
            menuTimer = new System.Windows.Forms.Timer(components);
            panelMenu.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxStaff).BeginInit();
            panelTitleBar.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(108, 92, 231);
            panelMenu.Controls.Add(btnUsersMgmt);
            panelMenu.Controls.Add(btnLogout);
            panelMenu.Controls.Add(btnReports);
            panelMenu.Controls.Add(btnMaintenances);
            panelMenu.Controls.Add(btnReturns);
            panelMenu.Controls.Add(btnRentals);
            panelMenu.Controls.Add(btnCustomers);
            panelMenu.Controls.Add(btnVehicles);
            panelMenu.Controls.Add(btnDashboard);
            panelMenu.Controls.Add(panel1);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Margin = new Padding(4, 2, 4, 2);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(395, 973);
            panelMenu.TabIndex = 0;
            // 
            // btnUsersMgmt
            // 
            btnUsersMgmt.Dock = DockStyle.Top;
            btnUsersMgmt.FlatAppearance.BorderSize = 0;
            btnUsersMgmt.FlatStyle = FlatStyle.Flat;
            btnUsersMgmt.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            btnUsersMgmt.Font = new Font("Trebuchet MS", 10F, FontStyle.Bold);
            btnUsersMgmt.ForeColor = Color.FromArgb(15, 255, 255, 255);
            btnUsersMgmt.IconChar = FontAwesome.Sharp.IconChar.UserPen;
            btnUsersMgmt.IconColor = SystemColors.Highlight;
            btnUsersMgmt.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnUsersMgmt.ImageAlign = ContentAlignment.MiddleLeft;
            btnUsersMgmt.Location = new Point(0, 803);
            btnUsersMgmt.Name = "btnUsersMgmt";
            btnUsersMgmt.Padding = new Padding(30, 0, 0, 0);
            btnUsersMgmt.Size = new Size(395, 70);
            btnUsersMgmt.TabIndex = 9;
            btnUsersMgmt.Text = "Users Management";
            btnUsersMgmt.TextAlign = ContentAlignment.MiddleRight;
            btnUsersMgmt.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUsersMgmt.UseVisualStyleBackColor = true;
            btnUsersMgmt.Click += btnUsersMgmt_Click_1;
            // 
            // btnLogout
            // 
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            btnLogout.Font = new Font("Trebuchet MS", 10F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.IconChar = FontAwesome.Sharp.IconChar.ArrowUpRightFromSquare;
            btnLogout.IconColor = Color.Brown;
            btnLogout.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLogout.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogout.Location = new Point(0, 903);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(35, 0, 0, 0);
            btnLogout.Size = new Size(395, 70);
            btnLogout.TabIndex = 8;
            btnLogout.Text = "Logout";
            btnLogout.TextAlign = ContentAlignment.MiddleRight;
            btnLogout.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnReports
            // 
            btnReports.Dock = DockStyle.Top;
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            btnReports.Font = new Font("Trebuchet MS", 10F, FontStyle.Bold);
            btnReports.ForeColor = Color.FromArgb(15, 255, 255, 255);
            btnReports.IconChar = FontAwesome.Sharp.IconChar.FileInvoice;
            btnReports.IconColor = SystemColors.Highlight;
            btnReports.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnReports.ImageAlign = ContentAlignment.MiddleLeft;
            btnReports.Location = new Point(0, 733);
            btnReports.Name = "btnReports";
            btnReports.Padding = new Padding(30, 0, 0, 0);
            btnReports.Size = new Size(395, 70);
            btnReports.TabIndex = 7;
            btnReports.Text = "Reports";
            btnReports.TextAlign = ContentAlignment.MiddleRight;
            btnReports.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click;
            // 
            // btnMaintenances
            // 
            btnMaintenances.Dock = DockStyle.Top;
            btnMaintenances.FlatAppearance.BorderSize = 0;
            btnMaintenances.FlatStyle = FlatStyle.Flat;
            btnMaintenances.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            btnMaintenances.Font = new Font("Trebuchet MS", 10F, FontStyle.Bold);
            btnMaintenances.ForeColor = Color.FromArgb(15, 255, 255, 255);
            btnMaintenances.IconChar = FontAwesome.Sharp.IconChar.Tools;
            btnMaintenances.IconColor = SystemColors.Highlight;
            btnMaintenances.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMaintenances.ImageAlign = ContentAlignment.MiddleLeft;
            btnMaintenances.Location = new Point(0, 663);
            btnMaintenances.Name = "btnMaintenances";
            btnMaintenances.Padding = new Padding(30, 0, 0, 0);
            btnMaintenances.Size = new Size(395, 70);
            btnMaintenances.TabIndex = 6;
            btnMaintenances.Text = "Maintenances";
            btnMaintenances.TextAlign = ContentAlignment.MiddleRight;
            btnMaintenances.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMaintenances.UseVisualStyleBackColor = true;
            btnMaintenances.Click += btnMaintenances_Click;
            // 
            // btnReturns
            // 
            btnReturns.Dock = DockStyle.Top;
            btnReturns.FlatAppearance.BorderSize = 0;
            btnReturns.FlatStyle = FlatStyle.Flat;
            btnReturns.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            btnReturns.Font = new Font("Trebuchet MS", 10F, FontStyle.Bold);
            btnReturns.ForeColor = Color.FromArgb(15, 255, 255, 255);
            btnReturns.IconChar = FontAwesome.Sharp.IconChar.ArrowCircleDown;
            btnReturns.IconColor = SystemColors.Highlight;
            btnReturns.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnReturns.ImageAlign = ContentAlignment.MiddleLeft;
            btnReturns.Location = new Point(0, 593);
            btnReturns.Name = "btnReturns";
            btnReturns.Padding = new Padding(30, 0, 0, 0);
            btnReturns.Size = new Size(395, 70);
            btnReturns.TabIndex = 5;
            btnReturns.Text = "Returns";
            btnReturns.TextAlign = ContentAlignment.MiddleRight;
            btnReturns.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReturns.UseVisualStyleBackColor = true;
            btnReturns.Click += btnReturns_Click;
            // 
            // btnRentals
            // 
            btnRentals.Dock = DockStyle.Top;
            btnRentals.FlatAppearance.BorderSize = 0;
            btnRentals.FlatStyle = FlatStyle.Flat;
            btnRentals.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            btnRentals.Font = new Font("Trebuchet MS", 10F, FontStyle.Bold);
            btnRentals.ForeColor = Color.FromArgb(15, 255, 255, 255);
            btnRentals.IconChar = FontAwesome.Sharp.IconChar.Key;
            btnRentals.IconColor = SystemColors.Highlight;
            btnRentals.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRentals.ImageAlign = ContentAlignment.MiddleLeft;
            btnRentals.Location = new Point(0, 523);
            btnRentals.Name = "btnRentals";
            btnRentals.Padding = new Padding(30, 0, 0, 0);
            btnRentals.Size = new Size(395, 70);
            btnRentals.TabIndex = 4;
            btnRentals.Text = "Rentals";
            btnRentals.TextAlign = ContentAlignment.MiddleRight;
            btnRentals.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRentals.UseVisualStyleBackColor = true;
            btnRentals.Click += btnRentals_Click;
            // 
            // btnCustomers
            // 
            btnCustomers.Dock = DockStyle.Top;
            btnCustomers.FlatAppearance.BorderSize = 0;
            btnCustomers.FlatStyle = FlatStyle.Flat;
            btnCustomers.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            btnCustomers.Font = new Font("Trebuchet MS", 10F, FontStyle.Bold);
            btnCustomers.ForeColor = Color.FromArgb(15, 255, 255, 255);
            btnCustomers.IconChar = FontAwesome.Sharp.IconChar.UserFriends;
            btnCustomers.IconColor = SystemColors.Highlight;
            btnCustomers.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCustomers.ImageAlign = ContentAlignment.MiddleLeft;
            btnCustomers.Location = new Point(0, 453);
            btnCustomers.Name = "btnCustomers";
            btnCustomers.Padding = new Padding(30, 0, 0, 0);
            btnCustomers.Size = new Size(395, 70);
            btnCustomers.TabIndex = 3;
            btnCustomers.Text = "Customers";
            btnCustomers.TextAlign = ContentAlignment.MiddleRight;
            btnCustomers.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCustomers.UseVisualStyleBackColor = true;
            btnCustomers.Click += btnCustomers_Click;
            // 
            // btnVehicles
            // 
            btnVehicles.Dock = DockStyle.Top;
            btnVehicles.FlatAppearance.BorderSize = 0;
            btnVehicles.FlatStyle = FlatStyle.Flat;
            btnVehicles.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            btnVehicles.Font = new Font("Trebuchet MS", 10F, FontStyle.Bold);
            btnVehicles.ForeColor = Color.FromArgb(15, 255, 255, 255);
            btnVehicles.IconChar = FontAwesome.Sharp.IconChar.Car;
            btnVehicles.IconColor = SystemColors.Highlight;
            btnVehicles.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnVehicles.ImageAlign = ContentAlignment.MiddleLeft;
            btnVehicles.Location = new Point(0, 383);
            btnVehicles.Name = "btnVehicles";
            btnVehicles.Padding = new Padding(30, 0, 0, 0);
            btnVehicles.Size = new Size(395, 70);
            btnVehicles.TabIndex = 2;
            btnVehicles.Text = "Vehicles";
            btnVehicles.TextAlign = ContentAlignment.MiddleRight;
            btnVehicles.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnVehicles.UseVisualStyleBackColor = true;
            btnVehicles.Click += btnVehicles_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.FromArgb(108, 92, 231);
            btnDashboard.Dock = DockStyle.Top;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            btnDashboard.Font = new Font("Trebuchet MS", 10F, FontStyle.Bold);
            btnDashboard.ForeColor = Color.FromArgb(15, 255, 255, 255);
            btnDashboard.IconChar = FontAwesome.Sharp.IconChar.HomeLg;
            btnDashboard.IconColor = SystemColors.Highlight;
            btnDashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDashboard.ImageAlign = ContentAlignment.MiddleLeft;
            btnDashboard.Location = new Point(0, 313);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(30, 0, 0, 0);
            btnDashboard.Size = new Size(395, 70);
            btnDashboard.TabIndex = 1;
            btnDashboard.Text = "Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleRight;
            btnDashboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblWelcome);
            panel1.Controls.Add(pictureBoxStaff);
            panel1.Dock = DockStyle.Top;
            panel1.Font = new Font("Trebuchet MS", 11F, FontStyle.Bold);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 2, 4, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(395, 313);
            panel1.TabIndex = 0;
            // 
            // lblWelcome
            // 
            lblWelcome.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Trebuchet MS", 10F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.FromArgb(30, 30, 47);
            lblWelcome.Location = new Point(27, 265);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(328, 35);
            lblWelcome.TabIndex = 3;
            lblWelcome.Text = "Mr. Mextenserst (Admin)";
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBoxStaff
            // 
            pictureBoxStaff.BackColor = Color.FromArgb(108, 92, 231);
            pictureBoxStaff.Image = Properties.Resources.Untitled__1_1;
            pictureBoxStaff.ImageLocation = "";
            pictureBoxStaff.Location = new Point(13, 11);
            pictureBoxStaff.Margin = new Padding(4, 2, 4, 2);
            pictureBoxStaff.Name = "pictureBoxStaff";
            pictureBoxStaff.Size = new Size(342, 252);
            pictureBoxStaff.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxStaff.TabIndex = 0;
            pictureBoxStaff.TabStop = false;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(108, 92, 231);
            panelTitleBar.Controls.Add(panel2);
            panelTitleBar.Controls.Add(lblTitle);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(395, 0);
            panelTitleBar.Margin = new Padding(4, 2, 4, 2);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(1292, 125);
            panelTitleBar.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(108, 92, 231);
            panel2.Controls.Add(btnMin);
            panel2.Controls.Add(btnMax);
            panel2.Controls.Add(lblCarrental);
            panel2.Controls.Add(btnClose);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1292, 40);
            panel2.TabIndex = 1;
            // 
            // btnMin
            // 
            btnMin.Dock = DockStyle.Right;
            btnMin.FlatAppearance.BorderSize = 0;
            btnMin.FlatStyle = FlatStyle.Flat;
            btnMin.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            btnMin.IconColor = Color.Black;
            btnMin.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMin.Location = new Point(1172, 0);
            btnMin.Margin = new Padding(10);
            btnMin.Name = "btnMin";
            btnMin.Padding = new Padding(30, 10, 30, 10);
            btnMin.Size = new Size(40, 40);
            btnMin.TabIndex = 1;
            btnMin.UseVisualStyleBackColor = true;
            btnMin.Click += btnMin_Click;
            // 
            // btnMax
            // 
            btnMax.Dock = DockStyle.Right;
            btnMax.FlatAppearance.BorderSize = 0;
            btnMax.FlatStyle = FlatStyle.Flat;
            btnMax.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            btnMax.IconColor = Color.Black;
            btnMax.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMax.Location = new Point(1212, 0);
            btnMax.Margin = new Padding(10);
            btnMax.Name = "btnMax";
            btnMax.Padding = new Padding(30, 10, 30, 10);
            btnMax.Size = new Size(40, 40);
            btnMax.TabIndex = 2;
            btnMax.UseVisualStyleBackColor = true;
            btnMax.Click += btnMax_Click;
            // 
            // lblCarrental
            // 
            lblCarrental.Anchor = AnchorStyles.None;
            lblCarrental.AutoSize = true;
            lblCarrental.Font = new Font("Trebuchet MS", 10F, FontStyle.Bold);
            lblCarrental.ForeColor = Color.FromArgb(30, 30, 47);
            lblCarrental.Location = new Point(469, 0);
            lblCarrental.Name = "lblCarrental";
            lblCarrental.Size = new Size(414, 35);
            lblCarrental.TabIndex = 0;
            lblCarrental.Text = "Car Rental Management System";
            lblCarrental.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            btnClose.Dock = DockStyle.Right;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.IconChar = FontAwesome.Sharp.IconChar.X;
            btnClose.IconColor = Color.OrangeRed;
            btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClose.Location = new Point(1252, 0);
            btnClose.Margin = new Padding(10);
            btnClose.Name = "btnClose";
            btnClose.Padding = new Padding(10);
            btnClose.Size = new Size(40, 40);
            btnClose.TabIndex = 0;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Trebuchet MS", 15F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 53);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(607, 49);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Car Rental Management System";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelDesktop
            // 
            panelDesktop.BackColor = Color.FromArgb(30, 30, 47);
            panelDesktop.BackgroundImage = Properties.Resources.dashboard;
            panelDesktop.BackgroundImageLayout = ImageLayout.Zoom;
            panelDesktop.Dock = DockStyle.Fill;
            panelDesktop.Location = new Point(395, 125);
            panelDesktop.Margin = new Padding(4, 2, 4, 2);
            panelDesktop.Name = "panelDesktop";
            panelDesktop.Size = new Size(1292, 848);
            panelDesktop.TabIndex = 2;
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1687, 973);
            Controls.Add(panelDesktop);
            Controls.Add(panelTitleBar);
            Controls.Add(panelMenu);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 2, 4, 2);
            Name = "Dashboard";
            StartPosition = FormStartPosition.WindowsDefaultBounds;
            Text = "Dashboard";
            WindowState = FormWindowState.Maximized;
            Load += Dashboard_Load;
            panelMenu.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxStaff).EndInit();
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private Panel panel1;
        private Panel panelTitleBar;
        private Panel panelDesktop;
        private PictureBox pictureBoxStaff;
        private FontAwesome.Sharp.IconButton btnDashboard;
        private FontAwesome.Sharp.IconButton btnReturns;
        private FontAwesome.Sharp.IconButton btnRentals;
        private FontAwesome.Sharp.IconButton btnCustomers;
        private FontAwesome.Sharp.IconButton btnVehicles;
        private FontAwesome.Sharp.IconButton btnLogout;
        private FontAwesome.Sharp.IconButton btnReports;
        private FontAwesome.Sharp.IconButton btnMaintenances;
        private FileSystemWatcher fileSystemWatcher1;
        private Label lblTitle;
        private Panel panel2;
        private Label lblCarrental;
        private FontAwesome.Sharp.IconButton btnClose;
        private FontAwesome.Sharp.IconButton btnMax;
        private FontAwesome.Sharp.IconButton btnMin;
        private System.Windows.Forms.Timer menuTimer;
        private FontAwesome.Sharp.IconButton btnUsersMgmt;
        private Label lblWelcome;
    }
}