using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        MovieWebAppDbContext _dbContext;
        public MovieRepository(MovieWebAppDbContext context) : base(context)
        {
            _dbContext = context;
        }
        public async Task<List<Movie>> Get30HighestGrossingMoviesAsync()
        {
            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();

            return movies;
        }

        public async Task<List<Movie>> Get30HighestRatedMoviesAsync()
        {
            var topRatedMovies = await _dbContext.Reviews.Include(r => r.Movie).GroupBy(r => new { r.MovieId, r.Movie.PosterUrl, r.Movie.Title })
                .OrderByDescending(m => m.Average(r => r.Rating)).Select(m => new Movie
                {
                    Id = m.Key.MovieId,
                    PosterUrl = m.Key.PosterUrl,
                    Title = m.Key.Title,
                }).Take(30).ToListAsync();

            return topRatedMovies;
        }

        public async Task<decimal> GetMovieRatingAsync(int id)
        {
            var movieRating = await _dbContext.Reviews.Where(r => r.MovieId == id).DefaultIfEmpty().AverageAsync(r => r == null ? 0 : r.Rating);
            return movieRating;
        }

        public async Task<PagedResultSet<Movie>> GetMoviesByTitleAsync(int pageSize = 30, int page = 1, string title = "")
        {
            var movies = await _dbContext.Movies.Where(m => m.Title.Contains(title)).OrderBy(m => m.Title).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // total movies  for that condition 
            // select count(*) from Movies where title like '%ave%'

            var totalMoviesCount = await _dbContext.Movies.Where(m => m.Title.Contains(title)).CountAsync();

            var pagedMovies = new PagedResultSet<Movie>(movies, page, pageSize, totalMoviesCount);

            return pagedMovies;
        }

        public async Task<List<Movie>> GetMoviesSameGenreAsync(int id)
        {
            var genreMovies = await _dbContext.MovieGenres.Include(m => m.Movie).Where(m => m.GenreId == id).Select(m => m.Movie).ToListAsync();
            return genreMovies;
        }
    }
}
