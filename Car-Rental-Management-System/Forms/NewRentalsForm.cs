using Car_Rental_Management_System;
using CRM_API.Models;
using System;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace Car_Rental_Management_System.Forms
{
    public partial class NewRentalsForm : Form
    {
        private readonly ApiClient _apiClient;
        private CustomerVM? _selectedCustomer;
        private VehicleVM? _selectedVehicle;
        private bool _isFormLoaded = false;
        private bool _isSaving = false;

        public NewRentalsForm(ApiClient apiClient)
        {
            try
            {
                InitializeComponent();
                _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));

                ApplyTheme();
                InitializeForm();
                _isFormLoaded = true;
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
            btnSelectCustomer.BackColor = secondary;
            btnSelectCustomer.ForeColor = Color.White;
            btnSelectCustomer.FlatStyle = FlatStyle.Flat;
            btnSelectCustomer.FlatAppearance.BorderSize = 0;

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
            cmbPaymentMethod.BackColor = Color.White;
            cmbPaymentMethod.ForeColor = Color.Black;

            // Style selection labels
            lblSelectedCustomer.ForeColor = Color.FromArgb(124, 77, 255);
            lblSelectedVehicle.ForeColor = Color.FromArgb(124, 77, 255);

            // Style calculation labels
            lblDailyRate.ForeColor = Color.FromArgb(83, 109, 254);
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
            cmbPaymentMethod.Items.Clear();
            cmbPaymentMethod.Items.AddRange(new string[] { "Cash", "Mobile", "Bank" });
            cmbPaymentMethod.SelectedIndex = 0;

            // Initialize labels
            lblSelectedCustomer.Text = "Not selected";
            lblSelectedVehicle.Text = "Not selected";
            lblDailyRate.Text = "ETB 0.00";
            lblRentalDays.Text = "1";
            lblSubtotal.Text = "ETB 0.00";
            txtDiscount.Text = "ETB 0.00";
            lblTotalAmount.Text = "ETB 0.00";
            txtAmountPaid.Text = "ETB 0.00";
            lblBalanceDue.Text = "ETB 0.00";

          

            this.DialogResult = DialogResult.None;
        }

        private void CalculateRental()
        {
            if (_selectedVehicle == null) return;

            try
            {
                // Calculate rental days
                int rentalDays = (dtpTo.Value - dtpFrom.Value).Days;
                if (rentalDays < 1) rentalDays = 1;

                lblRentalDays.Text = rentalDays.ToString();

                // Get daily rate from selected vehicle
                decimal dailyRate = _selectedVehicle.DailyRate;
                lblDailyRate.Text = $"ETB {dailyRate:N2}";

                // Calculate subtotal
                decimal subTotal = dailyRate * rentalDays;
                lblSubtotal.Text = $"ETB {subTotal:N2}";

                // Calculate discount
                decimal discount = 0;
                if (decimal.TryParse(txtDiscount.Text, out decimal discountValue))
                {
                    discount = discountValue;
                    txtDiscount.Text = $"ETB {discount:N2}";
                }

                // Calculate total
                decimal totalAmount = subTotal - discount;
                if (totalAmount < 0) totalAmount = 0;
                lblTotalAmount.Text = $"ETB {totalAmount:N2}";

                // Calculate amount paid and balance
                decimal amountPaid = 0;
                if (decimal.TryParse(txtAmountPaid.Text, out decimal paidValue))
                {
                    amountPaid = paidValue;
                    txtAmountPaid.Text = $"ETB {amountPaid:N2}";
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

        private async void btnSelectCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                using (var customerForm = new SelectCustomer(_apiClient))
                {
                    if (customerForm.ShowDialog() == DialogResult.OK)
                    {
                        _selectedCustomer = customerForm.SelectedCustomer;
                        if (_selectedCustomer != null)
                        {
                            lblSelectedCustomer.Text = $"{_selectedCustomer.FullName} ({_selectedCustomer.Phone})";
                            ValidateFormForSave();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to select customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSelectVehicle_Click(object sender, EventArgs e)
        {
            try
            {
                using (var vehicleForm = new SelectVehicle(_apiClient))
                {
                    if (vehicleForm.ShowDialog() == DialogResult.OK)
                    {
                        _selectedVehicle = vehicleForm.SelectedVehicle;
                        if (_selectedVehicle != null)
                        {
                            lblSelectedVehicle.Text = $"{_selectedVehicle.PlateNumber} ({_selectedVehicle.Make})";
                            
                            CalculateRental();
                            ValidateFormForSave();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to select vehicle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // Validate form
                if (!ValidateForm()) return;

                _isSaving = true;
                btnSaveRental.Enabled = false;
                btnSaveRental.Text = "Saving...";
                Cursor = Cursors.WaitCursor;

                // Get rental data
                var rentalData = GetRentalData();

                // Save rental
                var createdRental = await _apiClient.CreateRentalAsync(rentalData);

                if (createdRental != null)
                {
                    // Show success message
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("Rental created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to create rental: No response from server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to create rental: {CleanErrorMessage(ex.Message)}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            // Validate customer selection
            if (_selectedCustomer == null)
            {
                errors.Add("Please select a customer");
                isValid = false;
            }

            // Validate vehicle selection
            if (_selectedVehicle == null)
            {
                errors.Add("Please select a vehicle");
                isValid = false;
            }

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
            if (decimal.TryParse(txtDiscount.Text, out decimal discount))
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
            if (decimal.TryParse(txtDiscount.Text, out decimal amountPaid))
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

        private void ValidateFormForSave()
        {
            // Enable save button only when both customer and vehicle are selected
            btnSaveRental.Enabled = (_selectedCustomer != null && _selectedVehicle != null);
        }

        private RentalVM GetRentalData()
        {
            // Parse values
            decimal discount = decimal.TryParse(txtDiscount.Text, out decimal d) ? d : 0;
            decimal amountPaid = decimal.TryParse(txtAmountPaid.Text, out decimal a) ? a : 0;

            // Calculate values
            int rentalDays = (dtpTo.Value - dtpFrom.Value).Days;
            if (rentalDays < 1) rentalDays = 1;

            decimal dailyRate = _selectedVehicle.DailyRate;
            decimal subTotal = dailyRate * rentalDays;
            decimal totalAmount = subTotal - discount;
            decimal balanceDue = totalAmount - amountPaid;
            bool isPaid = amountPaid >= totalAmount;

            return new RentalVM
            {
                CustomerId = _selectedCustomer.Id,
                CustomerName = _selectedCustomer.FullName,
                CustomerPhone = _selectedCustomer.Phone,
                VehicleId = _selectedVehicle.Id,
                VehiclePlateNumber = _selectedVehicle.PlateNumber,
                VehicleMake = _selectedVehicle.Make,
                VehicleModel = _selectedVehicle.Model,
                VehicleColor = _selectedVehicle.Color,
                VehicleType = cmbPaymentMethod.SelectedItem?.ToString() ?? _selectedVehicle.VehicleType,
                StartDate = dtpFrom.Value,
                EndDate = dtpTo.Value,
                DailyRate = dailyRate,
                RentalDays = rentalDays,
                SubTotal = subTotal,
                Discount = discount,
                TotalAmount = totalAmount,
                AmountPaid = amountPaid,
                BalanceDue = balanceDue,
                IsPaid = isPaid,
                PaymentMethod = "Cash", // Default payment method
                Status = "Active",
                IsActive = true,
                CreatedAt = DateTime.Now
            };
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            CalculateRental();
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

        // Event handlers for form controls
        private void txtColor_TextChanged(object sender, EventArgs e)
        {
            // Color field changed - update if needed
        }

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
            // Transmission changed - update if needed
        }

        private void NewRentalsForm_Load(object sender, EventArgs e)
        {
            // Form loaded
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
        private void lblSelectedCustomer_Click(object sender, EventArgs e) { }
        private void lblSelectedVehicle_Click(object sender, EventArgs e) { }
        private void lblDailyRate_Click(object sender, EventArgs e) { }
        private void lblRentalDays_Click(object sender, EventArgs e) { }
        private void lblSubtotal_Click(object sender, EventArgs e) { }
        private void txtDiscount_Click(object sender, EventArgs e) { }
        private void lblTotalAmount_Click(object sender, EventArgs e) { }
        private void txtAmountPaid_Click(object sender, EventArgs e) { }
        private void lblBalanceDue_Click(object sender, EventArgs e) { }
    }
}