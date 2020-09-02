using CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Domain.Interfaces;
using CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Domain.Model;
using CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Repositories
{
    public class ValuesInArrayRepository : IValuesInArrayRepository
    {
        readonly DataContext _dataContext;

        public ValuesInArrayRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ValueInArray> AddValueInArray(ValueInArray valueInArray)
        {
            await _dataContext.ValueInArray.AddAsync(valueInArray);
            return valueInArray;
        }

        public async Task<ValueInArray> GetByValue(int value)
        {
            return await _dataContext.ValueInArray.FirstOrDefaultAsync(x => x.Value == value);
        }

        public async Task<List<int>> GetValuesBetween(int beginValue, int endValue)
        {
            return await _dataContext.ValueInArray
                .Where(v => v.Value > beginValue && v.Value < endValue)
                .Select(x => x.Value)
                .ToListAsync();
        }
    }
}
