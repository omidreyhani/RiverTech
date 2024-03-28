using Movies.Contracts;
using Orleans;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.GrainClients
{
	public class MoviesCatalogGrainClient : IMoviesCatalogGrainClient
	{
		private readonly IGrainFactory _grainFactory;

		public MoviesCatalogGrainClient(
			IGrainFactory grainFactory
		)
		{
			_grainFactory = grainFactory;
		}

		public Task AddMovie(MovieModel movie){
			var grain = _grainFactory.GetGrain<IMoviesCatalogGrain>(0);
			return grain.AddMovie(movie);
		}
		public Task<List<MovieModel>> FilterMoviesByGenre(string genre) => throw new System.NotImplementedException();
		public Task<List<MovieModel>> ListMovies() => throw new System.NotImplementedException();
		public Task<List<MovieModel>> ListTopRatedMovies()
		{
			var grain = _grainFactory.GetGrain<IMoviesCatalogGrain>(0);
			return grain.ListTopRatedMovies();
		}
		public Task<List<MovieModel>> SearchMovies(string query) => throw new System.NotImplementedException();

	}
}