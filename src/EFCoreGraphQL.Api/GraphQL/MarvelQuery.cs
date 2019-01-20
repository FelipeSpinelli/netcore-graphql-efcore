using EFCoreGraphQL.Api.GraphQL.Types;
using EFCoreGraphQL.Core.Data;
using GraphQL.Types;

namespace EFCoreGraphQL.Api.GraphQL
{
    public class MarvelQuery : ObjectGraphType
    {
        public MarvelQuery(
            ICharacterRepository characterRepository,
            IComicRepository comicRepository,
            IEventRepository eventRepository,
            ISerieRepository serieRepository)
        {
            Field<CharacterType>(
                "character",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "marvelId" }),
                resolve: context => characterRepository.Get(context.GetArgument<int>("marvelId")));
            Field<CharacterType>(
                "characters",
                resolve: context => characterRepository.GetAll());

            Field<ListGraphType<ComicType>>(
                "comics",
                resolve: context => comicRepository.GetAll());

            Field<EventType>(
                "events",
                resolve: context => eventRepository.GetAll());

            Field<SerieType>(
                "series",
                resolve: context => serieRepository.GetAll());
        }
    }
}
