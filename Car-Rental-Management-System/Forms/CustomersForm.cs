using System;
using System.Drawing;
using System.Windows.Forms;

namespace Car_Rental_Management_System.Forms
{
    public partial class CustomersForm : Form
    {
        public CustomersForm()
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
            dgvCustomers.BackgroundColor = Color.FromArgb(30, 30, 44);
            dgvCustomers.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 44);
            dgvCustomers.DefaultCellStyle.ForeColor = lightText;
            dgvCustomers.ColumnHeadersDefaultCellStyle.BackColor = primary;
            dgvCustomers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCustomers.EnableHeadersVisualStyles = false;
            dgvCustomers.GridColor = Color.FromArgb(55, 55, 70);
            dgvCustomers.RowTemplate.Height = 36;

            // Header
            lblHeader.ForeColor = lightText;
        }

        private void WireEvents()
        {
            // Example event handlers; wire real logic here
            btnAdd.Click += (s, e) => MessageBox.Show("Add - implement logic");
            btnEdit.Click += (s, e) =>
            {
                if (dgvCustomers.SelectedRows.Count == 0) { MessageBox.Show("Select a row first."); return; }
                MessageBox.Show("Edit - implement logic");
            };
            btnDelete.Click += (s, e) =>
            {
                if (dgvCustomers.SelectedRows.Count == 0) { MessageBox.Show("Select a row first."); return; }
                var id = dgvCustomers.SelectedRows[0].Cells[0].Value;
                if (MessageBox.Show($"Delete ID {id}?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // remove demo row (replace with DB logic)
                    dgvCustomers.Rows.RemoveAt(dgvCustomers.SelectedRows[0].Index);
                }
            };
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
