using Orleans;
using System.Threading.Tasks;

namespace Movies.Contracts
{
  public interface IMovieGrain : IGrainWithIntegerKey
  {
    Task<MovieModel> Get();
    Task Set(MovieModel movie);
  }
}