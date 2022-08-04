using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
       Task< List<Movie>> Get30HighestGrossingMoviesAsync();
       Task< List<Movie>> Get30HighestRatedMoviesAsync();
        Task<decimal> GetMovieRatingAsync(int id);
        Task<List<Movie>> GetMoviesSameGenreAsync(int id);

        Task<PagedResultSet<Movie>> GetMoviesByTitleAsync(int pageSize = 30, int page = 1, string title = "");
       


    }
}
