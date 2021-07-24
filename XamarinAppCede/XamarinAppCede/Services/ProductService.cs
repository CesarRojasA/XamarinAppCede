using XamarinAppCede.Interfaces;
using XamarinAppCede.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace XamarinAppCede.Services
{
    public class ProductService : IProductService
    {
        private readonly IApiService _apiService;
        public ProductService(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<ObservableCollection<Product>> getAllProducts()
        {
            var response = await _apiService.GetAsync<ObservableCollection<Product>>("products");
            return response.Result;
        }

        public async Task<ObservableCollection<Product>> getProductsByCategories(int category)
        {
            var response = await _apiService.GetAsync<ObservableCollection<Product>>($"products?category={category}");
            return response.Result;
        }
    }
}
