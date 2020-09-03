using Microsoft.Data.Sqlite;

namespace CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Repositories
{
    public abstract class SqLiteDapperBaseRepository
    {
        protected SqLiteDapperBaseRepository(string dbFile)
        {
            SqliteConnection = new SqliteConnection(dbFile);
        }

        public SqliteConnection SqliteConnection { get; }
    }
}
