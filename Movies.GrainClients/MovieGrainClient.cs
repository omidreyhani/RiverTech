using Movies.Contracts;
using Orleans;
using System;
using System.Threading.Tasks;

namespace Movies.GrainClients
{
	public class MovieGrainClient : IMovieGrainClient
	{
		private readonly IGrainFactory _grainFactory;

		public MovieGrainClient(
			IGrainFactory grainFactory
		)
		{
			_grainFactory = grainFactory;
		}

		public Task Add(MovieModel movie){
			var grain = _grainFactory.GetGrain<IMovieGrain>(movie.Id);
			return grain.Add(movie);
		}
		public Task<MovieModel> Get(long id){
			var grain = _grainFactory.GetGrain<IMovieGrain>(id);
			return grain.Get();
		}
		public Task Update(MovieModel movie){
			var grain = _grainFactory.GetGrain<IMovieGrain>(movie.Id);
			return grain.Update(movie);
		}
	}
}