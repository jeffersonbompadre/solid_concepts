using CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Domain.Handlers
{
    public class CalcAdjacentValueHandler
    {
        readonly IIndiceRepository _indiceRepository;
        readonly IValuesInArrayRepository _valuesInArrayRepository;

        public CalcAdjacentValueHandler(IIndiceRepository indiceRepository, IValuesInArrayRepository valuesInArrayRepository)
        {
            _indiceRepository = indiceRepository;
            _valuesInArrayRepository = valuesInArrayRepository;
        }


    }
}
