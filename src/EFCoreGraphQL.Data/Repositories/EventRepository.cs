using Dapper;
using EFCoreGraphQL.Core.Data;
using EFCoreGraphQL.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCoreGraphQL.Data.Repositories
{
    public class EventRepository : BaseRepository, IEventRepository
    {
        public EventRepository(MarvelContext db) : base(db) { }

        public async Task<IEnumerable<Event>> GetByCharacter(Guid characterId)
        {
            var query = $@"
                    SELECT E.* FROM [Event] E
                    INNER JOIN [CharacterEvents] CE ON CE.EventId = E.Id
                    INNER JOIN [Character] C ON C.Id = CE.CharacterId
                    WHERE C.[Id] = '{characterId}'";
            using (var conn = GetConnection())
            {
                conn.Open();
                return await conn.QueryAsync<Event>(query);
            }
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            var query = $"SELECT * FROM [Event]";
            using (var conn = GetConnection())
            {
                conn.Open();
                return await conn.QueryAsync<Event>(query);
            }
        }
    }
}