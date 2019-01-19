using System;
using System.Collections.Generic;

namespace EFCoreGraphQL.Core.Models
{
    public class Serie
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IList<CharacterSerie> Characters { get; set; }
    }
}
