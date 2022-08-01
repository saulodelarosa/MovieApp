using MovieApp.Core.Contracts.Repository;
using MovieApp.Core.Contracts.Service;
using MovieApp.Core.Entities;
using MovieApp.Core.Models;
using MovieApp.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Infrastructure.Service
{
    public class MovieService : IMovieService
    {
        IMovieRepository movieRepository;
        public MovieService(IMovieRepository _MovieRepository)
        {
            movieRepository = _MovieRepository;
        }
        public Task<int> InsertMovie(MovieModel MovieModel)
        {
            Movie MovieEntity = new Movie();
            MovieEntity.Title = MovieModel.Title;
            return movieRepository.InsertAsync(MovieEntity);

        }

        public async Task<IEnumerable<MovieModel>> GetAllMovies()
        {
            var result = await movieRepository.GetAllAsync();

            List<MovieModel> Movies = new List<MovieModel>();
            if (result != null)
            {
                foreach (var item in result)
                {
                    MovieModel r = new MovieModel();
                    r.Id = item.Id;
                    r.Title = item.Title;
                    Movies.Add(r);
                }
            }
            return Movies;
        }

        public Task<int> DeleteMovieAsync(int id)
        {
            return movieRepository.DeleteAsync(id);
        }

        public Task<int> UpdateMovieAsync(MovieModel model)
        {
            Movie MovieEntity = new Movie();
            MovieEntity.Title = model.Title;
            MovieEntity.Id = model.Id;
            return movieRepository.UpdateAsync(MovieEntity);
        }

        public async Task<MovieModel> GetMovieByIdAsync(int id)
        {
            Movie entity = await movieRepository.GetByIdAsync(id);
            if (entity != null)
            {
                MovieModel MovieModel = new MovieModel()
                {
                    Id = entity.Id,
                    Title = entity.Title
                };
                return MovieModel;
            }
            return null;
        }
    }
}
