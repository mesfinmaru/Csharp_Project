using CRM_API.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Car_Rental_Management_System.Forms
{
    public partial class AddUser : Form
    {
        private bool _isFormLoaded = false;
        private bool _validationInProgress = false;
        private bool _adminExists = false;



        public AddUser(bool adminExists = false)
        {
            try
            {
                InitializeComponent();
                _adminExists = adminExists;
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
            btnAdd.BackColor = primary;
            btnAdd.ForeColor = Color.White;
            btnCancel.BackColor = Color.FromArgb(255, 98, 70);
            btnCancel.ForeColor = Color.White;

        }

        private void SetupForm()
        {
            try
            {
                cmbRole.Items.Clear();

                // If Admin already exists, only show Staff option
                if (_adminExists)
                {
                    cmbRole.Items.Add("Staff");

                }
                else
                {
                    cmbRole.Items.AddRange(new object[] { "Staff", "Admin" });

                }

                cmbRole.SelectedIndex = 0;

                this.DialogResult = DialogResult.None;
            }
            catch
            {
                ShowSimpleError("Failed to set up form");
            }
        }

        public RegisterVM GetUserData()
        {
            if (!_isFormLoaded)
                throw new InvalidOperationException("Form not ready");

            return new RegisterVM
            {
                FullName = txtFullName.Text.Trim(),
                Username = txtUsername.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Password = txtPassword.Text,
                ConfirmPassword = txtConfirmPassword.Text,
                Role = cmbRole.SelectedItem?.ToString() ?? "Staff"
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

                // Validate Username
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    errorMessages.Add("Username is required");
                    HighlightError(txtUsername);
                    isValid = false;
                }
                else if (txtUsername.Text.Trim().Length < 3)
                {
                    errorMessages.Add("Username must be at least 3 characters");
                    HighlightError(txtUsername);
                    isValid = false;
                }
                else if (txtUsername.Text.Contains(" "))
                {
                    errorMessages.Add("Username cannot contain spaces");
                    HighlightError(txtUsername);
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

                // Validate Password
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    errorMessages.Add("Password is required");
                    HighlightError(txtPassword);
                    isValid = false;
                }
                else if (txtPassword.Text.Length < 6)
                {
                    errorMessages.Add("Password must be at least 6 characters");
                    HighlightError(txtPassword);
                    isValid = false;
                }

                // Validate Confirm Password
                if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
                {
                    errorMessages.Add("Please confirm your password");
                    HighlightError(txtConfirmPassword);
                    isValid = false;
                }
                else if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    errorMessages.Add("Passwords do not match");
                    HighlightError(txtConfirmPassword);
                    isValid = false;
                }

                // Validate Role
                if (cmbRole.SelectedItem == null)
                {
                    errorMessages.Add("Please select a role");
                    HighlightError(cmbRole);
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
            ClearErrorHighlight(txtUsername);
            ClearErrorHighlight(txtEmail);
            ClearErrorHighlight(txtPhone);
            ClearErrorHighlight(txtPassword);
            ClearErrorHighlight(txtConfirmPassword);
            ClearErrorHighlight(cmbRole);
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
                control.BackColor = Color.FromArgb(255, 255, 255);
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

        private static void ShowInfo(string message)
        {
            MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
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

                if (ValidateForm())
                {
                    // Only set DialogResult.OK if validation passed
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                // If validation failed, DialogResult remains None and form stays open
            }
            catch
            {
                ShowSimpleError("Failed to save user");
                // Don't close on error
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            if (_isFormLoaded)
            {
                txtFullName.Focus();
            }
        }

        private void TxtPhone_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtPhone.Text)) return;

                if (Regex.IsMatch(txtPhone.Text, "[^0-9+\\s-]"))
                {
                    txtPhone.Text = Regex.Replace(txtPhone.Text, "[^0-9+\\s-]", "");
                    txtPhone.SelectionStart = txtPhone.Text.Length;
                }

                FormatPhoneNumber();
            }
            catch { }
        }

        private void FormatPhoneNumber()
        {
            try
            {
                string digitsOnly = new string(txtPhone.Text.Where(char.IsDigit).ToArray());

                if (digitsOnly.Length <= 3)
                {
                    txtPhone.Text = digitsOnly;
                }
                else if (digitsOnly.Length <= 6)
                {
                    txtPhone.Text = $"{digitsOnly[..3]}-{digitsOnly[3..]}";
                }
                else if (digitsOnly.Length <= 10)
                {
                    txtPhone.Text = $"{digitsOnly[..3]}-{digitsOnly[3..6]}-{digitsOnly[6..]}";
                }
                else
                {
                    txtPhone.Text = $"{digitsOnly[..3]}-{digitsOnly[3..6]}-{digitsOnly[6..10]}";
                }

                txtPhone.SelectionStart = txtPhone.Text.Length;
            }
            catch { }
        }

        // Text change handlers
        private void TxtFullName_TextChanged(object sender, EventArgs e) => ClearErrorHighlight(txtFullName);
        private void TxtUsername_TextChanged(object sender, EventArgs e) => ClearErrorHighlight(txtUsername);
        private void TxtEmail_TextChanged(object sender, EventArgs e) => ClearErrorHighlight(txtEmail);
        private void TxtPassword_TextChanged(object sender, EventArgs e) => ClearErrorHighlight(txtPassword);
        private void TxtConfirmPassword_TextChanged(object sender, EventArgs e) => ClearErrorHighlight(txtConfirmPassword);
        private void CmbRole_SelectedIndexChanged(object sender, EventArgs e) => ClearErrorHighlight(cmbRole);

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

        private void txtFullName_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void formPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}