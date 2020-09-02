using CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Domain.Interfaces
{
    public interface IIndiceRepository
    {
        Task<Indice> AddIndice(Indice indice);
        Task<Indice> GetIndice(int indiceId);
        Task<int> GetTotalRecords();
        Task<List<Indice>> GetPairPAndQ(List<int> indices);
    }
}
