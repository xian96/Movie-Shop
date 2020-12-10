using MovieShop.Core.Entities;
using MovieShop.Core.Helpers;
using MovieShop.Core.Models.Request;
using MovieShop.Core.Models.Response;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.ServiceInterfaces;
using MovieShop.Infrastructure.Data;
using MovieShop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        //private object _dbContext;

        //constructor injection
        //DI is pattern that enables us to write loosly coupled code so taht code is mroe maintanable and testable expically unit testing...
        public MovieService(IMovieRepository movieRepository)
        {
            // create MovieRepo instance in every method in my service class
            // newing up is very convineint but we need to avoid it as much as we can
            // make sure you dont break any existing code....
            // always go back do the regression testing...
            //  _repository = new MovieRepository(new MovieShopDbContext(null));
            _movieRepository = movieRepository;
        }

        public async Task<MovieDetailsResponseModel> GetMovieAsync(int id)
        {
            Movie movie = await _movieRepository.GetByIdAsync(id);
            var movieGenres = movie.MovieGenres;
            List<Genre> genres = new List<Genre>();
            foreach (var movieGenre in movieGenres)
            {
                genres.Add(movieGenre.Genre);
            }
            var movieCasts = movie.MovieCasts;
            List<CastResponseModel> castResponseModels = new List<CastResponseModel>();
            foreach (var movieCast in movieCasts)
            {
                castResponseModels.Add(new CastResponseModel
                {
                    Id = movieCast.Cast.Id,
                    Name = movieCast.Cast.Name,
                    Gender = movieCast.Cast.Gender,
                    TmdbUrl = movieCast.Cast.TmdbUrl,
                    ProfilePath = movieCast.Cast.ProfilePath,
                    Character = movieCast.Character
                });
            }
            MovieDetailsResponseModel movieDetailsResponseModel = new MovieDetailsResponseModel
            {
                Id = movie.Id,
                Title = movie.Title,
                PosterUrl = movie.PosterUrl,
                BackdropUrl = movie.BackdropUrl,
                //Rating = movie.Rating,
                Overview = movie.Overview,
                Tagline = movie.Tagline,
                Budget = movie.Budget,
                Revenue = movie.Revenue,
                ImdbUrl = movie.ImdbUrl,
                TmdbUrl = movie.TmdbUrl,
                ReleaseDate = movie.ReleaseDate.Value,
                RunTime = movie.RunTime,
                Price = movie.Price,
                //FavoritesCount = movie.FavoritesCount,
                Casts = castResponseModels,
                Genres = genres,

            };
            /*            MovieDetailsResponseModel movieDetailsResponseModel = new MovieDetailsResponseModel();
                        List<CastResponseModel> castResponseModels = new List<CastResponseModel>();
                        List<Genre> genres = new List<Genre>();
                        movieDetailsResponseModel.Casts = castResponseModels;
                        movieDetailsResponseModel.Genres = genres;*/

            return movieDetailsResponseModel;
        }

        public async Task<IEnumerable<MovieResponseModel>> GetHighestGrossingMovies()
        {
            // Repository?
            // MovieRepository class

            var movies = await _movieRepository.GetHighestRevenueMovies();
            // Map our Movie Entity to MovieResponseModel
            var movieResponseModel = new List<MovieResponseModel>();
            foreach (var movie in movies)
            {
                movieResponseModel.Add(new MovieResponseModel
                {
                    Id = movie.Id,
                    PosterUrl = movie.PosterUrl,
                    ReleaseDate = movie.ReleaseDate.Value,
                    Title = movie.Title
                });
            }
            return movieResponseModel;
        }

        public Task<PagedResultSet<MovieResponseModel>> GetMoviesByPagination(int pageSize = 20, int page = 0, string title = "")
        {
            throw new NotImplementedException();
        }

/*        public async Task<PagedResultSet<MovieResponseModel>> GetAllMoviePurchasesByPagination(int pageSize = 20, int page = 0)
        {
            var movies = await _movieRepository.GetPurchasesMovie(pageSize, page);
            var resultSet = new PagedResultSet<MovieResponseModel>();
            foreach(var movie in movies)
            {
                resultSet.set.Add(new MovieResponseModel
                    {
                        Id = movie.Id,
                        Title = movie.Title,
                        PosterUrl = movie.PosterUrl,
                        ReleaseDate = movie.ReleaseDate.Value
                    }
                );

            }
            return resultSet;
        }*/

        public Task<PaginatedList<MovieResponseModel>> GetAllPurchasesByMovieId(int movieId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReviewMovieResponseModel>> GetReviewsForMovie(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetMoviesCount(string title = "")
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MovieResponseModel>> GetTopRatedMovies()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MovieResponseModel>> GetMoviesByGenre(int genreId)
        {
            throw new NotImplementedException();
        }

        public async Task<MovieDetailsResponseModel> CreateMovie(MovieCreateRequest movieCreateRequest)
        {
            var exists = await _movieRepository.GetExistsAsync(m => m.Title.Equals(movieCreateRequest.Title));

            if (exists)
            {
                throw new Exception("Movie Already Exits");
            }

            var movieEntity = new Movie
            {
                Title = movieCreateRequest.Title
            };
            var createdMovie = await _movieRepository.AddAsync(movieEntity);

            var movieGenres = createdMovie.MovieGenres;
            List<Genre> genres = new List<Genre>();
            if(movieGenres != null)
            {
                foreach (var movieGenre in movieGenres)
                {
                    genres.Add(movieGenre.Genre);
                }
            }

            var movieCasts = createdMovie.MovieCasts;
            List<CastResponseModel> castResponseModels = new List<CastResponseModel>();
            if(movieCasts != null)
            {
                foreach (var movieCast in movieCasts)
                {
                    castResponseModels.Add(new CastResponseModel
                    {
                        Id = movieCast.Cast.Id,
                        Name = movieCast.Cast.Name,
                        Gender = movieCast.Cast.Gender,
                        TmdbUrl = movieCast.Cast.TmdbUrl,
                        ProfilePath = movieCast.Cast.ProfilePath,
                        Character = movieCast.Character
                    });
                }
            }

            var response = new MovieDetailsResponseModel
            {
                Id = createdMovie.Id,
                Title = createdMovie.Title,
                PosterUrl = createdMovie.PosterUrl,
                BackdropUrl = createdMovie.BackdropUrl,
                //Rating = createdMovie.Rating,
                Overview = createdMovie.Overview,
                Tagline = createdMovie.Tagline,
                Budget = createdMovie.Budget,
                Revenue = createdMovie.Revenue,
                ImdbUrl = createdMovie.ImdbUrl,
                TmdbUrl = createdMovie.TmdbUrl,
                ReleaseDate = createdMovie.ReleaseDate,
                RunTime = createdMovie.RunTime,
                Price = createdMovie.Price,
                //FavoritesCount = createdMovie.FavoritesCount,
                Casts = castResponseModels,
                Genres = genres
            };
            return response;
        }

        public Task<MovieDetailsResponseModel> UpdateMovie(MovieCreateRequest movieCreateRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<PaginatedList<MovieResponseModel>> GetTopPurchasesMovies()
        {
            var movies = await _movieRepository.GetTopPurchasesMovies();
            var resultList = new PaginatedList<MovieResponseModel>();
            foreach (var movie in movies)
            {
                resultList.list.Add(new MovieResponseModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl,
                    ReleaseDate = movie.ReleaseDate.Value
                }
                );

            }
            return resultList;
        }
    }
}
