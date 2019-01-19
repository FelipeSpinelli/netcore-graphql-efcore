using System;

namespace EFCoreGraphQL.Core.Models
{
    public class CharacterComic
    {
        public Guid CharacterId { get; set; }
        public Guid ComicId { get; set; }

        public Character Character { get; set; }
        public Comic Comic { get; set; }
    }
}