using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;
namespace ApplicationCore.Contracts.Services
{
    public interface IGenreService
    {
       Task< IEnumerable<GenreModel>> GetAllGenresAsync();
        Task<int> InsertGenreAsync(GenreModel model);
        Task<int> DeleteGenreAsync(int id);
        Task<int> UpdateGenreAsync(GenreModel model);
    }
}
