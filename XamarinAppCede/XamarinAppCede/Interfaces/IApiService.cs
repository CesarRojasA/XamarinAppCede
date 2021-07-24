using XamarinAppCede.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XamarinAppCede.Interfaces
{
    public interface IApiService
    {
        Task<Response<T>> PostAsync<T>(object model, string service) where T : class;
        Task<Response<T>> GetAsync<T>(string service) where T : class;
    }
}
