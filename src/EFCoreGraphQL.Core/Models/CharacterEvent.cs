using System;

namespace EFCoreGraphQL.Core.Models
{
    public class CharacterEvent
    {
        public Guid CharacterId { get; set; }
        public Guid EventId { get; set; }

        public Character Character { get; set; }
        public Event Event { get; set; }
    }
}