using CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Domain.Interfaces
{
    public interface IValuesInArrayRepository
    {
        Task<ValueInArray> AddValueInArray(ValueInArray valueInArray);
        Task<ValueInArray> GetByValue(int value);
    }
}
