using EFCoreGraphQL.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCoreGraphQL.Core.Data
{
    public interface ICharacterRepository
    {
        Character Get(int marvelId);
        Task<IEnumerable<Character>> GetAll();
        Task<IEnumerable<Character>> GetByComic(Guid comicId);
        Task<IEnumerable<Character>> GetByEvent(Guid eventId);
        Task<IEnumerable<Character>> GetBySerie(Guid serieId);
    }
}
