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
    public partial class AddCustomer : Form
    {
        private readonly ApiClient _apiClient;
        private bool _isSaving = false;
        private bool _isFormLoaded = false;
        private bool _validationInProgress = false;

        public AddCustomer(ApiClient apiClient)
        {
            try
            {
                InitializeComponent();
                _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));

                ApplyTheme();
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
            btnCancel.BackColor = Color.FromArgb(255, 98, 70);
            btnCancel.ForeColor = Color.White;

            // Style all textboxes
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

        private void SetupForm()
        {
            try
            {
                
                cmbLicenseType.SelectedIndex = 1; // Default to Car

                // Set expiry date to 1 year from now
                dtpExpiryDate.Value = DateTime.Today.AddYears(1);
                dtpExpiryDate.Checked = true;

                ClearAllErrorHighlights();
                this.DialogResult = DialogResult.None;
            }
            catch
            {
                ShowSimpleError("Failed to set up form");
            }
        }

        public CustomerVM GetCustomerData()
        {
            if (!_isFormLoaded)
                throw new InvalidOperationException("Form not ready");

            return new CustomerVM
            {
                FullName = txtFullName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Phone = txtPhoneNumber.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                City = txtCity.Text.Trim(),
                Country = txtCountry.Text.Trim(),
                LicenseNumber = txtLicenseNumber.Text.Trim(),
                LicenseType = cmbLicenseType.SelectedItem?.ToString() ?? cmbLicenseType.Text,
                LicenseExpiryDate = dtpExpiryDate.Checked ? dtpExpiryDate.Value : (DateTime?)null,
                IsActive = true
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
                else if (txtFullName.Text.Trim().Length < 5)
                {
                    errorMessages.Add("Full name must be at least 5 characters");
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

                // Validate License Expiry Date - REQUIRED
                if (!dtpExpiryDate.Checked)
                {
                    errorMessages.Add("License expiry date is required");
                    HighlightError(dtpExpiryDate);
                    isValid = false;
                }
                else if (dtpExpiryDate.Value < DateTime.Today)
                {
                    errorMessages.Add("License expiry date cannot be in the past");
                    HighlightError(dtpExpiryDate);
                    isValid = false;
                }
                else if (dtpExpiryDate.Value > DateTime.Today.AddYears(10)) // Optional: Add max limit
                {
                    errorMessages.Add("License expiry date cannot be more than 10 years in the future");
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
            if (errorMessage.Contains("JSON tokens") || errorMessage.Contains("isFinalBlock") || errorMessage.Contains("LineNumber: 0"))
            {
                if (errorMessage.Contains("<title>") && errorMessage.Contains("</title>"))
                {
                    int start = errorMessage.IndexOf("<title>") + 7;
                    int end = errorMessage.IndexOf("</title>", start);
                    if (start > 7 && end > start)
                    {
                        return errorMessage.Substring(start, end - start).Trim();
                    }
                }
                return "Server returned an unexpected response. Please try again or contact support.";
            }

            if (errorMessage.Contains("BadRequest") || errorMessage.Contains("400"))
            {
                return errorMessage.Replace("BadRequest", "")
                                  .Replace("400", "")
                                  .Replace("\"", "")
                                  .Trim();
            }

            return errorMessage;
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

                if (_isSaving) return;

                if (ValidateForm())
                {
                    _isSaving = true;
                    btnSave.Enabled = false;
                    btnSave.Text = "Saving...";
                    Cursor = Cursors.WaitCursor;

                    var customerData = GetCustomerData();
                    var createdCustomer = await _apiClient.CreateCustomerAsync(customerData);

                    if (createdCustomer != null)
                    {
                        // Only set DialogResult.OK if save succeeded
                        this.DialogResult = DialogResult.OK;
                        ShowSuccess("Customer added successfully!");
                        this.Close();
                    }
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
                string cleanError = CleanErrorMessage(ex.Message);
                ShowSimpleError($"Failed to save customer: {cleanError}");
            }
            finally
            {
                _isSaving = false;
                btnSave.Enabled = true;
                btnSave.Text = "Save";
                Cursor = Cursors.Default;
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {
            if (_isFormLoaded)
            {
                txtFullName.Focus();
            }
        }

        // Text change handlers
        private void TxtFullName_TextChanged(object sender, EventArgs e) => ClearErrorHighlight(txtFullName);
        private void TxtPhoneNumber_TextChanged(object sender, EventArgs e) => ClearErrorHighlight(txtPhoneNumber);
        private void TxtEmail_TextChanged(object sender, EventArgs e) => ClearErrorHighlight(txtEmail);
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