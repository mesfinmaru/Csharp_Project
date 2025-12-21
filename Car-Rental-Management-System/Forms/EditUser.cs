using CRM_API.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static CRM_API.Models.UpdateUserRequest;

namespace Car_Rental_Management_System.Forms
{
    public partial class EditUser : Form
    {
        private readonly UserVM? _userToEdit;
        private readonly bool _adminExists;
        private bool _isFormLoaded = false;
        private bool _validationInProgress = false;

       
        public EditUser(UserVM? userToEdit, bool adminExists = false)
        {
            try
            {
                InitializeComponent();

                this.btnSave.Click += BtnSave_Click;

                if (userToEdit == null)
                {
                    ShowSimpleError("No user data provided");
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }

                _userToEdit = userToEdit;
                _adminExists = adminExists;
                LoadUserData();
                ApplyTheme();
                _isFormLoaded = true;
            }
            catch
            {
                ShowSimpleError("Failed to initialize form");
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
        private void LoadUserData()
        {
            try
            {
                if (_userToEdit == null) return;

                txtFullName.Text = _userToEdit.FullName ?? "";
                txtUsername.Text = _userToEdit.Username ?? "";
                txtEmail.Text = _userToEdit.Email ?? "";
                txtPhone.Text = _userToEdit.Phone ?? "";

                cmbRole.Items.Clear();
                cmbRole.Items.Add("Staff");

                // CRITICAL FIX: Only show Admin option if:
                // 1. User is already Admin (for display), OR
                // 2. No Admin exists in the system AND user is not currently Admin
                bool isCurrentUserAdmin = _userToEdit.Role?.Equals("Admin", StringComparison.OrdinalIgnoreCase) == true;

                if (isCurrentUserAdmin || (!_adminExists && !isCurrentUserAdmin))
                {
                    cmbRole.Items.Add("Admin");
                }

                cmbRole.SelectedItem = _userToEdit.Role ?? "Staff";

                txtPassword.UseSystemPasswordChar = true;
                txtConfirmPassword.UseSystemPasswordChar = true;
                txtPassword.Text = "";
                txtConfirmPassword.Text = "";

                txtUsername.Enabled = false;

                // If user is Admin, disable role change
                if (isCurrentUserAdmin)
                {
                    cmbRole.Enabled = false;
                    lblAdminNote.Text = "Admin role cannot be changed";
                    lblAdminNote.Visible = true;
                    lblAdminNote.ForeColor = Color.Orange;
                }
                
            }
            catch
            {
                ShowSimpleError("Failed to load user data");
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
        }

        public UpdateUserRequest GetUpdatedUserData()
        {
            if (!_isFormLoaded)
                throw new InvalidOperationException("Form not ready");

            return new UpdateUserRequest
            {
                FullName = txtFullName.Text.Trim(),
                Username = txtUsername.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Role = cmbRole.SelectedItem?.ToString() ?? "Staff",
                Password = string.IsNullOrEmpty(txtPassword.Text) ? "" : txtPassword.Text
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

                // Validate password if provided
                bool passwordProvided = !string.IsNullOrEmpty(txtPassword.Text);
                bool confirmPasswordProvided = !string.IsNullOrEmpty(txtConfirmPassword.Text);

                if (passwordProvided || confirmPasswordProvided)
                {
                    if (passwordProvided && !confirmPasswordProvided)
                    {
                        errorMessages.Add("Please confirm your password");
                        HighlightError(txtConfirmPassword);
                        isValid = false;
                    }
                    else if (!passwordProvided && confirmPasswordProvided)
                    {
                        errorMessages.Add("Please enter a new password");
                        HighlightError(txtPassword);
                        isValid = false;
                    }
                    else if (passwordProvided && confirmPasswordProvided)
                    {
                        if (txtPassword.Text.Length < 6)
                        {
                            errorMessages.Add("Password must be at least 6 characters");
                            HighlightError(txtPassword);
                            isValid = false;
                        }

                        if (txtPassword.Text != txtConfirmPassword.Text)
                        {
                            errorMessages.Add("Passwords do not match");
                            HighlightError(txtPassword);
                            HighlightError(txtConfirmPassword);
                            isValid = false;
                        }
                    }
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

            var errorText = new System.Text.StringBuilder("Please fix the following errors:\n\n");
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

        private void EditUser_Load(object sender, EventArgs e)
        {
            if (_isFormLoaded)
            {
                txtFullName.Focus();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
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
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch
            {
                ShowSimpleError("Failed to save changes");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
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

        private void BtnClose_Click(object sender, EventArgs e)
        {
            BtnCancel_Click(sender, e);
        }

        // Text change handlers
        private void TxtFullName_TextChanged(object sender, EventArgs e) => ClearErrorHighlight(txtFullName);
        private void TxtEmail_TextChanged(object sender, EventArgs e) => ClearErrorHighlight(txtEmail);
        private void TxtPhone_TextChanged(object sender, EventArgs e) => ClearErrorHighlight(txtPhone);
        private void TxtPassword_TextChanged(object sender, EventArgs e) => ClearErrorHighlight(txtPassword);
        private void TxtConfirmPassword_TextChanged(object sender, EventArgs e) => ClearErrorHighlight(txtConfirmPassword);

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

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}