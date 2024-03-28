using System.Threading.Tasks;

namespace Movies.Contracts
{
	public interface IMovieGrainClient
	{
		Task<MovieModel> Get(long id);
		Task Add(MovieModel movie);
		Task Update(MovieModel movie);
	}
}
