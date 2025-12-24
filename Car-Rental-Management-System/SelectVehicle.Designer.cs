namespace Car_Rental_Management_System
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
            dgvVehicles = new DataGridView();
            panel2 = new Panel();
            lblHeader = new Label();
            panel1 = new Panel();
            btnCancel = new Button();
            btnSelect = new Button();
            label4 = new Label();
            txtSearch = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvVehicles).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvVehicles
            // 
            dgvVehicles.AllowUserToAddRows = false;
            dgvVehicles.AllowUserToDeleteRows = false;
            dgvVehicles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvVehicles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVehicles.ColumnHeadersHeight = 46;
            dgvVehicles.Location = new Point(10, 173);
            dgvVehicles.Name = "dgvVehicles";
            dgvVehicles.ReadOnly = true;
            dgvVehicles.RowHeadersWidth = 82;
            dgvVehicles.Size = new Size(1006, 636);
            dgvVehicles.TabIndex = 21;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblHeader);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1015, 89);
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
            // panel1
            // 
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnSelect);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 827);
            panel1.Name = "panel1";
            panel1.Size = new Size(1015, 106);
            panel1.TabIndex = 17;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(259, 30);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 46);
            btnCancel.TabIndex = 22;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSelect
            // 
            btnSelect.Location = new Point(608, 30);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(150, 46);
            btnSelect.TabIndex = 21;
            btnSelect.Text = "Select";
            btnSelect.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Trebuchet MS", 10.125F);
            label4.Location = new Point(26, 111);
            label4.Name = "label4";
            label4.Size = new Size(96, 35);
            label4.TabIndex = 20;
            label4.Text = "Search";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Trebuchet MS", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(149, 111);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search for vehicles...";
            txtSearch.Size = new Size(572, 39);
            txtSearch.TabIndex = 19;
            // 
            // SelectVehicle
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1015, 933);
            Controls.Add(dgvVehicles);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label4);
            Controls.Add(txtSearch);
            Name = "SelectVehicle";
            Text = "SelectVehicle";
            ((System.ComponentModel.ISupportInitialize)dgvVehicles).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvVehicles;
        private Panel panel2;
        private Label lblHeader;
        private Panel panel1;
        private Button btnCancel;
        private Button btnSelect;
        private Label label4;
        private TextBox txtSearch;
    }
}