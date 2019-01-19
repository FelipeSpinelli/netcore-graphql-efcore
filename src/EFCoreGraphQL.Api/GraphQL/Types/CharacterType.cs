using EFCoreGraphQL.Core.Data;
using EFCoreGraphQL.Core.Models;
using GraphQL.Types;

namespace EFCoreGraphQL.Api.GraphQL.Types
{
    public class CharacterType : ObjectGraphType<Character>
    {
        public CharacterType(
            IComicRepository comicRepository,
            IEventRepository eventRepository,
            ISerieRepository serieRepository)
        {
            Field(x => x.Id, type: typeof(IdGraphType)); //https://github.com/graphql-dotnet/graphql-dotnet/issues/350
            Field(x => x.Name);
            Field(x => x.MarvelId);
            Field(x => x.Description, nullable: true);
            Field(x => x.Thumbnail, nullable: true);
            Field(x => x.Modified);

            Field<ListGraphType<ComicType>>("comics",
                resolve: context => comicRepository.GetByCharacter(context.Source.Id));

            Field<ListGraphType<EventType>>("events",
                resolve: context => eventRepository.GetByCharacter(context.Source.Id));

            Field<ListGraphType<SerieType>>("series",
                resolve: context => serieRepository.GetByCharacter(context.Source.Id));
        }
    }
}
