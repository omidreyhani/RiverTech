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
		public Task<MovieModel> Get()
			=> Task.FromResult(State);

		public Task Set(MovieModel movie)
		{
			movie.Id = this.GetPrimaryKeyLong();
			State = movie;
			return Task.CompletedTask;
		}
	}
}
