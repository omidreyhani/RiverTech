using GraphQL.Types;
using Movies.Contracts;
using Movies.Server.Gql.Types;

namespace Movies.Server.Gql.App
{
	public class AppGraphQuery : ObjectGraphType
	{
		public AppGraphQuery(ISampleGrainClient sampleClient, IMoviesCatalogGrainClient movieCatalogGrainClient, IMovieGrainClient movieGrainClient)
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

			Field<ListGraphType<MovieDataGraphType>>("movies",
				resolve: ctx => movieCatalogGrainClient.ListMovies()
			);

			Field<ListGraphType<MovieDataGraphType>>("search",
				arguments: new QueryArguments(new QueryArgument<StringGraphType>
				{
					Name = "query"
				}),
				resolve: ctx => movieCatalogGrainClient.SearchMovies(ctx.Arguments["query"].ToString())
			);

			Field<ListGraphType<MovieDataGraphType>>("filter",
				arguments: new QueryArguments(new QueryArgument<StringGraphType>
				{
					Name = "genre"
				}),
				resolve: ctx => movieCatalogGrainClient.FilterMoviesByGenre(ctx.Arguments["genre"].ToString())
			);

			Field<MovieDataGraphType>("movie",
				arguments: new QueryArguments(new QueryArgument<LongGraphType>
				{
					Name = "id"
				}),
				resolve: ctx => movieGrainClient.Get(long.Parse(ctx.Arguments["id"].ToString()))
			);
		}
	}
}
