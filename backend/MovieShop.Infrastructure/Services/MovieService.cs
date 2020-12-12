using MovieShop.Core.Entities;
using MovieShop.Core.Exceptions;
using MovieShop.Core.Helpers;
using MovieShop.Core.Models.Request;
using MovieShop.Core.Models.Response;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.ServiceInterfaces;
using MovieShop.Infrastructure.Data;
using MovieShop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IAsyncRepository<MovieGenre> _genresRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IAsyncRepository<Favorite> _favoriteRepository;
        //private object _dbContext;

        //constructor injection
        //DI is pattern that enables us to write loosly coupled code so taht code is mroe maintanable and testable expically unit testing...
        public MovieService(IMovieRepository movieRepository)//, IAsyncRepository<MovieGenre> genresRepository, IPurchaseRepository purchaseRepository, IAsyncRepository<Favorite> favoriteRepository
        {
            // create MovieRepo instance in every method in my service class
            // newing up is very convineint but we need to avoid it as much as we can
            // make sure you dont break any existing code....
            // always go back do the regression testing...
            //  _repository = new MovieRepository(new MovieShopDbContext(null));
            _movieRepository = movieRepository;
/*            _genresRepository = genresRepository;
            _purchaseRepository = purchaseRepository;
            _favoriteRepository = favoriteRepository;*/
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

        public async Task<PagedResultSet<MovieResponseModel>> GetMoviesByPagination(
            int pageSize = 20, int pageIndex = 0, string title = "")
        {
            /*            Expression<Func<Movie, bool>> filterExpression = null;
                        if (!string.IsNullOrEmpty(title)) filterExpression = movie => title != null && movie.Title.Contains(title);

                        var pagedMovies = await _movieRepository.GetPagedData(pageIndex, pageSize,
                                                                              movies => movies.OrderBy(m => m.Title),
                                                                              filterExpression);
                        var movies =
                            new PagedResultSet<MovieResponseModel>(_mapper.Map<List<MovieResponseModel>>(pagedMovies),
                                                                   pagedMovies.PageIndex,
                                                                   pageSize, pagedMovies.TotalCount);
                        return movies;*/
            throw new NotImplementedException();

        }

        public async Task<PagedResultSet<MovieResponseModel>> GetAllMoviePurchasesByPagination(int pageSize = 20, int page = 0)
        {
            /*            var movies = await _movieRepository.GetPurchasesMovie(pageSize, page);
                        var resultSet = new PagedResultSet<MovieResponseModel>();
                        foreach (var movie in movies)
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
                        return resultSet;*/

            /*            var totalPurchases = await _purchaseRepository.GetCountAsync();
                        var purchases = await _purchaseRepository.GetAllPurchases(pageSize, page);

                        var data = _mapper.Map<List<MovieResponseModel>>(purchases);
                        var purchasedMovies = new PagedResultSet<MovieResponseModel>(data, page, pageSize, totalPurchases);
                        return purchasedMovies;*/
            throw new NotImplementedException();


        }

        public async Task<PaginatedList<MovieResponseModel>> GetAllPurchasesByMovieId(int movieId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ReviewMovieResponseModel>> GetReviewsForMovie(int id)
        {
            /*var reviews = await _movieRepository.GetMovieReviews(id);
            var response = _mapper.Map<IEnumerable<ReviewMovieResponseModel>>(reviews);
            return response;*/

            throw new NotImplementedException();
        }

        public async Task<int> GetMoviesCount(string title = "")
        {
            if (string.IsNullOrEmpty(title)) return await _movieRepository.GetCountAsync();
            return await _movieRepository.GetCountAsync(m => m.Title.Contains(title));
        }

        public async Task<IEnumerable<MovieResponseModel>> GetTopRatedMovies()
        {
/*            var topMovies = await _movieRepository.GetTopRatedMovies();
            var response = _mapper.Map<IEnumerable<MovieResponseModel>>(topMovies);
            return response;*/
            throw new NotImplementedException();

        }

        public async Task<IEnumerable<MovieResponseModel>> GetHighestGrossingMovies()
        {
            // Repository?
            // MovieRepository class

            var movies = await _movieRepository.GetHighestGrossingMovies();
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

        public async Task<IEnumerable<MovieResponseModel>> GetMoviesByGenre(int genreId)
        {
            var movies = await _movieRepository.GetMoviesByGenre(genreId);
            if (!movies.Any())
                throw new NotFoundException("Movies for genre", genreId);
            /*            var response = _mapper.Map<IEnumerable<MovieResponseModel>>(movies);
            */
            var response = new List<MovieResponseModel>();
            foreach(var movie in movies)
            {
                response.Add(new MovieResponseModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl,
                    // ReleaseDate = null
                });
            };
            return response;

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
/*            var movie = _mapper.Map<Movie>(movieCreateRequest);

            var createdMovie = await _movieRepository.AddAsync(movie);
            // var movieGenres = new List<MovieGenre>();
            foreach (var genre in movieCreateRequest.Genres)
            {
                var movieGenre = new MovieGenre { MovieId = createdMovie.Id, GenreId = genre.Id };
                await _genresRepository.AddAsync(movieGenre);
            }

            return _mapper.Map<MovieDetailsResponseModel>(createdMovie);*/
        }

        public Task<MovieDetailsResponseModel> UpdateMovie(MovieCreateRequest movieCreateRequest)
        {
/*            var movie = _mapper.Map<Movie>(movieCreateRequest);

            var createdMovie = await _movieRepository.UpdateAsync(movie);
            // var movieGenres = new List<MovieGenre>();
            foreach (var genre in movieCreateRequest.Genres)
            {
                var movieGenre = new MovieGenre { MovieId = createdMovie.Id, GenreId = genre.Id };
                await _genresRepository.UpdateAsync(movieGenre);
            }

            return _mapper.Map<MovieDetailsResponseModel>(createdMovie);*/
            throw new NotImplementedException();
        }

/*        public async Task<PaginatedList<MovieResponseModel>> GetTopPurchasesMovies()
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
        }*/
    }
}
