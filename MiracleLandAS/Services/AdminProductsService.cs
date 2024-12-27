using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using MiracleLandAS.Models;

namespace MiracleLandAS.Services
{
    public class AdminProductsService
    {
        private readonly HttpClient _httpClient;

        public AdminProductsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Product>>("/api/AdminProducts");
        }

        public async Task AddProductAsync(PostPutProduct product)
        {
            await _httpClient.PostAsJsonAsync("/api/AdminProducts", product);
        }

        public async Task UpdateProductAsync(PostPutProduct product)
        {
            await _httpClient.PutAsJsonAsync($"/api/AdminProducts/{product.Pid}", product);
        }

        public async Task DeleteProductAsync(Guid productId)
        {
            await _httpClient.DeleteAsync($"/api/AdminProducts/{productId}");
        }
    }
}
