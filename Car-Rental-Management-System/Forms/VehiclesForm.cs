using Car_Rental_Management_System;
using CRM_API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Rental_Management_System.Forms
{
    public partial class VehiclesForm : Form
    {
        private ApiClient? _apiClient;
        private List<VehicleVM>? _vehiclesList;
        private List<VehicleVM>? _filteredVehiclesList;
        private ToolTip _toolTip;

        public VehiclesForm()
        {
            InitializeComponent();
            ApplyTheme();
            SetupDataGridView();
            SetupToolTip();
        }

        public VehiclesForm(ApiClient apiClient) : this()
        {
            _apiClient = apiClient;
            _ = LoadVehiclesAsync();
        }

        private void SetupToolTip()
        {
            _toolTip = new ToolTip();
            _toolTip.SetToolTip(btnDelete, "Delete selected vehicle");
            _toolTip.SetToolTip(btnEdit, "Edit selected vehicle");
            _toolTip.SetToolTip(btnAdd, "Add new vehicle");
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
            dgvVehicles.BackgroundColor = Color.FromArgb(30, 30, 44);
            dgvVehicles.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 44);
            dgvVehicles.DefaultCellStyle.ForeColor = lightText;
            dgvVehicles.DefaultCellStyle.SelectionBackColor = primary;
            dgvVehicles.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvVehicles.ColumnHeadersDefaultCellStyle.BackColor = primary;
            dgvVehicles.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvVehicles.EnableHeadersVisualStyles = false;
            dgvVehicles.GridColor = Color.FromArgb(55, 55, 70);
            dgvVehicles.RowTemplate.Height = 36;
            dgvVehicles.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(35, 35, 50);
            dgvVehicles.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvVehicles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvVehicles.ColumnHeadersHeight = 40;
        }

        private void SetupDataGridView()
        {
            dgvVehicles.AutoGenerateColumns = false;
            dgvVehicles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVehicles.MultiSelect = false;
            dgvVehicles.ReadOnly = true;
            dgvVehicles.AllowUserToAddRows = false;
            dgvVehicles.RowHeadersVisible = false;

            dgvVehicles.Columns.Clear();

            // Add columns
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colId",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Width = 50,
                Visible = false
            });

            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colPlateNumber",
                HeaderText = "Plate No",
                DataPropertyName = "PlateNumber",
                Width = 100
            });

            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colMake",
                HeaderText = "Make",
                DataPropertyName = "Make",
                Width = 100
            });

            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colModel",
                HeaderText = "Model",
                DataPropertyName = "Model",
                Width = 100
            });

            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colYear",
                HeaderText = "Year",
                DataPropertyName = "Year",
                Width = 70
            });

            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colType",
                HeaderText = "Type",
                DataPropertyName = "VehicleType",
                Width = 80
            });

            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colColor",
                HeaderText = "Color",
                DataPropertyName = "Color",
                Width = 80
            });

            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colDailyRate",
                HeaderText = "Daily Rate",
                DataPropertyName = "DailyRate",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Format = "C2"
                }
            });

            // Status column
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colStatus",
                HeaderText = "Status",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    ForeColor = Color.White
                }
            });

            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn()
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

            // Add DataError handler
            dgvVehicles.DataError += (sender, e) =>
            {
                if (e.Exception is FormatException)
                {
                    e.ThrowException = false;
                }
            };
        }

        private async Task LoadVehiclesAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvVehicles.DataSource = null;
                lblStatus.Text = "Loading vehicles...";

                if (_apiClient == null)
                {
                    lblStatus.Text = "API Client not initialized";
                    ShowError("VehiclesForm was not initialized properly. Please reopen the form.");
                    return;
                }

                if (!_apiClient.IsAuthenticated)
                {
                    lblStatus.Text = "Please login first";
                    ShowInfo("Please login to view vehicles");
                    return;
                }

                _vehiclesList = await _apiClient.GetVehiclesAsync(txtSearch.Text.Trim());

                if (_vehiclesList != null && _vehiclesList.Count > 0)
                {
                    _filteredVehiclesList = new List<VehicleVM>(_vehiclesList);

                    // Clear and rebind
                    dgvVehicles.DataSource = null;
                    dgvVehicles.DataSource = _filteredVehiclesList;

                    // Hide auto-generated boolean columns
                    if (dgvVehicles.Columns.Contains("IsActive"))
                    {
                        dgvVehicles.Columns["IsActive"].Visible = false;
                    }
                    if (dgvVehicles.Columns.Contains("IsAvailable"))
                    {
                        dgvVehicles.Columns["IsAvailable"].Visible = false;
                    }

                    // Format status columns
                    FormatStatusColumns();
                    UpdateStatusLabel();
                }
                else
                {
                    lblStatus.Text = "No vehicles found";
                    dgvVehicles.DataSource = new List<VehicleVM>();
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
                ShowError($"Failed to load vehicles: {CleanErrorMessage(ex.Message)}");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void FormatStatusColumns()
        {
            if (dgvVehicles.Columns["colStatus"] != null && dgvVehicles.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvVehicles.Rows)
                {
                    if (row.DataBoundItem is VehicleVM vehicle)
                    {
                        string status = vehicle.Status ?? (vehicle.IsActive ? "Active" : "Inactive");
                        row.Cells["colStatus"].Value = status;

                        // Apply color coding
                        switch (status.ToLower())
                        {
                            case "available":
                                row.Cells["colStatus"].Style.BackColor = Color.FromArgb(46, 204, 113);
                                break;
                            case "rented":
                                row.Cells["colStatus"].Style.BackColor = Color.FromArgb(255, 193, 7);
                                break;
                            case "maintenance":
                                row.Cells["colStatus"].Style.BackColor = Color.FromArgb(255, 98, 70);
                                break;
                            case "reserved":
                                row.Cells["colStatus"].Style.BackColor = Color.FromArgb(74, 144, 226);
                                break;
                            case "inactive":
                                row.Cells["colStatus"].Style.BackColor = Color.FromArgb(108, 117, 125);
                                break;
                            default:
                                row.Cells["colStatus"].Style.BackColor = vehicle.IsActive ?
                                    Color.FromArgb(46, 204, 113) :
                                    Color.FromArgb(255, 98, 70);
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
            if (_vehiclesList == null) return;

            int totalCount = _vehiclesList.Count;
            int filteredCount = _filteredVehiclesList?.Count ?? 0;

            if (string.IsNullOrEmpty(txtSearch.Text.Trim()))
            {
                lblStatus.Text = $"{totalCount} vehicle(s)";
            }
            else
            {
                lblStatus.Text = $"Showing {filteredCount} of {totalCount} vehicle(s)";
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
                if (errorMessage.Contains("The input does not contain any JSON tokens"))
                    return "Server returned an invalid response. Please check if the API endpoint is correct.";

                return "Server returned an unexpected response format.";
            }

            // Clean up excessive whitespace
            errorMessage = System.Text.RegularExpressions.Regex.Replace(errorMessage, @"\s+", " ");

            // Limit length
            if (errorMessage.Length > 200)
                errorMessage = errorMessage.Substring(0, 197) + "...";

            return errorMessage.Trim();
        }

        private void DgvVehicles_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = dgvVehicles.SelectedRows.Count > 0;
            btnEdit.Enabled = hasSelection;
            btnDelete.Enabled = hasSelection;
        }

        private async void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (_apiClient == null)
            {
                ShowError("API Client is null! VehiclesForm was not initialized properly.");
                return;
            }

            if (!_apiClient.IsAuthenticated)
            {
                ShowError("Please login first");
                return;
            }

            try
            {
                AddVehicle addForm = new AddVehicle(_apiClient);
                var dialogResult = addForm.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    await LoadVehiclesAsync();
                }

                addForm.Dispose();
            }
            catch (Exception ex)
            {
                ShowError($"Cannot open Add Vehicle form: {ex.Message}");
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvVehicles.SelectedRows.Count == 0)
            {
                ShowInfo("Please select a vehicle to delete.");
                return;
            }

            var selectedRow = dgvVehicles.SelectedRows[0];
            var idValue = selectedRow.Cells["colId"].Value;
            var plateNumber = selectedRow.Cells["colPlateNumber"].Value?.ToString() ?? "Unknown";

            if (idValue == null)
            {
                ShowError("Invalid selection");
                return;
            }

            if (_apiClient == null)
            {
                ShowError("API Client is null! VehiclesForm was not initialized properly.");
                return;
            }

            if (!_apiClient.IsAuthenticated)
            {
                ShowError("Please login first");
                return;
            }

            int vehicleId = Convert.ToInt32(idValue);

            var result = MessageBox.Show(
                $"Are you sure you want to delete vehicle '{plateNumber}'?\n\nThis action cannot be undone!",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                try
                {
                    lblStatus.Text = "Deleting...";
                    await _apiClient.DeleteVehicleAsync(vehicleId);

                    lblStatus.Text = "Vehicle deleted!";
                    ShowSuccess($"Vehicle '{plateNumber}' has been deleted.");

                    // Auto-refresh after delete
                    await LoadVehiclesAsync();
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Delete failed";
                    ShowError($"Failed to delete vehicle: {CleanErrorMessage(ex.Message)}");

                    // Still refresh to ensure data is current
                    await LoadVehiclesAsync();
                }
            }
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            await LoadVehiclesAsync();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
            }
        }

        private async void VehiclesForm_Load(object sender, EventArgs e)
        {
            await LoadVehiclesAsync();
        }

        private void VehiclesForm_Shown(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        private void dgvVehicles_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Format the status column
            if (dgvVehicles.Columns[e.ColumnIndex].Name == "colStatus" &&
                e.RowIndex >= 0 &&
                dgvVehicles.Rows[e.RowIndex].DataBoundItem is VehicleVM vehicle)
            {
                string status = vehicle.Status ?? (vehicle.IsActive ? "Active" : "Inactive");
                e.Value = status;

                // Color coding based on status
                switch (status.ToLower())
                {
                    case "available":
                        e.CellStyle.BackColor = Color.FromArgb(46, 204, 113);
                        break;
                    case "rented":
                        e.CellStyle.BackColor = Color.FromArgb(255, 193, 7);
                        break;
                    case "maintenance":
                        e.CellStyle.BackColor = Color.FromArgb(255, 98, 70);
                        break;
                    case "reserved":
                        e.CellStyle.BackColor = Color.FromArgb(74, 144, 226);
                        break;
                    case "inactive":
                        e.CellStyle.BackColor = Color.FromArgb(108, 117, 125);
                        break;
                    default:
                        e.CellStyle.BackColor = vehicle.IsActive ?
                            Color.FromArgb(46, 204, 113) :
                            Color.FromArgb(255, 98, 70);
                        break;
                }

                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvVehicles.SelectedRows.Count == 0)
            {
                ShowInfo("Please select a vehicle to edit.");
                return;
            }

            var selectedRow = dgvVehicles.SelectedRows[0];
            var idValue = selectedRow.Cells["colId"].Value;

            if (idValue == null)
            {
                ShowError("Invalid selection");
                return;
            }

            if (_apiClient == null)
            {
                ShowError("API Client is null! VehiclesForm was not initialized properly.");
                return;
            }

            if (!_apiClient.IsAuthenticated)
            {
                ShowError("Please login first");
                return;
            }

            try
            {
                int vehicleId = Convert.ToInt32(idValue);
                int selectedRowIndex = selectedRow.Index;

                // Create and show EditVehicle form
                using (EditVehicle editForm = new EditVehicle(_apiClient, vehicleId))
                {
                    editForm.VehicleUpdated += (s, args) =>
                    {
                        // This event will fire when vehicle is updated
                    };

                    var dialogResult = editForm.ShowDialog();

                    if (dialogResult == DialogResult.OK)
                    {
                        // Refresh the vehicles list
                        await LoadVehiclesAsync();

                        // Try to reselect the same row
                        if (dgvVehicles.Rows.Count > selectedRowIndex)
                        {
                            dgvVehicles.Rows[selectedRowIndex].Selected = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError($"Cannot open Edit Vehicle form: {ex.Message}");
            }
        }

        private void dgvVehicles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content click if needed
        }

        private void DgvVehicles_SelectionChanged_1(object sender, EventArgs e)
        {
            bool hasSelection = dgvVehicles.SelectedRows.Count > 0;
            btnEdit.Enabled = hasSelection;
            btnDelete.Enabled = hasSelection;
        }
    }
}