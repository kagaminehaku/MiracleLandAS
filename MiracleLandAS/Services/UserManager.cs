using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiracleLandAS.Models;
using System.Net.Http.Json;

namespace MiracleLandAS.Services
{
    public class UserManager
    {
        private readonly HttpClient _httpClient;

        public UserManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GetUserList>> GetCustomersAsync()
        {
            var response = await _httpClient.GetAsync("/api/AdminAccounts/GetCustomers");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<GetUserList>>() ?? new List<GetUserList>();
            }

            return new List<GetUserList>();
        }

        public async Task<bool> BanUserAsync(Guid userId)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/AdminAccounts/BanUser", userId);
            return response.IsSuccessStatusCode;
        }
    }
}
