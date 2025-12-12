namespace Car_Rental_Management_System.Forms
{
    partial class UsersForm
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
            btnAdd = new FontAwesome.Sharp.IconButton();
            txtSearch = new TextBox();
            dgvUsers = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
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
            btnDelete.Location = new Point(1195, 20);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(200, 60);
            btnDelete.TabIndex = 21;
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
            btnEdit.IconChar = FontAwesome.Sharp.IconChar.UserPen;
            btnEdit.IconColor = Color.Black;
            btnEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEdit.Location = new Point(951, 20);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(200, 60);
            btnEdit.TabIndex = 20;
            btnEdit.Text = "Edit";
            btnEdit.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Trebuchet MS", 10.125F);
            btnAdd.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            btnAdd.IconColor = Color.Black;
            btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAdd.Location = new Point(704, 20);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(200, 60);
            btnAdd.TabIndex = 19;
            btnAdd.Text = "Add";
            btnAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Trebuchet MS", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(15, 29);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search for users ...";
            txtSearch.Size = new Size(572, 39);
            txtSearch.TabIndex = 17;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.ColumnHeadersHeight = 46;
            dgvUsers.Location = new Point(15, 97);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersWidth = 82;
            dgvUsers.Size = new Size(1384, 679);
            dgvUsers.TabIndex = 18;
            dgvUsers.CellContentClick += dgvUsers_CellContentClick;
            // 
            // UsersForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1415, 788);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(txtSearch);
            Controls.Add(dgvUsers);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UsersForm";
            Text = "UsersForm";
            Load += UsersForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconButton btnDelete;
        private FontAwesome.Sharp.IconButton btnEdit;
        private FontAwesome.Sharp.IconButton btnAdd;
        private TextBox txtSearch;
        private DataGridView dgvUsers;
    }
}