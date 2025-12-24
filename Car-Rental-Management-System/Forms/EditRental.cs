using Car_Rental_Management_System;
using CRM_API.Models;
using System;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace Car_Rental_Management_System.Forms
{
    public partial class EditRental : Form
    {
        private readonly ApiClient _apiClient;
        private readonly int _rentalId;
        private RentalVM? _rentalToEdit;
        private bool _isFormLoaded = false;
        private bool _isSaving = false;

        public EditRental(ApiClient apiClient, int rentalId)
        {
            try
            {
                InitializeComponent();
                _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
                _rentalId = rentalId;

                ApplyTheme();
                InitializeForm();
                _ = LoadRentalDataAsync();
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
           
            var lightText = Color.FromArgb(230, 230, 235);
            var primary = Color.FromArgb(124, 77, 255);
            var secondary = Color.FromArgb(83, 109, 254);
            var accent = Color.FromArgb(46, 204, 113);

            this.BackColor = bg;

            // Apply theme to all labels
            foreach (Control control in this.Controls)
            {
                if (control is Label label)
                {
                    label.ForeColor = lightText;
                }
            }

            // Style buttons
            btnSelectVehicle.BackColor = secondary;
            btnSelectVehicle.ForeColor = Color.White;
            btnSelectVehicle.FlatStyle = FlatStyle.Flat;
            btnSelectVehicle.FlatAppearance.BorderSize = 0;

            btnCalculate.BackColor = secondary;
            btnCalculate.ForeColor = Color.White;
            btnCalculate.FlatStyle = FlatStyle.Flat;
            btnCalculate.FlatAppearance.BorderSize = 0;

            btnSaveRental.BackColor = accent;
            btnSaveRental.ForeColor = Color.White;
            btnSaveRental.FlatStyle = FlatStyle.Flat;
            btnSaveRental.FlatAppearance.BorderSize = 0;

            btnCancel.BackColor = Color.FromArgb(255, 98, 70);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;

            // Style textboxes
            textBox1.BackColor = Color.White;
            textBox1.ForeColor = Color.Black;

            textBox2.BackColor = Color.White;
            textBox2.ForeColor = Color.Black;

            // Style DateTimePickers
            dtpFrom.BackColor = Color.White;
            dtpFrom.ForeColor = Color.Black;

            dtpTo.BackColor = Color.White;
            dtpTo.ForeColor = Color.Black;

            // Style ComboBox
            cmbTransmission.BackColor = Color.White;
            cmbTransmission.ForeColor = Color.Black;

            // Style calculation labels (make them stand out)
            lblRentalDays.ForeColor = Color.FromArgb(124, 77, 255);
            lblSubtotal.ForeColor = Color.FromArgb(83, 109, 254);
            lblTotalAmount.ForeColor = Color.FromArgb(46, 204, 113);
            lblBalanceDue.ForeColor = Color.FromArgb(255, 152, 0);
        }

        private void InitializeForm()
        {
            // Initialize DateTimePickers
            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today.AddDays(1);

            // Initialize ComboBox
            cmbTransmission.Items.Clear();
            cmbTransmission.Items.AddRange(new string[] { "Automatic", "Manual", "Semi-Automatic" });

            // Initialize labels
            lblRentalDays.Text = "1";
            lblSubtotal.Text = "ETB 0.00";
            lblTotalAmount.Text = "ETB 0.00";
            lblBalanceDue.Text = "ETB 0.00";

            this.DialogResult = DialogResult.None;
        }

        private async Task LoadRentalDataAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                _rentalToEdit = await _apiClient.GetRentalAsync(_rentalId);

                if (_rentalToEdit != null)
                {
                    LoadRentalData();
                    _isFormLoaded = true;
                    CalculateRental();
                }
                else
                {
                    MessageBox.Show("Rental not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load rental: {CleanErrorMessage(ex.Message)}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void LoadRentalData()
        {
            if (_rentalToEdit == null) return;

            // Display rental information
            lblSelectedVehicle.Text = $"{_rentalToEdit.VehiclePlateNumber} ({_rentalToEdit.VehicleMake} {_rentalToEdit.VehicleModel})";
            dtpFrom.Value = _rentalToEdit.StartDate;
            dtpTo.Value = _rentalToEdit.EndDate;
            lblDailyRate.Text = $"ETB {_rentalToEdit.DailyRate:N2}";

            // Use textboxes for editable fields
            textBox1.Text = _rentalToEdit.Discount?.ToString("N2") ?? "0.00";
            textBox2.Text = _rentalToEdit.AmountPaid.ToString("N2");

            // Set transmission if available
            if (!string.IsNullOrEmpty(_rentalToEdit.VehicleType))
            {
                cmbTransmission.SelectedItem = _rentalToEdit.VehicleType;
            }
            else
            {
                cmbTransmission.SelectedIndex = 0;
            }
        }

        private void CalculateRental()
        {
            if (_rentalToEdit == null) return;

            try
            {
                // Calculate rental days
                int rentalDays = (dtpTo.Value - dtpFrom.Value).Days;
                if (rentalDays < 1) rentalDays = 1;

                lblRentalDays.Text = rentalDays.ToString();

                // Calculate subtotal
                decimal dailyRate = _rentalToEdit.DailyRate;
                decimal subTotal = dailyRate * rentalDays;
                lblSubtotal.Text = $"ETB {subTotal:N2}";

                // Calculate discount
                decimal discount = 0;
                if (decimal.TryParse(textBox1.Text, out decimal discountValue))
                {
                    discount = discountValue;
                }

                // Calculate total
                decimal totalAmount = subTotal - discount;
                if (totalAmount < 0) totalAmount = 0;
                lblTotalAmount.Text = $"ETB {totalAmount:N2}";

                // Calculate amount paid and balance
                decimal amountPaid = 0;
                if (decimal.TryParse(textBox2.Text, out decimal paidValue))
                {
                    amountPaid = paidValue;
                }

                decimal balanceDue = totalAmount - amountPaid;
                if (balanceDue < 0) balanceDue = 0;
                lblBalanceDue.Text = $"ETB {balanceDue:N2}";

                // Update label colors based on balance
                UpdateLabelColors(balanceDue);
            }
            catch
            {
                // Ignore calculation errors
            }
        }

        private void UpdateLabelColors(decimal balanceDue)
        {
            if (balanceDue == 0)
            {
                lblBalanceDue.ForeColor = Color.FromArgb(46, 204, 113); // Green
            }
            else if (balanceDue > 0)
            {
                lblBalanceDue.ForeColor = Color.FromArgb(255, 152, 0); // Orange
            }
            else
            {
                lblBalanceDue.ForeColor = Color.FromArgb(255, 98, 70); // Red
            }
        }

        private async void btnSaveRental_Click(object sender, EventArgs e)
        {
            if (!_isFormLoaded)
            {
                MessageBox.Show("Form not ready", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_isSaving) return;

            try
            {
                _isSaving = true;
                btnSaveRental.Enabled = false;
                btnSaveRental.Text = "Saving...";
                Cursor = Cursors.WaitCursor;

                // Validate form
                if (!ValidateForm()) return;

                // Get updated rental data
                var updatedRental = GetUpdatedRentalData();

                // Update rental
                await _apiClient.UpdateRentalAsync(updatedRental);

                // Show success message
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("Rental updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update rental: {CleanErrorMessage(ex.Message)}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isSaving = false;
                btnSaveRental.Enabled = true;
                btnSaveRental.Text = "Save Rental";
                Cursor = Cursors.Default;
            }
        }

        private bool ValidateForm()
        {
            bool isValid = true;
            List<string> errors = new List<string>();

            // Validate dates
            if (dtpFrom.Value >= dtpTo.Value)
            {
                errors.Add("End date must be after start date");
                isValid = false;
            }

            if (dtpFrom.Value < DateTime.Today)
            {
                errors.Add("Start date cannot be in the past");
                isValid = false;
            }

            // Validate discount
            if (decimal.TryParse(textBox1.Text, out decimal discount))
            {
                if (discount < 0)
                {
                    errors.Add("Discount cannot be negative");
                    isValid = false;
                }
            }
            else
            {
                errors.Add("Invalid discount amount");
                isValid = false;
            }

            // Validate amount paid
            if (decimal.TryParse(textBox2.Text, out decimal amountPaid))
            {
                if (amountPaid < 0)
                {
                    errors.Add("Amount paid cannot be negative");
                    isValid = false;
                }
            }
            else
            {
                errors.Add("Invalid amount paid");
                isValid = false;
            }

            if (!isValid)
            {
                var errorText = new StringBuilder("Please fix the following errors:\n\n");
                foreach (var error in errors)
                {
                    errorText.AppendLine($"• {error}");
                }

                MessageBox.Show(errorText.ToString(), "Validation Errors",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return isValid;
        }

        private RentalVM GetUpdatedRentalData()
        {
            if (_rentalToEdit == null) throw new InvalidOperationException("Rental data not loaded");

            // Parse values
            decimal discount = decimal.TryParse(textBox1.Text, out decimal d) ? d : 0;
            decimal amountPaid = decimal.TryParse(textBox2.Text, out decimal a) ? a : 0;

            // Calculate totals
            int rentalDays = (dtpTo.Value - dtpFrom.Value).Days;
            if (rentalDays < 1) rentalDays = 1;

            decimal subTotal = _rentalToEdit.DailyRate * rentalDays;
            decimal totalAmount = subTotal - discount;
            decimal balanceDue = totalAmount - amountPaid;
            bool isPaid = amountPaid >= totalAmount;

            return new RentalVM
            {
                Id = _rentalId,
                CustomerId = _rentalToEdit.CustomerId,
                CustomerName = _rentalToEdit.CustomerName,
                CustomerPhone = _rentalToEdit.CustomerPhone,
                VehicleId = _rentalToEdit.VehicleId,
                VehiclePlateNumber = _rentalToEdit.VehiclePlateNumber,
                VehicleMake = _rentalToEdit.VehicleMake,
                VehicleModel = _rentalToEdit.VehicleModel,
                VehicleColor = _rentalToEdit.VehicleColor,
                VehicleType = cmbTransmission.SelectedItem?.ToString() ?? _rentalToEdit.VehicleType,
                StartDate = dtpFrom.Value,
                EndDate = dtpTo.Value,
                DailyRate = _rentalToEdit.DailyRate,
                RentalDays = rentalDays,
                SubTotal = subTotal,
                Discount = discount,
                TotalAmount = totalAmount,
                AmountPaid = amountPaid,
                BalanceDue = balanceDue,
                IsPaid = isPaid,
                PaymentMethod = _rentalToEdit.PaymentMethod,
                TransactionId = _rentalToEdit.TransactionId,
                PaymentNotes = _rentalToEdit.PaymentNotes,
                Status = _rentalToEdit.Status,
                IsActive = _rentalToEdit.IsActive,
                Notes = _rentalToEdit.Notes,
                CreatedAt = _rentalToEdit.CreatedAt
            };
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            CalculateRental();
        }

        private void btnCancel_Click(object sender, EventArgs e)
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

        private void btnSelectVehicle_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vehicle selection is not allowed when editing a rental.\nVehicle details are locked to maintain rental history.",
                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Event handlers for form controls
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (_isFormLoaded)
                CalculateRental();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (_isFormLoaded)
                CalculateRental();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            if (_isFormLoaded)
                CalculateRental();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            if (_isFormLoaded)
                CalculateRental();
        }

        private void cmbTransmission_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Optional: Update vehicle type if needed
        }

        private string CleanErrorMessage(string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(errorMessage))
                return "Unknown error occurred";

            // Simple error cleanup
            errorMessage = errorMessage.Replace("API Error:", "").Trim();
            errorMessage = errorMessage.Replace("HttpRequestException:", "").Trim();
            errorMessage = errorMessage.Replace("System.Net.Http.HttpRequestException:", "").Trim();

            return errorMessage;
        }

        // Empty label click handlers
        private void lblSelectedVehicle_Click(object sender, EventArgs e) { }
        private void lblDailyRate_Click(object sender, EventArgs e) { }
        private void lblRentalDays_Click(object sender, EventArgs e) { }
        private void lblSubtotal_Click(object sender, EventArgs e) { }
        private void lblDiscount_Click(object sender, EventArgs e) { }
        private void lblTotalAmount_Click(object sender, EventArgs e) { }
        private void lblAmountPaid_Click(object sender, EventArgs e) { }
        private void lblBalanceDue_Click(object sender, EventArgs e) { }
    }
}