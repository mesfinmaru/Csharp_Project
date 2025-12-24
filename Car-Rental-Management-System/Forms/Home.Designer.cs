namespace Car_Rental_Management_System.Forms
{
    partial class Home
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
            panel1 = new Panel();
            btnManageMaintenance = new FontAwesome.Sharp.IconButton();
            ManageRentals = new FontAwesome.Sharp.IconButton();
            btnManageVehicles = new FontAwesome.Sharp.IconButton();
            btnManageCustomer = new FontAwesome.Sharp.IconButton();
            panel4 = new Panel();
            lblAvailableVehicles = new Label();
            label8 = new Label();
            panel3 = new Panel();
            lblActiveRentals = new Label();
            label6 = new Label();
            panel2 = new Panel();
            lblTotalVehicles = new Label();
            label4 = new Label();
            panel5 = new Panel();
            label1 = new Label();
            lblTotalCustomers = new Label();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnManageMaintenance);
            panel1.Controls.Add(ManageRentals);
            panel1.Controls.Add(btnManageVehicles);
            panel1.Controls.Add(btnManageCustomer);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(panel5);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1843, 711);
            panel1.TabIndex = 0;
            // 
            // btnManageMaintenance
            // 
            btnManageMaintenance.BackColor = Color.FromArgb(124, 77, 255);
            btnManageMaintenance.FlatStyle = FlatStyle.Flat;
            btnManageMaintenance.Font = new Font("Segoe UI", 10F);
            btnManageMaintenance.IconChar = FontAwesome.Sharp.IconChar.None;
            btnManageMaintenance.IconColor = Color.Black;
            btnManageMaintenance.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnManageMaintenance.Location = new Point(1411, 420);
            btnManageMaintenance.Name = "btnManageMaintenance";
            btnManageMaintenance.Size = new Size(400, 115);
            btnManageMaintenance.TabIndex = 15;
            btnManageMaintenance.Text = "Manage Maintenance";
            btnManageMaintenance.UseVisualStyleBackColor = false;
            // 
            // ManageRentals
            // 
            ManageRentals.BackColor = Color.Orchid;
            ManageRentals.FlatStyle = FlatStyle.Flat;
            ManageRentals.Font = new Font("Segoe UI", 10F);
            ManageRentals.IconChar = FontAwesome.Sharp.IconChar.None;
            ManageRentals.IconColor = Color.Black;
            ManageRentals.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ManageRentals.Location = new Point(955, 420);
            ManageRentals.Name = "ManageRentals";
            ManageRentals.Size = new Size(400, 115);
            ManageRentals.TabIndex = 14;
            ManageRentals.Text = "Manage Rentals";
            ManageRentals.UseVisualStyleBackColor = false;
            // 
            // btnManageVehicles
            // 
            btnManageVehicles.BackColor = Color.DarkGray;
            btnManageVehicles.FlatStyle = FlatStyle.Flat;
            btnManageVehicles.Font = new Font("Segoe UI", 10F);
            btnManageVehicles.IconChar = FontAwesome.Sharp.IconChar.None;
            btnManageVehicles.IconColor = Color.Black;
            btnManageVehicles.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnManageVehicles.Location = new Point(492, 420);
            btnManageVehicles.Name = "btnManageVehicles";
            btnManageVehicles.Size = new Size(400, 115);
            btnManageVehicles.TabIndex = 13;
            btnManageVehicles.Text = "Manage Vehicles";
            btnManageVehicles.UseVisualStyleBackColor = false;
            // 
            // btnManageCustomer
            // 
            btnManageCustomer.BackColor = Color.RoyalBlue;
            btnManageCustomer.FlatStyle = FlatStyle.Flat;
            btnManageCustomer.Font = new Font("Segoe UI", 10F);
            btnManageCustomer.IconChar = FontAwesome.Sharp.IconChar.None;
            btnManageCustomer.IconColor = Color.Black;
            btnManageCustomer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnManageCustomer.Location = new Point(39, 420);
            btnManageCustomer.Name = "btnManageCustomer";
            btnManageCustomer.Size = new Size(400, 115);
            btnManageCustomer.TabIndex = 12;
            btnManageCustomer.Text = "Manage Customers";
            btnManageCustomer.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(45, 45, 65);
            panel4.Controls.Add(lblAvailableVehicles);
            panel4.Controls.Add(label8);
            panel4.Location = new Point(1411, 129);
            panel4.Name = "panel4";
            panel4.Size = new Size(400, 200);
            panel4.TabIndex = 11;
            // 
            // lblAvailableVehicles
            // 
            lblAvailableVehicles.AutoSize = true;
            lblAvailableVehicles.BackColor = Color.Transparent;
            lblAvailableVehicles.Font = new Font("Segoe UI", 17F);
            lblAvailableVehicles.ForeColor = Color.SlateBlue;
            lblAvailableVehicles.Location = new Point(187, 115);
            lblAvailableVehicles.Name = "lblAvailableVehicles";
            lblAvailableVehicles.Size = new Size(52, 62);
            lblAvailableVehicles.TabIndex = 1;
            lblAvailableVehicles.Text = "0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 15F);
            label8.ForeColor = Color.LavenderBlush;
            label8.Location = new Point(43, 32);
            label8.Name = "label8";
            label8.Size = new Size(335, 54);
            label8.TabIndex = 2;
            label8.Text = "Available Vehicles";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(45, 45, 65);
            panel3.Controls.Add(lblActiveRentals);
            panel3.Controls.Add(label6);
            panel3.Location = new Point(955, 129);
            panel3.Name = "panel3";
            panel3.Size = new Size(400, 200);
            panel3.TabIndex = 9;
            // 
            // lblActiveRentals
            // 
            lblActiveRentals.AutoSize = true;
            lblActiveRentals.BackColor = Color.Transparent;
            lblActiveRentals.Font = new Font("Segoe UI", 17F);
            lblActiveRentals.ForeColor = Color.Orchid;
            lblActiveRentals.Location = new Point(167, 115);
            lblActiveRentals.Name = "lblActiveRentals";
            lblActiveRentals.Size = new Size(52, 62);
            lblActiveRentals.TabIndex = 3;
            lblActiveRentals.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 15F);
            label6.ForeColor = Color.GhostWhite;
            label6.Location = new Point(67, 32);
            label6.Name = "label6";
            label6.Size = new Size(270, 54);
            label6.TabIndex = 2;
            label6.Text = "Active Rentals";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(45, 45, 65);
            panel2.Controls.Add(lblTotalVehicles);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(492, 129);
            panel2.Name = "panel2";
            panel2.Size = new Size(400, 200);
            panel2.TabIndex = 10;
            // 
            // lblTotalVehicles
            // 
            lblTotalVehicles.AutoSize = true;
            lblTotalVehicles.BackColor = Color.Transparent;
            lblTotalVehicles.Font = new Font("Segoe UI", 17F);
            lblTotalVehicles.ForeColor = Color.Gray;
            lblTotalVehicles.Location = new Point(173, 115);
            lblTotalVehicles.Name = "lblTotalVehicles";
            lblTotalVehicles.Size = new Size(52, 62);
            lblTotalVehicles.TabIndex = 3;
            lblTotalVehicles.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 15F);
            label4.ForeColor = Color.FloralWhite;
            label4.Location = new Point(68, 29);
            label4.Name = "label4";
            label4.Size = new Size(260, 54);
            label4.TabIndex = 2;
            label4.Text = "Total Vehicles";
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(45, 45, 65);
            panel5.Controls.Add(label1);
            panel5.Controls.Add(lblTotalCustomers);
            panel5.Location = new Point(39, 129);
            panel5.Name = "panel5";
            panel5.Size = new Size(400, 200);
            panel5.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 15F);
            label1.ForeColor = Color.AliceBlue;
            label1.Location = new Point(46, 28);
            label1.Name = "label1";
            label1.Size = new Size(306, 54);
            label1.TabIndex = 0;
            label1.Text = "Total Customers";
            // 
            // lblTotalCustomers
            // 
            lblTotalCustomers.AutoSize = true;
            lblTotalCustomers.BackColor = Color.Transparent;
            lblTotalCustomers.Font = new Font("Segoe UI", 17F);
            lblTotalCustomers.ForeColor = Color.RoyalBlue;
            lblTotalCustomers.Location = new Point(164, 115);
            lblTotalCustomers.Name = "lblTotalCustomers";
            lblTotalCustomers.Size = new Size(52, 62);
            lblTotalCustomers.TabIndex = 3;
            lblTotalCustomers.Text = "0";
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 47);
            ClientSize = new Size(1843, 711);
            Controls.Add(panel1);
            ForeColor = Color.FromArgb(30, 30, 47);
            Name = "Home";
            Text = "Home";
            Load += Home_Load;
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private FontAwesome.Sharp.IconButton btnManageMaintenance;
        private FontAwesome.Sharp.IconButton ManageRentals;
        private FontAwesome.Sharp.IconButton btnManageVehicles;
        private FontAwesome.Sharp.IconButton btnManageCustomer;
        private Panel panel4;
        private Label lblAvailableVehicles;
        private Label label8;
        private Panel panel3;
        private Label lblActiveRentals;
        private Label label6;
        private Panel panel2;
        private Label lblTotalVehicles;
        private Label label4;
        private Panel panel5;
        private Label label1;
        private Label lblTotalCustomers;
    }
}