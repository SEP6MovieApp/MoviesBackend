using MoviesDB.API.Swagger.Controllers.Generated;
using MovieResponse = tmdb_api.MovieResponse;
using Rating = MoviesApi.Data.Models.Rating;

namespace MoviesApi.Services.Interfaces;

public interface IMovieService
{
    Task<MovieResponse> GetMovieAsync(int movie_id, string language = "en_US");
    Task<MoviesResponseDto> GetMoviesByTitleAsync(string? userId, string movieName, string language = "en_US");
    Task<MoviesResponseDto> GetFavoriteMovies(string userId);
    Task<MoviesResponseDto> GetTopFavoriteMovies(string? userId);
    Task AddFavorite(FavoritesDto favoritesDto);
    Task<Rating> GetMovieRatingAsync(int movieId);
    Task<RatedMovieDto> AddRatedMovieAsync(RatedMovieDto ratedMovie);
    Task<RatingDto> AddRatingAsync(RatedMovieDto ratedMovie);
    Task RemoveFavorite(FavoritesDto favoritesDto);
}