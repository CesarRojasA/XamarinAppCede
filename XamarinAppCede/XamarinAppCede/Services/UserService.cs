using XamarinAppCede.Interfaces;
using XamarinAppCede.Models;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace XamarinAppCede.Services
{
    public class UserService : IUserService
    {
        private readonly IApiService _apiService;
        
        public UserService(IApiService apiService)
        {
            _apiService = apiService;

        }
        public async Task<bool> Login(string email, string password)
        {
            var login = new
            {
                email = email,
                password = password
            };
            var result = await _apiService.PostAsync<Session>(login, "users/login");

            if (!result.IsSuccess)
            {
                return false;
            }
            
            Preferences.Set("accessToken", result.Result.Token);
            return result.IsSuccess;
        }

        public async Task<bool> Register(string name, string email, string password)
        {
            var register = new
            {
                name = name,
                email = email,
                password = password
            };
            var result = await _apiService.PostAsync<string>(register, "users/signup");
            return result.IsSuccess;
        }
    }
}
