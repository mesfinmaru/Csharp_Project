namespace Car_Rental_Management_System.Forms
{
    partial class AddUser
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
            mainPanel = new Panel();
            lblAdminMessage = new Label();
            btnClose = new FontAwesome.Sharp.IconButton();
            formPanel = new Panel();
            ButtonsPanel = new Panel();
            btnAdd = new Button();
            btnCancel = new Button();
            txtPassword = new TextBox();
            lblPasswd = new Label();
            txtConfirmPassword = new TextBox();
            label3 = new Label();
            lblRole = new Label();
            cmbRole = new ComboBox();
            txtUsername = new TextBox();
            lblUsername = new Label();
            txtEmail = new TextBox();
            label2 = new Label();
            txtPhone = new TextBox();
            lblPhone = new Label();
            txtFullName = new TextBox();
            lblFullname = new Label();
            lblHeader = new Label();
            toolTip1 = new ToolTip(components);
            mainPanel.SuspendLayout();
            formPanel.SuspendLayout();
            ButtonsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(lblAdminMessage);
            mainPanel.Controls.Add(btnClose);
            mainPanel.Controls.Add(formPanel);
            mainPanel.Controls.Add(lblHeader);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(20);
            mainPanel.Size = new Size(724, 729);
            mainPanel.TabIndex = 0;
            // 
            // lblAdminMessage
            // 
            lblAdminMessage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblAdminMessage.AutoSize = true;
            lblAdminMessage.ForeColor = Color.IndianRed;
            lblAdminMessage.Location = new Point(310, 18);
            lblAdminMessage.Name = "lblAdminMessage";
            lblAdminMessage.Size = new Size(0, 32);
            lblAdminMessage.TabIndex = 23;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.IconChar = FontAwesome.Sharp.IconChar.X;
            btnClose.IconColor = Color.IndianRed;
            btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClose.Location = new Point(665, 12);
            btnClose.Margin = new Padding(10);
            btnClose.Name = "btnClose";
            btnClose.Padding = new Padding(10);
            btnClose.Size = new Size(40, 45);
            btnClose.TabIndex = 2;
            btnClose.UseVisualStyleBackColor = true;
            // 
            // formPanel
            // 
            formPanel.AutoScroll = true;
            formPanel.Controls.Add(ButtonsPanel);
            formPanel.Controls.Add(txtPassword);
            formPanel.Controls.Add(lblPasswd);
            formPanel.Controls.Add(txtConfirmPassword);
            formPanel.Controls.Add(label3);
            formPanel.Controls.Add(lblRole);
            formPanel.Controls.Add(cmbRole);
            formPanel.Controls.Add(txtUsername);
            formPanel.Controls.Add(lblUsername);
            formPanel.Controls.Add(txtEmail);
            formPanel.Controls.Add(label2);
            formPanel.Controls.Add(txtPhone);
            formPanel.Controls.Add(lblPhone);
            formPanel.Controls.Add(txtFullName);
            formPanel.Controls.Add(lblFullname);
            formPanel.Dock = DockStyle.Fill;
            formPanel.Location = new Point(20, 57);
            formPanel.Name = "formPanel";
            formPanel.Size = new Size(684, 652);
            formPanel.TabIndex = 1;
            formPanel.Paint += formPanel_Paint;
            // 
            // ButtonsPanel
            // 
            ButtonsPanel.Controls.Add(btnAdd);
            ButtonsPanel.Controls.Add(btnCancel);
            ButtonsPanel.Dock = DockStyle.Bottom;
            ButtonsPanel.Location = new Point(0, 539);
            ButtonsPanel.Name = "ButtonsPanel";
            ButtonsPanel.Size = new Size(684, 113);
            ButtonsPanel.TabIndex = 14;
            // 
            // btnAdd
            // 
            btnAdd.DialogResult = DialogResult.OK;
            btnAdd.Location = new Point(378, 29);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(180, 60);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Save";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click_1;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(116, 29);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(180, 60);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click_1;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Trebuchet MS", 10.125F);
            txtPassword.Location = new Point(249, 380);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(380, 39);
            txtPassword.TabIndex = 13;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPasswd
            // 
            lblPasswd.AutoSize = true;
            lblPasswd.Font = new Font("Trebuchet MS", 10.125F);
            lblPasswd.Location = new Point(24, 383);
            lblPasswd.Name = "lblPasswd";
            lblPasswd.Size = new Size(125, 35);
            lblPasswd.TabIndex = 12;
            lblPasswd.Text = "Password";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Font = new Font("Trebuchet MS", 10.125F);
            txtConfirmPassword.Location = new Point(249, 450);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(380, 39);
            txtConfirmPassword.TabIndex = 11;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Trebuchet MS", 10.125F);
            label3.Location = new Point(20, 453);
            label3.Name = "label3";
            label3.Size = new Size(229, 35);
            label3.TabIndex = 10;
            label3.Text = "Confirm Password";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Trebuchet MS", 10.125F);
            lblRole.Location = new Point(24, 313);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(67, 35);
            lblRole.TabIndex = 9;
            lblRole.Text = "Role";
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Font = new Font("Trebuchet MS", 10.125F);
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "Staff", "Admin" });
            cmbRole.Location = new Point(249, 310);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(380, 43);
            cmbRole.TabIndex = 8;
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Trebuchet MS", 10.125F);
            txtUsername.Location = new Point(249, 100);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(380, 39);
            txtUsername.TabIndex = 7;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Trebuchet MS", 10.125F);
            lblUsername.Location = new Point(24, 103);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(136, 35);
            lblUsername.TabIndex = 6;
            lblUsername.Text = "Username";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Trebuchet MS", 10.125F);
            txtEmail.Location = new Point(249, 170);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(380, 39);
            txtEmail.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Trebuchet MS", 10.125F);
            label2.Location = new Point(24, 173);
            label2.Name = "label2";
            label2.Size = new Size(81, 35);
            label2.TabIndex = 4;
            label2.Text = "Email";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Trebuchet MS", 10.125F);
            txtPhone.Location = new Point(249, 240);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(380, 39);
            txtPhone.TabIndex = 3;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Trebuchet MS", 10.125F);
            lblPhone.Location = new Point(24, 243);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(88, 35);
            lblPhone.TabIndex = 2;
            lblPhone.Text = "Phone";
            // 
            // txtFullName
            // 
            txtFullName.BackColor = Color.White;
            txtFullName.Font = new Font("Trebuchet MS", 10.125F);
            txtFullName.Location = new Point(249, 30);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(380, 39);
            txtFullName.TabIndex = 1;
            txtFullName.TextChanged += txtFullName_TextChanged_1;
            // 
            // lblFullname
            // 
            lblFullname.AutoSize = true;
            lblFullname.Font = new Font("Trebuchet MS", 10.125F);
            lblFullname.Location = new Point(24, 30);
            lblFullname.Name = "lblFullname";
            lblFullname.Size = new Size(128, 35);
            lblFullname.TabIndex = 0;
            lblFullname.Text = "FullName";
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Dock = DockStyle.Top;
            lblHeader.FlatStyle = FlatStyle.Flat;
            lblHeader.Font = new Font("Trebuchet MS", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.Location = new Point(20, 20);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(207, 37);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Add New User";
            lblHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AddUser
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(724, 729);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add New User";
            Load += AddUser_Load;
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            formPanel.ResumeLayout(false);
            formPanel.PerformLayout();
            ButtonsPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
        private Panel formPanel;
        private Label lblHeader;
        private TextBox txtFullName;
        private Label lblFullname;
        private TextBox txtUsername;
        private Label lblUsername;
        private TextBox txtEmail;
        private Label label2;
        private TextBox txtPhone;
        private Label lblPhone;
        private Label lblRole;
        private ComboBox cmbRole;
        private TextBox txtPassword;
        private Label lblPasswd;
        private TextBox txtConfirmPassword;
        private Label label3;
        private Panel ButtonsPanel;
        private Button btnAdd;
        private Button btnCancel;
        private ToolTip toolTip1;
        private FontAwesome.Sharp.IconButton btnClose;
        private Label lblAdminMessage;
    }
}