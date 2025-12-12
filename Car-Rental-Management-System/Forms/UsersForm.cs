using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Car_Rental_Management_System.Forms
{
    public partial class UsersForm : Form
    {
        public UsersForm()
        {
            InitializeComponent();
            ApplyTheme();
            WireEvents();
        }



        private void ApplyTheme()
        {
            // Neon Theme A colors
            var bg = Color.FromArgb(26, 27, 39);
            var panelBg = Color.FromArgb(39, 40, 55);
            var primary = Color.FromArgb(124, 77, 255);
            var secondary = Color.FromArgb(83, 109, 254);
            var accent = Color.FromArgb(255, 152, 0);
            var lightText = Color.FromArgb(230, 230, 235);

            this.BackColor = bg;

            // Textbox
            txtSearch.BackColor = panelBg;
            txtSearch.ForeColor = lightText;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;

            // Buttons
            btnAdd.BackColor = primary;
            btnAdd.ForeColor = Color.White;
            btnEdit.BackColor = secondary;
            btnEdit.ForeColor = Color.White;
            btnDelete.BackColor = Color.FromArgb(255, 98, 70);
            btnDelete.ForeColor = Color.White;

            // DataGridView style
            dgvUsers.BackgroundColor = Color.FromArgb(30, 30, 44);
            dgvUsers.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 44);
            dgvUsers.DefaultCellStyle.ForeColor = lightText;
            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = primary;
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.GridColor = Color.FromArgb(55, 55, 70);
            dgvUsers.RowTemplate.Height = 36;

            // Header

        }

        private void WireEvents()
        {
            // Example event handlers; wire real logic here
            btnAdd.Click += (s, e) => MessageBox.Show("Add - implement logic");
            btnEdit.Click += (s, e) =>
            {
                if (dgvUsers.SelectedRows.Count == 0) { MessageBox.Show("Select a row first."); return; }
                MessageBox.Show("Edit - implement logic");
            };
            btnDelete.Click += (s, e) =>
            {
                if (dgvUsers.SelectedRows.Count == 0) { MessageBox.Show("Select a row first."); return; }
                var id = dgvUsers.SelectedRows[0].Cells[0].Value;
                if (MessageBox.Show($"Delete ID {id}?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // remove demo row (replace with DB logic)
                    dgvUsers.Rows.RemoveAt(dgvUsers.SelectedRows[0].Index);
                }
            };
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
