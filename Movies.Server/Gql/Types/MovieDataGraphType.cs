using GraphQL.Types;
using Movies.Contracts;

namespace Movies.Server.Gql.Types
{
	public class MovieDataGraphType : ObjectGraphType<MovieModel>
	{
		public MovieDataGraphType()
		{
			Name = "Movie";
			Description = "Movie data graphtype.";

			Field(x => x.Id, nullable: true).Description("Unique key.");
			Field(x => x.Name, nullable: true).Description("Name.");
			Field(x => x.Description, nullable: true).Description("Description.");
			Field(x => x.Genres, nullable: true).Description("Genres.");
			Field(x => x.Rate, nullable: true).Description("Rate.");
			Field(x => x.Length, nullable: true).Description("Length.");
			Field(x => x.Img, nullable: true).Description("Img.");
			Field(x => x.Key, nullable: true).Description("Key.");

			
		}
	}
}