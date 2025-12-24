namespace Car_Rental_Management_System.Forms
{
    partial class RentalsForm
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
            btnDelete = new FontAwesome.Sharp.IconButton();
            btnEdit = new FontAwesome.Sharp.IconButton();
            btnNewRental = new FontAwesome.Sharp.IconButton();
            dgvRentals = new DataGridView();
            lblStatus = new Label();
            txtSearch = new TextBox();
            btnReturnVehicle = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)dgvRentals).BeginInit();
            SuspendLayout();
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Trebuchet MS", 10.125F);
            btnDelete.IconChar = FontAwesome.Sharp.IconChar.Trash;
            btnDelete.IconColor = Color.Black;
            btnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDelete.IconSize = 45;
            btnDelete.Location = new Point(1196, 12);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(169, 60);
            btnDelete.TabIndex = 26;
            btnDelete.Text = "Delete";
            btnDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Trebuchet MS", 10.125F);
            btnEdit.IconChar = FontAwesome.Sharp.IconChar.Edit;
            btnEdit.IconColor = Color.Black;
            btnEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEdit.Location = new Point(1029, 12);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(152, 60);
            btnEdit.TabIndex = 25;
            btnEdit.Text = "Edit";
            btnEdit.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnNewRental
            // 
            btnNewRental.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNewRental.FlatStyle = FlatStyle.Flat;
            btnNewRental.Font = new Font("Trebuchet MS", 10.125F);
            btnNewRental.IconChar = FontAwesome.Sharp.IconChar.CirclePlus;
            btnNewRental.IconColor = Color.Black;
            btnNewRental.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnNewRental.Location = new Point(606, 12);
            btnNewRental.Name = "btnNewRental";
            btnNewRental.Size = new Size(225, 60);
            btnNewRental.TabIndex = 24;
            btnNewRental.Text = "New Rental";
            btnNewRental.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNewRental.UseVisualStyleBackColor = true;
            btnNewRental.Click += btnNewRental_Click;
            // 
            // dgvRentals
            // 
            dgvRentals.AllowUserToAddRows = false;
            dgvRentals.AllowUserToDeleteRows = false;
            dgvRentals.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvRentals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRentals.ColumnHeadersHeight = 46;
            dgvRentals.Location = new Point(12, 86);
            dgvRentals.Name = "dgvRentals";
            dgvRentals.ReadOnly = true;
            dgvRentals.RowHeadersWidth = 82;
            dgvRentals.Size = new Size(1353, 618);
            dgvRentals.TabIndex = 23;
            dgvRentals.CellContentClick += dgvRentals_CellContentClick;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.ForeColor = Color.IndianRed;
            lblStatus.Location = new Point(500, 20);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(104, 32);
            lblStatus.TabIndex = 28;
            lblStatus.Text = "lblStatus";
            lblStatus.Click += lblStatus_Click;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Trebuchet MS", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(12, 15);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search for rentals...";
            txtSearch.Size = new Size(481, 39);
            txtSearch.TabIndex = 27;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnReturnVehicle
            // 
            btnReturnVehicle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReturnVehicle.FlatStyle = FlatStyle.Flat;
            btnReturnVehicle.Font = new Font("Trebuchet MS", 10.125F);
            btnReturnVehicle.IconChar = FontAwesome.Sharp.IconChar.CircleDown;
            btnReturnVehicle.IconColor = Color.Black;
            btnReturnVehicle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnReturnVehicle.Location = new Point(847, 12);
            btnReturnVehicle.Name = "btnReturnVehicle";
            btnReturnVehicle.Size = new Size(171, 60);
            btnReturnVehicle.TabIndex = 29;
            btnReturnVehicle.Text = "Return";
            btnReturnVehicle.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReturnVehicle.UseVisualStyleBackColor = true;
            btnReturnVehicle.Click += btnReturnVehicle_Click;
            // 
            // RentalsForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1389, 717);
            Controls.Add(btnReturnVehicle);
            Controls.Add(lblStatus);
            Controls.Add(txtSearch);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnNewRental);
            Controls.Add(dgvRentals);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RentalsForm";
            Text = "RentalsForm";
            Load += RentalsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRentals).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconButton btnDelete;
        private FontAwesome.Sharp.IconButton btnEdit;
        private FontAwesome.Sharp.IconButton btnNewRental;
        private DataGridView dgvRentals;
        private Label lblStatus;
        private TextBox txtSearch;
        private FontAwesome.Sharp.IconButton btnReturnVehicle;
    }
}