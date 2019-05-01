using EFCoreGraphQL.Core.Data;
using EFCoreGraphQL.Core.Models;
using GraphQL.Types;

namespace EFCoreGraphQL.Api.GraphQL.Types
{
    public class ComicInputType : InputObjectGraphType
    {
        public ComicInputType()
        {
            Name = "ComicInput";
            Field<NonNullGraphType<StringGraphType>>("name");
        }
    }
}
