using System.Threading.Tasks;

namespace CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Domain.Interfaces
{
    public interface ISeedValuesInArrayHandler
    {
        /// <summary>
        /// Método para popular o arquivo SQLite com um número informado de elementos no array
        /// </summary>
        /// <param name="arrayLength"></param>
        /// <returns></returns>
        Task<int> SeedValues(int arrayLength);
    }
}
