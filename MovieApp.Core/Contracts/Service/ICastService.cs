using MovieApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Contracts.Service
{
    public interface ICastService
    {

        Task<int> InsertCast(CastModel CastModel);
        Task<IEnumerable<CastModel>> GetAllCasts();
        Task<int> DeleteCastAsync(int id);
        Task<int> UpdateCastAsync(CastModel model);
        Task<CastModel> GetCastByIdAsync(int id);

    }
}
