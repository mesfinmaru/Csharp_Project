namespace Car_Rental_Management_System.Forms
{
    partial class NewRentalsForm
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
            groupBox1 = new GroupBox();
            btnSelectCustomer = new Button();
            lblSelectedCustomer = new Label();
            txtSearchCustomer = new TextBox();
            label2 = new Label();
            groupBox2 = new GroupBox();
            btnSelectVehicle = new Button();
            lblSelectedVehicle = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            groupBox3 = new GroupBox();
            dtpTo = new DateTimePicker();
            dtpFrom = new DateTimePicker();
            label1 = new Label();
            label4 = new Label();
            groupBox4 = new GroupBox();
            txtDiscount = new TextBox();
            lblTotalAmount = new Label();
            label14 = new Label();
            label12 = new Label();
            lblSubtotal = new Label();
            label10 = new Label();
            lblRentalDays = new Label();
            label8 = new Label();
            lblDailyRate = new Label();
            label6 = new Label();
            groupBox5 = new GroupBox();
            txtAmountPaid = new TextBox();
            textBox2 = new TextBox();
            cmbPaymentMethod = new ComboBox();
            label11 = new Label();
            label15 = new Label();
            lblBalanceDue = new Label();
            label17 = new Label();
            label19 = new Label();
            panel2 = new Panel();
            btnCalculate = new Button();
            btnCancel = new Button();
            btnSaveRental = new Button();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
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
            panel1.Size = new Size(826, 72);
            panel1.TabIndex = 1;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.FlatStyle = FlatStyle.Flat;
            lblHeader.Font = new Font("Trebuchet MS", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.Location = new Point(28, 22);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(273, 37);
            lblHeader.TabIndex = 3;
            lblHeader.Text = "Create New Rental";
            lblHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnSelectCustomer);
            groupBox1.Controls.Add(lblSelectedCustomer);
            groupBox1.Controls.Add(txtSearchCustomer);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 78);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(802, 174);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Customer Selection";
            // 
            // btnSelectCustomer
            // 
            btnSelectCustomer.Location = new Point(565, 57);
            btnSelectCustomer.Name = "btnSelectCustomer";
            btnSelectCustomer.Size = new Size(150, 46);
            btnSelectCustomer.TabIndex = 17;
            btnSelectCustomer.Text = "Select";
            btnSelectCustomer.UseVisualStyleBackColor = true;
            btnSelectCustomer.Click += btnSelectCustomer_Click;
            // 
            // lblSelectedCustomer
            // 
            lblSelectedCustomer.AutoSize = true;
            lblSelectedCustomer.Font = new Font("Trebuchet MS", 10.125F);
            lblSelectedCustomer.Location = new Point(284, 118);
            lblSelectedCustomer.Name = "lblSelectedCustomer";
            lblSelectedCustomer.Size = new Size(170, 35);
            lblSelectedCustomer.TabIndex = 16;
            lblSelectedCustomer.Text = "Not Selected";
            lblSelectedCustomer.Click += lblSelectedCustomer_Click;
            // 
            // txtSearchCustomer
            // 
            txtSearchCustomer.Font = new Font("Trebuchet MS", 10.125F);
            txtSearchCustomer.Location = new Point(35, 59);
            txtSearchCustomer.Name = "txtSearchCustomer";
            txtSearchCustomer.PlaceholderText = "Search Customer ...";
            txtSearchCustomer.Size = new Size(494, 39);
            txtSearchCustomer.TabIndex = 15;
            txtSearchCustomer.TextChanged += txtColor_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Trebuchet MS", 10.125F);
            label2.Location = new Point(37, 118);
            label2.Name = "label2";
            label2.Size = new Size(261, 35);
            label2.TabIndex = 14;
            label2.Text = "Selected Customer: ";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnSelectVehicle);
            groupBox2.Controls.Add(lblSelectedVehicle);
            groupBox2.Controls.Add(textBox1);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(12, 258);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(802, 174);
            groupBox2.TabIndex = 18;
            groupBox2.TabStop = false;
            groupBox2.Text = "Vehicle Selection";
            // 
            // btnSelectVehicle
            // 
            btnSelectVehicle.Location = new Point(565, 57);
            btnSelectVehicle.Name = "btnSelectVehicle";
            btnSelectVehicle.Size = new Size(150, 46);
            btnSelectVehicle.TabIndex = 17;
            btnSelectVehicle.Text = "Select";
            btnSelectVehicle.UseVisualStyleBackColor = true;
            btnSelectVehicle.Click += btnSelectVehicle_Click;
            // 
            // lblSelectedVehicle
            // 
            lblSelectedVehicle.AutoSize = true;
            lblSelectedVehicle.Font = new Font("Trebuchet MS", 10.125F);
            lblSelectedVehicle.Location = new Point(286, 118);
            lblSelectedVehicle.Name = "lblSelectedVehicle";
            lblSelectedVehicle.Size = new Size(170, 35);
            lblSelectedVehicle.TabIndex = 16;
            lblSelectedVehicle.Text = "Not Selected";
            lblSelectedVehicle.Click += lblSelectedVehicle_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Trebuchet MS", 10.125F);
            textBox1.Location = new Point(35, 59);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Search Vehicle ...";
            textBox1.Size = new Size(494, 39);
            textBox1.TabIndex = 15;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Trebuchet MS", 10.125F);
            label3.Location = new Point(37, 118);
            label3.Name = "label3";
            label3.Size = new Size(234, 35);
            label3.TabIndex = 14;
            label3.Text = "Selected Vehicle: ";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dtpTo);
            groupBox3.Controls.Add(dtpFrom);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(label4);
            groupBox3.Location = new Point(12, 438);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(802, 131);
            groupBox3.TabIndex = 19;
            groupBox3.TabStop = false;
            groupBox3.Text = "Rental Peroid";
            // 
            // dtpTo
            // 
            dtpTo.Location = new Point(463, 62);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(252, 39);
            dtpTo.TabIndex = 18;
            dtpTo.ValueChanged += dtpTo_ValueChanged;
            // 
            // dtpFrom
            // 
            dtpFrom.Location = new Point(129, 61);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(252, 39);
            dtpFrom.TabIndex = 17;
            dtpFrom.ValueChanged += dtpFrom_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Trebuchet MS", 10.125F);
            label1.Location = new Point(405, 65);
            label1.Name = "label1";
            label1.Size = new Size(52, 35);
            label1.TabIndex = 16;
            label1.Text = "To:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Trebuchet MS", 10.125F);
            label4.Location = new Point(41, 65);
            label4.Name = "label4";
            label4.Size = new Size(86, 35);
            label4.TabIndex = 14;
            label4.Text = "From:";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(txtDiscount);
            groupBox4.Controls.Add(lblTotalAmount);
            groupBox4.Controls.Add(label14);
            groupBox4.Controls.Add(label12);
            groupBox4.Controls.Add(lblSubtotal);
            groupBox4.Controls.Add(label10);
            groupBox4.Controls.Add(lblRentalDays);
            groupBox4.Controls.Add(label8);
            groupBox4.Controls.Add(lblDailyRate);
            groupBox4.Controls.Add(label6);
            groupBox4.Location = new Point(12, 575);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(802, 332);
            groupBox4.TabIndex = 19;
            groupBox4.TabStop = false;
            groupBox4.Text = "Pricing Details";
            // 
            // txtDiscount
            // 
            txtDiscount.Font = new Font("Trebuchet MS", 10.125F);
            txtDiscount.Location = new Point(292, 219);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.Size = new Size(423, 39);
            txtDiscount.TabIndex = 41;
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
            lblTotalAmount.Click += lblTotalAmount_Click;
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
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Trebuchet MS", 10.125F);
            label12.Location = new Point(41, 219);
            label12.Name = "label12";
            label12.Size = new Size(137, 35);
            label12.TabIndex = 21;
            label12.Text = "Discount :";
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Font = new Font("Trebuchet MS", 10.125F);
            lblSubtotal.Location = new Point(327, 161);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(62, 35);
            lblSubtotal.TabIndex = 20;
            lblSubtotal.Text = "N/A";
            lblSubtotal.Click += lblSubtotal_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Trebuchet MS", 10.125F);
            label10.Location = new Point(41, 161);
            label10.Name = "label10";
            label10.Size = new Size(134, 35);
            label10.TabIndex = 19;
            label10.Text = "Subtotal :";
            // 
            // lblRentalDays
            // 
            lblRentalDays.AutoSize = true;
            lblRentalDays.Font = new Font("Trebuchet MS", 10.125F);
            lblRentalDays.Location = new Point(327, 106);
            lblRentalDays.Name = "lblRentalDays";
            lblRentalDays.Size = new Size(62, 35);
            lblRentalDays.TabIndex = 18;
            lblRentalDays.Text = "N/A";
            lblRentalDays.Click += lblRentalDays_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Trebuchet MS", 10.125F);
            label8.Location = new Point(41, 106);
            label8.Name = "label8";
            label8.Size = new Size(174, 35);
            label8.TabIndex = 17;
            label8.Text = "Rental Days :";
            // 
            // lblDailyRate
            // 
            lblDailyRate.AutoSize = true;
            lblDailyRate.Font = new Font("Trebuchet MS", 10.125F);
            lblDailyRate.Location = new Point(327, 52);
            lblDailyRate.Name = "lblDailyRate";
            lblDailyRate.Size = new Size(62, 35);
            lblDailyRate.TabIndex = 16;
            lblDailyRate.Text = "N/A";
            lblDailyRate.Click += lblDailyRate_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Trebuchet MS", 10.125F);
            label6.Location = new Point(41, 52);
            label6.Name = "label6";
            label6.Size = new Size(157, 35);
            label6.TabIndex = 14;
            label6.Text = "Daily Rate :";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(txtAmountPaid);
            groupBox5.Controls.Add(textBox2);
            groupBox5.Controls.Add(cmbPaymentMethod);
            groupBox5.Controls.Add(label11);
            groupBox5.Controls.Add(label15);
            groupBox5.Controls.Add(lblBalanceDue);
            groupBox5.Controls.Add(label17);
            groupBox5.Controls.Add(label19);
            groupBox5.Location = new Point(12, 913);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(802, 282);
            groupBox5.TabIndex = 25;
            groupBox5.TabStop = false;
            groupBox5.Text = "Payment Information";
            // 
            // txtAmountPaid
            // 
            txtAmountPaid.Font = new Font("Trebuchet MS", 10.125F);
            txtAmountPaid.Location = new Point(292, 49);
            txtAmountPaid.Name = "txtAmountPaid";
            txtAmountPaid.Size = new Size(423, 39);
            txtAmountPaid.TabIndex = 18;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Trebuchet MS", 10.125F);
            textBox2.Location = new Point(292, 216);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Enter Transaction ID here...";
            textBox2.Size = new Size(423, 39);
            textBox2.TabIndex = 40;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // cmbPaymentMethod
            // 
            cmbPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentMethod.Font = new Font("Trebuchet MS", 10.125F);
            cmbPaymentMethod.FormattingEnabled = true;
            cmbPaymentMethod.Location = new Point(292, 158);
            cmbPaymentMethod.Name = "cmbPaymentMethod";
            cmbPaymentMethod.Size = new Size(423, 43);
            cmbPaymentMethod.TabIndex = 39;
            cmbPaymentMethod.SelectedIndexChanged += cmbTransmission_SelectedIndexChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Trebuchet MS", 10.125F);
            label11.Location = new Point(41, 219);
            label11.Name = "label11";
            label11.Size = new Size(205, 35);
            label11.TabIndex = 21;
            label11.Text = "Transaction ID :";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Trebuchet MS", 10.125F);
            label15.Location = new Point(41, 161);
            label15.Name = "label15";
            label15.Size = new Size(235, 35);
            label15.TabIndex = 19;
            label15.Text = "Payment Method :";
            // 
            // lblBalanceDue
            // 
            lblBalanceDue.AutoSize = true;
            lblBalanceDue.Font = new Font("Trebuchet MS", 10.125F);
            lblBalanceDue.Location = new Point(327, 106);
            lblBalanceDue.Name = "lblBalanceDue";
            lblBalanceDue.Size = new Size(62, 35);
            lblBalanceDue.TabIndex = 18;
            lblBalanceDue.Text = "N/A";
            lblBalanceDue.Click += lblBalanceDue_Click;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Trebuchet MS", 10.125F);
            label17.Location = new Point(41, 106);
            label17.Name = "label17";
            label17.Size = new Size(182, 35);
            label17.TabIndex = 17;
            label17.Text = "Balance Due :";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Trebuchet MS", 10.125F);
            label19.Location = new Point(41, 52);
            label19.Name = "label19";
            label19.Size = new Size(185, 35);
            label19.TabIndex = 14;
            label19.Text = "Amount Paid :";
            // 
            // panel2
            // 
            panel2.Controls.Add(btnCalculate);
            panel2.Controls.Add(btnCancel);
            panel2.Controls.Add(btnSaveRental);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 1209);
            panel2.Name = "panel2";
            panel2.Size = new Size(826, 110);
            panel2.TabIndex = 26;
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(327, 37);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(150, 46);
            btnCalculate.TabIndex = 20;
            btnCalculate.Text = "Calculate";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(96, 37);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 46);
            btnCancel.TabIndex = 19;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSaveRental
            // 
            btnSaveRental.Location = new Point(565, 37);
            btnSaveRental.Name = "btnSaveRental";
            btnSaveRental.Size = new Size(150, 46);
            btnSaveRental.TabIndex = 18;
            btnSaveRental.Text = "Save Rental";
            btnSaveRental.UseVisualStyleBackColor = true;
            btnSaveRental.Click += btnSaveRental_Click;
            // 
            // NewRentalsForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(826, 1319);
            Controls.Add(panel2);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "NewRentalsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NewRentalsForm";
            Load += NewRentalsForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblHeader;
        private GroupBox groupBox1;
        private TextBox txtSearchCustomer;
        private Label label2;
        private Label lblSelectedCustomer;
        private Button btnSelectCustomer;
        private GroupBox groupBox2;
        private Button btnSelectVehicle;
        private Label lblSelectedVehicle;
        private TextBox textBox1;
        private Label label3;
        private GroupBox groupBox3;
        private DateTimePicker dtpTo;
        private DateTimePicker dtpFrom;
        private Label label1;
        private Label label4;
        private GroupBox groupBox4;
        private Label lblTotalAmount;
        private Label label14;
        private Label label12;
        private Label lblSubtotal;
        private Label label10;
        private Label lblRentalDays;
        private Label label8;
        private Label lblDailyRate;
        private Label label6;
        private GroupBox groupBox5;
        private Label label11;
        private Label label15;
        private Label lblBalanceDue;
        private Label label17;
        private Label label19;
        private TextBox textBox2;
        private ComboBox cmbPaymentMethod;
        private Panel panel2;
        private Button btnCalculate;
        private Button btnCancel;
        private Button btnSaveRental;
        private TextBox txtAmountPaid;
        private TextBox txtDiscount;
    }
}