using CRM_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static CRM_API.Models.UpdateUserRequest;
using JsonException = Newtonsoft.Json.JsonException;

namespace Car_Rental_Management_System
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        private string? _token;
        private UserVM? _currentUser;

        public ApiClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7209/")
            };

            // Add default headers for better error handling
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json, text/plain, */*");
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        // Helper method to handle API responses with JSON error handling
        private async Task<T?> HandleResponse<T>(HttpResponseMessage response)
        {
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                if (string.IsNullOrWhiteSpace(responseContent))
                {
                    return default;
                }

                try
                {
                    // Try to deserialize as JSON
                    return JsonConvert.DeserializeObject<T>(responseContent);
                }
                catch (JsonException)
                {
                    // If not JSON, try to handle based on type
                    if (typeof(T) == typeof(string))
                    {
                        return (T)(object)responseContent;
                    }
                    throw new HttpRequestException($"Server returned non-JSON response: {responseContent}");
                }
            }
            else
            {
                string errorMessage = ExtractErrorMessage(responseContent);
                throw new HttpRequestException($"{(int)response.StatusCode}: {errorMessage}");
            }
        }

        // Extract meaningful error message from various response formats
        private string ExtractErrorMessage(string responseContent)
        {
            if (string.IsNullOrWhiteSpace(responseContent))
            {
                return "No response from server";
            }

            // Clean HTML tags
            responseContent = CleanHtmlTags(responseContent);

            // Try to parse as JSON error object
            try
            {
                if (responseContent.Trim().StartsWith("{") || responseContent.Trim().StartsWith("["))
                {
                    var errorObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseContent);

                    if (errorObj != null)
                    {
                        if (errorObj.ContainsKey("message"))
                            return errorObj["message"].ToString();
                        if (errorObj.ContainsKey("error"))
                            return errorObj["error"].ToString();
                        if (errorObj.ContainsKey("Message"))
                            return errorObj["Message"].ToString();
                        if (errorObj.ContainsKey("Error"))
                            return errorObj["Error"].ToString();
                    }
                }
            }
            catch
            {
                // If JSON parsing fails, continue with other methods
            }

            // Try to extract from HTML title
            if (responseContent.Contains("<title>"))
            {
                int titleStart = responseContent.IndexOf("<title>") + 7;
                int titleEnd = responseContent.IndexOf("</title>", titleStart);
                if (titleEnd > titleStart)
                {
                    return responseContent.Substring(titleStart, titleEnd - titleStart).Trim();
                }
            }

            // Clean common error patterns
            string cleaned = responseContent;
            cleaned = cleaned.Replace("BadRequest", "")
                            .Replace("400", "")
                            .Replace("\"", "")
                            .Replace("The input does not contain any JSON tokens", "Server returned an invalid response")
                            .Replace("Expected the input to start with a valid JSON token", "")
                            .Replace("when isFinalBlock is true", "")
                            .Replace("Path: $ | LineNumber: 0 | BytePositionInLine: 0", "")
                            .Trim();

            // Remove multiple spaces and clean up
            while (cleaned.Contains("  "))
                cleaned = cleaned.Replace("  ", " ");

            if (cleaned.Length > 500)
                cleaned = cleaned.Substring(0, 500) + "...";

            return cleaned;
        }

        // Clean HTML tags from response
        private string CleanHtmlTags(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            string result = input;

            // Remove common HTML tags
            result = System.Text.RegularExpressions.Regex.Replace(result, "<[^>]*>", " ");

            // Replace HTML entities
            result = HttpUtility.HtmlDecode(result);

            // Clean up whitespace
            result = System.Text.RegularExpressions.Regex.Replace(result, @"\s+", " ");

            return result.Trim();
        }

        // Customer methods
        public async Task<List<CustomerVM>> GetCustomersAsync(string? search = null)
        {
            try
            {
                string url = "api/customers";
                if (!string.IsNullOrWhiteSpace(search))
                {
                    url += $"?search={Uri.EscapeDataString(search)}";
                }

                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"API Error: {response.StatusCode} - {errorContent}");
                }

                var content = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(content))
                {
                    return new List<CustomerVM>();
                }

                var customers = JsonConvert.DeserializeObject<List<CustomerVM>>(content);
                return customers ?? new List<CustomerVM>();
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"Failed to load customers: {ex.Message}");
            }
        }

        public async Task<CustomerVM> GetCustomerAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/customers/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"API Error: {response.StatusCode} - {errorContent}");
                }

                var content = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(content))
                {
                    throw new HttpRequestException($"Customer with ID {id} not found");
                }

                var customer = JsonConvert.DeserializeObject<CustomerVM>(content);
                return customer ?? throw new HttpRequestException($"Customer with ID {id} not found");
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"Failed to load customer: {ex.Message}");
            }
        }

        public async Task<CustomerVM> CreateCustomerAsync(CustomerVM customer)
        {
            try
            {
                var json = JsonConvert.SerializeObject(customer);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("api/customers", content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"API Error: {response.StatusCode} - {errorContent}");
                }

                var responseContent = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(responseContent))
                {
                    throw new HttpRequestException("Empty response from server");
                }

                return JsonConvert.DeserializeObject<CustomerVM>(responseContent);
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"Failed to create customer: {ex.Message}");
            }
        }

        public async Task UpdateCustomerAsync(CustomerVM customer)
        {
            try
            {
                var json = JsonConvert.SerializeObject(customer);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"api/customers/{customer.Id}", content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"API Error: {response.StatusCode} - {errorContent}");
                }
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"Failed to update customer: {ex.Message}");
            }
        }

        public async Task DeleteCustomerAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/customers/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"API Error: {response.StatusCode} - {errorContent}");
                }
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"Failed to delete customer: {ex.Message}");
            }
        }

        public async Task UpdateCustomerStatusAsync(int id, bool isActive)
        {
            try
            {
                // Ensure we have authentication token
                if (!string.IsNullOrEmpty(_token))
                {
                    _httpClient.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
                }

                var patchData = new { isActive };
                var json = JsonConvert.SerializeObject(patchData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Create PATCH request properly
                var request = new HttpRequestMessage(new HttpMethod("PATCH"), $"api/customers/{id}/status")
                {
                    Content = content
                };

                // Add necessary headers
                request.Headers.Accept.Clear();
                request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var response = await _httpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    // Try alternative endpoints if the first one fails

                    // Try PUT endpoint
                    var putResponse = await _httpClient.PutAsync($"api/customers/{id}/toggle-status?isActive={isActive}", null);

                    if (!putResponse.IsSuccessStatusCode)
                    {
                        // Try another PUT format
                        var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
                        putResponse = await _httpClient.PutAsync($"api/customers/{id}/toggle-status", jsonContent);

                        if (!putResponse.IsSuccessStatusCode)
                        {
                            // Try updating the whole customer object
                            var customer = await GetCustomerAsync(id);
                            if (customer != null)
                            {
                                customer.IsActive = isActive;
                                await UpdateCustomerAsync(customer);
                                return;
                            }

                            var errorContent = await response.Content.ReadAsStringAsync();
                            string errorMessage = ExtractErrorMessage(errorContent);

                            // Provide more specific error messages
                            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                                throw new HttpRequestException($"Customer with ID {id} not found");
                            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                                throw new HttpRequestException("Authentication required. Please login again.");
                            else
                                throw new HttpRequestException($"Failed to update status: {errorMessage}");
                        }
                    }
                }
            }
            catch (HttpRequestException)
            {
                throw; // Re-throw HTTP exceptions
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"Failed to update customer status: {ex.Message}");
            }
        }

        // Auth methods
        public async Task<AuthResponseVM?> Login(string username, string password)
        {
            try
            {
                var loginRequest = new
                {
                    Username = username,
                    Password = password
                };

                using var response = await _httpClient.PostAsJsonAsync("api/auth/login", loginRequest);

                if (response.IsSuccessStatusCode)
                {
                    var authResponse = await response.Content.ReadFromJsonAsync<AuthResponseVM>();

                    if (authResponse?.Success == true && !string.IsNullOrEmpty(authResponse.Token))
                    {
                        _token = authResponse.Token;
                        _currentUser = authResponse.User;

                        _httpClient.DefaultRequestHeaders.Authorization =
                            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
                    }

                    return authResponse;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    string errorMessage = ExtractErrorMessage(errorContent);

                    return new AuthResponseVM
                    {
                        Success = false,
                        Message = $"Login failed: {errorMessage}"
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
                using var response = await _httpClient.GetAsync("api/auth/check-admin-exists");
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
                using var response = await _httpClient.PostAsJsonAsync(endpoint, data);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<AuthResponseVM>();
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    string errorMessage = ExtractErrorMessage(errorContent);

                    return new AuthResponseVM
                    {
                        Success = false,
                        Message = $"Request failed: {errorMessage}"
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

        // Properties
        public string? Token => _token;
        public UserVM? CurrentUser => _currentUser;
        public bool IsAuthenticated => !string.IsNullOrEmpty(_token);
        public bool IsAdmin => _currentUser?.Role == "Admin";
        public bool IsStaff => _currentUser?.Role == "Staff";

        public void Logout()
        {
            _token = null;
            _currentUser = null;
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        // Dispose method for cleanup
        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}