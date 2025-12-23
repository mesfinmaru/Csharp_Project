using Car_Rental_Management_System;
using CRM_API.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Rental_Management_System.Forms
{
    public partial class EditVehicle : Form
    {
        private readonly ApiClient _apiClient;
        private readonly int _vehicleId;
        private VehicleVM? _vehicleToEdit;
        private bool _isFormLoaded = false;
        private bool _validationInProgress = false;
        private bool _isUpdating = false;

        public event EventHandler? VehicleUpdated;

        public EditVehicle(ApiClient apiClient, int vehicleId)
        {
            try
            {
                InitializeComponent();
                _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
                _vehicleId = vehicleId;

                ApplyTheme();
                InitializeNumericRanges();
                InitializeComboBoxes();
                _ = LoadVehicleDataAsync();
            }
            catch
            {
                ShowSimpleError("Failed to initialize form");
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void InitializeNumericRanges()
        {
            nurYear.Maximum = DateTime.Now.Year + 1;
            nurYear.Value = DateTime.Now.Year;

            nurSeats.Minimum = 1;
            nurSeats.Maximum = 50;
            nurSeats.Value = 5;

            nurMileage.Minimum = 0;
            nurMileage.Maximum = 1000000;
            nurMileage.Value = 0;

            nurDailyRate.Minimum = 0;
            nurDailyRate.Maximum = 10000;
            nurDailyRate.Value = 50;

            nurWeeklyRate.Minimum = 0;
            nurWeeklyRate.Maximum = 50000;
            nurWeeklyRate.Value = 300;

            nurMonthlyRate.Minimum = 0;
            nurMonthlyRate.Maximum = 200000;
            nurMonthlyRate.Value = 1000;
        }

        private void InitializeComboBoxes()
        {
            // Initialize Vehicle Type
            cmbVehicleType.Items.Clear();
            cmbVehicleType.Items.AddRange(new string[] {
                "Sedan", "SUV", "Truck", "Van", "Coupe", "Convertible", "Hatchback", "Minivan"
            });

            // Initialize Transmission
            cmbTransmission.Items.Clear();
            cmbTransmission.Items.AddRange(new string[] {
                "Automatic", "Manual", "Semi-Automatic", "CVT"
            });

            // Initialize Fuel Type
            cmbFuelType.Items.Clear();
            cmbFuelType.Items.AddRange(new string[] {
                "Petrol", "Diesel", "Electric", "Hybrid", "CNG", "LPG"
            });

            // Initialize Status
            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new string[] {
                "Available",
                "Rented",
                "Maintenance",
                "Reserved",
                "Inactive"
            });
        }

        private void ApplyTheme()
        {
            var bg = Color.FromArgb(0, 90, 158);
            var primary = Color.FromArgb(124, 77, 255);

            this.BackColor = bg;
            btnSave.BackColor = primary;
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;

            btnCancel.BackColor = Color.FromArgb(255, 98, 70);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;

            // Style all controls
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.BackColor = Color.White;
                    textBox.ForeColor = Color.Black;
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.BackColor = Color.White;
                    comboBox.ForeColor = Color.Black;
                    comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                }
                else if (control is NumericUpDown numericUpDown)
                {
                    numericUpDown.BackColor = Color.White;
                    numericUpDown.ForeColor = Color.Black;
                }
            }
        }

        private async Task LoadVehicleDataAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
          

                _vehicleToEdit = await _apiClient.GetVehicleAsync(_vehicleId);

                if (_vehicleToEdit != null)
                {
                    LoadVehicleData();
                    _isFormLoaded = true;
         
                }
                else
                {
                    ShowSimpleError("Vehicle not found");
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ShowSimpleError($"Failed to load vehicle: {CleanErrorMessage(ex.Message)}");
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void LoadVehicleData()
        {
            if (_vehicleToEdit == null) return;

            // Basic Information
            txtPlateNumber.Text = _vehicleToEdit.PlateNumber ?? "";
            txtMake.Text = _vehicleToEdit.Make ?? "";
            txtModel.Text = _vehicleToEdit.Model ?? "";
            txtColor.Text = _vehicleToEdit.Color ?? "";
            nurYear.Value = Math.Max(nurYear.Minimum, Math.Min(nurYear.Maximum, _vehicleToEdit.Year));

            // Dropdown Selections
            if (!string.IsNullOrEmpty(_vehicleToEdit.VehicleType))
                cmbVehicleType.SelectedItem = _vehicleToEdit.VehicleType;
            else
                cmbVehicleType.SelectedIndex = 0;

            if (!string.IsNullOrEmpty(_vehicleToEdit.Transmission))
                cmbTransmission.SelectedItem = _vehicleToEdit.Transmission;
            else
                cmbTransmission.SelectedIndex = 0;

            if (!string.IsNullOrEmpty(_vehicleToEdit.FuelType))
                cmbFuelType.SelectedItem = _vehicleToEdit.FuelType;
            else
                cmbFuelType.SelectedIndex = 0;

            // Status
            if (!string.IsNullOrEmpty(_vehicleToEdit.Status))
                cmbStatus.SelectedItem = _vehicleToEdit.Status;
            else
                cmbStatus.SelectedItem = _vehicleToEdit.IsActive ? "Available" : "Inactive";

            // Additional Details
            nurSeats.Value = Math.Max(nurSeats.Minimum, Math.Min(nurSeats.Maximum, _vehicleToEdit.Seats));
            nurMileage.Value = Math.Max(nurMileage.Minimum, Math.Min(nurMileage.Maximum, _vehicleToEdit.Mileage));

            txtVIN.Text = _vehicleToEdit.VIN ?? "";
            txtEngineNumber.Text = _vehicleToEdit.EngineNumber ?? "";
            txtFeatures.Text = _vehicleToEdit.Features ?? "";

            // Rates
            nurDailyRate.Value = Math.Max(nurDailyRate.Minimum, Math.Min(nurDailyRate.Maximum, _vehicleToEdit.DailyRate));
            nurWeeklyRate.Value = Math.Max(nurWeeklyRate.Minimum, Math.Min(nurWeeklyRate.Maximum, _vehicleToEdit.WeeklyRate));
            nurMonthlyRate.Value = Math.Max(nurMonthlyRate.Minimum, Math.Min(nurMonthlyRate.Maximum, _vehicleToEdit.MonthlyRate));
        }

        public VehicleVM GetUpdatedVehicleData()
        {
            if (!_isFormLoaded)
                throw new InvalidOperationException("Form not ready");

            if (_vehicleToEdit == null)
                throw new InvalidOperationException("Vehicle data not loaded");

            string selectedStatus = cmbStatus.SelectedItem?.ToString() ?? "Available";

            // Determine IsActive based on status
            bool isActive = !(selectedStatus.Equals("Inactive", StringComparison.OrdinalIgnoreCase) ||
                             selectedStatus.Equals("Maintenance", StringComparison.OrdinalIgnoreCase));

            return new VehicleVM
            {
                Id = _vehicleId,
                PlateNumber = txtPlateNumber.Text.Trim(),
                Make = txtMake.Text.Trim(),
                Model = txtModel.Text.Trim(),
                Year = (int)nurYear.Value,
                Color = txtColor.Text.Trim(),
                VehicleType = cmbVehicleType.SelectedItem?.ToString() ?? "",
                Transmission = cmbTransmission.SelectedItem?.ToString() ?? "",
                FuelType = cmbFuelType.SelectedItem?.ToString() ?? "",
                Seats = (int)nurSeats.Value,
                Mileage = (int)nurMileage.Value,
                VIN = txtVIN.Text.Trim(),
                EngineNumber = txtEngineNumber.Text.Trim(),
                Features = txtFeatures.Text.Trim(),
                DailyRate = nurDailyRate.Value,
                WeeklyRate = nurWeeklyRate.Value,
                MonthlyRate = nurMonthlyRate.Value,
                Status = selectedStatus,
                IsActive = isActive,
                IsAvailable = selectedStatus.Equals("Available", StringComparison.OrdinalIgnoreCase),
                CreatedAt = _vehicleToEdit.CreatedAt
            };
        }

        private bool ValidateForm()
        {
            _validationInProgress = true;

            try
            {
                if (!_isFormLoaded)
                {
                    ShowSimpleError("Form not ready");
                    return false;
                }

                bool isValid = true;
                List<string> errorMessages = new List<string>();

                ClearAllErrorHighlights();

                // Validate Plate Number
                if (string.IsNullOrWhiteSpace(txtPlateNumber.Text))
                {
                    errorMessages.Add("Plate number is required");
                    HighlightError(txtPlateNumber);
                    isValid = false;
                }

                // Validate Make
                if (string.IsNullOrWhiteSpace(txtMake.Text))
                {
                    errorMessages.Add("Make is required");
                    HighlightError(txtMake);
                    isValid = false;
                }

                // Validate Model
                if (string.IsNullOrWhiteSpace(txtModel.Text))
                {
                    errorMessages.Add("Model is required");
                    HighlightError(txtModel);
                    isValid = false;
                }

                // Validate Year
                if (nurYear.Value < 2000 || nurYear.Value > DateTime.Now.Year + 1)
                {
                    errorMessages.Add($"Year must be between 2000 and {DateTime.Now.Year + 1}");
                    HighlightError(nurYear);
                    isValid = false;
                }

                // Validate Color
                if (string.IsNullOrWhiteSpace(txtColor.Text))
                {
                    errorMessages.Add("Color is required");
                    HighlightError(txtColor);
                    isValid = false;
                }

                // Validate Vehicle Type
                if (cmbVehicleType.SelectedItem == null)
                {
                    errorMessages.Add("Vehicle type is required");
                    HighlightError(cmbVehicleType);
                    isValid = false;
                }

                // Validate Transmission
                if (cmbTransmission.SelectedItem == null)
                {
                    errorMessages.Add("Transmission is required");
                    HighlightError(cmbTransmission);
                    isValid = false;
                }

                // Validate Fuel Type
                if (cmbFuelType.SelectedItem == null)
                {
                    errorMessages.Add("Fuel type is required");
                    HighlightError(cmbFuelType);
                    isValid = false;
                }

                // Validate Status
                if (cmbStatus.SelectedItem == null)
                {
                    errorMessages.Add("Status is required");
                    HighlightError(cmbStatus);
                    isValid = false;
                }

                // Validate Seats
                if (nurSeats.Value < 1 || nurSeats.Value > 50)
                {
                    errorMessages.Add("Seats must be between 1 and 50");
                    HighlightError(nurSeats);
                    isValid = false;
                }

                // Validate Mileage
                if (nurMileage.Value < 0)
                {
                    errorMessages.Add("Mileage cannot be negative");
                    HighlightError(nurMileage);
                    isValid = false;
                }

                // Validate VIN length (if provided)
                if (!string.IsNullOrWhiteSpace(txtVIN.Text) && txtVIN.Text.Length != 17)
                {
                    errorMessages.Add("VIN must be 17 characters if provided");
                    HighlightError(txtVIN);
                    isValid = false;
                }

                // Validate Daily Rate
                if (nurDailyRate.Value <= 0)
                {
                    errorMessages.Add("Daily rate must be greater than 0");
                    HighlightError(nurDailyRate);
                    isValid = false;
                }

                // Validate Weekly Rate
                if (nurWeeklyRate.Value <= 0)
                {
                    errorMessages.Add("Weekly rate must be greater than 0");
                    HighlightError(nurWeeklyRate);
                    isValid = false;
                }

                // Validate Monthly Rate
                if (nurMonthlyRate.Value <= 0)
                {
                    errorMessages.Add("Monthly rate must be greater than 0");
                    HighlightError(nurMonthlyRate);
                    isValid = false;
                }

                if (!isValid)
                {
                    ShowValidationError(errorMessages);
                    return false;
                }

                return true;
            }
            finally
            {
                _validationInProgress = false;
            }
        }

        private void ClearAllErrorHighlights()
        {
            ClearErrorHighlight(txtPlateNumber);
            ClearErrorHighlight(txtMake);
            ClearErrorHighlight(txtModel);
            ClearErrorHighlight(txtColor);
            ClearErrorHighlight(txtVIN);
            ClearErrorHighlight(txtEngineNumber);
            ClearErrorHighlight(txtFeatures);
            ClearErrorHighlight(nurYear);
            ClearErrorHighlight(nurSeats);
            ClearErrorHighlight(nurMileage);
            ClearErrorHighlight(nurDailyRate);
            ClearErrorHighlight(nurWeeklyRate);
            ClearErrorHighlight(nurMonthlyRate);
            ClearErrorHighlight(cmbVehicleType);
            ClearErrorHighlight(cmbTransmission);
            ClearErrorHighlight(cmbFuelType);
            ClearErrorHighlight(cmbStatus);
        }

        private void HighlightError(Control control)
        {
            try
            {
                control.BackColor = Color.FromArgb(255, 200, 200);
                control.Focus();
            }
            catch { }
        }

        private void ClearErrorHighlight(Control control)
        {
            try
            {
                if (control is NumericUpDown numericUpDown)
                {
                    numericUpDown.BackColor = Color.White;
                    numericUpDown.ForeColor = Color.Black;
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.BackColor = Color.White;
                    comboBox.ForeColor = Color.Black;
                }
                else
                {
                    control.BackColor = Color.White;
                    control.ForeColor = Color.Black;
                }
            }
            catch { }
        }

        private static void ShowValidationError(List<string> errors)
        {
            if (errors.Count == 0) return;

            var errorText = new StringBuilder("Please fix the following errors:\n\n");
            foreach (var error in errors)
            {
                errorText.AppendLine($"• {error}");
            }

            MessageBox.Show(errorText.ToString(), "Validation Errors",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private static void ShowSimpleError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private async void btnSave_Click_1(object sender, EventArgs e)
        {
            // CRITICAL: Set DialogResult to None first
            this.DialogResult = DialogResult.None;

            try
            {
                if (!_isFormLoaded)
                {
                    ShowSimpleError("Form not ready");
                    return;
                }

                if (_isUpdating) return;

                if (ValidateForm())
                {
                    _isUpdating = true;
                    btnSave.Enabled = false;
                    btnSave.Text = "Saving...";
                    Cursor = Cursors.WaitCursor;

                    var updatedData = GetUpdatedVehicleData();
                    await _apiClient.UpdateVehicleAsync(updatedData);

                    // Set DialogResult.OK if update succeeded
                    this.DialogResult = DialogResult.OK;
                    ShowSuccess("Vehicle updated successfully!");

                    // Trigger the event to notify parent form
                    VehicleUpdated?.Invoke(this, EventArgs.Empty);

                    this.Close();
                }
            }
            catch (HttpRequestException ex)
            {
                string errorMessage = CleanErrorMessage(ex.Message);

                if (errorMessage.Contains("Plate number already exists"))
                    errorMessage = "Plate number already exists for another vehicle.";
                else if (errorMessage.Contains("VIN already exists"))
                    errorMessage = "VIN already exists for another vehicle.";

                ShowSimpleError(errorMessage);
            }
            catch (Exception ex)
            {
                ShowSimpleError($"Failed to update vehicle: {CleanErrorMessage(ex.Message)}");
            }
            finally
            {
                _isUpdating = false;
                btnSave.Enabled = true;
                btnSave.Text = "Save";
                Cursor = Cursors.Default;
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Cancel without saving changes?",
                "Confirm Cancel",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void EditVehicle_Load(object sender, EventArgs e)
        {
            if (_isFormLoaded)
            {
                txtPlateNumber.Focus();
            }
        }

        // Text change handlers
        private void TxtPlateNumber_TextChanged(object sender, EventArgs e) => ClearErrorHighlight(txtPlateNumber);
        private void TxtMake_TextChanged(object sender, EventArgs e) => ClearErrorHighlight(txtMake);
        private void TxtModel_TextChanged(object sender, EventArgs e) => ClearErrorHighlight(txtModel);
        private void TxtColor_TextChanged(object sender, EventArgs e) => ClearErrorHighlight(txtColor);
        private void TxtVIN_TextChanged(object sender, EventArgs e) => ClearErrorHighlight(txtVIN);
        private void TxtEngineNumber_TextChanged(object sender, EventArgs e) => ClearErrorHighlight(txtEngineNumber);
        private void TxtFeatures_TextChanged(object sender, EventArgs e) => ClearErrorHighlight(txtFeatures);

        // NumericUpDown change handlers
        private void NurYear_ValueChanged(object sender, EventArgs e) => ClearErrorHighlight(nurYear);
        private void NurSeats_ValueChanged(object sender, EventArgs e) => ClearErrorHighlight(nurSeats);
        private void NurMileage_ValueChanged(object sender, EventArgs e) => ClearErrorHighlight(nurMileage);
        private void NurDailyRate_ValueChanged(object sender, EventArgs e) => ClearErrorHighlight(nurDailyRate);
        private void NurWeeklyRate_ValueChanged(object sender, EventArgs e) => ClearErrorHighlight(nurWeeklyRate);
        private void NurMonthlyRate_ValueChanged(object sender, EventArgs e) => ClearErrorHighlight(nurMonthlyRate);

        // ComboBox change handlers
        private void CmbVehicleType_SelectedIndexChanged(object sender, EventArgs e) => ClearErrorHighlight(cmbVehicleType);
        private void CmbTransmission_SelectedIndexChanged(object sender, EventArgs e) => ClearErrorHighlight(cmbTransmission);
        private void CmbFuelType_SelectedIndexChanged(object sender, EventArgs e) => ClearErrorHighlight(cmbFuelType);
        private void CmbStatus_SelectedIndexChanged(object sender, EventArgs e) => ClearErrorHighlight(cmbStatus);

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_validationInProgress)
            {
                e.Cancel = true;
                return;
            }

            if (e.CloseReason == CloseReason.UserClosing && this.DialogResult == DialogResult.None)
            {
                var result = MessageBox.Show(
                    "Close without saving changes?",
                    "Confirm Close",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.Cancel;
                }
                else
                {
                    e.Cancel = true;
                    return;
                }
            }

            base.OnFormClosing(e);
        }
    }
}