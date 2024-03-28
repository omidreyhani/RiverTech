using GraphQL.Types;

namespace Movies.Server.Gql.Types
{
public class MovieInputType : InputObjectGraphType
{
    public MovieInputType()
    {
        Name = "MovieInput";
        Field<NonNullGraphType<LongGraphType>>("id");
        Field<NonNullGraphType<StringGraphType>>("key");
        Field<NonNullGraphType<StringGraphType>>("name");
        Field<StringGraphType>("description");
        Field<ListGraphType<StringGraphType>>("genres");
        Field<FloatGraphType>("rate");
        Field<StringGraphType>("length");
        Field<StringGraphType>("img");
    }
}
}