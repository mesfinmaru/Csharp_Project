using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRM_API.Models;

namespace Car_Rental_Management_System.Forms
{
    public partial class MaintenanceForm : Form
    {
        private ApiClient _apiClient;
        private List<MaintenanceVM> _maintenances = new List<MaintenanceVM>();
        private List<VehicleVM> _vehicles = new List<VehicleVM>();
        private bool _isEditMode = false;
        private int _currentMaintenanceId = 0;

        public MaintenanceForm(ApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            InitializeForm();
        }

        private void InitializeForm()
        {
            // Load maintenance types
            LoadMaintenanceTypes();

            // Load status filters
            LoadStatusFilters();

            // Set default date to tomorrow
            dtpScheduledDate.Value = DateTime.Today.AddDays(1);

            // Load data
            LoadMaintenancesAsync();
            LoadVehiclesAsync();
        }

        private void LoadMaintenanceTypes()
        {
            cmbMaintenanceType.Items.Clear();
            cmbMaintenanceType.Items.AddRange(new string[]
            {
                "Regular Service",
                "Oil Change",
                "Brake Repair",
                "Tire Replacement",
                "Engine Repair",
                "Transmission Repair",
                "Electrical Repair",
                "AC Repair",
                "Body Repair",
                "Accident Repair",
                "Preventive Maintenance",
                "Emergency Repair"
            });
        }

        private void LoadStatusFilters()
        {
            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.Add("All");
            cmbStatusFilter.Items.Add("Scheduled");
            cmbStatusFilter.Items.Add("In Progress");
            cmbStatusFilter.Items.Add("Completed");
            cmbStatusFilter.Items.Add("Cancelled");
            cmbStatusFilter.SelectedIndex = 0;
        }

        private async Task LoadMaintenancesAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                lblStatusBar.Text = "Loading maintenance records...";

                var search = txtSearch.Text.Trim();
                var status = cmbStatusFilter.SelectedItem?.ToString();
                if (status == "All") status = null;

                _maintenances = await _apiClient.GetMaintenancesAsync(search, status);
                RefreshDataGridView();

                lblStatusBar.Text = $"Loaded {_maintenances.Count} maintenance records";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading maintenance records: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatusBar.Text = "Error loading maintenance records";
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private async Task LoadVehiclesAsync()
        {
            try
            {
                _vehicles = await _apiClient.GetVehiclesAsync();

                cmbVehicle.Items.Clear();
                cmbVehicle.Items.Add("-- Select Vehicle --");

                foreach (var vehicle in _vehicles.Where(v => v.IsActive))
                {
                    cmbVehicle.Items.Add($"{vehicle.PlateNumber} - {vehicle.Make} {vehicle.Model} ({(vehicle.IsAvailable ? "Available" : "Not Available")})");
                }

                cmbVehicle.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading vehicles: {ex.Message}");
            }
        }

        private void RefreshDataGridView()
        {
            dgvMaintenances.Rows.Clear();

            foreach (var maintenance in _maintenances.OrderByDescending(m => m.ScheduledDate))
            {
                var vehicleInfo = $"{maintenance.VehiclePlateNumber} - {maintenance.VehicleMake} {maintenance.VehicleModel}";
                var rowIndex = dgvMaintenances.Rows.Add(
                    maintenance.Id,
                    vehicleInfo,
                    maintenance.MaintenanceType,
                    maintenance.Description.Length > 50 ? maintenance.Description.Substring(0, 50) + "..." : maintenance.Description,
                    maintenance.ScheduledDate.ToString("yyyy-MM-dd"),
                    maintenance.Status,
                    maintenance.Cost.ToString("C2"),
                    maintenance.MechanicName
                );

                // Color code rows based on status
                var row = dgvMaintenances.Rows[rowIndex];
                switch (maintenance.Status)
                {
                    case "Scheduled":
                        if (maintenance.IsOverdue)
                            row.DefaultCellStyle.BackColor = Color.LightPink;
                        else
                            row.DefaultCellStyle.BackColor = Color.LightYellow;
                        break;
                    case "In Progress":
                        row.DefaultCellStyle.BackColor = Color.LightBlue;
                        break;
                    case "Completed":
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        break;
                    case "Cancelled":
                        row.DefaultCellStyle.BackColor = Color.LightGray;
                        break;
                }

                row.DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        // ================= BUTTON EVENT HANDLERS =================

        private void btnAddMaintenance_Click(object sender, EventArgs e)
        {
            _isEditMode = false;
            _currentMaintenanceId = 0;
            ClearForm();
            panelDetails.Visible = true;
            lblStatusBar.Text = "Adding new maintenance record";
        }

        private void btnEditMaintenance_Click(object sender, EventArgs e)
        {
            var maintenance = GetSelectedMaintenance();
            if (maintenance == null)
            {
                MessageBox.Show("Please select a maintenance record to edit.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (maintenance.Status == "Completed")
            {
                MessageBox.Show("Cannot edit completed maintenance records.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _isEditMode = true;
            _currentMaintenanceId = maintenance.Id;
            LoadMaintenanceIntoForm(maintenance);
            panelDetails.Visible = true;
            lblStatusBar.Text = $"Editing maintenance record #{maintenance.Id}";
        }

        private async void btnDeleteMaintenance_Click(object sender, EventArgs e)
        {
            var maintenance = GetSelectedMaintenance();
            if (maintenance == null)
            {
                MessageBox.Show("Please select a maintenance record to delete.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (maintenance.Status == "In Progress" || maintenance.Status == "Completed")
            {
                MessageBox.Show($"Cannot delete {maintenance.Status} maintenance records.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Are you sure you want to delete maintenance record #{maintenance.Id}?\n\n" +
                                       $"Vehicle: {maintenance.VehicleMake} {maintenance.VehicleModel}\n" +
                                       $"Type: {maintenance.MaintenanceType}\n" +
                                       $"Description: {maintenance.Description}",
                                       "Confirm Delete",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    await _apiClient.DeleteMaintenanceAsync(maintenance.Id);
                    await LoadMaintenancesAsync();
                    lblStatusBar.Text = $"Maintenance record #{maintenance.Id} deleted successfully";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting maintenance record: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        private async void btnStartMaintenance_Click(object sender, EventArgs e)
        {
            var maintenance = GetSelectedMaintenance();
            if (maintenance == null)
            {
                MessageBox.Show("Please select a maintenance record to start.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (maintenance.Status != "Scheduled")
            {
                MessageBox.Show("Only scheduled maintenance records can be started.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Start maintenance for vehicle: {maintenance.VehicleMake} {maintenance.VehicleModel}?\n\n" +
                                       $"Type: {maintenance.MaintenanceType}\n" +
                                       $"Description: {maintenance.Description}",
                                       "Confirm Start Maintenance",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    await _apiClient.StartMaintenanceAsync(maintenance.Id);
                    await LoadMaintenancesAsync();
                    lblStatusBar.Text = $"Maintenance record #{maintenance.Id} started successfully";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error starting maintenance: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        private async void btnCompleteMaintenance_Click(object sender, EventArgs e)
        {
            var maintenance = GetSelectedMaintenance();
            if (maintenance == null)
            {
                MessageBox.Show("Please select a maintenance record to complete.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (maintenance.Status != "In Progress")
            {
                MessageBox.Show("Only maintenance records in progress can be completed.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var dialog = new CompleteMaintenanceDialog())
            {
                dialog.CompletionDate = DateTime.Today;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        await _apiClient.CompleteMaintenanceAsync(
                            maintenance.Id,
                            dialog.CompletionDate,
                            dialog.ActualCost,
                            dialog.Notes);

                        await LoadMaintenancesAsync();
                        lblStatusBar.Text = $"Maintenance record #{maintenance.Id} completed successfully";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error completing maintenance: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }
                }
            }
        }

        private async void btnCancelMaintenance_Click(object sender, EventArgs e)
        {
            var maintenance = GetSelectedMaintenance();
            if (maintenance == null)
            {
                MessageBox.Show("Please select a maintenance record to cancel.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (maintenance.Status == "Completed")
            {
                MessageBox.Show("Cannot cancel completed maintenance records.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var dialog = new InputDialog("Cancel Maintenance", "Please enter reason for cancellation:"))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        await _apiClient.CancelMaintenanceAsync(maintenance.Id, dialog.InputText);
                        await LoadMaintenancesAsync();
                        lblStatusBar.Text = $"Maintenance record #{maintenance.Id} cancelled successfully";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error cancelling maintenance: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            if (_isEditMode)
                UpdateMaintenanceAsync();
            else
                CreateMaintenanceAsync();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panelDetails.Visible = false;
            lblStatusBar.Text = "Ready";
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Debounce search
            await Task.Delay(500);
            if (txtSearch.Focused)
                await LoadMaintenancesAsync();
        }

        private async void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadMaintenancesAsync();
        }

        // ================= FORM METHODS =================

        private MaintenanceVM? GetSelectedMaintenance()
        {
            if (dgvMaintenances.SelectedRows.Count > 0)
            {
                var id = Convert.ToInt32(dgvMaintenances.SelectedRows[0].Cells[0].Value);
                return _maintenances.FirstOrDefault(m => m.Id == id);
            }
            return null;
        }

        private void ClearForm()
        {
            cmbVehicle.SelectedIndex = 0;
            cmbMaintenanceType.SelectedIndex = -1;
            txtDescription.Clear();
            dtpScheduledDate.Value = DateTime.Today.AddDays(1);
            txtMileage.Clear();
            txtCost.Clear();
            txtMechanicName.Clear();
            txtMechanicPhone.Clear();
            txtNotes.Clear();
        }

        private void LoadMaintenanceIntoForm(MaintenanceVM maintenance)
        {
            // Find vehicle in combobox
            var vehicleText = $"{maintenance.VehiclePlateNumber} - {maintenance.VehicleMake} {maintenance.VehicleModel}";

            for (int i = 0; i < cmbVehicle.Items.Count; i++)
            {
                if (cmbVehicle.Items[i].ToString().Contains(maintenance.VehiclePlateNumber))
                {
                    cmbVehicle.SelectedIndex = i;
                    break;
                }
            }

            cmbMaintenanceType.Text = maintenance.MaintenanceType;
            txtDescription.Text = maintenance.Description;
            dtpScheduledDate.Value = maintenance.ScheduledDate;
            txtMileage.Text = maintenance.CurrentMileage.ToString();
            txtCost.Text = maintenance.Cost.ToString("F2");
            txtMechanicName.Text = maintenance.MechanicName;
            txtMechanicPhone.Text = maintenance.MechanicPhone ?? "";
            txtNotes.Text = maintenance.Notes ?? "";
        }

        private bool ValidateForm()
        {
            if (cmbVehicle.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select a vehicle.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbVehicle.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbMaintenanceType.Text))
            {
                MessageBox.Show("Please select a maintenance type.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMaintenanceType.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Please enter a description.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return false;
            }

            if (!int.TryParse(txtMileage.Text, out int mileage) || mileage < 0)
            {
                MessageBox.Show("Please enter a valid mileage.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMileage.Focus();
                return false;
            }

            if (!decimal.TryParse(txtCost.Text, out decimal cost) || cost < 0)
            {
                MessageBox.Show("Please enter a valid cost.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCost.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMechanicName.Text))
            {
                MessageBox.Show("Please enter mechanic name.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMechanicName.Focus();
                return false;
            }

            return true;
        }

        private int GetVehicleIdFromText(string? vehicleText)
        {
            if (string.IsNullOrEmpty(vehicleText) || vehicleText == "-- Select Vehicle --")
                return 0;

            var plateNumber = vehicleText.Split('-')[0].Trim();
            var vehicle = _vehicles.FirstOrDefault(v => v.PlateNumber == plateNumber);
            return vehicle?.Id ?? 0;
        }

        private async void CreateMaintenanceAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                var selectedVehicleText = cmbVehicle.SelectedItem?.ToString();
                var vehicleId = GetVehicleIdFromText(selectedVehicleText);

                if (vehicleId == 0)
                {
                    MessageBox.Show("Invalid vehicle selection.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var request = new MaintenanceRequest
                {
                    VehicleId = vehicleId,
                    MaintenanceType = cmbMaintenanceType.Text,
                    Description = txtDescription.Text,
                    ScheduledDate = dtpScheduledDate.Value,
                    CurrentMileage = int.Parse(txtMileage.Text),
                    Cost = decimal.Parse(txtCost.Text),
                    MechanicName = txtMechanicName.Text,
                    MechanicPhone = txtMechanicPhone.Text,
                    Notes = txtNotes.Text
                };

                await _apiClient.CreateMaintenanceAsync(request);

                panelDetails.Visible = false;
                await LoadMaintenancesAsync();
                lblStatusBar.Text = "Maintenance record created successfully";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating maintenance: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private async void UpdateMaintenanceAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                var selectedVehicleText = cmbVehicle.SelectedItem?.ToString();
                var vehicleId = GetVehicleIdFromText(selectedVehicleText);

                if (vehicleId == 0)
                {
                    MessageBox.Show("Invalid vehicle selection.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var maintenance = new MaintenanceVM
                {
                    Id = _currentMaintenanceId,
                    VehicleId = vehicleId,
                    MaintenanceType = cmbMaintenanceType.Text,
                    Description = txtDescription.Text,
                    ScheduledDate = dtpScheduledDate.Value,
                    CurrentMileage = int.Parse(txtMileage.Text),
                    Cost = decimal.Parse(txtCost.Text),
                    MechanicName = txtMechanicName.Text,
                    MechanicPhone = txtMechanicPhone.Text,
                    Notes = txtNotes.Text,
                    Status = "Scheduled" // Default status
                };

                await _apiClient.UpdateMaintenanceAsync(maintenance);

                panelDetails.Visible = false;
                await LoadMaintenancesAsync();
                lblStatusBar.Text = $"Maintenance record #{_currentMaintenanceId} updated successfully";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating maintenance: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private async void MaintenanceForm_Load(object sender, EventArgs e)
        {
            await LoadMaintenancesAsync();
        }

        private void dgvMaintenances_SelectionChanged(object sender, EventArgs e)
        {
            var maintenance = GetSelectedMaintenance();
            if (maintenance != null)
            {
                lblStatusBar.Text = $"Selected: {maintenance.VehicleMake} {maintenance.VehicleModel} - {maintenance.MaintenanceType} ({maintenance.Status})";
            }
        }
    }

    // ================= HELPER DIALOGS =================

    public class CompleteMaintenanceDialog : Form
    {
        private DateTimePicker dtpCompletionDate;
        private TextBox txtActualCost;
        private RichTextBox txtNotes;
        private Button btnOK;
        private Button btnCancel;

        public DateTime CompletionDate { get; set; }
        public decimal? ActualCost { get; set; }
        public string Notes { get; set; } = string.Empty;

        public CompleteMaintenanceDialog()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Text = "Complete Maintenance";
            Size = new Size(400, 300);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;

            var lblCompletionDate = new Label { Text = "Completion Date:", Location = new Point(20, 20), Size = new Size(120, 25) };
            dtpCompletionDate = new DateTimePicker { Location = new Point(150, 20), Size = new Size(200, 25), Value = DateTime.Today };

            var lblActualCost = new Label { Text = "Actual Cost ($):", Location = new Point(20, 60), Size = new Size(120, 25) };
            txtActualCost = new TextBox { Location = new Point(150, 60), Size = new Size(200, 25) };

            var lblNotes = new Label { Text = "Notes:", Location = new Point(20, 100), Size = new Size(120, 25) };
            txtNotes = new RichTextBox { Location = new Point(150, 100), Size = new Size(200, 80) };

            btnOK = new Button { Text = "OK", Location = new Point(150, 200), Size = new Size(80, 30), DialogResult = DialogResult.OK };
            btnCancel = new Button { Text = "Cancel", Location = new Point(250, 200), Size = new Size(80, 30), DialogResult = DialogResult.Cancel };

            AcceptButton = btnOK;
            CancelButton = btnCancel;

            Controls.AddRange(new Control[] { lblCompletionDate, dtpCompletionDate, lblActualCost, txtActualCost, lblNotes, txtNotes, btnOK, btnCancel });

            btnOK.Click += (s, e) =>
            {
                CompletionDate = dtpCompletionDate.Value;
                if (decimal.TryParse(txtActualCost.Text, out decimal cost))
                    ActualCost = cost;
                Notes = txtNotes.Text;
                DialogResult = DialogResult.OK;
                Close();
            };
        }
    }

    public class InputDialog : Form
    {
        private TextBox txtInput;
        public string InputText => txtInput.Text;

        public InputDialog(string title, string prompt)
        {
            InitializeComponent(title, prompt);
        }

        private void InitializeComponent(string title, string prompt)
        {
            Text = title;
            Size = new Size(400, 200);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;

            var lblPrompt = new Label { Text = prompt, Location = new Point(20, 20), Size = new Size(350, 50) };
            txtInput = new TextBox { Location = new Point(20, 80), Size = new Size(340, 25) };
            var btnOK = new Button { Text = "OK", Location = new Point(150, 120), Size = new Size(80, 30), DialogResult = DialogResult.OK };
            var btnCancel = new Button { Text = "Cancel", Location = new Point(250, 120), Size = new Size(80, 30), DialogResult = DialogResult.Cancel };

            AcceptButton = btnOK;
            CancelButton = btnCancel;

            Controls.AddRange(new Control[] { lblPrompt, txtInput, btnOK, btnCancel });
        }
    }
}