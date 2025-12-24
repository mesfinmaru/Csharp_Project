using Car_Rental_Management_System;
using CRM_API.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;

namespace Car_Rental_Management_System.Forms
{
    public partial class SelectCustomer : Form
    {
        private readonly ApiClient _apiClient;
        private List<CustomerVM>? _customersList;
        private List<CustomerVM>? _filteredCustomersList;
        public CustomerVM? SelectedCustomer { get; private set; }

        public SelectCustomer(ApiClient apiClient)
        {
            try
            {
                InitializeComponent();
                _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));

                ApplyTheme();
                SetupDataGridView();
                _ = LoadCustomersAsync();
            }
            catch
            {
                MessageBox.Show("Failed to initialize form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void ApplyTheme()
        {
            var bg = Color.FromArgb(0, 90, 158);
           
            var panelBg = Color.FromArgb(39, 40, 55);
            var primary = Color.FromArgb(124, 77, 255);
            var secondary = Color.FromArgb(83, 109, 254);
            var lightText = Color.FromArgb(230, 230, 235);

            this.BackColor = bg;

            // Search TextBox
            txtSearch.BackColor = panelBg;
            txtSearch.ForeColor = lightText;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;

            // Buttons
            btnSelect.BackColor = primary;
            btnSelect.ForeColor = Color.White;
            btnSelect.FlatStyle = FlatStyle.Flat;
            btnSelect.FlatAppearance.BorderSize = 0;

            btnAddNewCustomer.BackColor = secondary;
            btnAddNewCustomer.ForeColor = Color.White;
            btnAddNewCustomer.FlatStyle = FlatStyle.Flat;
            btnAddNewCustomer.FlatAppearance.BorderSize = 0;

            btnCancel.BackColor = Color.FromArgb(255, 98, 70);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;

            // DataGridView
            dgvCustomers.BackgroundColor = Color.FromArgb(30, 30, 44);
            dgvCustomers.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 44);
            dgvCustomers.DefaultCellStyle.ForeColor = lightText;
            dgvCustomers.DefaultCellStyle.SelectionBackColor = primary;
            dgvCustomers.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvCustomers.ColumnHeadersDefaultCellStyle.BackColor = primary;
            dgvCustomers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCustomers.EnableHeadersVisualStyles = false;
            dgvCustomers.GridColor = Color.FromArgb(55, 55, 70);
            dgvCustomers.RowTemplate.Height = 36;
            dgvCustomers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(35, 35, 50);
            dgvCustomers.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvCustomers.ColumnHeadersHeight = 40;
        }

        private void SetupDataGridView()
        {
            dgvCustomers.AutoGenerateColumns = false;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.MultiSelect = false;
            dgvCustomers.ReadOnly = true;
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.RowHeadersVisible = false;

            dgvCustomers.Columns.Clear();

            // Add columns
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colId",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Width = 50,
                Visible = false
            });

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colName",
                HeaderText = "Name",
                DataPropertyName = "FullName",
                Width = 150
            });

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colPhone",
                HeaderText = "Phone",
                DataPropertyName = "Phone",
                Width = 120
            });

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colEmail",
                HeaderText = "Email",
                DataPropertyName = "Email",
                Width = 150
            });

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colLicense",
                HeaderText = "License No",
                DataPropertyName = "LicenseNumber",
                Width = 120
            });

            dgvCustomers.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                Name = "colSelect",
                HeaderText = "Select",
                Width = 60,
                ReadOnly = false
            });
        }

        private async Task LoadCustomersAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvCustomers.DataSource = null;

                if (_apiClient == null || !_apiClient.IsAuthenticated)
                {
                    MessageBox.Show("Please login first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _customersList = await _apiClient.GetCustomersAsync(txtSearch.Text.Trim());

                if (_customersList != null && _customersList.Count > 0)
                {
                    _filteredCustomersList = _customersList.Where(c => c.IsActive).ToList();
                    dgvCustomers.DataSource = _filteredCustomersList;
                }
                else
                {
                    dgvCustomers.DataSource = new List<CustomerVM>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load customers: {CleanErrorMessage(ex.Message)}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _ = LoadCustomersAsync();
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dgvCustomers.Columns[e.ColumnIndex].Name == "colSelect")
            {
                // Uncheck all other rows
                foreach (DataGridViewRow row in dgvCustomers.Rows)
                {
                    if (row.Index != e.RowIndex)
                    {
                        row.Cells["colSelect"].Value = false;
                    }
                }

                // Toggle current row
                bool currentValue = Convert.ToBoolean(dgvCustomers.Rows[e.RowIndex].Cells["colSelect"].Value ?? false);
                dgvCustomers.Rows[e.RowIndex].Cells["colSelect"].Value = !currentValue;

                // Update selected customer
                if (!currentValue)
                {
                    SelectedCustomer = dgvCustomers.Rows[e.RowIndex].DataBoundItem as CustomerVM;
                }
                else
                {
                    SelectedCustomer = null;
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (SelectedCustomer == null)
            {
                MessageBox.Show("Please select a customer first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                using (var addCustomerForm = new AddCustomer(_apiClient))
                {
                    if (addCustomerForm.ShowDialog() == DialogResult.OK)
                    {
                        // Refresh the list
                        _ = LoadCustomersAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cannot open Add Customer form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private string CleanErrorMessage(string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(errorMessage))
                return "Unknown error occurred";

            // Simple error cleanup
            return errorMessage;
        }
    }
}