namespace Car_Rental_Management_System
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            panel2 = new Panel();
            btnMin = new FontAwesome.Sharp.IconButton();
            btnMax = new FontAwesome.Sharp.IconButton();
            btnClose = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            lblPassword = new Label();
            lblUsername = new Label();
            btnLogin = new FontAwesome.Sharp.IconButton();
            txtbPassword = new TextBox();
            txtbUsername = new TextBox();
            btnCancel = new FontAwesome.Sharp.IconButton();
            panel3 = new Panel();
            label1 = new Label();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(30, 30, 47);
            panel2.Controls.Add(btnMin);
            panel2.Controls.Add(btnMax);
            panel2.Controls.Add(btnClose);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1701, 45);
            panel2.TabIndex = 8;
            // 
            // btnMin
            // 
            btnMin.Dock = DockStyle.Right;
            btnMin.FlatAppearance.BorderSize = 0;
            btnMin.FlatStyle = FlatStyle.Flat;
            btnMin.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            btnMin.IconColor = Color.Gray;
            btnMin.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMin.Location = new Point(1581, 0);
            btnMin.Margin = new Padding(10);
            btnMin.Name = "btnMin";
            btnMin.Padding = new Padding(30, 10, 40, 25);
            btnMin.Size = new Size(40, 45);
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
            btnMax.IconColor = Color.Gray;
            btnMax.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMax.Location = new Point(1621, 0);
            btnMax.Margin = new Padding(10);
            btnMax.Name = "btnMax";
            btnMax.Padding = new Padding(50, 10, 50, 10);
            btnMax.Size = new Size(40, 45);
            btnMax.TabIndex = 2;
            btnMax.UseVisualStyleBackColor = true;
            btnMax.Click += btnMax_Click;
            // 
            // btnClose
            // 
            btnClose.Dock = DockStyle.Right;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.IconChar = FontAwesome.Sharp.IconChar.X;
            btnClose.IconColor = Color.IndianRed;
            btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClose.Location = new Point(1661, 0);
            btnClose.Margin = new Padding(10);
            btnClose.Name = "btnClose";
            btnClose.Padding = new Padding(10);
            btnClose.Size = new Size(40, 45);
            btnClose.TabIndex = 0;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(lblPassword);
            panel1.Controls.Add(lblUsername);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(txtbPassword);
            panel1.Controls.Add(txtbUsername);
            panel1.Controls.Add(btnCancel);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 45);
            panel1.Name = "panel1";
            panel1.Size = new Size(1701, 952);
            panel1.TabIndex = 9;
            panel1.Paint += panel1_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = Properties.Resources.Untitled__1_1;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1701, 203);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            // 
            // lblPassword
            // 
            lblPassword.Anchor = AnchorStyles.None;
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Trebuchet MS", 10F, FontStyle.Bold);
            lblPassword.ForeColor = SystemColors.Highlight;
            lblPassword.Location = new Point(492, 529);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(132, 35);
            lblPassword.TabIndex = 15;
            lblPassword.Text = "Password";
            // 
            // lblUsername
            // 
            lblUsername.Anchor = AnchorStyles.None;
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Trebuchet MS", 10F, FontStyle.Bold);
            lblUsername.ForeColor = SystemColors.Highlight;
            lblUsername.Location = new Point(492, 448);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(142, 35);
            lblUsername.TabIndex = 14;
            lblUsername.Text = "Username";
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.None;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Trebuchet MS", 10F, FontStyle.Bold);
            btnLogin.ForeColor = SystemColors.ButtonHighlight;
            btnLogin.IconChar = FontAwesome.Sharp.IconChar.None;
            btnLogin.IconColor = Color.Black;
            btnLogin.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLogin.Location = new Point(928, 645);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(201, 50);
            btnLogin.TabIndex = 13;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click_1;
            // 
            // txtbPassword
            // 
            txtbPassword.Anchor = AnchorStyles.None;
            txtbPassword.BackColor = Color.FromArgb(30, 30, 47);
            txtbPassword.ForeColor = SystemColors.ButtonHighlight;
            txtbPassword.Location = new Point(640, 529);
            txtbPassword.Name = "txtbPassword";
            txtbPassword.PlaceholderText = "Enter Password";
            txtbPassword.Size = new Size(489, 39);
            txtbPassword.TabIndex = 2;
            txtbPassword.UseSystemPasswordChar = true;
            // 
            // txtbUsername
            // 
            txtbUsername.Anchor = AnchorStyles.None;
            txtbUsername.BackColor = Color.FromArgb(30, 30, 47);
            txtbUsername.ForeColor = SystemColors.ButtonHighlight;
            txtbUsername.Location = new Point(640, 447);
            txtbUsername.Name = "txtbUsername";
            txtbUsername.PlaceholderText = "Enter Username";
            txtbUsername.Size = new Size(489, 39);
            txtbUsername.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.None;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Trebuchet MS", 10F, FontStyle.Bold);
            btnCancel.ForeColor = SystemColors.ButtonHighlight;
            btnCancel.IconChar = FontAwesome.Sharp.IconChar.None;
            btnCancel.IconColor = SystemColors.MenuHighlight;
            btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancel.Location = new Point(640, 645);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(201, 50);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(30, 30, 40);
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 920);
            panel3.Name = "panel3";
            panel3.Size = new Size(1701, 80);
            panel3.TabIndex = 18;
            panel3.Paint += panel3_Paint;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Trebuchet MS", 8F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(544, 30);
            label1.Name = "label1";
            label1.Size = new Size(638, 27);
            label1.TabIndex = 19;
            label1.Text = "Information Systems Group Two ©️ 2025 , All rights reserved.";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 47);
            ClientSize = new Size(1701, 1000);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            WindowState = FormWindowState.Maximized;
            Load += Login_Load;
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private FontAwesome.Sharp.IconButton btnMin;
        private FontAwesome.Sharp.IconButton btnMax;
        private FontAwesome.Sharp.IconButton btnClose;
        private Panel panel1;
        private Label lblPassword;
        private Label lblUsername;
        private FontAwesome.Sharp.IconButton btnLogin;
        private TextBox txtbPassword;
        private TextBox txtbUsername;
        private FontAwesome.Sharp.IconButton btnCancel;
        private PictureBox pictureBox1;
        private Panel panel3;
        private Label label1;
    }
}
