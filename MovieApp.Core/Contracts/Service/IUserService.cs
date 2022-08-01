using MovieApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Contracts.Service
{
    public interface IUserService
    {

        Task<int> InsertUser(UserModel UserModel);
        Task<IEnumerable<UserModel>> GetAllUsers();
        Task<int> DeleteUserAsync(int id);
        Task<int> UpdateUserAsync(UserModel model);
        Task<UserModel> GetUserByIdAsync(int id);

    }
}
