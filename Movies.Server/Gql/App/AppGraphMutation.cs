using GraphQL;
using GraphQL.Types;
using Movies.Contracts;
using Movies.Server.Gql.Types;
using System.Security.Cryptography.X509Certificates;

namespace Movies.Server.Gql.App
{
	public class AppGraphMutation : ObjectGraphType
	{

		public AppGraphMutation(IMovieGrainClient movieGrainClient)
		{

			Name = "AppMutations";

			Field<MovieDataGraphType>("addMovie",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<MovieInputType>>
				{
					Name = "movie"
				}),
				resolve: ctx => movieGrainClient.Add(ctx.GetArgument<MovieModel>("movie"))
			);

			Field<MovieDataGraphType>("updateMovie",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<MovieInputType>>
				{
					Name = "movie"
				}),
				resolve: ctx => movieGrainClient.Update(ctx.GetArgument<MovieModel>("movie"))
			);
		}
	}
}