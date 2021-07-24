using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XamarinAppCede.Interfaces
{
    public interface IUserService
    {
        Task<bool> Register(string name, string email, string password);
        Task<bool> Login(string email, string password);
    }
}
