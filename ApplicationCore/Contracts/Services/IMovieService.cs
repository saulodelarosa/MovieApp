using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;
namespace ApplicationCore.Contracts.Services
{
    public interface IMovieService
    {
        Task<List<MovieCardResponseModel>> GetTop30GrossingMoviesAsync();
        Task<List<MovieCardResponseModel>> GetTop30GRatedMoviesAsync();
        Task<MovieDetailsResponseModel> GetMovieDetailsAsync(int id);
        Task<List<MovieCardResponseModel>> MoviesSameGenreAsync(int id);
        Task<PagedResultSet<MovieCardResponseModel>> GetMoviesByPaginationAsync(int pageSize, int page, string title);
        Task AddMovieAsync(MovieCreateRequestModel model);
        Task DeleteMovieAsync(int id);
        Task UpdateMovieAsync(MovieCreateRequestModel model);

    }
}
