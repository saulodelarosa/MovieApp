using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApp.Core.Models;

namespace MovieApp.Core.Contracts.Service
{
    public interface IMovieService
    {

        Task<int> InsertMovie(MovieModel MovieModel);
        Task<IEnumerable<MovieModel>> GetAllMovies();
        Task<int> DeleteMovieAsync(int id);
        Task<int> UpdateMovieAsync(MovieModel model);
        Task<MovieModel> GetMovieByIdAsync(int id);

    }
}
