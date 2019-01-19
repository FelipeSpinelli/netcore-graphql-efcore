﻿using Newtonsoft.Json.Linq;

namespace EFCoreGraphQL.Api.ViewModels.Requests
{
    public class GraphQLQueryRequestViewModel
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; } //https://github.com/graphql-dotnet/graphql-dotnet/issues/389
    }
}
