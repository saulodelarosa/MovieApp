using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using ApplicationCore.Entities;
namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task AddMovieAsync(MovieCreateRequestModel model)
        {
            Movie movie = new Movie();
            if (model != null)
            {
                movie.BackdropUrl = model.BackdropUrl;
                movie.Title = model.Title;
                movie.Budget = model.Budget;
                movie.ImdbUrl = model.ImdbUrl;
                movie.OriginalLanguage = model.OriginalLanguage;
                movie.Overview = model.Overview;
                movie.PosterUrl = model.PosterUrl;
                movie.Price = model.Price;
                movie.ReleaseDate = model.ReleaseDate;
                movie.Revenue = model.Revenue;
                movie.RunTime = model.RunTime;
                movie.Tagline = model.Tagline;
                movie.Title = model.Title;
                movie.TmdbUrl = model.TmdbUrl;
                await _movieRepository.InsertAsync(movie);

            }
        }

        public async Task DeleteMovieAsync(int id)
        {
            await _movieRepository.DeleteAsync(id);
        }

        public async Task<MovieDetailsResponseModel> GetMovieDetailsAsync(int id)
        {
            var movieDetails = await _movieRepository.GetByIdAsync(id);
            var rating = await _movieRepository.GetMovieRatingAsync(id);

            var movieModel = new MovieDetailsResponseModel
            {
                Id = movieDetails.Id,
                Title = movieDetails.Title,
                PosterUrl = movieDetails.PosterUrl,
                BackdropUrl = movieDetails.BackdropUrl,
                Overview = movieDetails.Overview,
                Tagline = movieDetails.Tagline,
                Budget = movieDetails.Budget,
                Revenue = movieDetails.Revenue,
                ImdbUrl = movieDetails.ImdbUrl,
                TmdbUrl = movieDetails.TmdbUrl,
                ReleaseDate = movieDetails.ReleaseDate,
                RunTime = movieDetails.RunTime,
                Price = movieDetails.Price,
                Rating = rating,

            };

            foreach (var genre in movieDetails.GernesOfMovie)
            {
                movieModel.Genres.Add(new GenreModel { Id = genre.GenreId, Name = genre.Genre.Name });
            }

            foreach (var trailer in movieDetails.Trailers)
            {
                movieModel.Trailers.Add(new TrailerResponseModel { Id = trailer.Id, Name = trailer.Name, TrailerUrl = trailer.TrailerUrl });
            }

            foreach (var cast in movieDetails.MovieCast)
            {
                movieModel.Casts.Add(new CastResponseModel { Id = cast.CastId, Name = cast.Cast.Name, Character = cast.Character, ProfilePath = cast.Cast.ProfilePath });
            }

            return movieModel;

        }
        public async Task<PagedResultSet<MovieCardResponseModel>> GetMoviesByPaginationAsync(int pageSize, int page, string title)
        {
            var pagedMovies = await _movieRepository.GetMoviesByTitleAsync(pageSize, page, title);

            var pagedMovieCards = new List<MovieCardResponseModel>();

            pagedMovieCards.AddRange(pagedMovies.Data.Select(m => new MovieCardResponseModel
            {
                Id = m.Id,
                Title = m.Title,
                PosterUrl = m.PosterUrl
            }));

            return new PagedResultSet<MovieCardResponseModel>(pagedMovieCards, page, pageSize, pagedMovies.Count);

        }
        public async Task<List<MovieCardResponseModel>> GetTop30GRatedMoviesAsync()
        {
            var topRatedMovies = await _movieRepository.Get30HighestRatedMoviesAsync();

            var movieCards = new List<MovieCardResponseModel>();
            foreach (var movie in topRatedMovies)
            {
                movieCards.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }

            return movieCards;

        }
        public async Task<List<MovieCardResponseModel>> GetTop30GrossingMoviesAsync()
        {
            // we need to call the MovieRepository and get the data from Movies Table
            var movies = await _movieRepository.Get30HighestGrossingMoviesAsync();
            // map the data from movies (List<Movie>) to movieCards (List<MovieCardResponseModel>)

            var movieCards = new List<MovieCardResponseModel>();

            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }

            return movieCards;
        }

        public async Task<List<MovieCardResponseModel>> MoviesSameGenreAsync(int id)
        {
            var genreMovies = await _movieRepository.GetMoviesSameGenreAsync(id);

            var genreModel = new List<MovieCardResponseModel>();

            foreach (var movie in genreMovies)
            {
                genreModel.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }
            return genreModel;
        }

        public async Task UpdateMovieAsync(MovieCreateRequestModel model)
        {
            Movie movie = new Movie();
            if (model != null)
            {
                movie.BackdropUrl = model.BackdropUrl;
                movie.Title = model.Title;
                movie.Budget = model.Budget;
                movie.ImdbUrl = model.ImdbUrl;
                movie.OriginalLanguage = model.OriginalLanguage;
                movie.Overview = model.Overview;
                movie.PosterUrl = model.PosterUrl;
                movie.Price = model.Price;
                movie.ReleaseDate = model.ReleaseDate;
                movie.Revenue = model.Revenue;
                movie.RunTime = model.RunTime;
                movie.Tagline = model.Tagline;
                movie.Title = model.Title;
                movie.TmdbUrl = model.TmdbUrl;
                await _movieRepository.UpdateAsync(movie);

            }
        }
    }
}
