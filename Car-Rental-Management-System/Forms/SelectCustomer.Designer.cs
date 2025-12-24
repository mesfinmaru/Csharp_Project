namespace Car_Rental_Management_System.Forms
{
    partial class SelectCustomer
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
            btnAddNewCustomer = new Button();
            btnCancel = new Button();
            btnSelect = new Button();
            panel2 = new Panel();
            lblHeader = new Label();
            txtSearch = new TextBox();
            label4 = new Label();
            dgvCustomers = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnAddNewCustomer);
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnSelect);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 838);
            panel1.Name = "panel1";
            panel1.Size = new Size(1030, 106);
            panel1.TabIndex = 0;
            // 
            // btnAddNewCustomer
            // 
            btnAddNewCustomer.Location = new Point(376, 30);
            btnAddNewCustomer.Name = "btnAddNewCustomer";
            btnAddNewCustomer.Size = new Size(259, 46);
            btnAddNewCustomer.TabIndex = 23;
            btnAddNewCustomer.Text = "Add New Customer";
            btnAddNewCustomer.UseVisualStyleBackColor = true;
            btnAddNewCustomer.Click += btnAddNewCustomer_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(172, 30);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 46);
            btnCancel.TabIndex = 22;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSelect
            // 
            btnSelect.Location = new Point(684, 30);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(150, 46);
            btnSelect.TabIndex = 21;
            btnSelect.Text = "Select";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblHeader);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1030, 89);
            panel2.TabIndex = 1;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.FlatStyle = FlatStyle.Flat;
            lblHeader.Font = new Font("Trebuchet MS", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.Location = new Point(37, 25);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(240, 37);
            lblHeader.TabIndex = 4;
            lblHeader.Text = "Select Customer";
            lblHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Trebuchet MS", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(151, 111);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search for customers...";
            txtSearch.Size = new Size(572, 39);
            txtSearch.TabIndex = 7;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Trebuchet MS", 10.125F);
            label4.Location = new Point(28, 111);
            label4.Name = "label4";
            label4.Size = new Size(96, 35);
            label4.TabIndex = 15;
            label4.Text = "Search";
            // 
            // dgvCustomers
            // 
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.AllowUserToDeleteRows = false;
            dgvCustomers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.ColumnHeadersHeight = 46;
            dgvCustomers.Location = new Point(12, 173);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.ReadOnly = true;
            dgvCustomers.RowHeadersWidth = 82;
            dgvCustomers.Size = new Size(1006, 648);
            dgvCustomers.TabIndex = 16;
            dgvCustomers.CellContentClick += dgvCustomers_CellContentClick;
            // 
            // SelectCustomer
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1030, 944);
            Controls.Add(dgvCustomers);
            Controls.Add(label4);
            Controls.Add(txtSearch);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SelectCustomer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SelectCustomer";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label lblHeader;
        private TextBox txtSearch;
        private Label label4;
        private DataGridView dgvCustomers;
        private Button btnAddNewCustomer;
        private Button btnCancel;
        private Button btnSelect;
    }
}