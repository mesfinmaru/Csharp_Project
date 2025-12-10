using CRM_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static CRM_API.Models.AuthVMs;
using static System.Net.WebRequestMethods;

namespace Car_Rental_Management_System
{
    public class ApiClient
    {
        private readonly HttpClient _http;

        public ApiClient()
        {
            // Use your API URL here
            _http = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7209/")
            };
        }


        public async Task<AuthVMs.AuthResponseVM?> Login(LoginRequest request)
        {
            var response = await _http.PostAsJsonAsync("api/Auth/Login", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<AuthVMs.AuthResponseVM>();
        }
    }
}
