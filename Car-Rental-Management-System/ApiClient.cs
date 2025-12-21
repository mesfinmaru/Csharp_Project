using CRM_API.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using static CRM_API.Models.UpdateUserRequest;

namespace Car_Rental_Management_System
{
    public class ApiClient
    {
        public readonly HttpClient _http;
        private string _token;
        private UserVM _currentUser;

        public ApiClient()
        {
            _http = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7209/") // Make sure this matches your API port
            };
        }

        public async Task<AuthResponseVM?> Login(string username, string password)
        {
            try
            {
                var loginRequest = new
                {
                    Username = username,
                    Password = password
                };

                var response = await _http.PostAsJsonAsync("api/auth/login", loginRequest);

                if (response.IsSuccessStatusCode)
                {
                    var authResponse = await response.Content.ReadFromJsonAsync<AuthResponseVM>();

                    if (authResponse?.Success == true)
                    {
                        // Store token and user
                        _token = authResponse.Token;
                        _currentUser = authResponse.User;

                        // Add token to future requests
                        _http.DefaultRequestHeaders.Authorization =
                            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
                    }

                    return authResponse;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    return new AuthResponseVM
                    {
                        Success = false,
                        Message = $"Login failed: {response.StatusCode}"
                    };
                }
            }
            catch (Exception ex)
            {
                return new AuthResponseVM
                {
                    Success = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }

        public async Task<AuthResponseVM?> RegisterAdmin(string fullName, string username, string email, string password)
        {
            var registerData = new
            {
                FullName = fullName,
                Username = username,
                Email = email,
                Password = password,
                ConfirmPassword = password,
                Role = "Admin"
            };

            return await PostRequest("api/auth/register-admin", registerData);
        }

        public async Task<AuthResponseVM?> RegisterStaff(string fullName, string username, string email, string password)
        {
            var registerData = new
            {
                FullName = fullName,
                Username = username,
                Email = email,
                Password = password,
                ConfirmPassword = password,
                Role = "Staff"
            };

            return await PostRequest("api/auth/register-staff", registerData);
        }

        public async Task<bool> CheckAdminExists()
        {
            try
            {
                var response = await _http.GetAsync("api/auth/check-admin-exists");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<bool>();
                    return result;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        // Helper method for POST requests
        private async Task<AuthResponseVM?> PostRequest(string endpoint, object data)
        {
            try
            {
                var response = await _http.PostAsJsonAsync(endpoint, data);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<AuthResponseVM>();
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    return new AuthResponseVM
                    {
                        Success = false,
                        Message = $"Request failed: {response.StatusCode}"
                    };
                }
            }
            catch (Exception ex)
            {
                return new AuthResponseVM
                {
                    Success = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }

        // Properties to access current user info
        public string Token => _token;
        public UserVM CurrentUser => _currentUser;
        public bool IsAuthenticated => !string.IsNullOrEmpty(_token);
        public bool IsAdmin => _currentUser?.Role == "Admin";
        public bool IsStaff => _currentUser?.Role == "Staff";

        // Method to logout
        public void Logout()
        {
            _token = null;
            _currentUser = null;
            _http.DefaultRequestHeaders.Authorization = null;
        }
    }
}