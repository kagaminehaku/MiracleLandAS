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

        public async Task UpdateProductAsync(PostPutProductNoImage product)
        {
            // Create a MultipartFormDataContent object to hold the form data
            var formContent = new MultipartFormDataContent
    {
        { new StringContent(product.Pid.ToString()), "Pid" },
        { new StringContent(product.Pname), "Pname" },
        { new StringContent(product.Pprice.ToString()), "Pprice" },
        { new StringContent(product.Pquantity.ToString()), "Pquantity" },
        { new StringContent(product.Pinfo), "Pinfo" },
    };

            // Send the form content to the API using PUT
            var response = await _httpClient.PutAsync("/api/Products/UpdateProduct", formContent);

            // Ensure the response is successful
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error updating product: {response.StatusCode}, {error}");
            }
        }




        public async Task DeleteProductAsync(Guid productId)
        {
            await _httpClient.DeleteAsync($"/api/AdminProducts/{productId}");
        }
    }
}
