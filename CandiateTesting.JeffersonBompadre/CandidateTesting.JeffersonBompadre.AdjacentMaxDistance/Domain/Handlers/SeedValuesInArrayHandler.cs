using CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Domain.Interfaces;
using CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Domain.Handlers
{
    public class SeedValuesInArrayHandler : ISeedValuesInArrayHandler
    {
        readonly IUnitDataContext _unitDataContext;
        readonly IIndiceRepository _indiceRepository;
        readonly IValuesInArrayRepository _valuesInArrayRepository;

        public SeedValuesInArrayHandler(IUnitDataContext unitDataContext, IIndiceRepository indiceRepository, IValuesInArrayRepository valuesInArrayRepository)
        {
            _unitDataContext = unitDataContext;
            _indiceRepository = indiceRepository;
            _valuesInArrayRepository = valuesInArrayRepository;
        }

        public async Task<int> SeedValues(int arrayLength)
        {
            var random = new Random();
            var indice_id = 0;
            var value_id = 0;
            var tasks = new List<Task>();
            for (int i = 0; i < arrayLength; i++)
            {
                await Task.Run(async () =>
                {
                    var value = random.Next(400000);
                    var indice = await _indiceRepository.GetIndice(i);
                    if (indice == null)
                    {
                        var valueInArray = await _valuesInArrayRepository.GetByValue(value);
                        if (valueInArray == null)
                            valueInArray = await _valuesInArrayRepository.AddValueInArray(new ValueInArray { Id = ++value_id, Value = value });
                        indice = new Indice { Id = indice_id++, ValueInArray = valueInArray };
                        await _indiceRepository.AddIndice(indice);
                        await _unitDataContext.Commit();
                    }
                });
            };
            var result = await Task.FromResult(indice_id);
            return result;
        }
    }
}
