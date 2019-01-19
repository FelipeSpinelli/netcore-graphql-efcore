using EFCoreGraphQL.Core.Data;
using EFCoreGraphQL.Core.Models;
using GraphQL.Types;

namespace EFCoreGraphQL.Api.GraphQL.Types
{
    public class ComicType : ObjectGraphType<Comic>
    {
        public ComicType(ICharacterRepository characterRepository)
        {
            Field(x => x.Id, type: typeof(IdGraphType));
            Field(x => x.Name);
            Field<ListGraphType<CharacterType>>("characters",
                resolve: context => characterRepository.GetByComic(context.Source.Id));
        }
    }
}
