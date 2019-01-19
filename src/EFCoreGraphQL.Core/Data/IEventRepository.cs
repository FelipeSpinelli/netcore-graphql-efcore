using EFCoreGraphQL.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCoreGraphQL.Core.Data
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAll();
        Task<IEnumerable<Event>> GetByCharacter(Guid characterId);
    }
}
