namespace Car_Rental_Management_System.Forms
{
    partial class EditCustomer
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
            dtpExpiryDate = new DateTimePicker();
            txtCity = new TextBox();
            label1 = new Label();
            txtCountry = new TextBox();
            lblPasswd = new Label();
            lblExpryDate = new Label();
            lblRole = new Label();
            cmbLicenseType = new ComboBox();
            label4 = new Label();
            txtPhoneNumber = new TextBox();
            lblUsername = new Label();
            txtEmail = new TextBox();
            label2 = new Label();
            txtAddress = new TextBox();
            txtLicenseNumber = new TextBox();
            groupBox2 = new GroupBox();
            lblPhone = new Label();
            txtFullName = new TextBox();
            groupBox1 = new GroupBox();
            lblFullname = new Label();
            formPanel = new Panel();
            ButtonsPanel = new Panel();
            btnActiveDeactive = new Button();
            btnSave = new Button();
            btnCancel = new Button();
            mainPanel = new Panel();
            lblAdminMessage = new Label();
            lblHeader = new Label();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            formPanel.SuspendLayout();
            ButtonsPanel.SuspendLayout();
            mainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // dtpExpiryDate
            // 
            dtpExpiryDate.Location = new Point(271, 191);
            dtpExpiryDate.Name = "dtpExpiryDate";
            dtpExpiryDate.Size = new Size(377, 39);
            dtpExpiryDate.TabIndex = 20;
            // 
            // txtCity
            // 
            txtCity.Font = new Font("Trebuchet MS", 10.125F);
            txtCity.Location = new Point(268, 331);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(380, 39);
            txtCity.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Trebuchet MS", 10.125F);
            label1.Location = new Point(43, 334);
            label1.Name = "label1";
            label1.Size = new Size(63, 35);
            label1.TabIndex = 18;
            label1.Text = "City";
            // 
            // txtCountry
            // 
            txtCountry.Font = new Font("Trebuchet MS", 10.125F);
            txtCountry.Location = new Point(268, 401);
            txtCountry.Name = "txtCountry";
            txtCountry.Size = new Size(380, 39);
            txtCountry.TabIndex = 17;
            // 
            // lblPasswd
            // 
            lblPasswd.AutoSize = true;
            lblPasswd.Font = new Font("Trebuchet MS", 10.125F);
            lblPasswd.Location = new Point(46, 125);
            lblPasswd.Name = "lblPasswd";
            lblPasswd.Size = new Size(209, 35);
            lblPasswd.TabIndex = 18;
            lblPasswd.Text = "License Number";
            // 
            // lblExpryDate
            // 
            lblExpryDate.AutoSize = true;
            lblExpryDate.Font = new Font("Trebuchet MS", 10.125F);
            lblExpryDate.Location = new Point(48, 195);
            lblExpryDate.Name = "lblExpryDate";
            lblExpryDate.Size = new Size(155, 35);
            lblExpryDate.TabIndex = 16;
            lblExpryDate.Text = "Expiry Date";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Trebuchet MS", 10.125F);
            lblRole.Location = new Point(46, 55);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(170, 35);
            lblRole.TabIndex = 15;
            lblRole.Text = "License Type";
            // 
            // cmbLicenseType
            // 
            cmbLicenseType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLicenseType.Font = new Font("Trebuchet MS", 10.125F);
            cmbLicenseType.FormattingEnabled = true;
            cmbLicenseType.Items.AddRange(new object[] { "Class A", "Class B", "Class C", "Class D", "Class E", "International" });
            cmbLicenseType.Location = new Point(271, 52);
            cmbLicenseType.Name = "cmbLicenseType";
            cmbLicenseType.Size = new Size(380, 43);
            cmbLicenseType.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Trebuchet MS", 10.125F);
            label4.Location = new Point(43, 404);
            label4.Name = "label4";
            label4.Size = new Size(110, 35);
            label4.TabIndex = 16;
            label4.Text = "Country";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Font = new Font("Trebuchet MS", 10.125F);
            txtPhoneNumber.Location = new Point(268, 117);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(380, 39);
            txtPhoneNumber.TabIndex = 15;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Trebuchet MS", 10.125F);
            lblUsername.Location = new Point(43, 120);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(191, 35);
            lblUsername.TabIndex = 14;
            lblUsername.Text = "Phone Number";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Trebuchet MS", 10.125F);
            txtEmail.Location = new Point(268, 187);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(380, 39);
            txtEmail.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Trebuchet MS", 10.125F);
            label2.Location = new Point(43, 190);
            label2.Name = "label2";
            label2.Size = new Size(81, 35);
            label2.TabIndex = 12;
            label2.Text = "Email";
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Trebuchet MS", 10.125F);
            txtAddress.Location = new Point(268, 257);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(380, 39);
            txtAddress.TabIndex = 11;
            // 
            // txtLicenseNumber
            // 
            txtLicenseNumber.Font = new Font("Trebuchet MS", 10.125F);
            txtLicenseNumber.Location = new Point(271, 122);
            txtLicenseNumber.Name = "txtLicenseNumber";
            txtLicenseNumber.Size = new Size(380, 39);
            txtLicenseNumber.TabIndex = 19;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dtpExpiryDate);
            groupBox2.Controls.Add(txtLicenseNumber);
            groupBox2.Controls.Add(lblPasswd);
            groupBox2.Controls.Add(lblExpryDate);
            groupBox2.Controls.Add(lblRole);
            groupBox2.Controls.Add(cmbLicenseType);
            groupBox2.Location = new Point(3, 478);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(715, 254);
            groupBox2.TabIndex = 16;
            groupBox2.TabStop = false;
            groupBox2.Text = "License Information";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Trebuchet MS", 10.125F);
            lblPhone.Location = new Point(43, 260);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(109, 35);
            lblPhone.TabIndex = 10;
            lblPhone.Text = "Address";
            // 
            // txtFullName
            // 
            txtFullName.BackColor = Color.White;
            txtFullName.Font = new Font("Trebuchet MS", 10.125F);
            txtFullName.Location = new Point(268, 47);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(380, 39);
            txtFullName.TabIndex = 9;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtCity);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtCountry);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtPhoneNumber);
            groupBox1.Controls.Add(lblUsername);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtAddress);
            groupBox1.Controls.Add(lblPhone);
            groupBox1.Controls.Add(txtFullName);
            groupBox1.Controls.Add(lblFullname);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(715, 469);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "Personal Information";
            // 
            // lblFullname
            // 
            lblFullname.AutoSize = true;
            lblFullname.Font = new Font("Trebuchet MS", 10.125F);
            lblFullname.Location = new Point(43, 47);
            lblFullname.Name = "lblFullname";
            lblFullname.Size = new Size(128, 35);
            lblFullname.TabIndex = 8;
            lblFullname.Text = "FullName";
            // 
            // formPanel
            // 
            formPanel.AutoScroll = true;
            formPanel.Controls.Add(groupBox2);
            formPanel.Controls.Add(groupBox1);
            formPanel.Controls.Add(ButtonsPanel);
            formPanel.Dock = DockStyle.Fill;
            formPanel.Location = new Point(20, 57);
            formPanel.Name = "formPanel";
            formPanel.Size = new Size(760, 861);
            formPanel.TabIndex = 1;
            // 
            // ButtonsPanel
            // 
            ButtonsPanel.Controls.Add(btnActiveDeactive);
            ButtonsPanel.Controls.Add(btnSave);
            ButtonsPanel.Controls.Add(btnCancel);
            ButtonsPanel.Dock = DockStyle.Bottom;
            ButtonsPanel.Location = new Point(0, 748);
            ButtonsPanel.Name = "ButtonsPanel";
            ButtonsPanel.Size = new Size(760, 113);
            ButtonsPanel.TabIndex = 14;
            // 
            // btnActiveDeactive
            // 
            btnActiveDeactive.Location = new Point(298, 29);
            btnActiveDeactive.Name = "btnActiveDeactive";
            btnActiveDeactive.Size = new Size(180, 60);
            btnActiveDeactive.TabIndex = 2;
            btnActiveDeactive.Text = "Deactivate";
            btnActiveDeactive.UseVisualStyleBackColor = true;
            btnActiveDeactive.Click += btnActiveDeactive_Click_1;
            // 
            // btnSave
            // 
            btnSave.DialogResult = DialogResult.OK;
            btnSave.Location = new Point(527, 29);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(180, 60);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click_1;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(66, 29);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(180, 60);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click_1;
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(lblAdminMessage);
            mainPanel.Controls.Add(formPanel);
            mainPanel.Controls.Add(lblHeader);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(20);
            mainPanel.Size = new Size(800, 938);
            mainPanel.TabIndex = 2;
            // 
            // lblAdminMessage
            // 
            lblAdminMessage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblAdminMessage.AutoSize = true;
            lblAdminMessage.ForeColor = Color.IndianRed;
            lblAdminMessage.Location = new Point(350, 58);
            lblAdminMessage.Name = "lblAdminMessage";
            lblAdminMessage.Size = new Size(0, 32);
            lblAdminMessage.TabIndex = 23;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Dock = DockStyle.Top;
            lblHeader.FlatStyle = FlatStyle.Flat;
            lblHeader.Font = new Font("Trebuchet MS", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.Location = new Point(20, 20);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(210, 37);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Edit Customer";
            lblHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // EditCustomer
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 938);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EditCustomer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EditCustomer";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            formPanel.ResumeLayout(false);
            ButtonsPanel.ResumeLayout(false);
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dtpExpiryDate;
        private TextBox txtCity;
        private Label label1;
        private TextBox txtCountry;
        private Label lblPasswd;
        private Label lblExpryDate;
        private Label lblRole;
        private ComboBox cmbLicenseType;
        private Label label4;
        private TextBox txtPhoneNumber;
        private Label lblUsername;
        private TextBox txtEmail;
        private Label label2;
        private TextBox txtAddress;
        private TextBox txtLicenseNumber;
        private GroupBox groupBox2;
        private Label lblPhone;
        private TextBox txtFullName;
        private GroupBox groupBox1;
        private Label lblFullname;
        private Panel formPanel;
        private Panel ButtonsPanel;
        private Button btnSave;
        private Button btnCancel;
        private Panel mainPanel;
        private Label lblAdminMessage;
        private Label lblHeader;
        private Button btnActiveDeactive;
    }
}