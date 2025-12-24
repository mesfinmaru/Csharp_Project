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
    public partial class SelectVehicle : Form
    {
        private readonly ApiClient _apiClient;
        private List<VehicleVM>? _vehiclesList;
        private List<VehicleVM>? _filteredVehiclesList;
        public VehicleVM? SelectedVehicle { get; private set; }

        public SelectVehicle(ApiClient apiClient)
        {
            try
            {
                InitializeComponent();
                _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));

                ApplyTheme();
                SetupDataGridView();
                _ = LoadVehiclesAsync();
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
            btnSelectVehicle.BackColor = primary;
            btnSelectVehicle.ForeColor = Color.White;
            btnSelectVehicle.FlatStyle = FlatStyle.Flat;
            btnSelectVehicle.FlatAppearance.BorderSize = 0;

            btnCancel.BackColor = Color.FromArgb(255, 98, 70);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;

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
                Name = "colPlate",
                HeaderText = "Plate No",
                DataPropertyName = "PlateNumber",
                Width = 100
            });

            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colMakeModel",
                HeaderText = "Make/Model",
                Width = 150,
                ValueType = typeof(string)
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
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Format = "ETB #,##0.00",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });

            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn()
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

            dgvVehicles.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                Name = "colSelect",
                HeaderText = "Select",
                Width = 60,
                ReadOnly = false
            });
        }

        private async Task LoadVehiclesAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvVehicles.DataSource = null;

                if (_apiClient == null || !_apiClient.IsAuthenticated)
                {
                    MessageBox.Show("Please login first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _vehiclesList = await _apiClient.GetVehiclesAsync(txtSearch.Text.Trim());

                if (_vehiclesList != null && _vehiclesList.Count > 0)
                {
                    // Filter to show only available vehicles
                    _filteredVehiclesList = _vehiclesList
                        .Where(v => v.IsAvailable && v.IsActive && v.Status == "Available")
                        .ToList();

                    // Calculate Make/Model column
                    foreach (var vehicle in _filteredVehiclesList)
                    {
                        vehicle.Model = $"{vehicle.Make} {vehicle.Model}";
                    }

                    dgvVehicles.DataSource = _filteredVehiclesList;

                    // Format status columns
                    FormatStatusColumns();
                }
                else
                {
                    dgvVehicles.DataSource = new List<VehicleVM>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load vehicles: {CleanErrorMessage(ex.Message)}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _ = LoadVehiclesAsync();
        }

        private void dgvVehicles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dgvVehicles.Columns[e.ColumnIndex].Name == "colSelect")
            {
                // Uncheck all other rows
                foreach (DataGridViewRow row in dgvVehicles.Rows)
                {
                    if (row.Index != e.RowIndex)
                    {
                        row.Cells["colSelect"].Value = false;
                    }
                }

                // Toggle current row
                bool currentValue = Convert.ToBoolean(dgvVehicles.Rows[e.RowIndex].Cells["colSelect"].Value ?? false);
                dgvVehicles.Rows[e.RowIndex].Cells["colSelect"].Value = !currentValue;

                // Update selected vehicle
                if (!currentValue)
                {
                    SelectedVehicle = dgvVehicles.Rows[e.RowIndex].DataBoundItem as VehicleVM;
                }
                else
                {
                    SelectedVehicle = null;
                }
            }
        }

        private void btnSelectVehicle_Click(object sender, EventArgs e)
        {
            if (SelectedVehicle == null)
            {
                MessageBox.Show("Please select a vehicle first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
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