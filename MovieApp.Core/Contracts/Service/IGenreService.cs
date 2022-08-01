using MovieApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Contracts.Service
{
    public interface IGenreService
    {
        Task<int> InsertGenre(GenreModel GenreModel);
        Task<IEnumerable<GenreModel>> GetAllGenres();
        Task<int> DeleteGenreAsync(int id);
        Task<int> UpdateGenreAsync(GenreModel model);
        Task<GenreModel> GetGenreByIdAsync(int id);
    }
}
