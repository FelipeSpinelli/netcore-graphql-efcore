using System;
using System.Collections.Generic;

namespace EFCoreGraphQL.Core.Models
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IList<CharacterEvent> Characters { get; set; }
    }
}
