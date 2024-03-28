using Movies.Contracts;
using Orleans;
using Orleans.Providers;
using System.Threading.Tasks;

namespace Movies.Grains
{
	[StorageProvider(ProviderName = "Default")]
	public class SampleGrain : Grain<SampleDataModel>, ISampleGrain
	{
		public Task<SampleDataModel> Get()
			=> Task.FromResult(State);

		public Task Set(string name)
		{
			State = new SampleDataModel { Id = this.GetPrimaryKeyString(), Name = name };
			return Task.CompletedTask;
		}
	}

	[StorageProvider(ProviderName = "Default")]
	public class MovieGrain : Grain<MovieModel>, IMovieGrain
	{

		public async Task<MovieModel> Get()
		{

			if (State == null)
			{
				var catalogGrain = GrainFactory.GetGrain<IMoviesCatalogGrain>(0);
				var movie = await catalogGrain.GetMovie(this.GetPrimaryKeyLong());
				State = movie;
			}

			return await Task.FromResult(State);
		}

		public async Task Add(MovieModel movie)
		{

			var catalogGrain = GrainFactory.GetGrain<IMoviesCatalogGrain>(0);
			await catalogGrain.AddOrUpdateMovie(movie);
			State = movie;
		}

		public async Task Update(MovieModel movie)
		{

			var catalogGrain = GrainFactory.GetGrain<IMoviesCatalogGrain>(0);
			await catalogGrain.AddOrUpdateMovie(movie);
			State = movie;
		}
	}
}
