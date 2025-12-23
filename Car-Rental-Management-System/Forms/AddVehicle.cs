using Car_Rental_Management_System;
using CRM_API.Models;
using Newtonsoft.Json;
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
    public partial class AddVehicle : Form
    {
        private readonly ApiClient _apiClient;
        private bool _isSaving = false;
        private bool _isFormLoaded = false;
        private bool _validationInProgress = false;

        public AddVehicle(ApiClient apiClient)
        {
            try
            {
                InitializeComponent();
                _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));

                ApplyTheme();
                InitializeComboBoxes();
                SetupForm();
                _isFormLoaded = true;
            }
            catch
            {
                ShowSimpleError("Failed to initialize form");
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
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

        private void InitializeComboBoxes()
        {
            try
            {
                // Initialize Vehicle Type
                cmbVehicleType.Items.Clear();
                cmbVehicleType.Items.AddRange(new string[] {
                    "Sedan", "SUV", "Truck", "Van", "Coupe", "Convertible", "Hatchback", "Minivan"
                });
                cmbVehicleType.SelectedIndex = 0;

                // Initialize Transmission
                cmbTransmission.Items.Clear();
                cmbTransmission.Items.AddRange(new string[] {
                    "Automatic", "Manual", "Semi-Automatic", "CVT"
                });
                cmbTransmission.SelectedIndex = 0;

                // Initialize Fuel Type
                cmbFuelType.Items.Clear();
                cmbFuelType.Items.AddRange(new string[] {
                    "Petrol", "Diesel", "Electric", "Hybrid", "CNG", "LPG"
                });
                cmbFuelType.SelectedIndex = 0;

                // Initialize Status
                cmbStatus.Items.Clear();
                cmbStatus.Items.AddRange(new string[] {
                    "Available",
                    "Maintenance",
                    "Reserved",
                    "Inactive"
                });
                cmbStatus.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ShowSimpleError($"Failed to initialize dropdowns: {ex.Message}");
            }
        }

        private void SetupForm()
        {
            try
            {
                // Set year range
                nurYear.Maximum = DateTime.Now.Year + 1;
                nurYear.Value = DateTime.Now.Year;

                // Set seats range
                nurSeats.Minimum = 1;
                nurSeats.Maximum = 50;
                nurSeats.Value = 5;

                // Set mileage range
                nurMileage.Minimum = 0;
                nurMileage.Maximum = 1000000;
                nurMileage.Value = 0;

                // Set rates
                nurDailyRate.Minimum = 0;
                nurDailyRate.Maximum = 10000;
                nurDailyRate.Value = 50.00m;

                nurWeeklyRate.Minimum = 0;
                nurWeeklyRate.Maximum = 50000;
                nurWeeklyRate.Value = 300.00m;

                nurMonthlyRate.Minimum = 0;
                nurMonthlyRate.Maximum = 200000;
                nurMonthlyRate.Value = 1200.00m;

                ClearAllErrorHighlights();
                this.DialogResult = DialogResult.None;
            }
            catch (Exception ex)
            {
                ShowSimpleError($"Failed to set up form: {ex.Message}");
            }
        }

        public VehicleVM GetVehicleData()
        {
            if (!_isFormLoaded)
                throw new InvalidOperationException("Form not ready");

            string selectedStatus = cmbStatus.SelectedItem?.ToString() ?? "Available";

            // Determine IsActive and IsAvailable based on status
            bool isActive = true;
            bool isAvailable = true;

            switch (selectedStatus.ToLower())
            {
                case "available":
                    isActive = true;
                    isAvailable = true;
                    break;
                case "rented":
                    isActive = true;
                    isAvailable = false;
                    break;
                case "maintenance":
                    isActive = false;
                    isAvailable = false;
                    break;
                case "inactive":
                    isActive = false;
                    isAvailable = false;
                    break;
                case "reserved":
                    isActive = true;
                    isAvailable = false;
                    break;
                default:
                    isActive = true;
                    isAvailable = true;
                    break;
            }

            var vehicle = new VehicleVM
            {
                // Basic Information
                PlateNumber = txtPlateNumber.Text.Trim(),
                Make = txtMake.Text.Trim(),
                Model = txtModel.Text.Trim(),
                Year = (int)nurYear.Value,
                Color = txtColor.Text.Trim(),

                // Vehicle Details
                VehicleType = cmbVehicleType.SelectedItem?.ToString() ?? "",
                Transmission = cmbTransmission.SelectedItem?.ToString() ?? "",
                FuelType = cmbFuelType.SelectedItem?.ToString() ?? "",
                Mileage = (int)nurMileage.Value,
                Seats = (int)nurSeats.Value,
                Features = string.IsNullOrWhiteSpace(txtFeatures.Text) ? null : txtFeatures.Text.Trim(),

                // Rental Information
                DailyRate = nurDailyRate.Value,
                WeeklyRate = nurWeeklyRate.Value,
                MonthlyRate = nurMonthlyRate.Value,
                IsAvailable = isAvailable,
                IsActive = isActive,

                // Additional Info
                VIN = string.IsNullOrWhiteSpace(txtVIN.Text) ? null : txtVIN.Text.Trim(),
                EngineNumber = string.IsNullOrWhiteSpace(txtEngineNumber.Text) ? null : txtEngineNumber.Text.Trim(),
                LastServiceDate = DateTime.Now,
                NextServiceDate = DateTime.Now.AddMonths(6),
                Notes = "New vehicle added via system",

                // System
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Status = selectedStatus // This is calculated property, but we send it for consistency
            };

            return vehicle;
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
                else if (txtPlateNumber.Text.Trim().Length > 20)
                {
                    errorMessages.Add("Plate number must be 20 characters or less");
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
                else if (txtMake.Text.Trim().Length > 50)
                {
                    errorMessages.Add("Make must be 50 characters or less");
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
                else if (txtModel.Text.Trim().Length > 50)
                {
                    errorMessages.Add("Model must be 50 characters or less");
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
                else if (txtColor.Text.Trim().Length > 30)
                {
                    errorMessages.Add("Color must be 30 characters or less");
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

                // Validate VIN
                if (!string.IsNullOrWhiteSpace(txtVIN.Text) && txtVIN.Text.Trim().Length != 17)
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

            // Try to parse JSON error message
            try
            {
                if (errorMessage.Contains("{") && errorMessage.Contains("}"))
                {
                    int start = errorMessage.IndexOf("{");
                    int end = errorMessage.LastIndexOf("}") + 1;
                    if (start >= 0 && end > start)
                    {
                        string jsonPart = errorMessage.Substring(start, end - start);
                        var errorObj = JsonConvert.DeserializeObject<dynamic>(jsonPart);
                        if (errorObj != null && errorObj.message != null)
                        {
                            return errorObj.message.ToString();
                        }
                    }
                }
            }
            catch { }

            // Remove common error prefixes
            string[] prefixes = {
                "API Error:", "HttpRequestException:", "System.Net.Http.HttpRequestException:",
                "BadRequest", "400", "404", "500", "StatusCode:", "InternalServerError"
            };

            foreach (var prefix in prefixes)
            {
                errorMessage = errorMessage.Replace(prefix, "").Trim();
            }

            // Check for SQL errors
            if (errorMessage.Contains("SQL") || errorMessage.Contains("constraint") ||
                errorMessage.Contains("foreign key") || errorMessage.Contains("unique") ||
                errorMessage.Contains("NOT NULL"))
            {
                if (errorMessage.Contains("FK_"))
                    return "Database constraint error: Related record not found.";
                if (errorMessage.Contains("IX_") || errorMessage.Contains("unique"))
                    return "Duplicate entry error. This vehicle may already exist.";
                if (errorMessage.Contains("NOT NULL"))
                    return "Database error: A required field is missing.";
            }

            // Clean up excessive whitespace
            errorMessage = System.Text.RegularExpressions.Regex.Replace(errorMessage, @"\s+", " ");

            // Limit length
            if (errorMessage.Length > 200)
                errorMessage = errorMessage.Substring(0, 197) + "...";

            return errorMessage.Trim();
        }

        private async void btnSave_Click(object sender, EventArgs e)
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

                if (_isSaving) return;

                if (ValidateForm())
                {
                    _isSaving = true;
                    btnSave.Enabled = false;
                    btnSave.Text = "Saving...";
                    Cursor = Cursors.WaitCursor;

                    var vehicleData = GetVehicleData();

                    // DEBUG: Show final data
                    Console.WriteLine("=== Final Vehicle Data ===");
                    Console.WriteLine($"Plate: {vehicleData.PlateNumber}");
                    Console.WriteLine($"Make: {vehicleData.Make}");
                    Console.WriteLine($"Model: {vehicleData.Model}");
                    Console.WriteLine($"Status: {vehicleData.Status}");
                    Console.WriteLine($"LastServiceDate: {vehicleData.LastServiceDate}");
                    Console.WriteLine($"NextServiceDate: {vehicleData.NextServiceDate}");
                    Console.WriteLine($"Notes: {vehicleData.Notes}");

                    var createdVehicle = await _apiClient.CreateVehicleAsync(vehicleData);

                    if (createdVehicle != null)
                    {
                        // Only set DialogResult.OK if save succeeded
                        this.DialogResult = DialogResult.OK;
                        ShowSuccess("Vehicle added successfully!");
                        this.Close();
                    }
                    else
                    {
                        ShowSimpleError("Failed to create vehicle: No response from server");
                    }
                }
                // If validation failed, DialogResult remains None and form stays open
            }
            catch (HttpRequestException ex)
            {
                string errorMessage = CleanErrorMessage(ex.Message);
                ShowSimpleError($"Failed to save vehicle: {errorMessage}");

                // DEBUG: Show full error for debugging
                Console.WriteLine($"Full error: {ex.Message}");
                Console.WriteLine($"Inner exception: {ex.InnerException?.Message}");
            }
            catch (Exception ex)
            {
                string cleanError = CleanErrorMessage(ex.Message);
                ShowSimpleError($"Failed to save vehicle: {cleanError}");

                // DEBUG: Show full error for debugging
                Console.WriteLine($"Full error: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }
            finally
            {
                _isSaving = false;
                btnSave.Enabled = true;
                btnSave.Text = "Save";
                Cursor = Cursors.Default;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Cancel without saving?",
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

        private void AddVehicle_Load(object sender, EventArgs e)
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
                    "Close without saving?",
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