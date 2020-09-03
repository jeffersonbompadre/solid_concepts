using CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Domain.Interfaces;
using CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Domain.QueryResult;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Repositories
{
    public class QueryRepository : SqLiteDapperBaseRepository, IQueryRepository
    {
        public QueryRepository(string dbFile) : base(dbFile)
        {
            SqliteConnection.Open();
        }

        public async Task<int> GetTotalRecords()
        {
            var result = await SqliteConnection.QueryAsync<int>("SELECT COUNT(Indice_Id) FROM TBL_Indice");
            return result.First();
        }

        public async Task<IEnumerable<IndiceResult>> GetPairPAndQ(IEnumerable<int> indices)
        {
            var result = await SqliteConnection.QueryAsync<IndiceResult>(
                @$"SELECT IND.Indice_Id AS Id, VAA.Value_Array
                   FROM TBL_Indice IND
                   JOIN TBL_ValueArray VAA ON IND.Value_Id = VAA.Value_Id
                   WHERE IND.Indice_Id IN ({string.Join(',', indices)})");
            return result;
        }

        public async Task<IEnumerable<int>> GetValuesBetween(int beginValue, int endValue)
        {
            var result = await SqliteConnection.QueryAsync<int>(
                @$"SELECT Value_Array
                   FROM TBL_ValueArray
                   WHERE Value_Array > {beginValue} AND Value_Array < {endValue}");
            return result;
        }
    }
}
