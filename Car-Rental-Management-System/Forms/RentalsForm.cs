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
    public partial class RentalsForm : Form
    {
        public RentalsForm()
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

            //// Textbox
            //txtSearch.BackColor = panelBg;
            //txtSearch.ForeColor = lightText;
            //txtSearch.BorderStyle = BorderStyle.FixedSingle;

            // Buttons
            btnCreateRental.BackColor = primary;
            btnCreateRental.ForeColor = Color.White;
            btnEdit.BackColor = secondary;
            btnEdit.ForeColor = Color.White;
            btnDelete.BackColor = Color.FromArgb(255, 98, 70);
            btnDelete.ForeColor = Color.White;

            // DataGridView style
            dgvRentals.BackgroundColor = Color.FromArgb(30, 30, 44);
            dgvRentals.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 44);
            dgvRentals.DefaultCellStyle.ForeColor = lightText;
            dgvRentals.ColumnHeadersDefaultCellStyle.BackColor = primary;
            dgvRentals.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRentals.EnableHeadersVisualStyles = false;
            dgvRentals.GridColor = Color.FromArgb(55, 55, 70);
            dgvRentals.RowTemplate.Height = 36;

            // Header

        }

        private void WireEvents()
        {
            // Example event handlers; wire real logic here
            btnCreateRental.Click += (s, e) => MessageBox.Show("Add - implement logic");
            btnEdit.Click += (s, e) =>
            {
                if (dgvRentals.SelectedRows.Count == 0) { MessageBox.Show("Select a row first."); return; }
                MessageBox.Show("Edit - implement logic");
            };
            btnDelete.Click += (s, e) =>
            {
                if (dgvRentals.SelectedRows.Count == 0) { MessageBox.Show("Select a row first."); return; }
                var id = dgvRentals.SelectedRows[0].Cells[0].Value;
                if (MessageBox.Show($"Delete ID {id}?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // remove demo row (replace with DB logic)
                    dgvRentals.Rows.RemoveAt(dgvRentals.SelectedRows[0].Index);
                }
            };
        }

        private void RentalsForm_Load(object sender, EventArgs e)
        {

        }

        private void dgvRentals_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
