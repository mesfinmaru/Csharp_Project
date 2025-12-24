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
            SuspendLayout();
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.DarkGray;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI", 10F);
            btnExport.IconChar = FontAwesome.Sharp.IconChar.None;
            btnExport.IconColor = Color.Black;
            btnExport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnExport.Location = new Point(670, 34);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(400, 115);
            btnExport.TabIndex = 15;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.BackColor = Color.RoyalBlue;
            btnGenerateReport.FlatStyle = FlatStyle.Flat;
            btnGenerateReport.Font = new Font("Segoe UI", 10F);
            btnGenerateReport.IconChar = FontAwesome.Sharp.IconChar.None;
            btnGenerateReport.IconColor = Color.Black;
            btnGenerateReport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnGenerateReport.Location = new Point(194, 34);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(400, 115);
            btnGenerateReport.TabIndex = 14;
            btnGenerateReport.Text = "Generate Report";
            btnGenerateReport.UseVisualStyleBackColor = false;
            btnGenerateReport.Click += btnGenerateReport_Click;
            // 
            // rtbReport
            // 
            rtbReport.Location = new Point(194, 225);
            rtbReport.Name = "rtbReport";
            rtbReport.Size = new Size(876, 642);
            rtbReport.TabIndex = 16;
            rtbReport.Text = "";
            rtbReport.TextChanged += rtbReport_TextChanged;
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 47);
            ClientSize = new Size(1389, 901);
            Controls.Add(rtbReport);
            Controls.Add(btnExport);
            Controls.Add(btnGenerateReport);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ReportsForm";
            Text = "ReportsForm";
            Load += ReportsForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private FontAwesome.Sharp.IconButton btnExport;
        private FontAwesome.Sharp.IconButton btnGenerateReport;
        private RichTextBox rtbReport;
    }
}