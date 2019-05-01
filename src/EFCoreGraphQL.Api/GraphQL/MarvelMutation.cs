using EFCoreGraphQL.Api.GraphQL.Types;
using EFCoreGraphQL.Core.Data;
using EFCoreGraphQL.Core.Models;
using GraphQL.Types;

namespace EFCoreGraphQL.Api.GraphQL
{
    public class MarvelMutation : ObjectGraphType
    {
        public MarvelMutation(IComicRepository comicRepository)
        {
            Name = "MarvelMutation";

            Field<ComicType>(
                "createComic",
                arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<ComicInputType>> { Name = "comic" }
            ),
            resolve: context =>
            {
                var comic = context.GetArgument<Comic>("comic");
                return comicRepository.Add(comic);
            });
        }
    }
}
