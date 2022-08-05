using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;
namespace ApplicationCore.Contracts.Services
{
    public interface ICastService
    {
        Task<CastResponseModel> GetAllCastAsync(int id);
        Task<IEnumerable<CastResponseModel>> GetAllCastAsyncAll();
        Task<int> InsertCastAsync(CastResponseModel model);
        Task<int> DeleteCastAsync(int id);
        Task<int> UpdateCastAsync(CastResponseModel model);
    }
}
