using MovieApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Contracts.Service
{
    public interface IAdminService
    {

        Task<int> InsertAdmin(AdminModel AdminModel);
        Task<IEnumerable<AdminModel>> GetAllAdmins();
        Task<int> DeleteAdminAsync(int id);
        Task<int> UpdateAdminAsync(AdminModel model);
        Task<AdminModel> GetAdminByIdAsync(int id);

    }
}
