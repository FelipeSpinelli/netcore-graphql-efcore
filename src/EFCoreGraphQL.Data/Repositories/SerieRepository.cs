using Dapper;
using EFCoreGraphQL.Core.Data;
using EFCoreGraphQL.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCoreGraphQL.Data.Repositories
{
    public class SerieRepository : BaseRepository, ISerieRepository
    {
        public SerieRepository(MarvelContext db) : base(db) { }

        public async Task<IEnumerable<Serie>> GetByCharacter(Guid characterId)
        {
            var query = $@"
                    SELECT S.* FROM [Serie] S
                    INNER JOIN [CharacterSeries] CS ON CS.SerieId = S.Id
                    INNER JOIN [Character] C ON C.Id = CS.CharacterId
                    WHERE C.[Id] = '{characterId}'";
            using (var conn = GetConnection())
            {
                conn.Open();
                return await conn.QueryAsync<Serie>(query);
            }
        }

        public async Task<IEnumerable<Serie>> GetAll()
        {
            var query = $"SELECT * FROM [Serie]";
            using (var conn = GetConnection())
            {
                conn.Open();
                return await conn.QueryAsync<Serie>(query);
            }
        }
    }
}