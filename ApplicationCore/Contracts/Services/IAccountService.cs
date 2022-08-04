using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public interface IAccountService
    {
        Task<int> Register(UserRegisterRequestModel user);
        Task<UserLoginResponseModel> Validate(string email, string password);
    }
}
