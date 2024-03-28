using Movies.Contracts;
using Orleans;
using Orleans.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Grains
{
  [StorageProvider(ProviderName = "Default")]
  public class MovieCatalogGrain : Grain<MoviesCatalogState>, IMoviesCatalogGrain
  {

    public async Task<List<MovieModel>> ListTopRatedMovies()
    {
      var topRatedMovies = State.Movies.OrderByDescending(m => m.Rate).Take(5).ToList();
      return await Task.FromResult(topRatedMovies);
    }

    public Task<List<MovieModel>> ListMovies() => Task.FromResult(State.Movies);

    public Task<List<MovieModel>> SearchMovies(string query)
    {
      var movies = State.Movies.Where(m => m.Name.IndexOf(query, StringComparison.OrdinalIgnoreCase) > 0).ToList();
      return Task.FromResult(movies);
    }

    public Task<List<MovieModel>> FilterMoviesByGenre(string genre)
    {
      var movies = State.Movies.Where(m => m.Genres.Contains(genre, StringComparer.OrdinalIgnoreCase)).ToList();
      return Task.FromResult(movies);
    }

    public async Task AddOrUpdateMovie(MovieModel movie)
    {
      State.Movies.Add(movie);
      await WriteStateAsync();
    }

    public async Task UpdateMovie(MovieModel movie)
    {
      var existingMovie = State.Movies.FirstOrDefault(m => m.Id == movie.Id);
      if (existingMovie != null)
      {
        existingMovie.Name = movie.Name;
        existingMovie.Description = movie.Description;
        existingMovie.Genres = movie.Genres;
        existingMovie.Rate = movie.Rate;
        existingMovie.Length = movie.Length;
        existingMovie.Img = movie.Img;
        await WriteStateAsync();
      }
    }

		public Task<MovieModel> GetMovie(long id){
      var movie = State.Movies.FirstOrDefault(m => m.Id == id);
      return Task.FromResult(movie);
    }
	}
}
