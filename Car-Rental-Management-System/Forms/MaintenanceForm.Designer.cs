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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
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
            dtpExpectedComplete = new DateTimePicker();
            txtContact = new TextBox();
            txtCost = new TextBox();
            cmbMaintenanceType = new ComboBox();
            label9 = new Label();
            txtProvider = new TextBox();
            label11 = new Label();
            rtbDescription = new RichTextBox();
            label8 = new Label();
            label7 = new Label();
            label5 = new Label();
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
            panelHeader = new Panel();
            lblFormTitle = new Label();
            cmbStatus = new ComboBox();
            label12 = new Label();
            panelTools = new Panel();
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
            lblStatus.Location = new Point(565, 24);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(201, 29);
            lblStatus.TabIndex = 29;
            lblStatus.Text = "0 maintenance(s)";
            lblStatus.Click += lblStatus_Click_1;
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
            txtSearch.TextChanged += txtSearch_TextChanged_1;
            // 
            // dgvMaintenance
            // 
            dgvMaintenance.AllowUserToAddRows = false;
            dgvMaintenance.AllowUserToDeleteRows = false;
            dgvMaintenance.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMaintenance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMaintenance.BackgroundColor = Color.FromArgb(30, 30, 44);
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(124, 77, 255);
            dataGridViewCellStyle4.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvMaintenance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvMaintenance.ColumnHeadersHeight = 46;
            dgvMaintenance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(30, 30, 44);
            dataGridViewCellStyle5.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(230, 230, 235);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(124, 77, 255);
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvMaintenance.DefaultCellStyle = dataGridViewCellStyle5;
            dgvMaintenance.GridColor = Color.FromArgb(55, 55, 70);
            dgvMaintenance.Location = new Point(559, 82);
            dgvMaintenance.Name = "dgvMaintenance";
            dgvMaintenance.ReadOnly = true;
            dgvMaintenance.RowHeadersVisible = false;
            dgvMaintenance.RowHeadersWidth = 82;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(30, 30, 44);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(230, 230, 235);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(124, 77, 255);
            dataGridViewCellStyle6.SelectionForeColor = Color.White;
            dgvMaintenance.RowsDefaultCellStyle = dataGridViewCellStyle6;
            dgvMaintenance.RowTemplate.Height = 36;
            dgvMaintenance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMaintenance.Size = new Size(1414, 694);
            dgvMaintenance.TabIndex = 25;
            dgvMaintenance.CellContentClick += dgvMaintenance_CellContentClick_1;
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
            btnComplete.Click += btnComplete_Click_1;
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
            btnDelete.Size = new Size(200, 60);
            btnDelete.TabIndex = 34;
            btnDelete.Text = "Delete";
            btnDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click_1;
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
            btnEdit.Size = new Size(200, 60);
            btnEdit.TabIndex = 33;
            btnEdit.Text = "Edit";
            btnEdit.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click_1;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Trebuchet MS", 10.125F);
            btnSave.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnSave.IconColor = Color.White;
            btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSave.Location = new Point(656, 20);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(200, 60);
            btnSave.TabIndex = 32;
            btnSave.Text = "Save";
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click_1;
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
            groupBox2.Controls.Add(dtpExpectedComplete);
            groupBox2.Controls.Add(txtContact);
            groupBox2.Controls.Add(txtCost);
            groupBox2.Controls.Add(cmbMaintenanceType);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(txtProvider);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(rtbDescription);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(dtpDate);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label6);
            groupBox2.ForeColor = Color.FromArgb(230, 230, 235);
            groupBox2.Location = new Point(19, 237);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(493, 458);
            groupBox2.TabIndex = 37;
            groupBox2.TabStop = false;
            groupBox2.Text = "Maintenance Information";
            // 
            // txtLocation
            // 
            txtLocation.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLocation.Location = new Point(172, 288);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(302, 35);
            txtLocation.TabIndex = 51;
            txtLocation.TextChanged += txtLocation_TextChanged_1;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(15, 291);
            label10.Name = "label10";
            label10.Size = new Size(115, 29);
            label10.TabIndex = 50;
            label10.Text = "Location:";
            // 
            // dtpExpectedComplete
            // 
            dtpExpectedComplete.CalendarFont = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpExpectedComplete.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpExpectedComplete.Location = new Point(172, 77);
            dtpExpectedComplete.Name = "dtpExpectedComplete";
            dtpExpectedComplete.Size = new Size(302, 35);
            dtpExpectedComplete.TabIndex = 38;
            dtpExpectedComplete.ValueChanged += dtpExpectedComplete_ValueChanged_1;
            // 
            // txtContact
            // 
            txtContact.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContact.Location = new Point(172, 245);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(302, 35);
            txtContact.TabIndex = 49;
            txtContact.TextChanged += txtContact_TextChanged_1;
            // 
            // txtCost
            // 
            txtCost.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCost.Location = new Point(172, 162);
            txtCost.Name = "txtCost";
            txtCost.Size = new Size(302, 35);
            txtCost.TabIndex = 39;
            txtCost.TextChanged += txtCost_TextChanged_1;
            // 
            // cmbMaintenanceType
            // 
            cmbMaintenanceType.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbMaintenanceType.FormattingEnabled = true;
            cmbMaintenanceType.Location = new Point(172, 34);
            cmbMaintenanceType.Name = "cmbMaintenanceType";
            cmbMaintenanceType.Size = new Size(302, 37);
            cmbMaintenanceType.TabIndex = 36;
            cmbMaintenanceType.SelectedIndexChanged += cmbMaintenanceType_SelectedIndexChanged_1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(15, 248);
            label9.Name = "label9";
            label9.Size = new Size(107, 29);
            label9.TabIndex = 48;
            label9.Text = "Contact:";
            // 
            // txtProvider
            // 
            txtProvider.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProvider.Location = new Point(172, 203);
            txtProvider.Name = "txtProvider";
            txtProvider.Size = new Size(302, 35);
            txtProvider.TabIndex = 47;
            txtProvider.Text = "Local Garage";
            txtProvider.TextChanged += txtProvider_TextChanged_1;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(15, 206);
            label11.Name = "label11";
            label11.Size = new Size(110, 29);
            label11.TabIndex = 46;
            label11.Text = "Provider:";
            label11.Click += label11_Click;
            // 
            // rtbDescription
            // 
            rtbDescription.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtbDescription.Location = new Point(172, 332);
            rtbDescription.Name = "rtbDescription";
            rtbDescription.Size = new Size(302, 114);
            rtbDescription.TabIndex = 41;
            rtbDescription.Text = "";
            rtbDescription.TextChanged += rtbDescription_TextChanged_1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(15, 335);
            label8.Name = "label8";
            label8.Size = new Size(144, 29);
            label8.TabIndex = 40;
            label8.Text = "Description:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(18, 163);
            label7.Name = "label7";
            label7.Size = new Size(69, 29);
            label7.TabIndex = 38;
            label7.Text = "Cost:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(15, 77);
            label5.Name = "label5";
            label5.Size = new Size(158, 29);
            label5.TabIndex = 37;
            label5.Text = "Complete By:";
            // 
            // dtpDate
            // 
            dtpDate.CalendarFont = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpDate.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpDate.Location = new Point(172, 121);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(302, 35);
            dtpDate.TabIndex = 36;
            dtpDate.ValueChanged += dtpDate_ValueChanged_1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(15, 120);
            label4.Name = "label4";
            label4.Size = new Size(73, 29);
            label4.TabIndex = 32;
            label4.Text = "Date:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(18, 39);
            label6.Name = "label6";
            label6.Size = new Size(71, 29);
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
            groupBox1.Size = new Size(493, 218);
            groupBox1.TabIndex = 36;
            groupBox1.TabStop = false;
            groupBox1.Text = "Vehicle Information";
            // 
            // cmbVehicle
            // 
            cmbVehicle.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbVehicle.FormattingEnabled = true;
            cmbVehicle.Location = new Point(172, 58);
            cmbVehicle.Name = "cmbVehicle";
            cmbVehicle.Size = new Size(302, 37);
            cmbVehicle.TabIndex = 37;
            cmbVehicle.SelectedIndexChanged += cmbVehicle_SelectedIndexChanged_1;
            // 
            // lblLastService
            // 
            lblLastService.AutoSize = true;
            lblLastService.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLastService.Location = new Point(172, 175);
            lblLastService.Name = "lblLastService";
            lblLastService.Size = new Size(55, 29);
            lblLastService.TabIndex = 36;
            lblLastService.Text = "N/A";
            lblLastService.Click += lblLastService_Click_1;
            // 
            // txtCurrentMilage
            // 
            txtCurrentMilage.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCurrentMilage.Location = new Point(172, 119);
            txtCurrentMilage.Name = "txtCurrentMilage";
            txtCurrentMilage.Size = new Size(302, 35);
            txtCurrentMilage.TabIndex = 35;
            txtCurrentMilage.TextChanged += txtCurrentMilage_TextChanged_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(15, 175);
            label2.Name = "label2";
            label2.Size = new Size(152, 29);
            label2.TabIndex = 32;
            label2.Text = "Last Service:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(15, 120);
            label1.Name = "label1";
            label1.Size = new Size(104, 29);
            label1.TabIndex = 31;
            label1.Text = "Mileage:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(15, 61);
            label3.Name = "label3";
            label3.Size = new Size(99, 29);
            label3.TabIndex = 30;
            label3.Text = "Vehicle:";
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
            lblFormTitle.BackColor = Color.Transparent;
            lblFormTitle.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFormTitle.ForeColor = Color.FromArgb(230, 230, 235);
            lblFormTitle.Location = new Point(114, 16);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(295, 40);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "Maintenance Form";
            lblFormTitle.Click += lblFormTitle_Click_1;
            // 
            // cmbStatus
            // 
            cmbStatus.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(172, 113);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(302, 37);
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
            // panelTools
            // 
            panelTools.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelTools.Controls.Add(txtSearch);
            panelTools.Controls.Add(lblStatus);
            panelTools.Location = new Point(550, 12);
            panelTools.Name = "panelTools";
            panelTools.Size = new Size(1426, 70);
            panelTools.TabIndex = 38;
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