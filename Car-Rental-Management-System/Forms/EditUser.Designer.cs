namespace Car_Rental_Management_System.Forms
{
    partial class EditUser
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
            lblHeader = new Label();
            ButtonsPanel = new Panel();
            btnSave = new Button();
            btnCancel = new Button();
            txtPassword = new TextBox();
            lblPasswd = new Label();
            txtConfirmPassword = new TextBox();
            label3 = new Label();
            lblRole = new Label();
            mainPanel = new Panel();
            lblAdminNote = new Label();
            btnClose = new FontAwesome.Sharp.IconButton();
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
            toolTip1 = new ToolTip(components);
            ButtonsPanel.SuspendLayout();
            mainPanel.SuspendLayout();
            formPanel.SuspendLayout();
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
            lblHeader.Size = new Size(142, 37);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Edit User";
            lblHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ButtonsPanel
            // 
            ButtonsPanel.Controls.Add(btnSave);
            ButtonsPanel.Controls.Add(btnCancel);
            ButtonsPanel.Dock = DockStyle.Bottom;
            ButtonsPanel.Location = new Point(0, 539);
            ButtonsPanel.Name = "ButtonsPanel";
            ButtonsPanel.Size = new Size(684, 113);
            ButtonsPanel.TabIndex = 14;
            // 
            // btnSave
            // 
            btnSave.DialogResult = DialogResult.OK;
            btnSave.Location = new Point(378, 29);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(180, 60);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
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
            // mainPanel
            // 
            mainPanel.Controls.Add(lblAdminNote);
            mainPanel.Controls.Add(btnClose);
            mainPanel.Controls.Add(formPanel);
            mainPanel.Controls.Add(lblHeader);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(20);
            mainPanel.Size = new Size(724, 729);
            mainPanel.TabIndex = 1;
            mainPanel.Paint += mainPanel_Paint;
            // 
            // lblAdminNote
            // 
            lblAdminNote.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblAdminNote.AutoSize = true;
            lblAdminNote.ForeColor = Color.IndianRed;
            lblAdminNote.Location = new Point(180, 18);
            lblAdminNote.Name = "lblAdminNote";
            lblAdminNote.Size = new Size(0, 32);
            lblAdminNote.TabIndex = 24;
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
            txtFullName.Font = new Font("Trebuchet MS", 10.125F);
            txtFullName.Location = new Point(249, 30);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(380, 39);
            txtFullName.TabIndex = 1;
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
            // EditUser
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(724, 729);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EditUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EditUser";
            Load += EditUser_Load;
            ButtonsPanel.ResumeLayout(false);
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            formPanel.ResumeLayout(false);
            formPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblHeader;
        private Panel ButtonsPanel;
        private Button btnSave;
        private Button btnCancel;
        private TextBox txtPassword;
        private Label lblPasswd;
        private TextBox txtConfirmPassword;
        private Label label3;
        private Label lblRole;
        private Panel mainPanel;
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
        private ToolTip toolTip1;
        private FontAwesome.Sharp.IconButton btnClose;
        private Label lblAdminNote;
    }
}