using Orleans;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Contracts
{
	public interface IMoviesCatalogGrain : IGrainWithIntegerKey 
	{
		Task<List<MovieModel>> ListTopRatedMovies();
		Task<List<MovieModel>> ListMovies();
		Task<List<MovieModel>> SearchMovies(string query);
		Task<List<MovieModel>> FilterMoviesByGenre(string genre);
		Task AddMovie(MovieModel movie);
	}
}