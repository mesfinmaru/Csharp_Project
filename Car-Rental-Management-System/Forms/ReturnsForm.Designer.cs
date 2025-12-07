namespace Car_Rental_Management_System.Forms
{
    partial class ReturnsForm
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
            btnComplete = new FontAwesome.Sharp.IconButton();
            dgvReturns = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvReturns).BeginInit();
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
            btnDelete.Location = new Point(1162, 21);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(200, 60);
            btnDelete.TabIndex = 30;
            btnDelete.Text = "Delete";
            btnDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Trebuchet MS", 10.125F);
            btnEdit.IconChar = FontAwesome.Sharp.IconChar.UserPen;
            btnEdit.IconColor = Color.Black;
            btnEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEdit.Location = new Point(927, 21);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(200, 60);
            btnEdit.TabIndex = 29;
            btnEdit.Text = "Edit";
            btnEdit.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnComplete
            // 
            btnComplete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnComplete.FlatStyle = FlatStyle.Flat;
            btnComplete.Font = new Font("Trebuchet MS", 10.125F);
            btnComplete.IconChar = FontAwesome.Sharp.IconChar.ArrowDown;
            btnComplete.IconColor = Color.Black;
            btnComplete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnComplete.Location = new Point(686, 21);
            btnComplete.Name = "btnComplete";
            btnComplete.Size = new Size(200, 60);
            btnComplete.TabIndex = 28;
            btnComplete.Text = "Complete";
            btnComplete.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnComplete.UseVisualStyleBackColor = true;
            // 
            // dgvReturns
            // 
            dgvReturns.AllowUserToAddRows = false;
            dgvReturns.AllowUserToDeleteRows = false;
            dgvReturns.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvReturns.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReturns.ColumnHeadersHeight = 46;
            dgvReturns.Location = new Point(26, 101);
            dgvReturns.Name = "dgvReturns";
            dgvReturns.ReadOnly = true;
            dgvReturns.RowHeadersWidth = 82;
            dgvReturns.Size = new Size(1336, 594);
            dgvReturns.TabIndex = 27;
            // 
            // ReturnsForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1389, 717);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnComplete);
            Controls.Add(dgvReturns);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ReturnsForm";
            Text = "ReturnsForm";
            Load += ReturnsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReturns).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FontAwesome.Sharp.IconButton btnDelete;
        private FontAwesome.Sharp.IconButton btnEdit;
        private FontAwesome.Sharp.IconButton btnComplete;
        private DataGridView dgvReturns;
    }
}