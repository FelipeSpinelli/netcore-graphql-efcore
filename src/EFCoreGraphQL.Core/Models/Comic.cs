using System;
using System.Collections.Generic;

namespace EFCoreGraphQL.Core.Models
{
    public class Comic
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }

        public IList<CharacterComic> Characters { get; set; }
    }
}
