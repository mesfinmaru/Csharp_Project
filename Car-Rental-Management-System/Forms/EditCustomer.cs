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
    public partial class EditCustomer : Form
    {
        private readonly ApiClient _apiClient;
        private readonly int _customerId;
        private CustomerVM? _customerToEdit;
        private bool _isFormLoaded = false;
        private bool _validationInProgress = false;
        private bool _isUpdating = false;

        // Add these events
        public event EventHandler? CustomerUpdated;
        public event EventHandler? CustomerStatusChanged;

        public EditCustomer(ApiClient apiClient, int customerId)
        {
            try
            {
                InitializeComponent();
                _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
                _customerId = customerId;

                ApplyTheme();
                _ = LoadCustomerDataAsync();
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
            btnCancel.BackColor = Color.FromArgb(255, 98, 70);
            btnCancel.ForeColor = Color.White;
            btnActiveDeactive.BackColor = Color.FromArgb(46, 204, 113);
            btnActiveDeactive.ForeColor = Color.White;

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
                }
                else if (control is DateTimePicker dateTimePicker)
                {
                    dateTimePicker.BackColor = Color.White;
                    dateTimePicker.ForeColor = Color.Black;
                }
            }
        }

        private async Task LoadCustomerDataAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                _customerToEdit = await _apiClient.GetCustomerAsync(_customerId);

                if (_customerToEdit != null)
                {
                    LoadCustomerData();
                    _isFormLoaded = true;
                }
                else
                {
                    ShowSimpleError("Customer not found");
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ShowSimpleError($"Failed to load customer: {CleanErrorMessage(ex.Message)}");
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void LoadCustomerData()
        {
            if (_customerToEdit == null) return;

            txtFullName.Text = _customerToEdit.FullName ?? "";
            txtEmail.Text = _customerToEdit.Email ?? "";
            txtPhoneNumber.Text = _customerToEdit.Phone ?? "";
            txtAddress.Text = _customerToEdit.Address ?? "";
            txtCity.Text = _customerToEdit.City ?? "";
            txtCountry.Text = _customerToEdit.Country ?? "";
            txtLicenseNumber.Text = _customerToEdit.LicenseNumber ?? "";

            // Load license type
            cmbLicenseType.Items.Clear();
            cmbLicenseType.Items.AddRange(new object[] {
                "A - Motorcycle",
                "B - Car",
                "C - Truck",
                "D - Bus",
                "E - Trailer"
            });

            if (!string.IsNullOrEmpty(_customerToEdit.LicenseType))
            {
                cmbLicenseType.SelectedItem = _customerToEdit.LicenseType;
            }
            else
            {
                cmbLicenseType.SelectedIndex = 1; // Default to Car
            }

            // Load expiry date
            if (_customerToEdit.LicenseExpiryDate.HasValue)
            {
                dtpExpiryDate.Value = _customerToEdit.LicenseExpiryDate.Value;
                dtpExpiryDate.Checked = true;
            }
            else
            {
                dtpExpiryDate.Checked = false;
                dtpExpiryDate.Value = DateTime.Today.AddYears(1);
            }

            // Update active/deactive button
            UpdateActiveDeactiveButton();

            this.DialogResult = DialogResult.None;
        }

        private void UpdateActiveDeactiveButton()
        {
            if (_customerToEdit == null) return;

            if (_customerToEdit.IsActive)
            {
                btnActiveDeactive.BackColor = Color.FromArgb(255, 98, 70);
                btnActiveDeactive.ForeColor = Color.White;
                btnActiveDeactive.Text = "Deactivate Customer";
            }
            else
            {
                btnActiveDeactive.BackColor = Color.FromArgb(46, 204, 113);
                btnActiveDeactive.ForeColor = Color.White;
                btnActiveDeactive.Text = "Activate Customer";
            }
        }

        public CustomerVM GetUpdatedCustomerData()
        {
            if (!_isFormLoaded)
                throw new InvalidOperationException("Form not ready");

            if (_customerToEdit == null)
                throw new InvalidOperationException("Customer data not loaded");

            return new CustomerVM
            {
                Id = _customerId,
                FullName = txtFullName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Phone = txtPhoneNumber.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                City = txtCity.Text.Trim(),
                Country = txtCountry.Text.Trim(),
                LicenseNumber = txtLicenseNumber.Text.Trim(),
                LicenseType = cmbLicenseType.SelectedItem?.ToString() ?? cmbLicenseType.Text,
                LicenseExpiryDate = dtpExpiryDate.Checked ? dtpExpiryDate.Value : (DateTime?)null,
                IsActive = _customerToEdit.IsActive
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

                // Validate Full Name
                if (string.IsNullOrWhiteSpace(txtFullName.Text))
                {
                    errorMessages.Add("Full name is required");
                    HighlightError(txtFullName);
                    isValid = false;
                }
                else if (txtFullName.Text.Trim().Length < 2)
                {
                    errorMessages.Add("Full name must be at least 2 characters");
                    HighlightError(txtFullName);
                    isValid = false;
                }

                // Validate Email
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    errorMessages.Add("Email is required");
                    HighlightError(txtEmail);
                    isValid = false;
                }
                else if (!IsValidEmail(txtEmail.Text))
                {
                    errorMessages.Add("Please enter a valid email address");
                    HighlightError(txtEmail);
                    isValid = false;
                }

                // Validate Phone
                if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
                {
                    errorMessages.Add("Phone number is required");
                    HighlightError(txtPhoneNumber);
                    isValid = false;
                }
                else if (txtPhoneNumber.Text.Trim().Length < 7)
                {
                    errorMessages.Add("Phone number must be at least 7 digits");
                    HighlightError(txtPhoneNumber);
                    isValid = false;
                }

                // Validate Address
                if (string.IsNullOrWhiteSpace(txtAddress.Text))
                {
                    errorMessages.Add("Address is required");
                    HighlightError(txtAddress);
                    isValid = false;
                }

                // Validate City
                if (string.IsNullOrWhiteSpace(txtCity.Text))
                {
                    errorMessages.Add("City is required");
                    HighlightError(txtCity);
                    isValid = false;
                }

                // Validate Country
                if (string.IsNullOrWhiteSpace(txtCountry.Text))
                {
                    errorMessages.Add("Country is required");
                    HighlightError(txtCountry);
                    isValid = false;
                }

                // Validate License Number
                if (string.IsNullOrWhiteSpace(txtLicenseNumber.Text))
                {
                    errorMessages.Add("License number is required");
                    HighlightError(txtLicenseNumber);
                    isValid = false;
                }

                // Validate License Type
                if (cmbLicenseType.SelectedItem == null)
                {
                    errorMessages.Add("License type is required");
                    HighlightError(cmbLicenseType);
                    isValid = false;
                }

                // Validate License Expiry Date
                if (dtpExpiryDate.Checked && dtpExpiryDate.Value < DateTime.Today)
                {
                    errorMessages.Add("License expiry date cannot be in the past");
                    HighlightError(dtpExpiryDate);
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
            ClearErrorHighlight(txtFullName);
            ClearErrorHighlight(txtPhoneNumber);
            ClearErrorHighlight(txtEmail);
            ClearErrorHighlight(txtAddress);
            ClearErrorHighlight(txtCity);
            ClearErrorHighlight(txtCountry);
            ClearErrorHighlight(txtLicenseNumber);
            ClearErrorHighlight(cmbLicenseType);
            ClearErrorHighlight(dtpExpiryDate);
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void HighlightError(Control control)
        {
            try
            {
                control.BackColor = Color.FromArgb(192, 0, 0);
                control.Focus();
            }
            catch { }
        }

        private void ClearErrorHighlight(Control control)
        {
            try
            {
                if (control is DateTimePicker dtp)
                {
                    dtp.BackColor = Color.White;
                    dtp.ForeColor = Color.Black;
                }
                else if (control is ComboBox cmb)
                {
                    cmb.BackColor = Color.White;
                    cmb.ForeColor = Color.Black;
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

        private async void btnActiveDeactive_Click_1(object sender, EventArgs e)
        {
            if (_customerToEdit == null || _isUpdating) return;

            var action = _customerToEdit.IsActive ? "deactivate" : "activate";
            var result = MessageBox.Show(
                $"Are you sure you want to {action} this customer?",
                $"Confirm {action}",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _isUpdating = true;
                    btnActiveDeactive.Enabled = false;
                    btnActiveDeactive.Text = "Updating...";
                    Cursor = Cursors.WaitCursor;

                    // Call the API
                    await _apiClient.UpdateCustomerStatusAsync(_customerId, !_customerToEdit.IsActive);

                    // Update local state
                    _customerToEdit.IsActive = !_customerToEdit.IsActive;

                    // Update button appearance
                    UpdateActiveDeactiveButton();

                    ShowSuccess($"Customer {action}d successfully!");

                    // CRITICAL: Trigger the event to notify parent form
                    CustomerStatusChanged?.Invoke(this, EventArgs.Empty);
                }
                catch (HttpRequestException ex)
                {
                    // Handle specific HTTP errors
                    string errorMessage = ex.Message;

                    if (errorMessage.Contains("404") || errorMessage.Contains("not found"))
                    {
                        ShowSimpleError("Customer not found. It may have been deleted.");
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                    }
                    else if (errorMessage.Contains("401") || errorMessage.Contains("Authentication"))
                    {
                        ShowSimpleError("Authentication required. Please login again.");
                    }
                    else
                    {
                        ShowSimpleError($"Status update failed: {CleanErrorMessage(errorMessage)}");
                    }
                }
                catch (Exception ex)
                {
                    ShowSimpleError($"An unexpected error occurred: {CleanErrorMessage(ex.Message)}");
                }
                finally
                {
                    _isUpdating = false;
                    btnActiveDeactive.Enabled = true;
                    Cursor = Cursors.Default;
                }
            }
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

                    var updatedData = GetUpdatedCustomerData();
                    await _apiClient.UpdateCustomerAsync(updatedData);

                    // Only set DialogResult.OK if update succeeded
                    this.DialogResult = DialogResult.OK;
                    ShowSuccess("Customer updated successfully!");

                    // CRITICAL: Trigger the event to notify parent form
                    CustomerUpdated?.Invoke(this, EventArgs.Empty);

                    this.Close();
                }
                // If validation failed, DialogResult remains None and form stays open
            }
            catch (HttpRequestException ex)
            {
                string errorMessage = CleanErrorMessage(ex.Message);

                if (errorMessage.Contains("Phone number already exists"))
                    errorMessage = "Phone number already exists for another customer.";
                else if (errorMessage.Contains("Email already exists"))
                    errorMessage = "Email already exists for another customer.";
                else if (errorMessage.Contains("License number already exists"))
                    errorMessage = "License number already exists for another customer.";

                ShowSimpleError(errorMessage);
            }
            catch (Exception ex)
            {
                ShowSimpleError($"Failed to update customer: {CleanErrorMessage(ex.Message)}");
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

        private void EditCustomer_Load(object sender, EventArgs e)
        {
            if (_isFormLoaded)
            {
                txtFullName.Focus();
            }
        }

        // Text change handlers
        private void TxtFullName_TextChanged(object sender, EventArgs e) => ClearErrorHighlight(txtFullName);
        private void TxtEmail_TextChanged(object sender, EventArgs e) => ClearErrorHighlight(txtEmail);
        private void TxtPhoneNumber_TextChanged(object sender, EventArgs e) => ClearErrorHighlight(txtPhoneNumber);
        private void TxtAddress_TextChanged(object sender, EventArgs e) => ClearErrorHighlight(txtAddress);
        private void TxtCity_TextChanged(object sender, EventArgs e) => ClearErrorHighlight(txtCity);
        private void TxtCountry_TextChanged(object sender, EventArgs e) => ClearErrorHighlight(txtCountry);
        private void TxtLicenseNumber_TextChanged(object sender, EventArgs e) => ClearErrorHighlight(txtLicenseNumber);
        private void CmbLicenseType_SelectedIndexChanged(object sender, EventArgs e) => ClearErrorHighlight(cmbLicenseType);
        private void DtpExpiryDate_ValueChanged(object sender, EventArgs e) => ClearErrorHighlight(dtpExpiryDate);

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
                    e.Cancel = false;
                    return;
                }
            }

            base.OnFormClosing(e);
        }
    }
}