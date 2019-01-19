using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;

namespace EFCoreGraphQL.Data.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly MarvelContext _db;

        public BaseRepository(MarvelContext db)
        {
            _db = db;
        }

        protected IDbConnection GetConnection() => new SqlConnection(_db.Database.GetDbConnection().ConnectionString);
    }
}