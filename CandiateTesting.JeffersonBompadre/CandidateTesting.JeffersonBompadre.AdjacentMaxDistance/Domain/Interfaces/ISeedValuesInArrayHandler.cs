using System.Threading.Tasks;

namespace CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Domain.Interfaces
{
    public interface ISeedValuesInArrayHandler
    {
        Task<int> SeedValues(int arrayLength);
    }
}
