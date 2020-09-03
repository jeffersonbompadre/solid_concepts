using CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Domain.QueryResult;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Domain.Interfaces
{
    public interface IQueryRepository
    {
        Task<int> GetTotalRecords();
        Task<IEnumerable<IndiceResult>> GetPairPAndQ(IEnumerable<int> indices);
        Task<IEnumerable<int>> GetValuesBetween(int beginValue, int endValue);
    }
}
