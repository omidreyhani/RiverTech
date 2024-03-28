using GraphQL.Types;
using Movies.Contracts;
using Movies.Server.Gql.Types;

namespace Movies.Server.Gql.App
{
	public class AppGraphQuery : ObjectGraphType
	{
		public AppGraphQuery(ISampleGrainClient sampleClient, IMoviesCatalogGrainClient movieCatalogGrainClient)
		{
			Name = "AppQueries";

			Field<SampleDataGraphType>("sample",
				arguments: new QueryArguments(new QueryArgument<StringGraphType>
				{
					Name = "id"
				}),
				resolve: ctx => sampleClient.Get(ctx.Arguments["id"].ToString())
			);


			Field<ListGraphType<MovieDataGraphType>>("toprated",
				resolve: ctx => movieCatalogGrainClient.ListTopRatedMovies()
			);

		}
	}
}
