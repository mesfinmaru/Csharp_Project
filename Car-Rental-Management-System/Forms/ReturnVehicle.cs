using Car_Rental_Management_System;
using CRM_API.Controllers;
using CRM_API.Models;
using System;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace Car_Rental_Management_System.Forms
{
    public partial class ReturnVehicle : Form
    {
        private readonly ApiClient _apiClient;
        private readonly int _rentalId;
        private RentalVM? _rentalToReturn;
        private bool _isFormLoaded = false;
        private bool _isSaving = false;


        public ReturnVehicle(ApiClient apiClient, int rentalId)
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
           
            var lightText = Color.FromArgb(230, 230, 235);
            var primary = Color.FromArgb(124, 77, 255);
            var secondary = Color.FromArgb(83, 109, 254);
            var accent = Color.FromArgb(46, 204, 113);
            var bg = Color.FromArgb(0, 90, 158);
            this.BackColor = bg;

            // Apply theme to all labels
            foreach (Control control in this.Controls)
            {
                if (control is Label label)
                {
                    label.ForeColor = lightText;
                }
                else if (control is GroupBox groupBox)
                {
                    groupBox.ForeColor = lightText;
                    foreach (Control innerControl in groupBox.Controls)
                    {
                        if (innerControl is Label innerLabel)
                        {
                            innerLabel.ForeColor = lightText;
                        }
                        else if (innerControl is CheckBox checkBox)
                        {
                            checkBox.ForeColor = lightText;
                        }
                    }
                }
            }

            // Style buttons
            btnCalculate.BackColor = secondary;
            btnCalculate.ForeColor = Color.White;
            btnCalculate.FlatStyle = FlatStyle.Flat;
            btnCalculate.FlatAppearance.BorderSize = 0;

            btnCompleteReturn.BackColor = accent;
            btnCompleteReturn.ForeColor = Color.White;
            btnCompleteReturn.FlatStyle = FlatStyle.Flat;
            btnCompleteReturn.FlatAppearance.BorderSize = 0;

            btnCancel.BackColor = Color.FromArgb(255, 98, 70);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;

            // Style DateTimePicker
            dtpActualReturnDate.BackColor = Color.White;
            dtpActualReturnDate.ForeColor = Color.Black;
        }

        private void InitializeForm()
        {
            // Set default return date to today
            dtpActualReturnDate.Value = DateTime.Today;

            // Initialize values for calculation labels
            lblCustomer.Text = "";
            lblVehicle.Text = "";
            lblRentalPeriod.Text = "";
            lblOriginalRate.Text = "";
            lblTotalAmount.Text = "";
            lblTotalLateDays.Text = "0 days";
            lblNewTotal.Text = "ETB 0.00";
            lblBalanceDue.Text = "ETB 0.00";

            this.DialogResult = DialogResult.None;
        }

        private async Task LoadRentalDataAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                _rentalToReturn = await _apiClient.GetRentalAsync(_rentalId);

                if (_rentalToReturn != null)
                {
                    LoadRentalData();
                    _isFormLoaded = true;
                    CalculateCharges();
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
            if (_rentalToReturn == null) return;

            // Display rental information in labels
            lblCustomer.Text = $"{_rentalToReturn.CustomerName}";
            lblVehicle.Text = $"{_rentalToReturn.VehiclePlateNumber}";
            lblRentalPeriod.Text = $"{_rentalToReturn.StartDate:dd/MM/yyyy} to {_rentalToReturn.EndDate:dd/MM/yyyy}";
            lblOriginalRate.Text = $"ETB {_rentalToReturn.DailyRate:N2}/day";
            lblTotalAmount.Text = $"ETB {_rentalToReturn.TotalAmount:N2}";
        }

        private void CalculateCharges()
        {
            if (_rentalToReturn == null) return;

            try
            {
                // Calculate late days
                DateTime actualReturnDate = dtpActualReturnDate.Value;
                int lateDays = 0;

                if (actualReturnDate > _rentalToReturn.EndDate)
                {
                    lateDays = (actualReturnDate - _rentalToReturn.EndDate).Days;
                }

                lblTotalLateDays.Text = $"{lateDays} days";

                // Calculate new total (simple calculation)
                decimal lateFee = lateDays * 100; // Assume 100 ETB per day late fee
                decimal damageFee = GetDamageFeeFromCheckboxes();
                decimal additionalCharges = lateFee + damageFee;

                decimal newTotal = _rentalToReturn.TotalAmount + additionalCharges;
                lblNewTotal.Text = $"ETB {newTotal:N2}";

                // Calculate balance due
                decimal balanceDue = newTotal - _rentalToReturn.AmountPaid;
                if (balanceDue < 0) balanceDue = 0;
                lblBalanceDue.Text = $"ETB {balanceDue:N2}";

                // Update label colors based on values
                UpdateLabelColors();
            }
            catch
            {
                // Ignore calculation errors
            }
        }

        private decimal GetDamageFeeFromCheckboxes()
        {
            decimal damageFee = 0;

            if (chbMinorScratches.Checked) damageFee += 500;
            if (chbDented.Checked) damageFee += 2000;
            if (chbMajorDamage.Checked) damageFee += 5000;
            if (chbMechanicalIssue.Checked) damageFee += 3000;
            if (chbOtherIssues.Checked) damageFee += 1000;

            return damageFee;
        }

        private void UpdateLabelColors()
        {
            // Color code the late days label
            if (lblTotalLateDays.Text != "0 days")
            {
                lblTotalLateDays.ForeColor = Color.FromArgb(255, 152, 0); // Orange
            }
            else
            {
                lblTotalLateDays.ForeColor = Color.FromArgb(46, 204, 113); // Green
            }

            // Color code the balance due label
            if (lblBalanceDue.Text != "ETB 0.00")
            {
                lblBalanceDue.ForeColor = Color.FromArgb(255, 98, 70); // Red
            }
            else
            {
                lblBalanceDue.ForeColor = Color.FromArgb(46, 204, 113); // Green
            }
        }

        private void dtpActualReturnDate_ValueChanged(object sender, EventArgs e)
        {
            if (_isFormLoaded)
                CalculateCharges();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            CalculateCharges();
        }

        private async void btnCompleteReturn_Click(object sender, EventArgs e)
        {
   
            if (!_isFormLoaded)
            {
                MessageBox.Show("Form not ready", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_isSaving) return;

            // Confirm with user
            var confirmResult = MessageBox.Show(
                "Are you sure you want to return this vehicle?",
                "Confirm Return",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (confirmResult != DialogResult.Yes)
                return;

            try
            {
                _isSaving = true;
                btnCompleteReturn.Enabled = false;
                Cursor = Cursors.WaitCursor;

                // Calculate fees
                DateTime actualReturnDate = dtpActualReturnDate.Value;
                int lateDays = 0;
                if (actualReturnDate > _rentalToReturn.EndDate)
                {
                    lateDays = (actualReturnDate - _rentalToReturn.EndDate).Days;
                }
                decimal lateFee = lateDays * 100;
                decimal damageFee = GetDamageFeeFromCheckboxes();

                // Call the API method that EXISTS
                // This method takes 4 parameters: rentalId, returnDate, lateFee, damageFee
                await _apiClient.ReturnVehicleAsync(_rentalId, actualReturnDate, lateFee, damageFee);

                // Success
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("Vehicle returned successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {CleanErrorMessage(ex.Message)}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isSaving = false;
                btnCompleteReturn.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private string GetConditionNotes()
        {
            StringBuilder notes = new StringBuilder();
            notes.AppendLine("Vehicle Condition Report:");
            notes.AppendLine($"Return Date: {dtpActualReturnDate.Value:dd/MM/yyyy}");

            if (chbClean.Checked) notes.AppendLine("- Vehicle is clean");
            if (chbMinorScratches.Checked) notes.AppendLine("- Minor scratches present");
            if (chbDented.Checked) notes.AppendLine("- Dents present");
            if (chbMajorDamage.Checked) notes.AppendLine("- Major damage present");
            if (chbMechanicalIssue.Checked) notes.AppendLine("- Mechanical issues noted");
            if (chbOtherIssues.Checked) notes.AppendLine("- Other issues noted");

            // Check if any damage was noted
            bool anyDamage = chbMinorScratches.Checked || chbDented.Checked ||
                            chbMajorDamage.Checked || chbMechanicalIssue.Checked ||
                            chbOtherIssues.Checked;

            if (!anyDamage && chbClean.Checked)
            {
                notes.AppendLine("- Vehicle returned in excellent condition");
            }

            return notes.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Cancel vehicle return?",
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

        // Checkbox event handlers
        private void chbClean_CheckedChanged(object sender, EventArgs e)
        {
            if (_isFormLoaded)
                CalculateCharges();
        }

        private void chbMinorScratches_CheckedChanged(object sender, EventArgs e)
        {
            if (_isFormLoaded)
                CalculateCharges();
        }

        private void chbDented_CheckedChanged(object sender, EventArgs e)
        {
            if (_isFormLoaded)
                CalculateCharges();
        }

        private void chbMajorDamage_CheckedChanged(object sender, EventArgs e)
        {
            if (_isFormLoaded)
                CalculateCharges();
        }

        private void chbMechanicalIssue_CheckedChanged(object sender, EventArgs e)
        {
            if (_isFormLoaded)
                CalculateCharges();
        }

        private void chbOtherIssues_CheckedChanged(object sender, EventArgs e)
        {
            if (_isFormLoaded)
                CalculateCharges();
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

        // Other label click handlers (empty implementations as requested)
        private void lblCustomer_Click(object sender, EventArgs e) { }
        private void lblVehicle_Click(object sender, EventArgs e) { }
        private void lblRentalPeriod_Click(object sender, EventArgs e) { }
        private void lblOriginalRate_Click(object sender, EventArgs e) { }
        private void lblTotalAmount_Click(object sender, EventArgs e) { }
        private void lblLateFee_Click(object sender, EventArgs e) { }
        private void lblTotalLateDays_Click(object sender, EventArgs e) { }
        private void lblDamageFee_Click(object sender, EventArgs e) { }
        private void lblFuelCharge_Click(object sender, EventArgs e) { }
        private void lblOtherCharge_Click(object sender, EventArgs e) { }
        private void lblNewTotal_Click(object sender, EventArgs e) { }
        private void lblBalanceDue_Click(object sender, EventArgs e) { }
        private void lblPaymentRecieved_Click(object sender, EventArgs e) { }

        private void groupBox1_Enter(object sender, EventArgs e) { }
    }
}