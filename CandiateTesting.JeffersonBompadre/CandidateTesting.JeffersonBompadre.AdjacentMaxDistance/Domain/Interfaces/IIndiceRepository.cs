using CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Domain.Model;
using System.Threading.Tasks;

namespace CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Domain.Interfaces
{
    public interface IIndiceRepository
    {
        Task<Indice> AddIndice(Indice indice);
        Task<Indice> GetIndice(int indiceId);
    }
}
