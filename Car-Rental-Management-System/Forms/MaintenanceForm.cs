using Car_Rental_Management_System;
using CRM_API.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Rental_Management_System.Forms
{
    public partial class MaintenanceForm : Form
    {
        private ApiClient? _apiClient;
        private List<MaintenanceVM>? _maintenancesList;
        private List<VehicleVM>? _vehiclesList;
        private List<MaintenanceVM>? _filteredList;
        private bool _isEditMode = false;
        private int _currentMaintenanceId = 0;
        private Button btnNew;
        private Button btnCancel;

        public MaintenanceForm()
        {
            InitializeComponent();
            ApplyTheme();
            SetupDataGridView();
            InitializeDropdowns();
            SetupUIButtons();
            SetFormState(false);
        }

        public MaintenanceForm(ApiClient apiClient) : this()
        {
            _apiClient = apiClient;
            _ = LoadMaintenancesAsync();
            _ = LoadVehiclesAsync();
        }

        private void SetupUIButtons()
        {
            // Add New Button
            btnNew = new Button
            {
                Text = "New Maintenance",
                BackColor = Color.FromArgb(124, 77, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Size = new Size(180, 45),
                Location = new Point(20, 25),
                Cursor = Cursors.Hand,
                Font = new Font("Trebuchet MS", 9F)
            };
            btnNew.Click += btnNew_Click;
            panelHeader.Controls.Add(btnNew);

            // Cancel Button
            btnCancel = new Button
            {
                Text = "Cancel",
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Size = new Size(120, 45),
                Location = new Point(210, 25),
                Visible = false,
                Font = new Font("Trebuchet MS", 9F)
            };
            btnCancel.Click += btnCancel_Click;
            panelHeader.Controls.Add(btnCancel);
        }

        private void ApplyTheme()
        {
            var bg = Color.FromArgb(26, 27, 39);
            var panelBg = Color.FromArgb(39, 40, 55);
            var primary = Color.FromArgb(124, 77, 255);
            var secondary = Color.FromArgb(83, 109, 254);
            var accent = Color.FromArgb(46, 204, 113);
            var lightText = Color.FromArgb(230, 230, 235);

            // Main form
            this.BackColor = bg;
            panel2.BackColor = panelBg;
            panelTools.BackColor = panelBg;
            panelHeader.BackColor = panelBg;

            // Search TextBox
            txtSearch.BackColor = Color.FromArgb(45, 45, 60);
            txtSearch.ForeColor = lightText;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;

            // Status Filter
            cmbStatusFilter.BackColor = Color.FromArgb(45, 45, 60);
            cmbStatusFilter.ForeColor = lightText;
            cmbStatusFilter.FlatStyle = FlatStyle.Flat;

            // Buttons
            btnEdit.BackColor = secondary;
            btnEdit.ForeColor = Color.White;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.IconColor = Color.White;

            btnDelete.BackColor = Color.FromArgb(255, 98, 70);
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.IconColor = Color.White;

            btnComplete.BackColor = accent;
            btnComplete.ForeColor = Color.White;
            btnComplete.FlatStyle = FlatStyle.Flat;
            btnComplete.FlatAppearance.BorderSize = 0;
            btnComplete.IconColor = Color.White;

            btnSave.BackColor = primary;
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.IconColor = Color.White;

            // Form Controls
            cmbVehicle.BackColor = Color.FromArgb(45, 45, 60);
            cmbVehicle.ForeColor = lightText;
            cmbVehicle.FlatStyle = FlatStyle.Flat;

            cmbMaintenanceType.BackColor = Color.FromArgb(45, 45, 60);
            cmbMaintenanceType.ForeColor = lightText;
            cmbMaintenanceType.FlatStyle = FlatStyle.Flat;

            cmbStatus.BackColor = Color.FromArgb(45, 45, 60);
            cmbStatus.ForeColor = lightText;
            cmbStatus.FlatStyle = FlatStyle.Flat;

            txtCurrentMilage.BackColor = Color.FromArgb(45, 45, 60);
            txtCurrentMilage.ForeColor = lightText;
            txtCurrentMilage.BorderStyle = BorderStyle.FixedSingle;

            txtCost.BackColor = Color.FromArgb(45, 45, 60);
            txtCost.ForeColor = lightText;
            txtCost.BorderStyle = BorderStyle.FixedSingle;

            txtProvider.BackColor = Color.FromArgb(45, 45, 60);
            txtProvider.ForeColor = lightText;
            txtProvider.BorderStyle = BorderStyle.FixedSingle;

            txtContact.BackColor = Color.FromArgb(45, 45, 60);
            txtContact.ForeColor = lightText;
            txtContact.BorderStyle = BorderStyle.FixedSingle;

            txtLocation.BackColor = Color.FromArgb(45, 45, 60);
            txtLocation.ForeColor = lightText;
            txtLocation.BorderStyle = BorderStyle.FixedSingle;

            rtbDescription.BackColor = Color.FromArgb(45, 45, 60);
            rtbDescription.ForeColor = lightText;
            rtbDescription.BorderStyle = BorderStyle.FixedSingle;

            // DateTimePickers
            dtpDate.CalendarMonthBackground = Color.FromArgb(45, 45, 60);
            dtpDate.CalendarTitleBackColor = primary;
            dtpDate.CalendarForeColor = lightText;
            dtpDate.CalendarTrailingForeColor = Color.FromArgb(100, 100, 120);
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.ShowCheckBox = false;

            dtpExpectedComplete.CalendarMonthBackground = Color.FromArgb(45, 45, 60);
            dtpExpectedComplete.CalendarTitleBackColor = primary;
            dtpExpectedComplete.CalendarForeColor = lightText;
            dtpExpectedComplete.CalendarTrailingForeColor = Color.FromArgb(100, 100, 120);
            dtpExpectedComplete.Format = DateTimePickerFormat.Short;
            dtpExpectedComplete.ShowCheckBox = false;

            // GroupBox borders
            groupBox1.ForeColor = lightText;
            groupBox2.ForeColor = lightText;
        }

        private void SetupDataGridView()
        {
            dgvMaintenance.AutoGenerateColumns = false;
            dgvMaintenance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMaintenance.MultiSelect = false;
            dgvMaintenance.ReadOnly = true;
            dgvMaintenance.AllowUserToAddRows = false;
            dgvMaintenance.RowHeadersVisible = false;

            // Clear existing columns
            dgvMaintenance.Columns.Clear();

            // Add columns
            dgvMaintenance.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colId",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Width = 50,
                Visible = false
            });

            dgvMaintenance.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colVehicle",
                HeaderText = "Vehicle",
                DataPropertyName = "VehicleInfo",
                Width = 180,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvMaintenance.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colType",
                HeaderText = "Type",
                DataPropertyName = "MaintenanceType",
                Width = 120
            });

            dgvMaintenance.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colDate",
                HeaderText = "Date",
                DataPropertyName = "MaintenanceDate",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Format = "dd/MM/yyyy",
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            dgvMaintenance.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colExpectedComplete",
                HeaderText = "Complete By",
                DataPropertyName = "CompletionDate",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Format = "dd/MM/yyyy",
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            dgvMaintenance.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colStatus",
                HeaderText = "Status",
                DataPropertyName = "Status",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Trebuchet MS", 9F, FontStyle.Bold)
                }
            });

            dgvMaintenance.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colCost",
                HeaderText = "Cost (ETB)",
                DataPropertyName = "Cost",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Format = "#,##0.00",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });

            dgvMaintenance.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colProvider",
                HeaderText = "Provider",
                DataPropertyName = "ServiceProvider",
                Width = 150
            });

            dgvMaintenance.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colCreated",
                HeaderText = "Created",
                DataPropertyName = "CreatedAt",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Format = "dd/MM/yyyy",
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            // Handle data errors
            dgvMaintenance.DataError += (sender, e) =>
            {
                if (e.Exception is FormatException)
                {
                    e.ThrowException = false;
                }
            };

            // Handle selection changed
            dgvMaintenance.SelectionChanged += dgvMaintenance_SelectionChanged;
            dgvMaintenance.CellFormatting += dgvMaintenance_CellFormatting;
        }

        private void InitializeDropdowns()
        {
            // Status Filter
            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.AddRange(new string[] {
                "All Status",
                "Scheduled",
                "In Progress",
                "Completed",
                "Cancelled"
            });
            cmbStatusFilter.SelectedIndex = 0;

            // Maintenance Type
            cmbMaintenanceType.Items.Clear();
            cmbMaintenanceType.Items.AddRange(new string[] {
                "Regular Service",
                "Repair",
                "Emergency",
                "Oil Change",
                "Tire Replacement",
                "Battery Replacement",
                "Brake Service",
                "Engine Repair",
                "Transmission Service",
                "Electrical Work",
                "AC Service",
                "Body Work",
                "Other"
            });

            // Status
            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new string[] {
                "Scheduled",
                "In Progress",
                "Completed",
                "Cancelled"
            });

            // Set default dates
            dtpDate.Value = DateTime.Today;
            dtpExpectedComplete.Value = DateTime.Today.AddDays(1);
        }

        private async Task LoadVehiclesAsync()
        {
            try
            {
                if (_apiClient == null || !_apiClient.IsAuthenticated) return;

                _vehiclesList = await _apiClient.GetVehiclesAsync();
                if (_vehiclesList != null)
                {
                    cmbVehicle.Items.Clear();
                    cmbVehicle.Items.Add("-- Select Vehicle --");
                    foreach (var vehicle in _vehiclesList.Where(v => v.IsActive))
                    {
                        cmbVehicle.Items.Add($"{vehicle.PlateNumber} - {vehicle.Make} {vehicle.Model} ({vehicle.Year})");
                    }
                    cmbVehicle.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                ShowError($"Error loading vehicles: {ex.Message}");
            }
        }

        private async Task LoadMaintenancesAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvMaintenance.DataSource = null;
                lblStatus.Text = "Loading maintenances...";

                if (_apiClient == null)
                {
                    lblStatus.Text = "API Client not initialized";
                    ShowError("MaintenanceForm was not initialized properly.");
                    return;
                }

                if (!_apiClient.IsAuthenticated)
                {
                    lblStatus.Text = "Please login first";
                    ShowInfo("Please login to view maintenances");
                    return;
                }

                _maintenancesList = await _apiClient.GetMaintenancesAsync(txtSearch.Text.Trim());
                _filteredList = new List<MaintenanceVM>(_maintenancesList);

                // Apply status filter
                if (cmbStatusFilter.SelectedIndex > 0)
                {
                    string selectedStatus = cmbStatusFilter.Text;
                    _filteredList = _filteredList.Where(m => m.Status == selectedStatus).ToList();
                }

                // Set the data source
                dgvMaintenance.DataSource = null;
                dgvMaintenance.DataSource = _filteredList;

                // Format columns
                FormatStatusColumns();
                UpdateStatusLabel();
            }
            catch (HttpRequestException ex)
            {
                lblStatus.Text = "Connection failed";
                ShowError($"Cannot connect to server: {CleanErrorMessage(ex.Message)}");
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error loading";
                ShowError($"Failed to load maintenances: {CleanErrorMessage(ex.Message)}");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void FormatStatusColumns()
        {
            if (dgvMaintenance.Columns["colStatus"] != null && dgvMaintenance.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvMaintenance.Rows)
                {
                    if (row.DataBoundItem is MaintenanceVM maintenance)
                    {
                        var cell = row.Cells["colStatus"];
                        string status = maintenance.Status?.ToLower() ?? "unknown";

                        switch (status)
                        {
                            case "scheduled":
                                if (maintenance.IsOverdue)
                                {
                                    cell.Style.BackColor = Color.FromArgb(255, 87, 34); // Red for overdue
                                    cell.Value = $"OVERDUE ({maintenance.DaysOverdue}d)";
                                }
                                else
                                {
                                    cell.Style.BackColor = Color.FromArgb(255, 193, 7); // Amber for scheduled
                                    cell.Value = "Scheduled";
                                }
                                break;
                            case "in progress":
                                cell.Style.BackColor = Color.FromArgb(33, 150, 243); // Blue
                                cell.Value = "In Progress";
                                break;
                            case "completed":
                                cell.Style.BackColor = Color.FromArgb(46, 204, 113); // Green
                                cell.Value = "Completed";
                                break;
                            case "cancelled":
                                cell.Style.BackColor = Color.FromArgb(255, 98, 70); // Red
                                cell.Value = "Cancelled";
                                break;
                            default:
                                cell.Style.BackColor = Color.FromArgb(108, 117, 125); // Gray
                                cell.Value = maintenance.Status;
                                break;
                        }
                        cell.Style.ForeColor = Color.White;
                        cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
            }
        }

        private void UpdateStatusLabel()
        {
            if (_maintenancesList == null) return;

            int totalCount = _maintenancesList.Count;
            int filteredCount = _filteredList?.Count ?? 0;
            int scheduledCount = _maintenancesList.Count(m => m.Status == "Scheduled");
            int inProgressCount = _maintenancesList.Count(m => m.Status == "In Progress");
            int completedCount = _maintenancesList.Count(m => m.Status == "Completed");
            int overdueCount = _maintenancesList.Count(m => m.IsOverdue);
            int cancelledCount = _maintenancesList.Count(m => m.Status == "Cancelled");

            if (string.IsNullOrEmpty(txtSearch.Text.Trim()) && cmbStatusFilter.SelectedIndex == 0)
            {
                lblStatus.Text = $"{totalCount} maintenance(s) - {scheduledCount} scheduled, {inProgressCount} in progress, {completedCount} completed, {cancelledCount} cancelled, {overdueCount} overdue";
            }
            else
            {
                lblStatus.Text = $"Showing {filteredCount} of {totalCount} maintenance(s)";
            }
        }

        private void SetFormState(bool enable)
        {
            // Show/hide form controls based on mode
            panelInput.Visible = enable;
            btnNew.Visible = !enable;
            btnCancel.Visible = enable;

            // Enable/disable form controls
            cmbVehicle.Enabled = enable;
            txtCurrentMilage.Enabled = enable;
            cmbMaintenanceType.Enabled = enable;
            cmbStatus.Enabled = enable;
            dtpDate.Enabled = enable;
            dtpExpectedComplete.Enabled = enable;
            txtCost.Enabled = enable;
            txtProvider.Enabled = enable;
            txtContact.Enabled = enable;
            rtbDescription.Enabled = enable;
            txtLocation.Enabled = enable;
            btnSave.Enabled = enable;

            // Enable/disable grid and buttons
            dgvMaintenance.Enabled = !enable;
            btnEdit.Enabled = !enable && dgvMaintenance.SelectedRows.Count > 0;
            btnDelete.Enabled = !enable && dgvMaintenance.SelectedRows.Count > 0;
            btnComplete.Enabled = !enable && dgvMaintenance.SelectedRows.Count > 0;
            txtSearch.Enabled = !enable;
            cmbStatusFilter.Enabled = !enable;

            // Update form title
            if (enable)
            {
                lblFormTitle.Text = _isEditMode ? "Edit Maintenance" : "Add New Maintenance";
                if (_isEditMode)
                {
                    btnSave.Text = "Update";
                    btnSave.IconChar = FontAwesome.Sharp.IconChar.Edit;
                }
                else
                {
                    btnSave.Text = "Save";
                    btnSave.IconChar = FontAwesome.Sharp.IconChar.Save;
                }
            }
            else
            {
                lblFormTitle.Text = "Maintenance Management";
                btnSave.Text = "Save";
                btnSave.IconChar = FontAwesome.Sharp.IconChar.Save;
            }
        }

        private void ClearForm()
        {
            cmbVehicle.SelectedIndex = 0;
            txtCurrentMilage.Text = "";
            cmbMaintenanceType.SelectedIndex = -1;
            cmbStatus.SelectedIndex = 0; // Default to "Scheduled"
            dtpDate.Value = DateTime.Today;
            dtpExpectedComplete.Value = DateTime.Today.AddDays(1);
            txtCost.Text = "";
            txtProvider.Text = "Local Garage";
            txtContact.Text = "";
            rtbDescription.Text = "";
            txtLocation.Text = "";
            lblLastService.Text = "N/A";
            lblLastService.ForeColor = Color.FromArgb(230, 230, 235);

            _currentMaintenanceId = 0;
            _isEditMode = false;
        }

        private void LoadMaintenanceToForm(MaintenanceVM maintenance)
        {
            if (maintenance == null) return;

            // Find vehicle in combobox
            string vehicleText = $"{maintenance.VehiclePlateNumber} - {maintenance.VehicleMake} {maintenance.VehicleModel} )";
            int index = cmbVehicle.FindStringExact(vehicleText);
            if (index >= 0)
                cmbVehicle.SelectedIndex = index;
            else
                cmbVehicle.SelectedIndex = 0;

            txtCurrentMilage.Text = maintenance.CurrentMileage > 0 ? maintenance.CurrentMileage.ToString() : "";

            index = cmbMaintenanceType.FindStringExact(maintenance.MaintenanceType);
            if (index >= 0)
                cmbMaintenanceType.SelectedIndex = index;

            index = cmbStatus.FindStringExact(maintenance.Status);
            if (index >= 0)
                cmbStatus.SelectedIndex = index;

            dtpDate.Value = maintenance.MaintenanceDate;
            dtpExpectedComplete.Value = maintenance.CompletionDate ?? DateTime.Today.AddDays(1);
            txtCost.Text = maintenance.Cost > 0 ? maintenance.Cost.ToString("F2") : "";
            txtProvider.Text = maintenance.ServiceProvider;
            txtContact.Text = maintenance.ServiceContact;
            rtbDescription.Text = maintenance.Description;
           

            _currentMaintenanceId = maintenance.Id;
            _isEditMode = true;
        }

        private MaintenanceVM GetMaintenanceFromForm()
        {
            var maintenance = new MaintenanceVM
            {
                Id = _currentMaintenanceId,
                CurrentMileage = int.TryParse(txtCurrentMilage.Text, out int mileage) ? mileage : 0,
                MaintenanceDate = dtpDate.Value,
                CompletionDate = dtpExpectedComplete.Value,
                MaintenanceType = cmbMaintenanceType.Text,
                Status = cmbStatus.Text,
                Description = rtbDescription.Text,
                Cost = decimal.TryParse(txtCost.Text, out decimal cost) ? cost : 0,
                ServiceProvider = txtProvider.Text,
                ServiceContact = txtContact.Text,
               
                IsActive = true,
                CreatedAt = DateTime.Now,
                NextMaintenanceDate = dtpDate.Value.AddMonths(6),
                NextServiceKm = int.TryParse(txtCurrentMilage.Text, out int currentKm) ? currentKm + 5000 : 0
            };

            // Get selected vehicle
            if (cmbVehicle.SelectedIndex > 0 && _vehiclesList != null)
            {
                string selectedText = cmbVehicle.Text;
                var vehicle = _vehiclesList.FirstOrDefault(v =>
                    $"{v.PlateNumber} - {v.Make} {v.Model} ({v.Year})" == selectedText);

                if (vehicle != null)
                {
                    maintenance.VehicleId = vehicle.Id;
                    maintenance.VehiclePlateNumber = vehicle.PlateNumber;
                    maintenance.VehicleMake = vehicle.Make;
                    maintenance.VehicleModel = vehicle.Model;
                
                }
            }

            return maintenance;
        }

        private bool ValidateForm()
        {
            if (cmbVehicle.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select a vehicle", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbVehicle.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(cmbMaintenanceType.Text))
            {
                MessageBox.Show("Please select maintenance type", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMaintenanceType.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(cmbStatus.Text))
            {
                MessageBox.Show("Please select status", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbStatus.Focus();
                return false;
            }

            if (!decimal.TryParse(txtCost.Text, out decimal cost) || cost < 0)
            {
                MessageBox.Show("Please enter a valid cost amount", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCost.Focus();
                return false;
            }

            if (dtpExpectedComplete.Value < dtpDate.Value)
            {
                MessageBox.Show("Expected completion date cannot be before maintenance date", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpExpectedComplete.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtProvider.Text))
            {
                MessageBox.Show("Please enter service provider", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProvider.Focus();
                return false;
            }

            return true;
        }

        #region Event Handlers

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
            SetFormState(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetFormState(false);
            ClearForm();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm() || _apiClient == null) return;

            try
            {
                Cursor = Cursors.WaitCursor;
                var maintenance = GetMaintenanceFromForm();

                if (_isEditMode)
                {
                    await _apiClient.UpdateMaintenanceAsync(maintenance);
                    ShowSuccess("Maintenance updated successfully!");
                }
                else
                {
                    await _apiClient.CreateMaintenanceAsync(maintenance);
                    ShowSuccess("Maintenance created successfully!");
                }

                SetFormState(false);
                ClearForm();
                await LoadMaintenancesAsync();
            }
            catch (HttpRequestException ex)
            {
                ShowError($"Cannot connect to server: {CleanErrorMessage(ex.Message)}");
            }
            catch (Exception ex)
            {
                ShowError($"Failed to save maintenance: {CleanErrorMessage(ex.Message)}");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvMaintenance.SelectedRows.Count == 0) return;

            var selectedRow = dgvMaintenance.SelectedRows[0];
            var maintenance = selectedRow.DataBoundItem as MaintenanceVM;

            if (maintenance != null)
            {
                LoadMaintenanceToForm(maintenance);
                SetFormState(true);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMaintenance.SelectedRows.Count == 0) return;

            var selectedRow = dgvMaintenance.SelectedRows[0];
            var id = selectedRow.Cells["colId"].Value;
            var vehicle = selectedRow.Cells["colVehicle"].Value?.ToString() ?? "Unknown";
            var status = selectedRow.Cells["colStatus"].Value?.ToString() ?? "Unknown";

            if (id == null || _apiClient == null) return;

            if (status == "Completed")
            {
                ShowError("Cannot delete completed maintenances. They are kept for records.");
                return;
            }

            var result = MessageBox.Show(
                $"Are you sure you want to delete maintenance for '{vehicle}'?\n\n" +
                $"Status: {status}\n" +
                $"This action cannot be undone!",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                try
                {
                    lblStatus.Text = "Deleting...";
                    await _apiClient.DeleteMaintenanceAsync(Convert.ToInt32(id));

                    lblStatus.Text = "Maintenance deleted!";
                    ShowSuccess($"Maintenance has been deleted.");

                    await LoadMaintenancesAsync();
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Delete failed";
                    ShowError($"Failed to delete maintenance: {CleanErrorMessage(ex.Message)}");
                    await LoadMaintenancesAsync();
                }
            }
        }

        private async void btnComplete_Click(object sender, EventArgs e)
        {
            if (dgvMaintenance.SelectedRows.Count == 0 || _apiClient == null) return;

            var selectedRow = dgvMaintenance.SelectedRows[0];
            var id = selectedRow.Cells["colId"].Value;
            var maintenance = selectedRow.DataBoundItem as MaintenanceVM;

            if (id == null || maintenance == null) return;

            if (maintenance.Status == "Completed")
            {
                ShowInfo("Maintenance is already completed.");
                return;
            }

            var result = MessageBox.Show(
                $"Mark maintenance for '{maintenance.VehicleInfo}' as completed?\n\n" +
                $"This will update the vehicle status to 'Available' if it was 'In Maintenance'.",
                "Complete Maintenance",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    lblStatus.Text = "Completing maintenance...";
                    maintenance.Status = "Completed";
                    maintenance.CompletionDate = DateTime.Today;
                    await _apiClient.UpdateMaintenanceAsync(maintenance);

                    ShowSuccess("Maintenance marked as completed!");
                    await LoadMaintenancesAsync();
                }
                catch (Exception ex)
                {
                    ShowError($"Failed to complete maintenance: {CleanErrorMessage(ex.Message)}");
                }
            }
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Add delay to prevent too many API calls
            await Task.Delay(500);
            await LoadMaintenancesAsync();
        }

        private async void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadMaintenancesAsync();
        }

        private void cmbVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVehicle.SelectedIndex > 0 && _vehiclesList != null && _maintenancesList != null)
            {
                string selectedText = cmbVehicle.Text;
                var plateNumber = selectedText.Split('-')[0].Trim();

                var vehicle = _vehiclesList.FirstOrDefault(v => v.PlateNumber == plateNumber);
                if (vehicle != null)
                {
                    // Set current mileage from vehicle
                   

                    // Find last maintenance for this vehicle
                    var lastMaintenance = _maintenancesList
                        .Where(m => m.VehiclePlateNumber == plateNumber && m.Status == "Completed")
                        .OrderByDescending(m => m.CompletionDate)
                        .FirstOrDefault();

                    if (lastMaintenance != null)
                    {
                        lblLastService.Text = $"{lastMaintenance.CompletionDate:dd/MM/yyyy}";
                        lblLastService.ForeColor = Color.FromArgb(46, 204, 113);
                    }
                    else
                    {
                        lblLastService.Text = "Never";
                        lblLastService.ForeColor = Color.FromArgb(255, 98, 70);
                    }
                }
            }
            else
            {
                lblLastService.Text = "N/A";
                lblLastService.ForeColor = Color.FromArgb(230, 230, 235);
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpExpectedComplete.Value < dtpDate.Value)
            {
                dtpExpectedComplete.Value = dtpDate.Value.AddDays(1);
            }
        }

        private void dgvMaintenance_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = dgvMaintenance.SelectedRows.Count > 0;
            btnEdit.Enabled = hasSelection;
            btnDelete.Enabled = hasSelection;
            btnComplete.Enabled = hasSelection;

            if (hasSelection)
            {
                var selectedMaintenance = dgvMaintenance.SelectedRows[0].DataBoundItem as MaintenanceVM;
                btnComplete.Enabled = selectedMaintenance?.Status != "Completed";
            }
        }

        private void dgvMaintenance_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvMaintenance.Columns["colStatus"].Index)
                return;

            if (dgvMaintenance.Rows[e.RowIndex].DataBoundItem is MaintenanceVM maintenance)
            {
                string status = maintenance.Status?.ToLower() ?? "unknown";

                switch (status)
                {
                    case "scheduled":
                        if (maintenance.IsOverdue)
                        {
                            e.CellStyle.BackColor = Color.FromArgb(255, 87, 34);
                            e.Value = $"OVERDUE ({maintenance.DaysOverdue}d)";
                        }
                        else
                        {
                            e.CellStyle.BackColor = Color.FromArgb(255, 193, 7);
                            e.Value = "Scheduled";
                        }
                        break;
                    case "in progress":
                        e.CellStyle.BackColor = Color.FromArgb(33, 150, 243);
                        e.Value = "In Progress";
                        break;
                    case "completed":
                        e.CellStyle.BackColor = Color.FromArgb(46, 204, 113);
                        e.Value = "Completed";
                        break;
                    case "cancelled":
                        e.CellStyle.BackColor = Color.FromArgb(255, 98, 70);
                        e.Value = "Cancelled";
                        break;
                }

                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void MaintenanceForm_Load(object sender, EventArgs e)
        {
            _ = LoadMaintenancesAsync();
        }

        private void MaintenanceForm_Shown(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        #endregion

        #region Helper Methods

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

            errorMessage = System.Text.RegularExpressions.Regex.Replace(errorMessage, @"\s+", " ");

            if (errorMessage.Length > 200)
                errorMessage = errorMessage.Substring(0, 197) + "...";

            return errorMessage.Trim();
        }

        #endregion

        #region Empty Event Handlers

        private void label7_Click(object sender, EventArgs e) { }
        private void lblLastService_Click(object sender, EventArgs e) { }
        private void cmbMaintenanceType_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dtpExpectedComplete_ValueChanged(object sender, EventArgs e) { }
        private void txtProvider_TextChanged(object sender, EventArgs e) { }
        private void txtContact_TextChanged(object sender, EventArgs e) { }
        private void txtLocation_TextChanged(object sender, EventArgs e) { }
        private void rtbDescription_TextChanged(object sender, EventArgs e) { }
        private void lblStatus_Click(object sender, EventArgs e) { }
        private void lblFormTitle_Click(object sender, EventArgs e) { }
        private void txtCurrentMilage_TextChanged(object sender, EventArgs e) { }
        private void txtCost_TextChanged(object sender, EventArgs e) { }
        private void dgvMaintenance_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        #endregion
    }
}