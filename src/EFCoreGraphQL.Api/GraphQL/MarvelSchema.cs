using GraphQL;
using GraphQL.Types;

namespace EFCoreGraphQL.Api.GraphQL
{
    public class MarvelSchema : Schema
    {
        public MarvelSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<MarvelQuery>();
            Mutation = resolver.Resolve<MarvelMutation>();
        }
    }
}
