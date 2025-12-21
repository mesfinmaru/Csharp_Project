using Car_Rental_Management_System;
using CRM_API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CRM_API.Models.UpdateUserRequest;

namespace Car_Rental_Management_System.Forms
{
    public partial class UsersForm : Form
    {
        private ApiClient? _apiClient;
        private List<UserVM>? _usersList;
        private List<UserVM>? _filteredUsersList;

        public UsersForm()
        {

            InitializeComponent();
            ApplyTheme();
            SetupDataGridView();
            LoadUsers();

            // Initialize tooltip
            toolTip1 = new ToolTip();
            toolTip1.SetToolTip(btnDelete, "Delete selected user");
        }



        public UsersForm(ApiClient apiClient) : this()
        {
            _apiClient = apiClient;
            LoadUsers();
        }

        private void ApplyTheme()
        {
            var bg = Color.FromArgb(26, 27, 39);
            var panelBg = Color.FromArgb(39, 40, 55);
            var primary = Color.FromArgb(124, 77, 255);
            var secondary = Color.FromArgb(83, 109, 254);
            var lightText = Color.FromArgb(230, 230, 235);

            this.BackColor = bg;

            txtSearch.BackColor = panelBg;
            txtSearch.ForeColor = lightText;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;

            btnAdd.BackColor = primary;
            btnAdd.ForeColor = Color.White;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderSize = 0;

            btnEdit.BackColor = secondary;
            btnEdit.ForeColor = Color.White;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.FlatAppearance.BorderSize = 0;

            btnDelete.BackColor = Color.FromArgb(255, 98, 70);
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;

            dgvUsers.BackgroundColor = Color.FromArgb(30, 30, 44);
            dgvUsers.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 44);
            dgvUsers.DefaultCellStyle.ForeColor = lightText;
            dgvUsers.DefaultCellStyle.SelectionBackColor = primary;
            dgvUsers.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = primary;
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.GridColor = Color.FromArgb(55, 55, 70);
            dgvUsers.RowTemplate.Height = 36;
            dgvUsers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(35, 35, 50);
        }

        private void SetupDataGridView()
        {
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.MultiSelect = false;
            dgvUsers.ReadOnly = true;
            dgvUsers.AllowUserToAddRows = false;

            dgvUsers.Columns.Clear();

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colId",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Width = 50,
                Visible = false
            });

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colFullName",
                HeaderText = "Full Name",
                DataPropertyName = "FullName",
                Width = 180,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colUsername",
                HeaderText = "Username",
                DataPropertyName = "Username",
                Width = 120
            });

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colEmail",
                HeaderText = "Email",
                DataPropertyName = "Email",
                Width = 180
            });

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colPhone",
                HeaderText = "Phone",
                DataPropertyName = "Phone",
                Width = 100
            });

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colRole",
                HeaderText = "Role",
                DataPropertyName = "Role",
                Width = 80
            });

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colCreatedAt",
                HeaderText = "Created",
                DataPropertyName = "CreatedAt",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Format = "yyyy-MM-dd"
                }
            });
        }

        private async void LoadUsers()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvUsers.DataSource = null;
                lblStatus.Text = "Loading users...";

                string? token = ConfigurationManager.AppSettings["UserToken"];

                if (string.IsNullOrEmpty(token))
                {
                    lblStatus.Text = "Please login first";
                    ShowInfo("Please login to view users");
                    return;
                }

                using var client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7209/");
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                client.Timeout = TimeSpan.FromSeconds(30);

                var response = await client.GetAsync("api/users");

                if (response.IsSuccessStatusCode)
                {
                    _usersList = await response.Content.ReadFromJsonAsync<List<UserVM>>();

                    if (_usersList != null)
                    {
                        _filteredUsersList = new List<UserVM>(_usersList);
                        dgvUsers.DataSource = _filteredUsersList;
                        UpdateStatusLabel();
                    }
                    else
                    {
                        lblStatus.Text = "No users found";
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    lblStatus.Text = "Session expired";
                    ShowError("Session expired. Please login again.");
                }
                else
                {
                    lblStatus.Text = "Failed to load";
                    ShowError("Failed to load users");
                }
            }
            catch (HttpRequestException)
            {
                lblStatus.Text = "Connection failed";
                ShowError("Cannot connect to server");
            }
            catch (Exception)
            {
                lblStatus.Text = "Error loading";
                ShowError("Failed to load users");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void UpdateStatusLabel()
        {
            if (_usersList == null) return;

            int totalCount = _usersList.Count;
            int filteredCount = _filteredUsersList?.Count ?? 0;

            if (string.IsNullOrEmpty(txtSearch.Text.Trim()))
            {
                lblStatus.Text = $"{totalCount} user(s)";
            }
            else
            {
                lblStatus.Text = $"Showing {filteredCount} of {totalCount} user(s)";
            }
        }

        private void FilterUsers()
        {
            if (_usersList == null) return;

            string searchTerm = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                _filteredUsersList = new List<UserVM>(_usersList);
            }
            else
            {
                _filteredUsersList = _usersList.Where(u =>
                    (u.FullName?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (u.Username?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (u.Email?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (u.Phone?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (u.Role?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false)
                ).ToList();
            }

            dgvUsers.DataSource = _filteredUsersList;
            UpdateStatusLabel();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }


        private void DgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = dgvUsers.SelectedRows.Count > 0;

            if (hasSelection)
            {
                var selectedRow = dgvUsers.SelectedRows[0];
                var userRole = selectedRow.Cells["colRole"].Value?.ToString() ?? "";

                // Disable delete button for Admin
                btnDelete.Enabled = !userRole.Equals("Admin", StringComparison.OrdinalIgnoreCase);
                btnEdit.Enabled = true;

                // Optional: Change delete button text/tooltip for Admin
                if (!btnDelete.Enabled)
                {
                    btnDelete.Text = "Delete (Admin)";
                    btnDelete.BackColor = Color.Gray;
                    toolTip1.SetToolTip(btnDelete, "Admin user cannot be deleted");
                }
                else
                {
                    btnDelete.Text = "Delete";
                    btnDelete.BackColor = Color.FromArgb(255, 98, 70);
                    toolTip1.SetToolTip(btnDelete, "Delete selected user");
                }
            }
            else
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private async void btnAdd_Click_1(object sender, EventArgs e)
        {
            // Check if Admin already exists
            bool adminExists = _usersList?.Any(u =>
                u.Role?.Equals("Admin", StringComparison.OrdinalIgnoreCase) == true) ?? false;

            // Pass adminExists to AddUser constructor
            using AddUser addForm = new AddUser(adminExists);
            var dialogResult = addForm.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                try
                {
                    var userData = addForm.GetUserData();
                    string? token = ConfigurationManager.AppSettings["UserToken"];

                    if (string.IsNullOrEmpty(token))
                    {
                        ShowError("Please login first");
                        return;
                    }

                    // Check if username already exists (including deleted staffs)
                    bool usernameExists = _usersList?.Any(u =>
                        u.Username?.Equals(userData.Username, StringComparison.OrdinalIgnoreCase) == true) ?? false;

                    if (usernameExists)
                    {
                        ShowError($"Username '{userData.Username}' already exists");
                        return;
                    }

                    using var client = new HttpClient();
                    client.BaseAddress = new Uri("https://localhost:7209/");
                    client.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                    string endpoint = userData.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase)
                        ? "api/auth/register-admin"
                        : "api/auth/register-staff";

                    lblStatus.Text = "Adding user...";

                    var registerData = new
                    {
                        FullName = userData.FullName,
                        Username = userData.Username,
                        Email = userData.Email,
                        Phone = userData.Phone,
                        Password = userData.Password,
                        ConfirmPassword = userData.ConfirmPassword,
                        Role = userData.Role
                    };

                    var response = await client.PostAsJsonAsync(endpoint, registerData);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadFromJsonAsync<AuthResponseVM>();
                        if (result?.Success == true)
                        {
                            lblStatus.Text = "User added!";
                            ShowSuccess($"User added successfully!\nUsername: {userData.Username}");
                            LoadUsers();
                        }
                        else
                        {
                            lblStatus.Text = "Failed to add user";
                            ShowError($"Failed: {result?.Message ?? "Username may already exist"}");
                        }
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                    {
                        lblStatus.Text = "Username exists";
                        ShowError("Username already exists in the system");
                    }
                    else
                    {
                        lblStatus.Text = "Failed to add user";
                        ShowError("Failed to add user");
                    }
                }
                catch (Exception)
                {
                    lblStatus.Text = "Add failed";
                    ShowError("Failed to add user");
                }
            }
        }

        private async void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                ShowInfo("Please select a user to edit.");
                return;
            }

            var selectedRow = dgvUsers.SelectedRows[0];
            var idValue = selectedRow.Cells["colId"].Value;

            if (idValue == null)
            {
                ShowError("Invalid selection");
                return;
            }

            int userId = Convert.ToInt32(idValue);
            string token = ConfigurationManager.AppSettings["UserToken"] ?? "";

            if (string.IsNullOrEmpty(token))
            {
                ShowError("Please login first");
                return;
            }

            try
            {
                using var client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7209/");
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var response = await client.GetAsync($"api/users/{userId}");

                if (response.IsSuccessStatusCode)
                {
                    var userToEdit = await response.Content.ReadFromJsonAsync<UserVM>();

                    if (userToEdit != null)
                    {
                        // Check if Admin already exists
                        bool adminExists = _usersList?.Any(u =>
                            u.Role?.Equals("Admin", StringComparison.OrdinalIgnoreCase) == true &&
                            u.Id != userId) ?? false;

                        // Pass adminExists to EditUser constructor
                        using EditUser editForm = new EditUser(userToEdit, adminExists);

                        var dialogResult = editForm.ShowDialog();

                        if (dialogResult == DialogResult.OK)
                        {
                            var updatedData = editForm.GetUpdatedUserData();

                            var updateRequest = new
                            {
                                FullName = updatedData.FullName,
                                Email = updatedData.Email,
                                Phone = updatedData.Phone,
                                Role = updatedData.Role,
                                Password = updatedData.Password
                            };

                            lblStatus.Text = "Updating...";

                            var updateResponse = await client.PutAsJsonAsync($"api/users/{userId}", updateRequest);

                            if (updateResponse.IsSuccessStatusCode)
                            {
                                lblStatus.Text = "User updated!";
                                ShowSuccess("User updated successfully!");
                                LoadUsers();
                            }
                            else if (updateResponse.StatusCode == System.Net.HttpStatusCode.Conflict)
                            {
                                lblStatus.Text = "Update failed";
                                ShowError("Cannot change to Admin: Only one Admin allowed in system");
                            }
                            else
                            {
                                lblStatus.Text = "Update failed";
                                ShowError("Failed to update user");
                            }
                        }
                    }
                }
                else
                {
                    ShowError("Failed to load user data");
                }
            }
            catch (Exception)
            {
                ShowError("Failed to update user");
            }
        }
        private async void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                ShowInfo("Please select a user to delete.");
                return;
            }

            var selectedRow = dgvUsers.SelectedRows[0];
            var idValue = selectedRow.Cells["colId"].Value;
            var userRole = selectedRow.Cells["colRole"].Value?.ToString() ?? "";
            var userName = selectedRow.Cells["colFullName"].Value?.ToString() ?? "User";

            if (idValue == null)
            {
                ShowError("Invalid selection");
                return;
            }

            // Client-side check for admin
            if (userRole.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                ShowError("Admin user cannot be deleted. You can only edit the admin.");
                return;
            }

            int userId = Convert.ToInt32(idValue);
            string token = ConfigurationManager.AppSettings["UserToken"] ?? "";

            if (string.IsNullOrEmpty(token))
            {
                ShowError("Please login first");
                return;
            }

            var result = MessageBox.Show(
                $"Permanently delete user '{userName}'?\n\nThis action cannot be undone!",
                "Confirm Permanent Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                try
                {
                    lblStatus.Text = "Deleting...";

                    using var client = new HttpClient();
                    client.BaseAddress = new Uri("https://localhost:7209/");
                    client.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                    var response = await client.DeleteAsync($"api/users/{userId}");

                    if (response.IsSuccessStatusCode)
                    {
                        lblStatus.Text = "User permanently deleted!";
                        ShowSuccess($"User '{userName}' has been permanently deleted from the database.");
                        LoadUsers();
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        var errorContent = await response.Content.ReadAsStringAsync();
                        lblStatus.Text = "Delete blocked";
                        ShowError("Cannot delete admin user");
                    }
                    else
                    {
                        lblStatus.Text = "Delete failed";
                        ShowError("Failed to delete user");
                    }
                }
                catch (Exception)
                {
                    lblStatus.Text = "Delete failed";
                    ShowError("Failed to delete user");
                }
            }
        }
        private static void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static void ShowInfo(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
            }
        }



        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            FilterUsers();
        }

        private void UsersForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}