using System.Collections.Generic;

namespace CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Domain.Model
{
    public class ValueInArray
    {
        public int Id { get; set; }
        public int Value { get; set; }

        public List<Indice> Indices { get; set; } = new List<Indice>();
    }
}
