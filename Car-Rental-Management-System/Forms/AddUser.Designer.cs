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
            lblHeader = new Label();
            ButtonsPanel = new Panel();
            btnAdd = new Button();
            btnCancel = new Button();
            txtPassword = new TextBox();
            lblPasswd = new Label();
            txtVonfirmPassword = new TextBox();
            label3 = new Label();
            lblRole = new Label();
            formPanel = new Panel();
            cmbRole = new ComboBox();
            txtUsername = new TextBox();
            lblUsername = new Label();
            txtEmail = new TextBox();
            label2 = new Label();
            txtPhone = new TextBox();
            lblPhone = new Label();
            txtFullName = new TextBox();
            lblFullname = new Label();
            mainPanel = new Panel();
            ButtonsPanel.SuspendLayout();
            formPanel.SuspendLayout();
            mainPanel.SuspendLayout();
            SuspendLayout();
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
            // ButtonsPanel
            // 
            ButtonsPanel.Controls.Add(btnAdd);
            ButtonsPanel.Controls.Add(btnCancel);
            ButtonsPanel.Dock = DockStyle.Bottom;
            ButtonsPanel.Location = new Point(0, 584);
            ButtonsPanel.Name = "ButtonsPanel";
            ButtonsPanel.Size = new Size(706, 113);
            ButtonsPanel.TabIndex = 14;
            // 
            // btnAdd
            // 
            btnAdd.DialogResult = DialogResult.OK;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Trebuchet MS", 10.125F, FontStyle.Bold);
            btnAdd.Location = new Point(378, 29);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(180, 60);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Trebuchet MS", 10.125F, FontStyle.Bold);
            btnCancel.Location = new Point(116, 29);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(180, 60);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Trebuchet MS", 10.125F);
            txtPassword.Location = new Point(249, 380);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(380, 39);
            txtPassword.TabIndex = 13;
            txtPassword.TextChanged += txtPassword_TextChanged;
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
            // txtVonfirmPassword
            // 
            txtVonfirmPassword.Font = new Font("Trebuchet MS", 10.125F);
            txtVonfirmPassword.Location = new Point(249, 450);
            txtVonfirmPassword.Name = "txtVonfirmPassword";
            txtVonfirmPassword.Size = new Size(380, 39);
            txtVonfirmPassword.TabIndex = 11;
            txtVonfirmPassword.TextChanged += txtVonfirmPassword_TextChanged;
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
            // formPanel
            // 
            formPanel.AutoScroll = true;
            formPanel.Controls.Add(ButtonsPanel);
            formPanel.Controls.Add(txtPassword);
            formPanel.Controls.Add(lblPasswd);
            formPanel.Controls.Add(txtVonfirmPassword);
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
            formPanel.Size = new Size(706, 697);
            formPanel.TabIndex = 1;
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
            cmbRole.SelectedIndexChanged += cmbRole_SelectedIndexChanged;
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Trebuchet MS", 10.125F);
            txtUsername.Location = new Point(249, 100);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(380, 39);
            txtUsername.TabIndex = 7;
            txtUsername.TextChanged += txtUsername_TextChanged;
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
            txtEmail.TextChanged += txtEmail_TextChanged;
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
            txtPhone.TextChanged += txtPhone_TextChanged;
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
            txtFullName.Font = new Font("Trebuchet MS", 10.125F);
            txtFullName.Location = new Point(249, 30);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(380, 39);
            txtFullName.TabIndex = 1;
            txtFullName.TextChanged += txtFullName_TextChanged;
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
            // mainPanel
            // 
            mainPanel.Controls.Add(formPanel);
            mainPanel.Controls.Add(lblHeader);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(20);
            mainPanel.Size = new Size(746, 774);
            mainPanel.TabIndex = 1;
            mainPanel.Paint += mainPanel_Paint;
            // 
            // AddUser
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(746, 774);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "AddUser";
            Text = "AddUser";
            Load += AddUser_Load;
            ButtonsPanel.ResumeLayout(false);
            formPanel.ResumeLayout(false);
            formPanel.PerformLayout();
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblHeader;
        private Panel ButtonsPanel;
        private Button btnAdd;
        private Button btnCancel;
        private TextBox txtPassword;
        private Label lblPasswd;
        private TextBox txtVonfirmPassword;
        private Label label3;
        private Label lblRole;
        private Panel formPanel;
        private ComboBox cmbRole;
        private TextBox txtUsername;
        private Label lblUsername;
        private TextBox txtEmail;
        private Label label2;
        private TextBox txtPhone;
        private Label lblPhone;
        private TextBox txtFullName;
        private Label lblFullname;
        private Panel mainPanel;
    }
}