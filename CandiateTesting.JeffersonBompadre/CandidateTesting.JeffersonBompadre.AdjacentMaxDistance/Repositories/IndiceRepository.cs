using CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Domain.Interfaces;
using CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Domain.Model;
using CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Repositories
{
    public class IndiceRepository : IIndiceRepository
    {
        readonly DataContext _dataContext;

        public IndiceRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Indice> AddIndice(Indice indice)
        {
            await _dataContext.Indice.AddAsync(indice);
            return indice;
        }

        public async Task<Indice> GetIndice(int indiceId)
        {
            return await _dataContext.Indice.FirstOrDefaultAsync(x => x.Id == indiceId);
        }
    }
}
