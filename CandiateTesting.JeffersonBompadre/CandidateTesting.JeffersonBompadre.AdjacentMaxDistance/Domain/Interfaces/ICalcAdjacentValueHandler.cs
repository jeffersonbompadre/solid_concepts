using System.Threading.Tasks;

namespace CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Domain.Interfaces
{
    public interface ICalcAdjacentValueHandler
    {
        Task<int> CalcAdjacentMaxDistance();
    }
}
