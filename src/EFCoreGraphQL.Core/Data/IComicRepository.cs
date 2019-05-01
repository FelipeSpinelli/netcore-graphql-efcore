using EFCoreGraphQL.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCoreGraphQL.Core.Data
{
    public interface IComicRepository
    {
        Task<Comic> Add(Comic comic);
        Task<IEnumerable<Comic>> GetAll();
        Task<IEnumerable<Comic>> GetByCharacter(Guid characterId);
    }
}
