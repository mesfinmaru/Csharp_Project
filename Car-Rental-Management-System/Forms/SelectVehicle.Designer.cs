namespace Car_Rental_Management_System.Forms
{
    partial class SelectVehicle
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
            btnCancel = new Button();
            btnSelectVehicle = new Button();
            panel2 = new Panel();
            lblHeader = new Label();
            dgvVehicles = new DataGridView();
            label4 = new Label();
            txtSearch = new TextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVehicles).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnSelectVehicle);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 805);
            panel1.Name = "panel1";
            panel1.Size = new Size(1058, 106);
            panel1.TabIndex = 17;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(213, 30);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 46);
            btnCancel.TabIndex = 22;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSelectVehicle
            // 
            btnSelectVehicle.Location = new Point(622, 30);
            btnSelectVehicle.Name = "btnSelectVehicle";
            btnSelectVehicle.Size = new Size(150, 46);
            btnSelectVehicle.TabIndex = 21;
            btnSelectVehicle.Text = "Select";
            btnSelectVehicle.UseVisualStyleBackColor = true;
            btnSelectVehicle.Click += btnSelectVehicle_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblHeader);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1058, 89);
            panel2.TabIndex = 18;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.FlatStyle = FlatStyle.Flat;
            lblHeader.Font = new Font("Trebuchet MS", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.Location = new Point(37, 25);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(211, 37);
            lblHeader.TabIndex = 4;
            lblHeader.Text = "Select Vehicle";
            lblHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvVehicles
            // 
            dgvVehicles.AllowUserToAddRows = false;
            dgvVehicles.AllowUserToDeleteRows = false;
            dgvVehicles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvVehicles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVehicles.ColumnHeadersHeight = 46;
            dgvVehicles.Location = new Point(12, 173);
            dgvVehicles.Name = "dgvVehicles";
            dgvVehicles.ReadOnly = true;
            dgvVehicles.RowHeadersWidth = 82;
            dgvVehicles.Size = new Size(1030, 603);
            dgvVehicles.TabIndex = 21;
            dgvVehicles.CellContentClick += dgvVehicles_CellContentClick;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Trebuchet MS", 10.125F);
            label4.Location = new Point(28, 111);
            label4.Name = "label4";
            label4.Size = new Size(96, 35);
            label4.TabIndex = 20;
            label4.Text = "Search";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Trebuchet MS", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(151, 111);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search for vehicles...";
            txtSearch.Size = new Size(572, 39);
            txtSearch.TabIndex = 19;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // SelectVehicle
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1058, 911);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(dgvVehicles);
            Controls.Add(label4);
            Controls.Add(txtSearch);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SelectVehicle";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SelectVehicle";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVehicles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button btnCancel;
        private Button btnSelectVehicle;
        private Panel panel2;
        private Label lblHeader;
        private DataGridView dgvVehicles;
        private Label label4;
        private TextBox txtSearch;
    }
}