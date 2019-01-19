using Dapper;
using EFCoreGraphQL.Core.Data;
using EFCoreGraphQL.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreGraphQL.Data.Repositories
{
    public class CharacterRepository : BaseRepository, ICharacterRepository
    {
        public CharacterRepository(MarvelContext db) : base(db) { }

        public Character Get(int marvelId)
        {
            var query = $"SELECT * FROM [Character] WHERE [MarvelId] = {marvelId}";
            using (var conn = GetConnection())
            {
                conn.Open();
                return conn.Query<Character>(query).FirstOrDefault();
            }
        }

        public async Task<IEnumerable<Character>> GetAll()
        {
            var query = $"SELECT * FROM [Character]";
            using (var conn = GetConnection())
            {
                conn.Open();
                return await conn.QueryAsync<Character>(query);
            }
        }

        public async Task<IEnumerable<Character>> GetByComic(Guid comicId)
        {
            var query = $@"
                    SELECT C1.* FROM [Character] C1
                    INNER JOIN [CharacterComics] CC ON CC.CharacterId = C1.Id
                    INNER JOIN [Comic] C2 ON C2.Id = CC.ComicId
                    WHERE C2.[Id] = '{comicId}'";
            using (var conn = GetConnection())
            {
                conn.Open();
                return await conn.QueryAsync<Character>(query);
            }
        }

        public async Task<IEnumerable<Character>> GetByEvent(Guid eventId)
        {
            var query = $@"
                    SELECT C.* FROM [Character] C
                    INNER JOIN [CharacterEvents] CE ON CE.CharacterId = C.Id
                    INNER JOIN [Event] E ON E.Id = CE.EventId
                    WHERE E.[Id] = '{eventId}'";
            using (var conn = GetConnection())
            {
                conn.Open();
                return await conn.QueryAsync<Character>(query);
            }
        }

        public async Task<IEnumerable<Character>> GetBySerie(Guid serieId)
        {
            var query = $@"
                    SELECT C.* FROM [Character] C
                    INNER JOIN [CharacterSeries] CS ON CS.CharacterId = C.Id
                    INNER JOIN [Serie] S ON S.Id = CS.SerieId
                    WHERE S.[Id] = '{serieId}'";
            using (var conn = GetConnection())
            {
                conn.Open();
                return await conn.QueryAsync<Character>(query);
            }
        }
    }
}