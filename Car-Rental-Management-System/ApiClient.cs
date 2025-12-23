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

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json, text/plain, */*");
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        // ==============================================
        // VEHICLE METHODS
        // ==============================================

        public async Task<List<VehicleVM>> GetVehiclesAsync(string? search = null)
        {
            try
            {
                string url = "api/vehicles";
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
                    return new List<VehicleVM>();
                }

                var vehicles = JsonConvert.DeserializeObject<List<VehicleVM>>(content);
                return vehicles ?? new List<VehicleVM>();
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"Failed to load vehicles: {ex.Message}");
            }
        }

        public async Task<VehicleVM> GetVehicleAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/vehicles/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"API Error: {response.StatusCode} - {errorContent}");
                }

                var content = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(content))
                {
                    throw new HttpRequestException($"Vehicle with ID {id} not found");
                }

                var vehicle = JsonConvert.DeserializeObject<VehicleVM>(content);
                return vehicle ?? throw new HttpRequestException($"Vehicle with ID {id} not found");
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"Failed to load vehicle: {ex.Message}");
            }
        }

        public async Task<VehicleVM> CreateVehicleAsync(VehicleVM vehicle)
        {
            try
            {
                Console.WriteLine($"=== Creating Vehicle ===");
                Console.WriteLine($"Sending: Plate: {vehicle.PlateNumber}, Make: {vehicle.Make}, Status: {vehicle.Status}");
                Console.WriteLine($"Full JSON: {JsonConvert.SerializeObject(vehicle, Formatting.Indented)}");

                var json = JsonConvert.SerializeObject(vehicle);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("api/vehicles", content);

                Console.WriteLine($"Response Status: {response.StatusCode}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error Response: {errorContent}");
                    throw new HttpRequestException($"API Error: {response.StatusCode} - {errorContent}");
                }

                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Success Response: {responseContent}");

                if (string.IsNullOrWhiteSpace(responseContent))
                {
                    throw new HttpRequestException("Empty response from server");
                }

                var createdVehicle = JsonConvert.DeserializeObject<VehicleVM>(responseContent);
                Console.WriteLine($"Created Vehicle ID: {createdVehicle?.Id}");

                return createdVehicle;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in CreateVehicleAsync: {ex}");
                throw new HttpRequestException($"Failed to create vehicle: {ex.Message}");
            }
        }

        public async Task UpdateVehicleAsync(VehicleVM vehicle)
        {
            try
            {
                var json = JsonConvert.SerializeObject(vehicle);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"api/vehicles/{vehicle.Id}", content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"API Error: {response.StatusCode} - {errorContent}");
                }
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"Failed to update vehicle: {ex.Message}");
            }
        }

        public async Task DeleteVehicleAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/vehicles/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"API Error: {response.StatusCode} - {errorContent}");
                }
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"Failed to delete vehicle: {ex.Message}");
            }
        }

        public async Task UpdateVehicleStatusAsync(int id, bool isActive)
        {
            try
            {
                if (!string.IsNullOrEmpty(_token))
                {
                    _httpClient.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
                }

                var patchData = new { isActive };
                var json = JsonConvert.SerializeObject(patchData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(new HttpMethod("PATCH"), $"api/vehicles/{id}/status")
                {
                    Content = content
                };

                request.Headers.Accept.Clear();
                request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var response = await _httpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    // Try alternative endpoints
                    var putResponse = await _httpClient.PutAsync($"api/vehicles/{id}/toggle-status?isActive={isActive}", null);

                    if (!putResponse.IsSuccessStatusCode)
                    {
                        var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
                        putResponse = await _httpClient.PutAsync($"api/vehicles/{id}/toggle-status", jsonContent);

                        if (!putResponse.IsSuccessStatusCode)
                        {
                            // Try updating the whole vehicle object
                            var vehicle = await GetVehicleAsync(id);
                            if (vehicle != null)
                            {
                                vehicle.IsActive = isActive;
                                await UpdateVehicleAsync(vehicle);
                                return;
                            }

                            var errorContent = await response.Content.ReadAsStringAsync();
                            string errorMessage = ExtractErrorMessage(errorContent);

                            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                                throw new HttpRequestException($"Vehicle with ID {id} not found");
                            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                                throw new HttpRequestException("Authentication required. Please login again.");
                            else
                                throw new HttpRequestException($"Failed to update vehicle status: {errorMessage}");
                        }
                    }
                }
            }
            catch (HttpRequestException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"Failed to update vehicle status: {ex.Message}");
            }
        }

        public async Task UpdateVehicleAvailabilityAsync(int id, bool isAvailable)
        {
            try
            {
                if (!string.IsNullOrEmpty(_token))
                {
                    _httpClient.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
                }

                var patchData = new { isAvailable };
                var json = JsonConvert.SerializeObject(patchData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(new HttpMethod("PATCH"), $"api/vehicles/{id}/availability")
                {
                    Content = content
                };

                request.Headers.Accept.Clear();
                request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var response = await _httpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    // Try alternative endpoint
                    var putResponse = await _httpClient.PutAsync($"api/vehicles/{id}/toggle-availability?isAvailable={isAvailable}", null);

                    if (!putResponse.IsSuccessStatusCode)
                    {
                        var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
                        putResponse = await _httpClient.PutAsync($"api/vehicles/{id}/toggle-availability", jsonContent);

                        if (!putResponse.IsSuccessStatusCode)
                        {
                            var vehicle = await GetVehicleAsync(id);
                            if (vehicle != null)
                            {
                                vehicle.IsAvailable = isAvailable;
                                await UpdateVehicleAsync(vehicle);
                                return;
                            }

                            var errorContent = await response.Content.ReadAsStringAsync();
                            string errorMessage = ExtractErrorMessage(errorContent);

                            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                                throw new HttpRequestException($"Vehicle with ID {id} not found");
                            else
                                throw new HttpRequestException($"Failed to update vehicle availability: {errorMessage}");
                        }
                    }
                }
            }
            catch (HttpRequestException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"Failed to update vehicle availability: {ex.Message}");
            }
        }

        // ==============================================
        // EXISTING CUSTOMER METHODS
        // ==============================================

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
                if (!string.IsNullOrEmpty(_token))
                {
                    _httpClient.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
                }

                var patchData = new { isActive };
                var json = JsonConvert.SerializeObject(patchData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(new HttpMethod("PATCH"), $"api/customers/{id}/status")
                {
                    Content = content
                };

                request.Headers.Accept.Clear();
                request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var response = await _httpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    // Try alternative endpoints
                    var putResponse = await _httpClient.PutAsync($"api/customers/{id}/toggle-status?isActive={isActive}", null);

                    if (!putResponse.IsSuccessStatusCode)
                    {
                        var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
                        putResponse = await _httpClient.PutAsync($"api/customers/{id}/toggle-status", jsonContent);

                        if (!putResponse.IsSuccessStatusCode)
                        {
                            var customer = await GetCustomerAsync(id);
                            if (customer != null)
                            {
                                customer.IsActive = isActive;
                                await UpdateCustomerAsync(customer);
                                return;
                            }

                            var errorContent = await response.Content.ReadAsStringAsync();
                            string errorMessage = ExtractErrorMessage(errorContent);

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
                throw;
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"Failed to update customer status: {ex.Message}");
            }
        }

        // ==============================================
        // AUTH METHODS
        // ==============================================

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

        // ==============================================
        // HELPER METHODS
        // ==============================================

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
                    return JsonConvert.DeserializeObject<T>(responseContent);
                }
                catch (JsonException)
                {
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

        private string ExtractErrorMessage(string responseContent)
        {
            if (string.IsNullOrWhiteSpace(responseContent))
                return "No response from server";

            responseContent = CleanHtmlTags(responseContent);

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
            catch { }

            if (responseContent.Contains("<title>"))
            {
                int titleStart = responseContent.IndexOf("<title>") + 7;
                int titleEnd = responseContent.IndexOf("</title>", titleStart);
                if (titleEnd > titleStart)
                {
                    return responseContent.Substring(titleStart, titleEnd - titleStart).Trim();
                }
            }

            string cleaned = responseContent;
            cleaned = cleaned.Replace("BadRequest", "")
                            .Replace("400", "")
                            .Replace("\"", "")
                            .Replace("The input does not contain any JSON tokens", "Server returned an invalid response")
                            .Replace("Expected the input to start with a valid JSON token", "")
                            .Replace("when isFinalBlock is true", "")
                            .Replace("Path: $ | LineNumber: 0 | BytePositionInLine: 0", "")
                            .Trim();

            while (cleaned.Contains("  "))
                cleaned = cleaned.Replace("  ", " ");

            if (cleaned.Length > 500)
                cleaned = cleaned.Substring(0, 500) + "...";

            return cleaned;
        }

        private string CleanHtmlTags(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            string result = input;
            result = System.Text.RegularExpressions.Regex.Replace(result, "<[^>]*>", " ");
            result = HttpUtility.HtmlDecode(result);
            result = System.Text.RegularExpressions.Regex.Replace(result, @"\s+", " ");
            return result.Trim();
        }

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

        // ==============================================
        // PROPERTIES
        // ==============================================

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

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}