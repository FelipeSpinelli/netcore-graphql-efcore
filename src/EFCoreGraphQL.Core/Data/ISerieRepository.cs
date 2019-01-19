using EFCoreGraphQL.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCoreGraphQL.Core.Data
{
    public interface ISerieRepository
    {
        Task<IEnumerable<Serie>> GetAll();
        Task<IEnumerable<Serie>> GetByCharacter(Guid characterId);
    }
}
