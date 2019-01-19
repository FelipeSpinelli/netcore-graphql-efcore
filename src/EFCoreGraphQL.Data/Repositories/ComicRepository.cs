using Dapper;
using EFCoreGraphQL.Core.Data;
using EFCoreGraphQL.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCoreGraphQL.Data.Repositories
{
    public class ComicRepository : BaseRepository, IComicRepository
    {
        public ComicRepository(MarvelContext db) : base(db) { }

        public async Task<IEnumerable<Comic>> GetByCharacter(Guid characterId)
        {
            var query = $@"
                    SELECT C1.* FROM [Comic] C1
                    INNER JOIN [CharacterComics] CC ON CC.ComicId = C1.Id
                    INNER JOIN [Character] C2 ON C2.Id = CC.CharacterId
                    WHERE C2.[Id] = '{characterId}'";
            using (var conn = GetConnection())
            {
                conn.Open();
                return await conn.QueryAsync<Comic>(query);
            }
        }

        public async Task<IEnumerable<Comic>> GetAll()
        {
            var query = $"SELECT * FROM [Comic]";
            using (var conn = GetConnection())
            {
                conn.Open();
                return await conn.QueryAsync<Comic>(query);
            }
        }
    }
}