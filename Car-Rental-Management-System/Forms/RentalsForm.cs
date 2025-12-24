using Car_Rental_Management_System;
using CRM_API.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Rental_Management_System.Forms
{
    public partial class RentalsForm : Form
    {
        private ApiClient? _apiClient;
        private List<RentalVM>? _rentalsList;
        private List<RentalVM>? _filteredRentalsList;
        private ToolTip _toolTip;

        public RentalsForm()
        {
            InitializeComponent();
            ApplyTheme();
            SetupDataGridView();
            SetupToolTip();
        }

        public RentalsForm(ApiClient apiClient) : this()
        {
            _apiClient = apiClient;
            _ = LoadRentalsAsync();
        }

        private void SetupToolTip()
        {
            _toolTip = new ToolTip();
            _toolTip.SetToolTip(btnDelete, "Delete selected rental");
            _toolTip.SetToolTip(btnEdit, "Edit selected rental");
            _toolTip.SetToolTip(btnNewRental, "Create new rental");
            _toolTip.SetToolTip(btnReturnVehicle, "Return selected vehicle");
        }

        private void ApplyTheme()
        {
            var bg = Color.FromArgb(26, 27, 39);
            var panelBg = Color.FromArgb(39, 40, 55);
            var primary = Color.FromArgb(124, 77, 255);
            var secondary = Color.FromArgb(83, 109, 254);
            var accent = Color.FromArgb(46, 204, 113);
            var lightText = Color.FromArgb(230, 230, 235);

            this.BackColor = bg;

            // Search TextBox
            txtSearch.BackColor = panelBg;
            txtSearch.ForeColor = lightText;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;

            // Buttons
            btnNewRental.BackColor = primary;
            btnNewRental.ForeColor = Color.White;
            btnNewRental.FlatStyle = FlatStyle.Flat;
            btnNewRental.FlatAppearance.BorderSize = 0;

            btnEdit.BackColor = secondary;
            btnEdit.ForeColor = Color.White;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.FlatAppearance.BorderSize = 0;

            btnDelete.BackColor = Color.FromArgb(255, 98, 70);
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;

            btnReturnVehicle.BackColor = accent;
            btnReturnVehicle.ForeColor = Color.White;
            btnReturnVehicle.FlatStyle = FlatStyle.Flat;
            btnReturnVehicle.FlatAppearance.BorderSize = 0;

            // DataGridView
            dgvRentals.BackgroundColor = Color.FromArgb(30, 30, 44);
            dgvRentals.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 44);
            dgvRentals.DefaultCellStyle.ForeColor = lightText;
            dgvRentals.DefaultCellStyle.SelectionBackColor = primary;
            dgvRentals.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvRentals.ColumnHeadersDefaultCellStyle.BackColor = primary;
            dgvRentals.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRentals.EnableHeadersVisualStyles = false;
            dgvRentals.GridColor = Color.FromArgb(55, 55, 70);
            dgvRentals.RowTemplate.Height = 36;
            dgvRentals.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(35, 35, 50);
            dgvRentals.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRentals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvRentals.ColumnHeadersHeight = 40;
        }

        private void SetupDataGridView()
        {
            dgvRentals.AutoGenerateColumns = false;
            dgvRentals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRentals.MultiSelect = false;
            dgvRentals.ReadOnly = true;
            dgvRentals.AllowUserToAddRows = false;
            dgvRentals.RowHeadersVisible = false;

            dgvRentals.Columns.Clear();

            // Add columns
            dgvRentals.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colId",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Width = 50,
                Visible = false
            });

            dgvRentals.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colCustomer",
                HeaderText = "Customer",
                DataPropertyName = "CustomerName",
                Width = 150
            });

            dgvRentals.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colVehicle",
                HeaderText = "Vehicle",
                DataPropertyName = "VehiclePlateNumber",
                Width = 100
            });

            dgvRentals.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colMakeModel",
                HeaderText = "Make/Model",
                Width = 120,
                ValueType = typeof(string)
            });

            dgvRentals.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colStartDate",
                HeaderText = "From Date",
                DataPropertyName = "StartDate",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Format = "dd/MM/yyyy",
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            dgvRentals.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colEndDate",
                HeaderText = "To Date",
                DataPropertyName = "EndDate",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Format = "dd/MM/yyyy",
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            dgvRentals.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colDays",
                HeaderText = "Days",
                DataPropertyName = "RentalDays",
                Width = 60,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            dgvRentals.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colTotal",
                HeaderText = "Total",
                DataPropertyName = "TotalAmount",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Format = "ETB #,##0.00",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });

            dgvRentals.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colPaid",
                HeaderText = "Paid",
                DataPropertyName = "AmountPaid",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Format = "ETB #,##0.00",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });

            dgvRentals.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colBalance",
                HeaderText = "Balance",
                DataPropertyName = "BalanceDue",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Format = "ETB #,##0.00",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });

            dgvRentals.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colStatus",
                HeaderText = "Status",
                DataPropertyName = "Status",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    ForeColor = Color.White
                }
            });

            dgvRentals.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colCreated",
                HeaderText = "Created",
                DataPropertyName = "CreatedAt",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Format = "dd/MM/yyyy",
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            dgvRentals.DataError += (sender, e) =>
            {
                if (e.Exception is FormatException)
                {
                    e.ThrowException = false;
                }
            };
        }

        private async Task LoadRentalsAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvRentals.DataSource = null;
                lblStatus.Text = "Loading rentals...";

                if (_apiClient == null)
                {
                    lblStatus.Text = "API Client not initialized";
                    ShowError("RentalsForm was not initialized properly. Please reopen the form.");
                    return;
                }

                if (!_apiClient.IsAuthenticated)
                {
                    lblStatus.Text = "Please login first";
                    ShowInfo("Please login to view rentals");
                    return;
                }

                try
                {
                    _rentalsList = await _apiClient.GetRentalsAsync(txtSearch.Text.Trim());

                    if (_rentalsList != null && _rentalsList.Count > 0)
                    {
                        _filteredRentalsList = new List<RentalVM>(_rentalsList);

                        // Calculate Make/Model column
                        foreach (var rental in _filteredRentalsList)
                        {
                            rental.VehicleModel = $"{rental.VehicleMake} {rental.VehicleModel}";
                        }

                        dgvRentals.DataSource = null;
                        dgvRentals.DataSource = _filteredRentalsList;

                        // Format status columns
                        FormatStatusColumns();
                        UpdateStatusLabel();
                    }
                    else
                    {
                        lblStatus.Text = "No rentals found";
                        dgvRentals.DataSource = new List<RentalVM>();
                    }
                }
                catch (HttpRequestException httpEx)
                {
                    lblStatus.Text = "API Error";

                    // Check for specific error messages
                    if (httpEx.Message.Contains("Authentication required"))
                    {
                        ShowError("Your session has expired. Please login again.");
                        // You might want to trigger logout here
                    }
                    else if (httpEx.Message.Contains("404"))
                    {
                        ShowError("Rentals API endpoint not found. Please check if the API is running.");
                    }
                    else
                    {
                        ShowError($"Cannot connect to server: {CleanErrorMessage(httpEx.Message)}");
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error loading";
                ShowError($"Failed to load rentals: {CleanErrorMessage(ex.Message)}");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void FormatStatusColumns()
        {
            if (dgvRentals.Columns["colStatus"] != null && dgvRentals.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvRentals.Rows)
                {
                    if (row.DataBoundItem is RentalVM rental)
                    {
                        // Apply color coding
                        switch (rental.Status?.ToLower())
                        {
                            case "active":
                                if (rental.IsOverdue)
                                {
                                    row.Cells["colStatus"].Style.BackColor = Color.FromArgb(255, 152, 0); // Orange for overdue
                                    row.Cells["colStatus"].Value = $"Overdue ({rental.DaysOverdue}d)";
                                }
                                else
                                {
                                    row.Cells["colStatus"].Style.BackColor = Color.FromArgb(46, 204, 113); // Green
                                }
                                break;
                            case "completed":
                                row.Cells["colStatus"].Style.BackColor = Color.FromArgb(108, 117, 125); // Gray
                                break;
                            case "cancelled":
                                row.Cells["colStatus"].Style.BackColor = Color.FromArgb(255, 98, 70); // Red
                                break;
                            case "reserved":
                                row.Cells["colStatus"].Style.BackColor = Color.FromArgb(255, 193, 7); // Yellow
                                break;
                            default:
                                row.Cells["colStatus"].Style.BackColor = rental.IsActive ?
                                    Color.FromArgb(46, 204, 113) :
                                    Color.FromArgb(108, 117, 125);
                                break;
                        }
                        row.Cells["colStatus"].Style.ForeColor = Color.White;
                        row.Cells["colStatus"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
            }
        }

        private void UpdateStatusLabel()
        {
            if (_rentalsList == null) return;

            int totalCount = _rentalsList.Count;
            int filteredCount = _filteredRentalsList?.Count ?? 0;
            int activeCount = _rentalsList.Count(r => r.Status == "Active");
            int overdueCount = _rentalsList.Count(r => r.IsOverdue);

            if (string.IsNullOrEmpty(txtSearch.Text.Trim()))
            {
                lblStatus.Text = $"{totalCount} rental(s) - {activeCount} active, {overdueCount} overdue";
            }
            else
            {
                lblStatus.Text = $"Showing {filteredCount} of {totalCount} rental(s)";
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

            // Clean error message (same as VehiclesForm)
            errorMessage = System.Text.RegularExpressions.Regex.Replace(errorMessage, "<[^>]*>", " ");
            errorMessage = System.Web.HttpUtility.HtmlDecode(errorMessage);

            string[] prefixes = {
                "API Error:", "HttpRequestException:", "System.Net.Http.HttpRequestException:",
                "BadRequest", "400", "404", "500", "StatusCode:"
            };

            foreach (var prefix in prefixes)
            {
                errorMessage = errorMessage.Replace(prefix, "").Trim();
            }

            if (errorMessage.Contains("JSON tokens") || errorMessage.Contains("isFinalBlock") ||
                errorMessage.Contains("LineNumber: 0") || errorMessage.Contains("BytePositionInLine"))
            {
                if (errorMessage.Contains("The input does not contain any JSON tokens"))
                    return "Server returned an invalid response. Please check if the API endpoint is correct.";

                return "Server returned an unexpected response format.";
            }

            errorMessage = System.Text.RegularExpressions.Regex.Replace(errorMessage, @"\s+", " ");

            if (errorMessage.Length > 200)
                errorMessage = errorMessage.Substring(0, 197) + "...";

            return errorMessage.Trim();
        }

        private void DgvRentals_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = dgvRentals.SelectedRows.Count > 0;
            btnEdit.Enabled = hasSelection;
            btnDelete.Enabled = hasSelection;
            btnReturnVehicle.Enabled = hasSelection;

            // Only enable return button for active rentals
            if (hasSelection)
            {
                var selectedRental = dgvRentals.SelectedRows[0].DataBoundItem as RentalVM;
                btnReturnVehicle.Enabled = selectedRental?.Status == "Active";
            }
        }

        private async void btnNewRental_Click(object sender, EventArgs e)
        {
            if (_apiClient == null)
            {
                ShowError("API Client is null! RentalsForm was not initialized properly.");
                return;
            }

            if (!_apiClient.IsAuthenticated)
            {
                ShowError("Please login first");
                return;
            }

            try
            {
                using (var newRentalForm = new NewRentalsForm(_apiClient))
                {
                    if (newRentalForm.ShowDialog() == DialogResult.OK)
                    {
                        await LoadRentalsAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError($"Cannot open New Rental form: {ex.Message}");
            }
        }

        private async void btnReturnVehicle_Click(object sender, EventArgs e)
        {
            if (dgvRentals.SelectedRows.Count == 0)
            {
                ShowInfo("Please select a rental to return vehicle.");
                return;
            }

            var selectedRow = dgvRentals.SelectedRows[0];
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

            int rentalId = Convert.ToInt32(idValue);

            try
            {
                using (var returnForm = new ReturnVehicle(_apiClient, rentalId))
                {
                    if (returnForm.ShowDialog() == DialogResult.OK)
                    {
                        var vehiclePlate = selectedRow.Cells["colVehicle"].Value?.ToString() ?? "Unknown";
                        ShowSuccess($"Vehicle {vehiclePlate} returned successfully!");
                        await LoadRentalsAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError($"Cannot return vehicle: {ex.Message}");
            }
        }
        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvRentals.SelectedRows.Count == 0)
            {
                ShowInfo("Please select a rental to edit.");
                return;
            }

            var selectedRow = dgvRentals.SelectedRows[0];
            var idValue = selectedRow.Cells["colId"].Value;

            if (idValue == null)
            {
                ShowError("Invalid selection");
                return;
            }

            if (_apiClient == null)
            {
                ShowError("API Client is null! RentalsForm was not initialized properly.");
                return;
            }

            if (!_apiClient.IsAuthenticated)
            {
                ShowError("Please login first");
                return;
            }

            try
            {
                int rentalId = Convert.ToInt32(idValue);
                int selectedRowIndex = selectedRow.Index;

                using (var editForm = new EditRental(_apiClient, rentalId))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        await LoadRentalsAsync();

                        // Try to reselect the same row
                        if (dgvRentals.Rows.Count > selectedRowIndex)
                        {
                            dgvRentals.Rows[selectedRowIndex].Selected = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError($"Cannot open Edit Rental form: {ex.Message}");
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvRentals.SelectedRows.Count == 0)
            {
                ShowInfo("Please select a rental to delete.");
                return;
            }

            var selectedRow = dgvRentals.SelectedRows[0];
            var idValue = selectedRow.Cells["colId"].Value;
            var customerName = selectedRow.Cells["colCustomer"].Value?.ToString() ?? "Unknown";
            var vehiclePlate = selectedRow.Cells["colVehicle"].Value?.ToString() ?? "Unknown";
            var status = selectedRow.Cells["colStatus"].Value?.ToString() ?? "Unknown";

            if (idValue == null)
            {
                ShowError("Invalid selection");
                return;
            }

            if (_apiClient == null)
            {
                ShowError("API Client is null! RentalsForm was not initialized properly.");
                return;
            }

            if (!_apiClient.IsAuthenticated)
            {
                ShowError("Please login first");
                return;
            }

            int rentalId = Convert.ToInt32(idValue);

            // Check if rental is completed
            if (status == "Completed")
            {
                ShowError("Cannot delete completed rentals. They are kept for accounting records.");
                return;
            }

            var result = MessageBox.Show(
                $"Are you sure you want to delete rental for '{customerName}' with vehicle '{vehiclePlate}'?\n\n" +
                $"This will: {(status == "Active" ? "\n• Mark vehicle as AVAILABLE again" : "")}\n• This action cannot be undone!",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                try
                {
                    lblStatus.Text = "Deleting...";
                    await _apiClient.DeleteRentalAsync(rentalId);

                    lblStatus.Text = "Rental deleted!";
                    ShowSuccess($"Rental has been deleted.");

                    await LoadRentalsAsync();
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Delete failed";
                    ShowError($"Failed to delete rental: {CleanErrorMessage(ex.Message)}");
                    await LoadRentalsAsync();
                }
            }
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            await LoadRentalsAsync();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
            }
        }

        private async void RentalsForm_Load(object sender, EventArgs e)
        {
            await LoadRentalsAsync();
        }

        private void RentalsForm_Shown(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        private void dgvRentals_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Format the Make/Model column
            if (dgvRentals.Columns[e.ColumnIndex].Name == "colMakeModel" &&
                e.RowIndex >= 0 &&
                dgvRentals.Rows[e.RowIndex].DataBoundItem is RentalVM rental)
            {
                e.Value = $"{rental.VehicleMake} {rental.VehicleModel}";
            }

            // Format the status column
            else if (dgvRentals.Columns[e.ColumnIndex].Name == "colStatus" &&
                     e.RowIndex >= 0 &&
                     dgvRentals.Rows[e.RowIndex].DataBoundItem is RentalVM rentalVM)
            {
                string status = rentalVM.Status ?? "Unknown";
                e.Value = status;

                // Color coding based on status
                switch (status.ToLower())
                {
                    case "active":
                        if (rentalVM.IsOverdue)
                        {
                            e.CellStyle.BackColor = Color.FromArgb(255, 152, 0);
                            e.Value = $"Overdue ({rentalVM.DaysOverdue}d)";
                        }
                        else
                        {
                            e.CellStyle.BackColor = Color.FromArgb(46, 204, 113);
                        }
                        break;
                    case "completed":
                        e.CellStyle.BackColor = Color.FromArgb(108, 117, 125);
                        break;
                    case "cancelled":
                        e.CellStyle.BackColor = Color.FromArgb(255, 98, 70);
                        break;
                    case "reserved":
                        e.CellStyle.BackColor = Color.FromArgb(255, 193, 7);
                        break;
                    default:
                        e.CellStyle.BackColor = rentalVM.IsActive ?
                            Color.FromArgb(46, 204, 113) :
                            Color.FromArgb(108, 117, 125);
                        break;
                }

                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void dgvRentals_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content click if needed
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {
            // Status label click handler
        }
    }
}