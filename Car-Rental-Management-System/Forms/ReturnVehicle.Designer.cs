namespace Car_Rental_Management_System.Forms
{
    partial class ReturnVehicle
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
            lblHeader = new Label();
            groupBox4 = new GroupBox();
            lblTotalAmount = new Label();
            label14 = new Label();
            lblOriginalRate = new Label();
            label12 = new Label();
            lblRentalPeriod = new Label();
            label10 = new Label();
            lblVehicle = new Label();
            label8 = new Label();
            lblCustomer = new Label();
            label6 = new Label();
            groupBox1 = new GroupBox();
            lblPaymentRecieved = new Label();
            label16 = new Label();
            lblBalanceDue = new Label();
            label13 = new Label();
            lblOtherCharge = new Label();
            label15 = new Label();
            label11 = new Label();
            dtpActualReturnDate = new DateTimePicker();
            label9 = new Label();
            lblNewTotal = new Label();
            label2 = new Label();
            lblFuelCharge = new Label();
            label3 = new Label();
            lblDamageFee = new Label();
            label4 = new Label();
            lblTotalLateDays = new Label();
            label5 = new Label();
            lblLateFee = new Label();
            label7 = new Label();
            groupBox5 = new GroupBox();
            chbOtherIssues = new CheckBox();
            chbMajorDamage = new CheckBox();
            chbMinorScratches = new CheckBox();
            chbMechanicalIssue = new CheckBox();
            chbDented = new CheckBox();
            chbClean = new CheckBox();
            panel2 = new Panel();
            btnCalculate = new Button();
            btnCancel = new Button();
            btnCompleteReturn = new Button();
            panel1.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox5.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblHeader);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(872, 96);
            panel1.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.FlatStyle = FlatStyle.Flat;
            lblHeader.Font = new Font("Trebuchet MS", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.Location = new Point(30, 33);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(219, 37);
            lblHeader.TabIndex = 4;
            lblHeader.Text = "Return Vehicle";
            lblHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(lblTotalAmount);
            groupBox4.Controls.Add(label14);
            groupBox4.Controls.Add(lblOriginalRate);
            groupBox4.Controls.Add(label12);
            groupBox4.Controls.Add(lblRentalPeriod);
            groupBox4.Controls.Add(label10);
            groupBox4.Controls.Add(lblVehicle);
            groupBox4.Controls.Add(label8);
            groupBox4.Controls.Add(lblCustomer);
            groupBox4.Controls.Add(label6);
            groupBox4.Dock = DockStyle.Top;
            groupBox4.Location = new Point(0, 96);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(872, 332);
            groupBox4.TabIndex = 20;
            groupBox4.TabStop = false;
            groupBox4.Text = "Rental Information";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Trebuchet MS", 10.125F);
            lblTotalAmount.Location = new Point(327, 274);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(62, 35);
            lblTotalAmount.TabIndex = 24;
            lblTotalAmount.Text = "N/A";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Trebuchet MS", 10.125F);
            label14.Location = new Point(41, 274);
            label14.Name = "label14";
            label14.Size = new Size(193, 35);
            label14.TabIndex = 23;
            label14.Text = "Total Amount :";
            // 
            // lblOriginalRate
            // 
            lblOriginalRate.AutoSize = true;
            lblOriginalRate.Font = new Font("Trebuchet MS", 10.125F);
            lblOriginalRate.Location = new Point(327, 219);
            lblOriginalRate.Name = "lblOriginalRate";
            lblOriginalRate.Size = new Size(62, 35);
            lblOriginalRate.TabIndex = 22;
            lblOriginalRate.Text = "N/A";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Trebuchet MS", 10.125F);
            label12.Location = new Point(41, 219);
            label12.Name = "label12";
            label12.Size = new Size(193, 35);
            label12.TabIndex = 21;
            label12.Text = "Original Rate :";
            // 
            // lblRentalPeriod
            // 
            lblRentalPeriod.AutoSize = true;
            lblRentalPeriod.Font = new Font("Trebuchet MS", 10.125F);
            lblRentalPeriod.Location = new Point(327, 161);
            lblRentalPeriod.Name = "lblRentalPeriod";
            lblRentalPeriod.Size = new Size(62, 35);
            lblRentalPeriod.TabIndex = 20;
            lblRentalPeriod.Text = "N/A";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Trebuchet MS", 10.125F);
            label10.Location = new Point(41, 161);
            label10.Name = "label10";
            label10.Size = new Size(196, 35);
            label10.TabIndex = 19;
            label10.Text = "Rental Period :";
            // 
            // lblVehicle
            // 
            lblVehicle.AutoSize = true;
            lblVehicle.Font = new Font("Trebuchet MS", 10.125F);
            lblVehicle.Location = new Point(327, 106);
            lblVehicle.Name = "lblVehicle";
            lblVehicle.Size = new Size(62, 35);
            lblVehicle.TabIndex = 18;
            lblVehicle.Text = "N/A";
            lblVehicle.Click += lblVehicle_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Trebuchet MS", 10.125F);
            label8.Location = new Point(41, 106);
            label8.Name = "label8";
            label8.Size = new Size(121, 35);
            label8.TabIndex = 17;
            label8.Text = "Vehicle :";
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Font = new Font("Trebuchet MS", 10.125F);
            lblCustomer.Location = new Point(327, 52);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(62, 35);
            lblCustomer.TabIndex = 16;
            lblCustomer.Text = "N/A";
            lblCustomer.Click += lblCustomer_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Trebuchet MS", 10.125F);
            label6.Location = new Point(41, 52);
            label6.Name = "label6";
            label6.Size = new Size(148, 35);
            label6.TabIndex = 14;
            label6.Text = "Customer :";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblPaymentRecieved);
            groupBox1.Controls.Add(label16);
            groupBox1.Controls.Add(lblBalanceDue);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(lblOtherCharge);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(dtpActualReturnDate);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(lblNewTotal);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(lblFuelCharge);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(lblDamageFee);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(lblTotalLateDays);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(lblLateFee);
            groupBox1.Controls.Add(label7);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 428);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(872, 529);
            groupBox1.TabIndex = 25;
            groupBox1.TabStop = false;
            groupBox1.Text = "Return Details";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // lblPaymentRecieved
            // 
            lblPaymentRecieved.AutoSize = true;
            lblPaymentRecieved.Font = new Font("Trebuchet MS", 10.125F);
            lblPaymentRecieved.Location = new Point(389, 473);
            lblPaymentRecieved.Name = "lblPaymentRecieved";
            lblPaymentRecieved.Size = new Size(62, 35);
            lblPaymentRecieved.TabIndex = 33;
            lblPaymentRecieved.Text = "N/A";
            lblPaymentRecieved.Click += lblPaymentRecieved_Click;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Trebuchet MS", 10.125F);
            label16.Location = new Point(97, 473);
            label16.Name = "label16";
            label16.Size = new Size(254, 35);
            label16.TabIndex = 32;
            label16.Text = "Payment Recieved :";
            // 
            // lblBalanceDue
            // 
            lblBalanceDue.AutoSize = true;
            lblBalanceDue.Font = new Font("Trebuchet MS", 10.125F);
            lblBalanceDue.Location = new Point(385, 422);
            lblBalanceDue.Name = "lblBalanceDue";
            lblBalanceDue.Size = new Size(62, 35);
            lblBalanceDue.TabIndex = 31;
            lblBalanceDue.Text = "N/A";
            lblBalanceDue.Click += lblBalanceDue_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Trebuchet MS", 10.125F);
            label13.Location = new Point(97, 422);
            label13.Name = "label13";
            label13.Size = new Size(182, 35);
            label13.TabIndex = 30;
            label13.Text = "Balance Due :";
            // 
            // lblOtherCharge
            // 
            lblOtherCharge.AutoSize = true;
            lblOtherCharge.Font = new Font("Trebuchet MS", 10.125F);
            lblOtherCharge.Location = new Point(382, 326);
            lblOtherCharge.Name = "lblOtherCharge";
            lblOtherCharge.Size = new Size(62, 35);
            lblOtherCharge.TabIndex = 29;
            lblOtherCharge.Text = "N/A";
            lblOtherCharge.Click += lblOtherCharge_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Trebuchet MS", 10.125F);
            label15.Location = new Point(96, 326);
            label15.Name = "label15";
            label15.Size = new Size(196, 35);
            label15.TabIndex = 28;
            label15.Text = "Other Charge :";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Trebuchet MS", 10.125F);
            label11.Location = new Point(50, 109);
            label11.Name = "label11";
            label11.Size = new Size(261, 35);
            label11.TabIndex = 27;
            label11.Text = "Additional Charges :";
            // 
            // dtpActualReturnDate
            // 
            dtpActualReturnDate.Location = new Point(321, 55);
            dtpActualReturnDate.Name = "dtpActualReturnDate";
            dtpActualReturnDate.Size = new Size(252, 39);
            dtpActualReturnDate.TabIndex = 26;
            dtpActualReturnDate.ValueChanged += dtpActualReturnDate_ValueChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Trebuchet MS", 10.125F);
            label9.Location = new Point(50, 55);
            label9.Name = "label9";
            label9.Size = new Size(265, 35);
            label9.TabIndex = 25;
            label9.Text = "Actual Return Date :";
            // 
            // lblNewTotal
            // 
            lblNewTotal.AutoSize = true;
            lblNewTotal.Font = new Font("Trebuchet MS", 10.125F);
            lblNewTotal.Location = new Point(385, 380);
            lblNewTotal.Name = "lblNewTotal";
            lblNewTotal.Size = new Size(62, 35);
            lblNewTotal.TabIndex = 24;
            lblNewTotal.Text = "N/A";
            lblNewTotal.Click += lblNewTotal_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Trebuchet MS", 10.125F);
            label2.Location = new Point(97, 380);
            label2.Name = "label2";
            label2.Size = new Size(153, 35);
            label2.TabIndex = 23;
            label2.Text = "New Total :";
            // 
            // lblFuelCharge
            // 
            lblFuelCharge.AutoSize = true;
            lblFuelCharge.Font = new Font("Trebuchet MS", 10.125F);
            lblFuelCharge.Location = new Point(383, 287);
            lblFuelCharge.Name = "lblFuelCharge";
            lblFuelCharge.Size = new Size(62, 35);
            lblFuelCharge.TabIndex = 22;
            lblFuelCharge.Text = "N/A";
            lblFuelCharge.Click += lblFuelCharge_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Trebuchet MS", 10.125F);
            label3.Location = new Point(97, 287);
            label3.Name = "label3";
            label3.Size = new Size(178, 35);
            label3.TabIndex = 21;
            label3.Text = "Fuel Charge :";
            // 
            // lblDamageFee
            // 
            lblDamageFee.AutoSize = true;
            lblDamageFee.Font = new Font("Trebuchet MS", 10.125F);
            lblDamageFee.Location = new Point(383, 247);
            lblDamageFee.Name = "lblDamageFee";
            lblDamageFee.Size = new Size(62, 35);
            lblDamageFee.TabIndex = 20;
            lblDamageFee.Text = "N/A";
            lblDamageFee.Click += lblDamageFee_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Trebuchet MS", 10.125F);
            label4.Location = new Point(97, 247);
            label4.Name = "label4";
            label4.Size = new Size(181, 35);
            label4.TabIndex = 19;
            label4.Text = "Damage Fee :";
            // 
            // lblTotalLateDays
            // 
            lblTotalLateDays.AutoSize = true;
            lblTotalLateDays.Font = new Font("Trebuchet MS", 10.125F);
            lblTotalLateDays.Location = new Point(382, 194);
            lblTotalLateDays.Name = "lblTotalLateDays";
            lblTotalLateDays.Size = new Size(62, 35);
            lblTotalLateDays.TabIndex = 18;
            lblTotalLateDays.Text = "N/A";
            lblTotalLateDays.Click += lblTotalLateDays_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Trebuchet MS", 10.125F);
            label5.Location = new Point(93, 194);
            label5.Name = "label5";
            label5.Size = new Size(218, 35);
            label5.TabIndex = 17;
            label5.Text = "Total Late Days :";
            // 
            // lblLateFee
            // 
            lblLateFee.AutoSize = true;
            lblLateFee.Font = new Font("Trebuchet MS", 10.125F);
            lblLateFee.Location = new Point(382, 156);
            lblLateFee.Name = "lblLateFee";
            lblLateFee.Size = new Size(62, 35);
            lblLateFee.TabIndex = 16;
            lblLateFee.Text = "N/A";
            lblLateFee.Click += lblLateFee_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Trebuchet MS", 10.125F);
            label7.Location = new Point(93, 156);
            label7.Name = "label7";
            label7.Size = new Size(139, 35);
            label7.TabIndex = 14;
            label7.Text = "Late Fee :";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(chbOtherIssues);
            groupBox5.Controls.Add(chbMajorDamage);
            groupBox5.Controls.Add(chbMinorScratches);
            groupBox5.Controls.Add(chbMechanicalIssue);
            groupBox5.Controls.Add(chbDented);
            groupBox5.Controls.Add(chbClean);
            groupBox5.Dock = DockStyle.Top;
            groupBox5.Location = new Point(0, 957);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(872, 267);
            groupBox5.TabIndex = 26;
            groupBox5.TabStop = false;
            groupBox5.Text = "Vehicle Condition";
            // 
            // chbOtherIssues
            // 
            chbOtherIssues.AutoSize = true;
            chbOtherIssues.Location = new Point(387, 197);
            chbOtherIssues.Name = "chbOtherIssues";
            chbOtherIssues.Size = new Size(177, 36);
            chbOtherIssues.TabIndex = 5;
            chbOtherIssues.Text = "Other Issues";
            chbOtherIssues.UseVisualStyleBackColor = true;
            chbOtherIssues.CheckedChanged += chbOtherIssues_CheckedChanged;
            // 
            // chbMajorDamage
            // 
            chbMajorDamage.AutoSize = true;
            chbMajorDamage.Location = new Point(387, 129);
            chbMajorDamage.Name = "chbMajorDamage";
            chbMajorDamage.Size = new Size(204, 36);
            chbMajorDamage.TabIndex = 4;
            chbMajorDamage.Text = "Major Damage";
            chbMajorDamage.UseVisualStyleBackColor = true;
            chbMajorDamage.CheckedChanged += chbMajorDamage_CheckedChanged;
            // 
            // chbMinorScratches
            // 
            chbMinorScratches.AutoSize = true;
            chbMinorScratches.Location = new Point(387, 62);
            chbMinorScratches.Name = "chbMinorScratches";
            chbMinorScratches.Size = new Size(217, 36);
            chbMinorScratches.TabIndex = 3;
            chbMinorScratches.Text = "Minor Scratches";
            chbMinorScratches.UseVisualStyleBackColor = true;
            chbMinorScratches.CheckedChanged += chbMinorScratches_CheckedChanged;
            // 
            // chbMechanicalIssue
            // 
            chbMechanicalIssue.AutoSize = true;
            chbMechanicalIssue.Location = new Point(113, 197);
            chbMechanicalIssue.Name = "chbMechanicalIssue";
            chbMechanicalIssue.Size = new Size(227, 36);
            chbMechanicalIssue.TabIndex = 2;
            chbMechanicalIssue.Text = "Mechanical Issue";
            chbMechanicalIssue.UseVisualStyleBackColor = true;
            chbMechanicalIssue.CheckedChanged += chbMechanicalIssue_CheckedChanged;
            // 
            // chbDented
            // 
            chbDented.AutoSize = true;
            chbDented.Location = new Point(113, 129);
            chbDented.Name = "chbDented";
            chbDented.Size = new Size(125, 36);
            chbDented.TabIndex = 1;
            chbDented.Text = "Dented";
            chbDented.UseVisualStyleBackColor = true;
            chbDented.CheckedChanged += chbDented_CheckedChanged;
            // 
            // chbClean
            // 
            chbClean.AutoSize = true;
            chbClean.Location = new Point(113, 62);
            chbClean.Name = "chbClean";
            chbClean.Size = new Size(106, 36);
            chbClean.TabIndex = 0;
            chbClean.Text = "Clean";
            chbClean.UseVisualStyleBackColor = true;
            chbClean.CheckedChanged += chbClean_CheckedChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnCalculate);
            panel2.Controls.Add(btnCancel);
            panel2.Controls.Add(btnCompleteReturn);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 1212);
            panel2.Name = "panel2";
            panel2.Size = new Size(872, 101);
            panel2.TabIndex = 27;
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(303, 28);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(150, 46);
            btnCalculate.TabIndex = 20;
            btnCalculate.Text = "Calculate";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(96, 28);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 46);
            btnCancel.TabIndex = 19;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnCompleteReturn
            // 
            btnCompleteReturn.Location = new Point(508, 28);
            btnCompleteReturn.Name = "btnCompleteReturn";
            btnCompleteReturn.Size = new Size(232, 46);
            btnCompleteReturn.TabIndex = 18;
            btnCompleteReturn.Text = "Complete Return";
            btnCompleteReturn.UseVisualStyleBackColor = true;
            btnCompleteReturn.Click += btnCompleteReturn_Click;
            // 
            // ReturnVehicle
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(872, 1313);
            Controls.Add(panel2);
            Controls.Add(groupBox5);
            Controls.Add(groupBox1);
            Controls.Add(groupBox4);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ReturnVehicle";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ReturnVehicle";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblHeader;
        private GroupBox groupBox4;
        private Label lblTotalAmount;
        private Label label14;
        private Label lblOriginalRate;
        private Label label12;
        private Label lblRentalPeriod;
        private Label label10;
        private Label lblVehicle;
        private Label label8;
        private Label lblCustomer;
        private Label label6;
        private GroupBox groupBox1;
        private Label label9;
        private Label lblNewTotal;
        private Label label2;
        private Label lblFuelCharge;
        private Label label3;
        private Label lblDamageFee;
        private Label label4;
        private Label lblTotalLateDays;
        private Label label5;
        private Label lblLateFee;
        private Label label7;
        private DateTimePicker dtpActualReturnDate;
        private Label label11;
        private Label lblOtherCharge;
        private Label label15;
        private Label lblPaymentRecieved;
        private Label label16;
        private Label lblBalanceDue;
        private Label label13;
        private GroupBox groupBox5;
        private CheckBox chbOtherIssues;
        private CheckBox chbMajorDamage;
        private CheckBox chbMinorScratches;
        private CheckBox chbMechanicalIssue;
        private CheckBox chbDented;
        private CheckBox chbClean;
        private Panel panel2;
        private Button btnCalculate;
        private Button btnCancel;
        private Button btnCompleteReturn;
    }
}