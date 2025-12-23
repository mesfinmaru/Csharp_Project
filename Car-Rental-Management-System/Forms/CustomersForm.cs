using Car_Rental_Management_System;
using CRM_API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Rental_Management_System.Forms
{
    public partial class CustomersForm : Form
    {
        private ApiClient? _apiClient;
        private List<CustomerVM>? _customersList;
        private List<CustomerVM>? _filteredCustomersList;
        private ToolTip _toolTip;

        public CustomersForm()
        {
            InitializeComponent();
            ApplyTheme();
            SetupDataGridView();
            SetupToolTip();
        }

        public CustomersForm(ApiClient apiClient) : this()
        {
            _apiClient = apiClient;
            _ = LoadCustomersAsync();
        }

        private void SetupToolTip()
        {
            _toolTip = new ToolTip();
            _toolTip.SetToolTip(btnDelete, "Delete selected customer");
            _toolTip.SetToolTip(btnEdit, "Edit selected customer");
            _toolTip.SetToolTip(btnAdd, "Add new customer");
        }

        private void ApplyTheme()
        {
            var bg = Color.FromArgb(26, 27, 39);
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
            btnAdd.BackColor = primary;
            btnAdd.ForeColor = Color.White;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderSize = 0;

            btnEdit.BackColor = secondary;
            btnEdit.ForeColor = Color.White;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.FlatAppearance.BorderSize = 0;

            btnDelete.BackColor = Color.FromArgb(255, 98, 70);
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;

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
                Name = "colFullName",
                HeaderText = "Full Name",
                DataPropertyName = "FullName",
                Width = 150,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colEmail",
                HeaderText = "Email",
                DataPropertyName = "Email",
                Width = 180
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
                Name = "colLicenseNumber",
                HeaderText = "License No.",
                DataPropertyName = "LicenseNumber",
                Width = 100
            });

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colLicenseType",
                HeaderText = "License Type",
                DataPropertyName = "LicenseType",
                Width = 100
            });

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colLicenseExpiryDate",
                HeaderText = "License Expiry",
                DataPropertyName = "LicenseExpiryDate",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Format = "yyyy-MM-dd",
                    NullValue = "N/A"
                }
            });

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colCity",
                HeaderText = "City",
                DataPropertyName = "City",
                Width = 100
            });

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colCountry",
                HeaderText = "Country",
                DataPropertyName = "Country",
                Width = 100
            });

            // Status column - DO NOT bind to IsActive directly
            // Create a custom column that we'll populate manually
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colStatus",
                HeaderText = "Status",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    ForeColor = Color.White
                }
            });

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colCreatedAt",
                HeaderText = "Created",
                DataPropertyName = "CreatedAt",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Format = "yyyy-MM-dd"
                }
            });

         

            // ADD THIS: DataError event handler to prevent the error dialog
            dgvCustomers.DataError += (sender, e) =>
            {
                // Suppress all format errors (like boolean parsing)
                if (e.Exception is FormatException)
                {
                    e.ThrowException = false; // This prevents the error dialog
                }
            };
        }

        private async Task LoadCustomersAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvCustomers.DataSource = null;
                lblStatus.Text = "Loading customers...";

                if (_apiClient == null || !_apiClient.IsAuthenticated)
                {
                    lblStatus.Text = "Please login first";
                    ShowInfo("Please login to view customers");
                    return;
                }

                _customersList = await _apiClient.GetCustomersAsync(txtSearch.Text.Trim());

                if (_customersList != null)
                {
                    _filteredCustomersList = new List<CustomerVM>(_customersList);

                    // Set the data source
                    dgvCustomers.DataSource = _filteredCustomersList;

                    // IMPORTANT: Hide the IsActive column if it was auto-generated
                    if (dgvCustomers.Columns.Contains("IsActive"))
                    {
                        dgvCustomers.Columns["IsActive"].Visible = false;
                    }

                    // Format status column with text values
                    FormatStatusColumn();

                    UpdateStatusLabel();
                }
                else
                {
                    lblStatus.Text = "No customers found";
                    dgvCustomers.DataSource = new List<CustomerVM>();
                }
            }
            catch (HttpRequestException ex)
            {
                lblStatus.Text = "Connection failed";
                ShowError($"Cannot connect to server: {CleanErrorMessage(ex.Message)}");
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error loading";
                ShowError($"Failed to load customers: {CleanErrorMessage(ex.Message)}");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void FormatStatusColumn()
        {
            if (dgvCustomers.Columns["colStatus"] != null)
            {
                foreach (DataGridViewRow row in dgvCustomers.Rows)
                {
                    if (row.DataBoundItem is CustomerVM customer)
                    {
                        // Get the actual boolean value from the data item
                        bool isActive = customer.IsActive;

                        // Display text instead of boolean
                        row.Cells["colStatus"].Value = isActive ? "Active" : "Inactive";
                        row.Cells["colStatus"].Style.BackColor = isActive ?
                            Color.FromArgb(46, 204, 113) :
                            Color.FromArgb(255, 98, 70);
                    }
                }
            }
        }

        private void UpdateStatusLabel()
        {
            if (_customersList == null) return;

            int totalCount = _customersList.Count;
            int filteredCount = _filteredCustomersList?.Count ?? 0;

            if (string.IsNullOrEmpty(txtSearch.Text.Trim()))
            {
                lblStatus.Text = $"{totalCount} customer(s)";
            }
            else
            {
                lblStatus.Text = $"Showing {filteredCount} of {totalCount} customer(s)";
            }
        }


        // Helper Methods
        private static void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static void ShowInfo(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string CleanErrorMessage(string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(errorMessage))
                return "Unknown error occurred";

            // Remove HTML tags
            errorMessage = System.Text.RegularExpressions.Regex.Replace(errorMessage, "<[^>]*>", " ");

            // Decode HTML entities
            errorMessage = System.Web.HttpUtility.HtmlDecode(errorMessage);

            // Remove common error prefixes
            string[] prefixes = {
                "API Error:", "HttpRequestException:", "System.Net.Http.HttpRequestException:",
                "BadRequest", "400", "404", "500", "StatusCode:"
            };

            foreach (var prefix in prefixes)
            {
                errorMessage = errorMessage.Replace(prefix, "").Trim();
            }

            // Clean up JSON parsing errors
            if (errorMessage.Contains("JSON tokens") || errorMessage.Contains("isFinalBlock") ||
                errorMessage.Contains("LineNumber: 0") || errorMessage.Contains("BytePositionInLine"))
            {
                // Try to extract from HTML title if present
                if (errorMessage.Contains("<title>") && errorMessage.Contains("</title>"))
                {
                    int start = errorMessage.IndexOf("<title>") + 7;
                    int end = errorMessage.IndexOf("</title>", start);
                    if (start > 7 && end > start)
                    {
                        return errorMessage.Substring(start, end - start).Trim();
                    }
                }

                // Check if it's a common error
                if (errorMessage.Contains("The input does not contain any JSON tokens"))
                    return "Server returned an invalid response. Please check if the API endpoint is correct.";

                if (errorMessage.Contains("Expected the input to start with a valid JSON token"))
                    return "Server response format is incorrect. Please contact support.";

                return "Server returned an unexpected response format.";
            }

            // Clean up excessive whitespace
            errorMessage = System.Text.RegularExpressions.Regex.Replace(errorMessage, @"\s+", " ");

            // Limit length
            if (errorMessage.Length > 200)
                errorMessage = errorMessage.Substring(0, 197) + "...";

            return errorMessage.Trim();
        }

        private void DgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = dgvCustomers.SelectedRows.Count > 0;
            btnEdit.Enabled = hasSelection;
            btnDelete.Enabled = hasSelection;
        }

        private async void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (_apiClient == null || !_apiClient.IsAuthenticated)
            {
                ShowError("Please login first");
                return;
            }

            using AddCustomer addForm = new AddCustomer(_apiClient);

            // Show the dialog
            var dialogResult = addForm.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                // Auto-refresh when AddCustomer form closes successfully
                await LoadCustomersAsync();
              
            }
        }

        private async void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                ShowInfo("Please select a customer to edit.");
                return;
            }

            var selectedRow = dgvCustomers.SelectedRows[0];
            var idValue = selectedRow.Cells["colId"].Value;

            if (idValue == null)
            {
                ShowError("Invalid selection");
                return;
            }

            if (_apiClient == null || !_apiClient.IsAuthenticated)
            {
                ShowError("Please login first");
                return;
            }

            int customerId = Convert.ToInt32(idValue);

            using EditCustomer editForm = new EditCustomer(_apiClient, customerId);

            // Subscribe to the events BEFORE showing the dialog
            editForm.CustomerUpdated += async (s, args) =>
            {
                await LoadCustomersAsync();
              
            };

            editForm.CustomerStatusChanged += async (s, args) =>
            {
                await LoadCustomersAsync();
            
            };

            var dialogResult = editForm.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                // Auto-refresh when EditCustomer form closes successfully
                await LoadCustomersAsync();
            }
        }

        private async void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                ShowInfo("Please select a customer to delete.");
                return;
            }

            var selectedRow = dgvCustomers.SelectedRows[0];
            var idValue = selectedRow.Cells["colId"].Value;
            var customerName = selectedRow.Cells["colFullName"].Value?.ToString() ?? "Unknown";

            if (idValue == null)
            {
                ShowError("Invalid selection");
                return;
            }

            if (_apiClient == null || !_apiClient.IsAuthenticated)
            {
                ShowError("Please login first");
                return;
            }

            int customerId = Convert.ToInt32(idValue);

            var result = MessageBox.Show(
                $"Are you sure you want to delete customer '{customerName}'?\n\nThis action cannot be undone!",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                try
                {
                    lblStatus.Text = "Deleting...";
                    await _apiClient.DeleteCustomerAsync(customerId);

                    lblStatus.Text = "Customer deleted!";
                    ShowSuccess($"Customer '{customerName}' has been deleted.");

                    // Auto-refresh after delete
                    await LoadCustomersAsync();
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Delete failed";
                    ShowError($"Failed to delete customer: {CleanErrorMessage(ex.Message)}");

                    // Still refresh to ensure data is current
                    await LoadCustomersAsync();
                }
            }
        }

        private async void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            await LoadCustomersAsync();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
            }
        }

        private async void CustomersForm_Load_1(object sender, EventArgs e)
        {
            await LoadCustomersAsync();
        }

        private void CustomersForm_Shown(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        private void dgvCustomers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Format the status column
            if (dgvCustomers.Columns[e.ColumnIndex].Name == "colStatus" &&
                dgvCustomers.Rows[e.RowIndex].DataBoundItem is CustomerVM customer)
            {
                bool isActive = customer.IsActive;
                e.Value = isActive ? "Active" : "Inactive";
                e.CellStyle.BackColor = isActive ?
                    Color.FromArgb(46, 204, 113) :
                    Color.FromArgb(255, 98, 70);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
    }
}