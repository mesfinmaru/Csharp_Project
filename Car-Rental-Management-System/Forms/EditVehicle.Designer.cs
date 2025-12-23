namespace Car_Rental_Management_System.Forms
{
    partial class EditVehicle
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
            label6 = new Label();
            label14 = new Label();
            nurYear = new NumericUpDown();
            txtFeatures = new TextBox();
            cmbVehicleType = new ComboBox();
            groupBox3 = new GroupBox();
            nurDailyRate = new NumericUpDown();
            nurWeeklyRate = new NumericUpDown();
            nurMonthlyRate = new NumericUpDown();
            cmbStatus = new ComboBox();
            label12 = new Label();
            label15 = new Label();
            label13 = new Label();
            label11 = new Label();
            nurMileage = new NumericUpDown();
            nurSeats = new NumericUpDown();
            cmbTransmission = new ComboBox();
            cmbFuelType = new ComboBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            txtEngineNumber = new TextBox();
            label4 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtVIN = new TextBox();
            label9 = new Label();
            label10 = new Label();
            txtModel = new TextBox();
            lblUsername = new Label();
            txtColor = new TextBox();
            label2 = new Label();
            txtPlateNumber = new TextBox();
            lblFullname = new Label();
            formPanel = new Panel();
            groupBox1 = new GroupBox();
            txtMake = new TextBox();
            label3 = new Label();
            label5 = new Label();
            ButtonsPanel = new Panel();
            btnSave = new Button();
            btnCancel = new Button();
            lblAdminMessage = new Label();
            lblHeader = new Label();
            mainPanel = new Panel();
            ((System.ComponentModel.ISupportInitialize)nurYear).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nurDailyRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nurWeeklyRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nurMonthlyRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nurMileage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nurSeats).BeginInit();
            groupBox2.SuspendLayout();
            formPanel.SuspendLayout();
            groupBox1.SuspendLayout();
            ButtonsPanel.SuspendLayout();
            mainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Trebuchet MS", 10.125F);
            label6.Location = new Point(544, 46);
            label6.Name = "label6";
            label6.Size = new Size(167, 35);
            label6.TabIndex = 20;
            label6.Text = "Vehicle Type";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Trebuchet MS", 10.125F);
            label14.Location = new Point(40, 131);
            label14.Name = "label14";
            label14.Size = new Size(175, 35);
            label14.TabIndex = 53;
            label14.Text = "Monthly Rate";
            // 
            // nurYear
            // 
            nurYear.Location = new Point(769, 187);
            nurYear.Name = "nurYear";
            nurYear.Size = new Size(237, 39);
            nurYear.TabIndex = 39;
            // 
            // txtFeatures
            // 
            txtFeatures.Font = new Font("Trebuchet MS", 10.125F);
            txtFeatures.Location = new Point(268, 267);
            txtFeatures.Name = "txtFeatures";
            txtFeatures.Size = new Size(738, 39);
            txtFeatures.TabIndex = 43;
            // 
            // cmbVehicleType
            // 
            cmbVehicleType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVehicleType.Font = new Font("Trebuchet MS", 10.125F);
            cmbVehicleType.FormattingEnabled = true;
            cmbVehicleType.Items.AddRange(new object[] { "Sedan", "SUV", "Truck", "Van", "Hatchback", "Convertible" });
            cmbVehicleType.Location = new Point(769, 44);
            cmbVehicleType.Name = "cmbVehicleType";
            cmbVehicleType.Size = new Size(237, 43);
            cmbVehicleType.TabIndex = 21;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(nurDailyRate);
            groupBox3.Controls.Add(nurWeeklyRate);
            groupBox3.Controls.Add(nurMonthlyRate);
            groupBox3.Controls.Add(cmbStatus);
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(label15);
            groupBox3.Controls.Add(label13);
            groupBox3.Controls.Add(label14);
            groupBox3.Location = new Point(6, 604);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1051, 233);
            groupBox3.TabIndex = 52;
            groupBox3.TabStop = false;
            groupBox3.Text = "Rental Infromation";
            // 
            // nurDailyRate
            // 
            nurDailyRate.Location = new Point(265, 59);
            nurDailyRate.Name = "nurDailyRate";
            nurDailyRate.Size = new Size(237, 39);
            nurDailyRate.TabIndex = 60;
            // 
            // nurWeeklyRate
            // 
            nurWeeklyRate.Location = new Point(766, 54);
            nurWeeklyRate.Name = "nurWeeklyRate";
            nurWeeklyRate.Size = new Size(237, 39);
            nurWeeklyRate.TabIndex = 59;
            // 
            // nurMonthlyRate
            // 
            nurMonthlyRate.Location = new Point(265, 130);
            nurMonthlyRate.Name = "nurMonthlyRate";
            nurMonthlyRate.Size = new Size(237, 39);
            nurMonthlyRate.TabIndex = 58;
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Trebuchet MS", 10.125F);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Available", "Rented", "Maintenance", "Reserved" });
            cmbStatus.Location = new Point(766, 126);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(237, 43);
            cmbStatus.TabIndex = 55;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Trebuchet MS", 10.125F);
            label12.Location = new Point(541, 130);
            label12.Name = "label12";
            label12.Size = new Size(90, 35);
            label12.TabIndex = 56;
            label12.Text = "Status";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Trebuchet MS", 10.125F);
            label15.Location = new Point(40, 58);
            label15.Name = "label15";
            label15.Size = new Size(139, 35);
            label15.TabIndex = 52;
            label15.Text = "Daily Rate";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Trebuchet MS", 10.125F);
            label13.Location = new Point(541, 57);
            label13.Name = "label13";
            label13.Size = new Size(166, 35);
            label13.TabIndex = 54;
            label13.Text = "Weekly Rate";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Trebuchet MS", 10.125F);
            label11.Location = new Point(43, 270);
            label11.Name = "label11";
            label11.Size = new Size(121, 35);
            label11.TabIndex = 42;
            label11.Text = "Features";
            // 
            // nurMileage
            // 
            nurMileage.Location = new Point(769, 129);
            nurMileage.Name = "nurMileage";
            nurMileage.Size = new Size(237, 39);
            nurMileage.TabIndex = 41;
            // 
            // nurSeats
            // 
            nurSeats.Location = new Point(268, 132);
            nurSeats.Name = "nurSeats";
            nurSeats.Size = new Size(237, 39);
            nurSeats.TabIndex = 41;
            nurSeats.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cmbTransmission
            // 
            cmbTransmission.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTransmission.Font = new Font("Trebuchet MS", 10.125F);
            cmbTransmission.FormattingEnabled = true;
            cmbTransmission.Items.AddRange(new object[] { "Automatic", "Manual" });
            cmbTransmission.Location = new Point(268, 57);
            cmbTransmission.Name = "cmbTransmission";
            cmbTransmission.Size = new Size(237, 43);
            cmbTransmission.TabIndex = 38;
            // 
            // cmbFuelType
            // 
            cmbFuelType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFuelType.Font = new Font("Trebuchet MS", 10.125F);
            cmbFuelType.FormattingEnabled = true;
            cmbFuelType.Items.AddRange(new object[] { "Petrol", "Diesel", "Electric", "Hybrid" });
            cmbFuelType.Location = new Point(769, 57);
            cmbFuelType.Name = "cmbFuelType";
            cmbFuelType.Size = new Size(237, 43);
            cmbFuelType.TabIndex = 33;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Trebuchet MS", 10.125F);
            label1.Location = new Point(544, 132);
            label1.Name = "label1";
            label1.Size = new Size(109, 35);
            label1.TabIndex = 36;
            label1.Text = "Mileage";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtFeatures);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(nurMileage);
            groupBox2.Controls.Add(nurSeats);
            groupBox2.Controls.Add(cmbTransmission);
            groupBox2.Controls.Add(cmbFuelType);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(txtEngineNumber);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(txtVIN);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label10);
            groupBox2.Location = new Point(3, 262);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1051, 336);
            groupBox2.TabIndex = 16;
            groupBox2.TabStop = false;
            groupBox2.Text = "Vehicle Details";
            // 
            // txtEngineNumber
            // 
            txtEngineNumber.Font = new Font("Trebuchet MS", 10.125F);
            txtEngineNumber.Location = new Point(769, 199);
            txtEngineNumber.Name = "txtEngineNumber";
            txtEngineNumber.Size = new Size(237, 39);
            txtEngineNumber.TabIndex = 35;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Trebuchet MS", 10.125F);
            label4.Location = new Point(544, 202);
            label4.Name = "label4";
            label4.Size = new Size(199, 35);
            label4.TabIndex = 34;
            label4.Text = "Engine Number";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Trebuchet MS", 10.125F);
            label7.Location = new Point(544, 59);
            label7.Name = "label7";
            label7.Size = new Size(131, 35);
            label7.TabIndex = 32;
            label7.Text = "Fuel Type";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Trebuchet MS", 10.125F);
            label8.Location = new Point(43, 133);
            label8.Name = "label8";
            label8.Size = new Size(79, 35);
            label8.TabIndex = 30;
            label8.Text = "Seats";
            // 
            // txtVIN
            // 
            txtVIN.Font = new Font("Trebuchet MS", 10.125F);
            txtVIN.Location = new Point(268, 200);
            txtVIN.Name = "txtVIN";
            txtVIN.Size = new Size(237, 39);
            txtVIN.TabIndex = 29;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Trebuchet MS", 10.125F);
            label9.Location = new Point(43, 203);
            label9.Name = "label9";
            label9.Size = new Size(56, 35);
            label9.TabIndex = 28;
            label9.Text = "VIN";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Trebuchet MS", 10.125F);
            label10.Location = new Point(43, 60);
            label10.Name = "label10";
            label10.Size = new Size(168, 35);
            label10.TabIndex = 26;
            label10.Text = "Transmission";
            // 
            // txtModel
            // 
            txtModel.Font = new Font("Trebuchet MS", 10.125F);
            txtModel.Location = new Point(268, 117);
            txtModel.Name = "txtModel";
            txtModel.Size = new Size(237, 39);
            txtModel.TabIndex = 15;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Trebuchet MS", 10.125F);
            lblUsername.Location = new Point(43, 120);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(87, 35);
            lblUsername.TabIndex = 14;
            lblUsername.Text = "Model";
            // 
            // txtColor
            // 
            txtColor.Font = new Font("Trebuchet MS", 10.125F);
            txtColor.Location = new Point(268, 187);
            txtColor.Name = "txtColor";
            txtColor.Size = new Size(237, 39);
            txtColor.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Trebuchet MS", 10.125F);
            label2.Location = new Point(43, 190);
            label2.Name = "label2";
            label2.Size = new Size(78, 35);
            label2.TabIndex = 12;
            label2.Text = "Color";
            // 
            // txtPlateNumber
            // 
            txtPlateNumber.BackColor = Color.White;
            txtPlateNumber.Font = new Font("Trebuchet MS", 10.125F);
            txtPlateNumber.Location = new Point(268, 47);
            txtPlateNumber.Name = "txtPlateNumber";
            txtPlateNumber.Size = new Size(237, 39);
            txtPlateNumber.TabIndex = 9;
            // 
            // lblFullname
            // 
            lblFullname.AutoSize = true;
            lblFullname.Font = new Font("Trebuchet MS", 10.125F);
            lblFullname.Location = new Point(43, 47);
            lblFullname.Name = "lblFullname";
            lblFullname.Size = new Size(181, 35);
            lblFullname.TabIndex = 8;
            lblFullname.Text = "Plate Number";
            // 
            // formPanel
            // 
            formPanel.AutoScroll = true;
            formPanel.Controls.Add(groupBox3);
            formPanel.Controls.Add(groupBox2);
            formPanel.Controls.Add(groupBox1);
            formPanel.Controls.Add(ButtonsPanel);
            formPanel.Dock = DockStyle.Fill;
            formPanel.Location = new Point(20, 57);
            formPanel.Name = "formPanel";
            formPanel.Size = new Size(1060, 958);
            formPanel.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(nurYear);
            groupBox1.Controls.Add(cmbVehicleType);
            groupBox1.Controls.Add(txtMake);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtModel);
            groupBox1.Controls.Add(lblUsername);
            groupBox1.Controls.Add(txtColor);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtPlateNumber);
            groupBox1.Controls.Add(lblFullname);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1051, 259);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "Basic Information";
            // 
            // txtMake
            // 
            txtMake.Font = new Font("Trebuchet MS", 10.125F);
            txtMake.Location = new Point(769, 116);
            txtMake.Name = "txtMake";
            txtMake.Size = new Size(237, 39);
            txtMake.TabIndex = 25;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Trebuchet MS", 10.125F);
            label3.Location = new Point(544, 119);
            label3.Name = "label3";
            label3.Size = new Size(78, 35);
            label3.TabIndex = 24;
            label3.Text = "Make";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Trebuchet MS", 10.125F);
            label5.Location = new Point(544, 189);
            label5.Name = "label5";
            label5.Size = new Size(67, 35);
            label5.TabIndex = 22;
            label5.Text = "Year";
            // 
            // ButtonsPanel
            // 
            ButtonsPanel.Controls.Add(btnSave);
            ButtonsPanel.Controls.Add(btnCancel);
            ButtonsPanel.Dock = DockStyle.Bottom;
            ButtonsPanel.Location = new Point(0, 845);
            ButtonsPanel.Name = "ButtonsPanel";
            ButtonsPanel.Size = new Size(1060, 113);
            ButtonsPanel.TabIndex = 14;
            // 
            // btnSave
            // 
            btnSave.DialogResult = DialogResult.OK;
            btnSave.Location = new Point(598, 29);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(180, 60);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save Changes";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click_1;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(266, 29);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(180, 60);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click_1;
            // 
            // lblAdminMessage
            // 
            lblAdminMessage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblAdminMessage.AutoSize = true;
            lblAdminMessage.ForeColor = Color.IndianRed;
            lblAdminMessage.Location = new Point(370, 78);
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
            lblHeader.Size = new Size(181, 37);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Edit Vehicle";
            lblHeader.TextAlign = ContentAlignment.MiddleLeft;
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
            mainPanel.Size = new Size(1100, 1035);
            mainPanel.TabIndex = 3;
            // 
            // EditVehicle
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 1035);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EditVehicle";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EditVehicle";
            Load += EditVehicle_Load;
            ((System.ComponentModel.ISupportInitialize)nurYear).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nurDailyRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)nurWeeklyRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)nurMonthlyRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)nurMileage).EndInit();
            ((System.ComponentModel.ISupportInitialize)nurSeats).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            formPanel.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ButtonsPanel.ResumeLayout(false);
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label6;
        private Label label14;
        private NumericUpDown nurYear;
        private TextBox txtFeatures;
        private ComboBox cmbVehicleType;
        private GroupBox groupBox3;
        private NumericUpDown nurDailyRate;
        private NumericUpDown nurWeeklyRate;
        private NumericUpDown nurMonthlyRate;
        private ComboBox cmbStatus;
        private Label label12;
        private Label label15;
        private Label label13;
        private Label label11;
        private NumericUpDown nurMileage;
        private NumericUpDown nurSeats;
        private ComboBox cmbTransmission;
        private ComboBox cmbFuelType;
        private Label label1;
        private GroupBox groupBox2;
        private TextBox txtEngineNumber;
        private Label label4;
        private Label label7;
        private Label label8;
        private TextBox txtVIN;
        private Label label9;
        private Label label10;
        private TextBox txtModel;
        private Label lblUsername;
        private TextBox txtColor;
        private Label label2;
        private TextBox txtPlateNumber;
        private Label lblFullname;
        private Panel formPanel;
        private GroupBox groupBox1;
        private TextBox txtMake;
        private Label label3;
        private Label label5;
        private Panel ButtonsPanel;
        private Button btnSave;
        private Button btnCancel;
        private Label lblAdminMessage;
        private Label lblHeader;
        private Panel mainPanel;
    }
}