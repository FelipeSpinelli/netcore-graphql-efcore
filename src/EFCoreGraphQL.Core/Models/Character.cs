using System;
using System.Collections.Generic;

namespace EFCoreGraphQL.Core.Models
{
    public class Character
    {
        public Guid Id { get; set; }
        public int MarvelId { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public string Description { get; set; }
        public DateTime Modified { get; set; }

        public IList<CharacterComic> Comics { get; set; }
        public IList<CharacterSerie> Series { get; set; }
        public IList<CharacterEvent> Events { get; set; }
    }


}
