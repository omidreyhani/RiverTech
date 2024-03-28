using Microsoft.AspNetCore.Mvc;
using Movies.Contracts;
using System.Threading.Tasks;

namespace Movies.Server.Controllers
{
	[Route("api/[controller]")]
	public class MoviesCatalogController : Controller
	{
		private readonly IMoviesCatalogGrainClient _client;

		public MoviesCatalogController(
			IMoviesCatalogGrainClient client
		)
		{
			_client = client;
		}

		// GET api/moviescatalog/toprated
		[HttpGet("toprated")]
		public async Task<IActionResult> ListTopRatedMovies()
		{
			var movies = await _client.ListTopRatedMovies().ConfigureAwait(false);
			return Ok(movies);
		}
	}
}