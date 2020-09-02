using CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Domain.Interfaces;
using CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Repositories.Context;
using System.Threading.Tasks;

namespace CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Domain.Uow
{
    public class UnitDataContext : IUnitDataContext
    {
        readonly DataContext _dataContext;

        public UnitDataContext(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Commit()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}
