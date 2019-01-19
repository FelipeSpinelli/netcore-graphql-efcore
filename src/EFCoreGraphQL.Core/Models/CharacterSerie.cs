using System;

namespace EFCoreGraphQL.Core.Models
{
    public class CharacterSerie
    {
        public Guid CharacterId { get; set; }
        public Guid SerieId { get; set; }

        public Character Character { get; set; }
        public Serie Serie { get; set; }
    }
}