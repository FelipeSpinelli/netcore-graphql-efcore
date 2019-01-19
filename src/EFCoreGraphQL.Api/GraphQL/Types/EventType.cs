using EFCoreGraphQL.Core.Data;
using EFCoreGraphQL.Core.Models;
using GraphQL.Types;

namespace EFCoreGraphQL.Api.GraphQL.Types
{
    public class EventType : ObjectGraphType<Event>
    {
        public EventType(ICharacterRepository characterRepository)
        {
            Field(x => x.Id, type: typeof(IdGraphType));
            Field(x => x.Name);
            Field<ListGraphType<CharacterType>>("characters",
                resolve: context => characterRepository.GetByEvent(context.Source.Id));
        }
    }
}
