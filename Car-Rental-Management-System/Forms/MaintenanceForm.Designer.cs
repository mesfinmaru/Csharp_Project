namespace Car_Rental_Management_System.Forms
{
    partial class MaintenanceForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            lblStatus = new Label();
            txtSearch = new TextBox();
            dgvMaintenance = new DataGridView();
            panel1 = new Panel();
            btnComplete = new FontAwesome.Sharp.IconButton();
            btnDelete = new FontAwesome.Sharp.IconButton();
            btnEdit = new FontAwesome.Sharp.IconButton();
            btnSave = new FontAwesome.Sharp.IconButton();
            panel2 = new Panel();
            panelInput = new Panel();
            groupBox2 = new GroupBox();
            txtLocation = new TextBox();
            label10 = new Label();
            txtContact = new TextBox();
            label9 = new Label();
            txtProvider = new TextBox();
            label11 = new Label();
            rtbDescription = new RichTextBox();
            label8 = new Label();
            txtCost = new TextBox();
            dtpExpectedComplete = new DateTimePicker();
            label7 = new Label();
            label5 = new Label();
            cmbMaintenanceType = new ComboBox();
            dtpDate = new DateTimePicker();
            label4 = new Label();
            label6 = new Label();
            groupBox1 = new GroupBox();
            cmbVehicle = new ComboBox();
            lblLastService = new Label();
            txtCurrentMilage = new TextBox();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            cmbStatus = new ComboBox();
            label12 = new Label();
            panelHeader = new Panel();
            lblFormTitle = new Label();
            panelTools = new Panel();
            cmbStatusFilter = new ComboBox();
            label13 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMaintenance).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panelInput.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            panelHeader.SuspendLayout();
            panelTools.SuspendLayout();
            SuspendLayout();
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.FromArgb(230, 230, 235);
            lblStatus.Location = new Point(1250, 19);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(148, 30);
            lblStatus.TabIndex = 29;
            lblStatus.Text = "0 maintenance(s)";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Font = new Font("Trebuchet MS", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(12, 16);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search by vehicle, type, or status...";
            txtSearch.Size = new Size(512, 39);
            txtSearch.TabIndex = 24;
            // 
            // dgvMaintenance
            // 
            dgvMaintenance.AllowUserToAddRows = false;
            dgvMaintenance.AllowUserToDeleteRows = false;
            dgvMaintenance.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMaintenance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMaintenance.BackgroundColor = Color.FromArgb(30, 30, 44);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(124, 77, 255);
            dataGridViewCellStyle1.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMaintenance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMaintenance.ColumnHeadersHeight = 46;
            dgvMaintenance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(30, 30, 44);
            dataGridViewCellStyle2.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(230, 230, 235);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(124, 77, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvMaintenance.DefaultCellStyle = dataGridViewCellStyle2;
            dgvMaintenance.GridColor = Color.FromArgb(55, 55, 70);
            dgvMaintenance.Location = new Point(550, 73);
            dgvMaintenance.Name = "dgvMaintenance";
            dgvMaintenance.ReadOnly = true;
            dgvMaintenance.RowHeadersVisible = false;
            dgvMaintenance.RowHeadersWidth = 82;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(30, 30, 44);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(230, 230, 235);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(124, 77, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dgvMaintenance.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvMaintenance.RowTemplate.Height = 36;
            dgvMaintenance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMaintenance.Size = new Size(1426, 703);
            dgvMaintenance.TabIndex = 25;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnComplete);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnEdit);
            panel1.Controls.Add(btnSave);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 799);
            panel1.Name = "panel1";
            panel1.Size = new Size(1988, 94);
            panel1.TabIndex = 36;
            // 
            // btnComplete
            // 
            btnComplete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnComplete.FlatStyle = FlatStyle.Flat;
            btnComplete.Font = new Font("Trebuchet MS", 10.125F);
            btnComplete.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
            btnComplete.IconColor = Color.White;
            btnComplete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnComplete.Location = new Point(1420, 20);
            btnComplete.Name = "btnComplete";
            btnComplete.Size = new Size(200, 60);
            btnComplete.TabIndex = 35;
            btnComplete.Text = "Complete";
            btnComplete.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnComplete.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Trebuchet MS", 10.125F);
            btnDelete.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            btnDelete.IconColor = Color.White;
            btnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDelete.Location = new Point(1160, 22);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(166, 60);
            btnDelete.TabIndex = 34;
            btnDelete.Text = "Delete";
            btnDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Trebuchet MS", 10.125F);
            btnEdit.IconChar = FontAwesome.Sharp.IconChar.Edit;
            btnEdit.IconColor = Color.White;
            btnEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEdit.Location = new Point(900, 22);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(148, 60);
            btnEdit.TabIndex = 33;
            btnEdit.Text = "Edit";
            btnEdit.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Trebuchet MS", 10.125F);
            btnSave.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnSave.IconColor = Color.White;
            btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSave.Location = new Point(640, 20);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(132, 60);
            btnSave.TabIndex = 32;
            btnSave.Text = "Save";
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(panelInput);
            panel2.Controls.Add(panelHeader);
            panel2.Location = new Point(16, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(528, 768);
            panel2.TabIndex = 37;
            // 
            // panelInput
            // 
            panelInput.Controls.Add(groupBox2);
            panelInput.Controls.Add(groupBox1);
            panelInput.Dock = DockStyle.Fill;
            panelInput.Location = new Point(0, 70);
            panelInput.Name = "panelInput";
            panelInput.Size = new Size(528, 698);
            panelInput.TabIndex = 39;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtLocation);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(txtContact);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(txtProvider);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(rtbDescription);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(txtCost);
            groupBox2.Controls.Add(dtpExpectedComplete);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(cmbMaintenanceType);
            groupBox2.Controls.Add(dtpDate);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label6);
            groupBox2.ForeColor = Color.FromArgb(230, 230, 235);
            groupBox2.Location = new Point(19, 309);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(493, 376);
            groupBox2.TabIndex = 37;
            groupBox2.TabStop = false;
            groupBox2.Text = "Maintenance Information";
            // 
            // txtLocation
            // 
            txtLocation.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLocation.Location = new Point(172, 203);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(302, 35);
            txtLocation.TabIndex = 51;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(15, 206);
            label10.Name = "label10";
            label10.Size = new Size(104, 30);
            label10.TabIndex = 50;
            label10.Text = "Location:";
            // 
            // txtContact
            // 
            txtContact.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContact.Location = new Point(172, 158);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(302, 35);
            txtContact.TabIndex = 49;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(15, 161);
            label9.Name = "label9";
            label9.Size = new Size(91, 30);
            label9.TabIndex = 48;
            label9.Text = "Contact:";
            // 
            // txtProvider
            // 
            txtProvider.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProvider.Location = new Point(172, 113);
            txtProvider.Name = "txtProvider";
            txtProvider.Size = new Size(302, 35);
            txtProvider.TabIndex = 47;
            txtProvider.Text = "Local Garage";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(15, 116);
            label11.Name = "label11";
            label11.Size = new Size(101, 30);
            label11.TabIndex = 46;
            label11.Text = "Provider:";
            // 
            // rtbDescription
            // 
            rtbDescription.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtbDescription.Location = new Point(172, 248);
            rtbDescription.Name = "rtbDescription";
            rtbDescription.Size = new Size(302, 114);
            rtbDescription.TabIndex = 41;
            rtbDescription.Text = "";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(15, 251);
            label8.Name = "label8";
            label8.Size = new Size(126, 30);
            label8.TabIndex = 40;
            label8.Text = "Description:";
            // 
            // txtCost
            // 
            txtCost.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCost.Location = new Point(172, 68);
            txtCost.Name = "txtCost";
            txtCost.Size = new Size(302, 35);
            txtCost.TabIndex = 39;
            // 
            // dtpExpectedComplete
            // 
            dtpExpectedComplete.CalendarFont = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpExpectedComplete.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpExpectedComplete.Location = new Point(172, 23);
            dtpExpectedComplete.Name = "dtpExpectedComplete";
            dtpExpectedComplete.Size = new Size(302, 35);
            dtpExpectedComplete.TabIndex = 38;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(15, 71);
            label7.Name = "label7";
            label7.Size = new Size(63, 30);
            label7.TabIndex = 38;
            label7.Text = "Cost:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(15, 28);
            label5.Name = "label5";
            label5.Size = new Size(151, 30);
            label5.TabIndex = 37;
            label5.Text = "Complete By:";
            // 
            // cmbMaintenanceType
            // 
            cmbMaintenanceType.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbMaintenanceType.FormattingEnabled = true;
            cmbMaintenanceType.Location = new Point(172, 23);
            cmbMaintenanceType.Name = "cmbMaintenanceType";
            cmbMaintenanceType.Size = new Size(302, 38);
            cmbMaintenanceType.TabIndex = 36;
            // 
            // dtpDate
            // 
            dtpDate.CalendarFont = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpDate.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpDate.Location = new Point(172, 68);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(302, 35);
            dtpDate.TabIndex = 36;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(15, 71);
            label4.Name = "label4";
            label4.Size = new Size(67, 30);
            label4.TabIndex = 32;
            label4.Text = "Date:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(15, 26);
            label6.Name = "label6";
            label6.Size = new Size(57, 30);
            label6.TabIndex = 30;
            label6.Text = "Type:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmbVehicle);
            groupBox1.Controls.Add(lblLastService);
            groupBox1.Controls.Add(txtCurrentMilage);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label3);
            groupBox1.ForeColor = Color.FromArgb(230, 230, 235);
            groupBox1.Location = new Point(19, 13);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(493, 290);
            groupBox1.TabIndex = 36;
            groupBox1.TabStop = false;
            groupBox1.Text = "Vehicle Information";
            // 
            // cmbVehicle
            // 
            cmbVehicle.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbVehicle.FormattingEnabled = true;
            cmbVehicle.Location = new Point(172, 83);
            cmbVehicle.Name = "cmbVehicle";
            cmbVehicle.Size = new Size(302, 38);
            cmbVehicle.TabIndex = 37;
            // 
            // lblLastService
            // 
            lblLastService.AutoSize = true;
            lblLastService.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLastService.Location = new Point(172, 233);
            lblLastService.Name = "lblLastService";
            lblLastService.Size = new Size(39, 30);
            lblLastService.TabIndex = 36;
            lblLastService.Text = "N/A";
            // 
            // txtCurrentMilage
            // 
            txtCurrentMilage.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCurrentMilage.Location = new Point(172, 160);
            txtCurrentMilage.Name = "txtCurrentMilage";
            txtCurrentMilage.Size = new Size(302, 35);
            txtCurrentMilage.TabIndex = 35;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(15, 233);
            label2.Name = "label2";
            label2.Size = new Size(130, 30);
            label2.TabIndex = 32;
            label2.Text = "Last Service:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(15, 161);
            label1.Name = "label1";
            label1.Size = new Size(119, 30);
            label1.TabIndex = 31;
            label1.Text = "Mileage:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(15, 86);
            label3.Name = "label3";
            label3.Size = new Size(87, 30);
            label3.TabIndex = 30;
            label3.Text = "Vehicle:";
            // 
            // cmbStatus
            // 
            cmbStatus.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(172, 113);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(302, 38);
            cmbStatus.TabIndex = 52;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.FromArgb(230, 230, 235);
            label12.Location = new Point(15, 116);
            label12.Name = "label12";
            label12.Size = new Size(74, 30);
            label12.TabIndex = 53;
            label12.Text = "Status:";
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(lblFormTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(528, 70);
            panelHeader.TabIndex = 38;
            // 
            // lblFormTitle
            // 
            lblFormTitle.AutoSize = true;
            lblFormTitle.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFormTitle.ForeColor = Color.FromArgb(230, 230, 235);
            lblFormTitle.Location = new Point(19, 15);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(279, 40);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "Maintenance Form";
            // 
            // panelTools
            // 
            panelTools.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelTools.Controls.Add(cmbStatusFilter);
            panelTools.Controls.Add(label13);
            panelTools.Controls.Add(txtSearch);
            panelTools.Location = new Point(550, 12);
            panelTools.Name = "panelTools";
            panelTools.Size = new Size(1426, 70);
            panelTools.TabIndex = 38;
            // 
            // cmbStatusFilter
            // 
            cmbStatusFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbStatusFilter.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbStatusFilter.FormattingEnabled = true;
            cmbStatusFilter.Items.AddRange(new object[] {
            "All Status",
            "Scheduled",
            "In Progress",
            "Completed",
            "Cancelled"});
            cmbStatusFilter.Location = new Point(1050, 16);
            cmbStatusFilter.Name = "cmbStatusFilter";
            cmbStatusFilter.Size = new Size(242, 38);
            cmbStatusFilter.TabIndex = 26;
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label13.AutoSize = true;
            label13.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.FromArgb(230, 230, 235);
            label13.Location = new Point(953, 19);
            label13.Name = "label13";
            label13.Size = new Size(91, 30);
            label13.TabIndex = 25;
            label13.Text = "Filter by:";
            // 
            // MaintenanceForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 27, 39);
            ClientSize = new Size(1988, 893);
            Controls.Add(panelTools);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(lblStatus);
            Controls.Add(dgvMaintenance);
            Name = "MaintenanceForm";
            Text = "Maintenance Management";
            Load += MaintenanceForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMaintenance).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panelInput.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelTools.ResumeLayout(false);
            panelTools.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStatus;
        private TextBox txtSearch;
        private DataGridView dgvMaintenance;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton btnComplete;
        private FontAwesome.Sharp.IconButton btnDelete;
        private FontAwesome.Sharp.IconButton btnEdit;
        private FontAwesome.Sharp.IconButton btnSave;
        private Panel panel2;
        private Panel panelInput;
        private GroupBox groupBox2;
        private RichTextBox rtbDescription;
        private Label label8;
        private TextBox txtCost;
        private DateTimePicker dtpExpectedComplete;
        private Label label7;
        private Label label5;
        private ComboBox cmbMaintenanceType;
        private DateTimePicker dtpDate;
        private Label label4;
        private Label label6;
        private GroupBox groupBox1;
        private ComboBox cmbVehicle;
        private Label lblLastService;
        private TextBox txtCurrentMilage;
        private Label label2;
        private Label label1;
        private Label label3;
        private Panel panelHeader;
        private Label lblFormTitle;
        private Panel panelTools;
        private ComboBox cmbStatusFilter;
        private Label label13;
        private TextBox txtProvider;
        private Label label11;
        private TextBox txtContact;
        private Label label9;
        private TextBox txtLocation;
        private Label label10;
        private ComboBox cmbStatus;
        private Label label12;
    }
}