using CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Domain.Handlers
{
    public sealed class CalcAdjacentValueHandler : ICalcAdjacentValueHandler
    {
        static int maxValue = 0;
        readonly IQueryRepository _queryRepository;

        public CalcAdjacentValueHandler(IQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<int> CalcAdjacentMaxDistance()
        {
            var max = 0;
            var arrayCount = await _queryRepository.GetTotalRecords();
            for (int i = 0; i < arrayCount - 1; i++)
            {
                for (int y = i + 1; y < arrayCount; y++)
                {
                    var adjacentValues = await _queryRepository.GetPairPAndQ(new List<int> { i, y });
                    var aux = 0;
                    var p = adjacentValues.FirstOrDefault(x => x.Id == i).Value_Array;
                    var q = adjacentValues.FirstOrDefault(x => x.Id == y).Value_Array;
                    if (p > q)
                    {
                        aux = p;
                        p = q;
                        q = aux;
                    }
                    var v = await _queryRepository.GetValuesBetween(p, q);
                    if (v.Count() == 0)
                    {
                        var distance = Math.Abs(p - q);
                        max = Math.Max(max, distance);
                    }
                }
            };
            return max;
        }
    }
}
