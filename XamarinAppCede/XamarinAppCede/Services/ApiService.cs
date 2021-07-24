using Acr.UserDialogs;
using XamarinAppCede.Interfaces;
using XamarinAppCede.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamarinAppCede.Services
{
    public class ApiService : IApiService
    {

        public async Task<Response<T>> PostAsync<T>(object model, string service) where T : class
        {
            string json = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var httpClient = new HttpClient();
            var response = await httpClient.PostAsync($"{AppSettings.ApiUrl}/{service}", content);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(jsonResponse);

            return new Response<T>
            {
                IsSuccess = response.IsSuccessStatusCode,
                Result = result
            };
        }
        public async Task<Response<T>> GetAsync<T>(string service) where T : class
        { 
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
                var response = await httpClient.GetAsync($"{AppSettings.ApiUrl}/{service}");
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<T>(jsonResponse);
                return new Response<T>
                {
                    IsSuccess = response.IsSuccessStatusCode,
                    Result = result
                };
         }
    }
}