namespace Car_Rental_Management_System.Forms
{
    partial class ReportsForm
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
            btnExport = new FontAwesome.Sharp.IconButton();
            btnGenerateReport = new FontAwesome.Sharp.IconButton();
            rtbReport = new RichTextBox();
            cmbReportType = new ComboBox();
            cmbStatus = new ComboBox();
            cmbVehicleType = new ComboBox();
            dtpFrom = new DateTimePicker();
            dtpTo = new DateTimePicker();
            lblReportType = new Label();
            lblFrom = new Label();
            lblTo = new Label();
            lblStatus = new Label();
            lblVehicleType = new Label();
            cbAllDates = new CheckBox();
            btnPrint = new FontAwesome.Sharp.IconButton();
            btnClear = new FontAwesome.Sharp.IconButton();
            statusStrip = new StatusStrip();
            lblStatusBar = new ToolStripStatusLabel();
            lblReportTitle = new Label();
            gbDateRange = new GroupBox();
            gbFilters = new GroupBox();
            statusStrip.SuspendLayout();
            gbDateRange.SuspendLayout();
            gbFilters.SuspendLayout();
            SuspendLayout();
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.DarkGray;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI", 10F);
            btnExport.ForeColor = Color.White;
            btnExport.IconChar = FontAwesome.Sharp.IconChar.ArrowRightFromFile;
            btnExport.IconColor = Color.White;
            btnExport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnExport.IconSize = 30;
            btnExport.Location = new Point(272, 901);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(200, 115);
            btnExport.TabIndex = 15;
            btnExport.Text = "Export to PDF";
            btnExport.TextImageRelation = TextImageRelation.ImageAboveText;
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.BackColor = Color.RoyalBlue;
            btnGenerateReport.FlatStyle = FlatStyle.Flat;
            btnGenerateReport.Font = new Font("Segoe UI", 10F);
            btnGenerateReport.ForeColor = Color.White;
            btnGenerateReport.IconChar = FontAwesome.Sharp.IconChar.BarChart;
            btnGenerateReport.IconColor = Color.White;
            btnGenerateReport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnGenerateReport.IconSize = 30;
            btnGenerateReport.Location = new Point(70, 901);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(200, 115);
            btnGenerateReport.TabIndex = 14;
            btnGenerateReport.Text = "Generate Report";
            btnGenerateReport.TextImageRelation = TextImageRelation.ImageAboveText;
            btnGenerateReport.UseVisualStyleBackColor = false;
            btnGenerateReport.Click += btnGenerateReport_Click;
            // 
            // rtbReport
            // 
            rtbReport.BackColor = Color.FromArgb(45, 45, 65);
            rtbReport.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtbReport.ForeColor = Color.White;
            rtbReport.Location = new Point(952, 182);
            rtbReport.Name = "rtbReport";
            rtbReport.Size = new Size(1161, 834);
            rtbReport.TabIndex = 16;
            rtbReport.Text = "";
            rtbReport.TextChanged += rtbReport_TextChanged;
            // 
            // cmbReportType
            // 
            cmbReportType.BackColor = Color.FromArgb(45, 45, 65);
            cmbReportType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReportType.FlatStyle = FlatStyle.Flat;
            cmbReportType.Font = new Font("Segoe UI", 10F);
            cmbReportType.ForeColor = Color.White;
            cmbReportType.FormattingEnabled = true;
            cmbReportType.Items.AddRange(new object[] { "Customer Reports", "Rental Reports", "Vehicle Reports", "Financial Reports", "Overdue Rentals" });
            cmbReportType.Location = new Point(260, 160);
            cmbReportType.Name = "cmbReportType";
            cmbReportType.Size = new Size(300, 45);
            cmbReportType.TabIndex = 17;
            // 
            // cmbStatus
            // 
            cmbStatus.BackColor = Color.FromArgb(45, 45, 65);
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FlatStyle = FlatStyle.Flat;
            cmbStatus.Font = new Font("Segoe UI", 9F);
            cmbStatus.ForeColor = Color.White;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "All", "Active", "Completed", "Cancelled", "Overdue" });
            cmbStatus.Location = new Point(149, 38);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(200, 40);
            cmbStatus.TabIndex = 18;
            // 
            // cmbVehicleType
            // 
            cmbVehicleType.BackColor = Color.FromArgb(45, 45, 65);
            cmbVehicleType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVehicleType.FlatStyle = FlatStyle.Flat;
            cmbVehicleType.Font = new Font("Segoe UI", 9F);
            cmbVehicleType.ForeColor = Color.White;
            cmbVehicleType.FormattingEnabled = true;
            cmbVehicleType.Items.AddRange(new object[] { "All", "Sedan", "SUV", "Truck", "Van", "Luxury", "" });
            cmbVehicleType.Location = new Point(563, 41);
            cmbVehicleType.Name = "cmbVehicleType";
            cmbVehicleType.Size = new Size(200, 40);
            cmbVehicleType.TabIndex = 19;
            // 
            // dtpFrom
            // 
            dtpFrom.CalendarMonthBackground = Color.FromArgb(45, 45, 65);
            dtpFrom.CalendarTitleBackColor = Color.FromArgb(30, 30, 47);
            dtpFrom.CalendarTitleForeColor = Color.White;
            dtpFrom.CalendarTrailingForeColor = Color.Gray;
            dtpFrom.Font = new Font("Segoe UI", 9F);
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(285, 52);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(200, 39);
            dtpFrom.TabIndex = 20;
            // 
            // dtpTo
            // 
            dtpTo.CalendarMonthBackground = Color.FromArgb(45, 45, 65);
            dtpTo.Font = new Font("Segoe UI", 9F);
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(563, 52);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(200, 39);
            dtpTo.TabIndex = 21;
            // 
            // lblReportType
            // 
            lblReportType.AutoSize = true;
            lblReportType.Font = new Font("Segoe UI", 10F);
            lblReportType.ForeColor = Color.White;
            lblReportType.Location = new Point(70, 163);
            lblReportType.Name = "lblReportType";
            lblReportType.Size = new Size(165, 37);
            lblReportType.TabIndex = 22;
            lblReportType.Text = "Report Type:";
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.Font = new Font("Segoe UI", 9F);
            lblFrom.ForeColor = Color.White;
            lblFrom.Location = new Point(205, 59);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(74, 32);
            lblFrom.TabIndex = 23;
            lblFrom.Text = "From:";
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Font = new Font("Segoe UI", 9F);
            lblTo.ForeColor = Color.White;
            lblTo.Location = new Point(501, 59);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(44, 32);
            lblTo.TabIndex = 24;
            lblTo.Text = "To:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Color.White;
            lblStatus.Location = new Point(65, 44);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(83, 32);
            lblStatus.TabIndex = 25;
            lblStatus.Text = "Status:";
            // 
            // lblVehicleType
            // 
            lblVehicleType.AutoSize = true;
            lblVehicleType.Font = new Font("Segoe UI", 9F);
            lblVehicleType.ForeColor = Color.White;
            lblVehicleType.Location = new Point(392, 43);
            lblVehicleType.Name = "lblVehicleType";
            lblVehicleType.Size = new Size(153, 32);
            lblVehicleType.TabIndex = 26;
            lblVehicleType.Text = "Vehicle Type:";
            // 
            // cbAllDates
            // 
            cbAllDates.AutoSize = true;
            cbAllDates.Font = new Font("Segoe UI", 9F);
            cbAllDates.ForeColor = Color.White;
            cbAllDates.Location = new Point(28, 57);
            cbAllDates.Name = "cbAllDates";
            cbAllDates.Size = new Size(140, 36);
            cbAllDates.TabIndex = 27;
            cbAllDates.Text = "All Dates";
            cbAllDates.UseVisualStyleBackColor = true;
            cbAllDates.CheckedChanged += cbAllDates_CheckedChanged;
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.MediumSeaGreen;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Font = new Font("Segoe UI", 10F);
            btnPrint.ForeColor = Color.White;
            btnPrint.IconChar = FontAwesome.Sharp.IconChar.Print;
            btnPrint.IconColor = Color.White;
            btnPrint.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnPrint.IconSize = 30;
            btnPrint.Location = new Point(473, 901);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(200, 115);
            btnPrint.TabIndex = 28;
            btnPrint.Text = "Print Report";
            btnPrint.TextImageRelation = TextImageRelation.ImageAboveText;
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.IndianRed;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 10F);
            btnClear.ForeColor = Color.White;
            btnClear.IconChar = FontAwesome.Sharp.IconChar.Broom;
            btnClear.IconColor = Color.White;
            btnClear.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClear.IconSize = 30;
            btnClear.Location = new Point(675, 901);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(200, 115);
            btnClear.TabIndex = 29;
            btnClear.Text = "Clear";
            btnClear.TextImageRelation = TextImageRelation.ImageAboveText;
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // statusStrip
            // 
            statusStrip.BackColor = Color.FromArgb(64, 64, 64);
            statusStrip.ImageScalingSize = new Size(24, 24);
            statusStrip.Items.AddRange(new ToolStripItem[] { lblStatusBar });
            statusStrip.Location = new Point(0, 1019);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(2125, 42);
            statusStrip.TabIndex = 30;
            statusStrip.Text = "statusStrip1";
            // 
            // lblStatusBar
            // 
            lblStatusBar.Name = "lblStatusBar";
            lblStatusBar.Size = new Size(78, 32);
            lblStatusBar.Text = "Ready";
            // 
            // lblReportTitle
            // 
            lblReportTitle.AutoSize = true;
            lblReportTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblReportTitle.ForeColor = Color.White;
            lblReportTitle.Location = new Point(1017, 110);
            lblReportTitle.Name = "lblReportTitle";
            lblReportTitle.Size = new Size(260, 45);
            lblReportTitle.TabIndex = 31;
            lblReportTitle.Text = "Report Preview:";
            // 
            // gbDateRange
            // 
            gbDateRange.Controls.Add(dtpFrom);
            gbDateRange.Controls.Add(lblFrom);
            gbDateRange.Controls.Add(lblTo);
            gbDateRange.Controls.Add(dtpTo);
            gbDateRange.Controls.Add(cbAllDates);
            gbDateRange.FlatStyle = FlatStyle.Flat;
            gbDateRange.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gbDateRange.ForeColor = Color.White;
            gbDateRange.Location = new Point(70, 248);
            gbDateRange.Name = "gbDateRange";
            gbDateRange.Size = new Size(800, 120);
            gbDateRange.TabIndex = 32;
            gbDateRange.TabStop = false;
            gbDateRange.Text = "Date Range";
            // 
            // gbFilters
            // 
            gbFilters.Controls.Add(lblStatus);
            gbFilters.Controls.Add(cmbStatus);
            gbFilters.Controls.Add(lblVehicleType);
            gbFilters.Controls.Add(cmbVehicleType);
            gbFilters.FlatStyle = FlatStyle.Flat;
            gbFilters.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gbFilters.ForeColor = Color.White;
            gbFilters.Location = new Point(70, 413);
            gbFilters.Name = "gbFilters";
            gbFilters.Size = new Size(800, 100);
            gbFilters.TabIndex = 33;
            gbFilters.TabStop = false;
            gbFilters.Text = "Filters";
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 47);
            ClientSize = new Size(2125, 1061);
            Controls.Add(gbFilters);
            Controls.Add(gbDateRange);
            Controls.Add(lblReportTitle);
            Controls.Add(statusStrip);
            Controls.Add(btnClear);
            Controls.Add(btnPrint);
            Controls.Add(lblReportType);
            Controls.Add(cmbReportType);
            Controls.Add(rtbReport);
            Controls.Add(btnExport);
            Controls.Add(btnGenerateReport);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ReportsForm";
            Text = "ReportsForm";
            Load += ReportsForm_Load;
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            gbDateRange.ResumeLayout(false);
            gbDateRange.PerformLayout();
            gbFilters.ResumeLayout(false);
            gbFilters.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconButton btnExport;
        private FontAwesome.Sharp.IconButton btnGenerateReport;
        private RichTextBox rtbReport;
        private ComboBox cmbReportType;
        private ComboBox cmbStatus;
        private ComboBox cmbVehicleType;
        private DateTimePicker dtpFrom;
        private DateTimePicker dtpTo;
        private Label lblReportType;
        private Label lblFrom;
        private Label lblTo;
        private Label lblStatus;
        private Label lblVehicleType;
        private CheckBox cbAllDates;
        private FontAwesome.Sharp.IconButton btnPrint;
        private FontAwesome.Sharp.IconButton btnClear;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblStatusBar;
        private Label lblReportTitle;
        private GroupBox gbDateRange;
        private GroupBox gbFilters;
    }
}