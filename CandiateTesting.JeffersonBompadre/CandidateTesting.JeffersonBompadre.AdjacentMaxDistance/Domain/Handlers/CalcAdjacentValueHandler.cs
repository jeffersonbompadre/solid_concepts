using CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Domain.Handlers
{
    public class CalcAdjacentValueHandler : ICalcAdjacentValueHandler
    {
        readonly IIndiceRepository _indiceRepository;
        readonly IValuesInArrayRepository _valuesInArrayRepository;

        public CalcAdjacentValueHandler(IIndiceRepository indiceRepository, IValuesInArrayRepository valuesInArrayRepository)
        {
            _indiceRepository = indiceRepository;
            _valuesInArrayRepository = valuesInArrayRepository;
        }

        public async Task<int> CalcAdjacentMaxDistance()
        {
            var max = 0;
            var arrayCount = await _indiceRepository.GetTotalRecords();
            for (int i = 0; i < arrayCount; i++)
            {
                for (int y = 0; y < arrayCount - 1; y++)
                {
                    var adjacentValues = await _indiceRepository.GetPairPAndQ(new List<int> { i, y });
                    var aux = 0;
                    var p = adjacentValues.FirstOrDefault(x => x.Id == i).ValueInArray.Value;
                    var q = adjacentValues.FirstOrDefault(x => x.Id == y).ValueInArray.Value;
                    if (p > q)
                    {
                        aux = p;
                        p = q;
                        q = aux;
                    }
                    var v = await _valuesInArrayRepository.GetValuesBetween(p, q);
                    if (v.Count == 0)
                    {
                        var distance = Math.Abs(p - q);
                        max = Math.Max(max, distance);
                    }
                }
            }
            return max;
        }
    }
}
