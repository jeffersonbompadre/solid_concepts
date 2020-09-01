using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTesting.JeffersonBompadre.AdjacentMaxDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = MountArray();
            var maxDistance = AdjacentMaxDistance(arr);
            Console.WriteLine(maxDistance);
            Console.ReadKey();
        }

        public static int[] MountArray()
        {
            var adjacentArray = new int[1000];
            var ramdom = new Random();
            Parallel.For(0, adjacentArray.Length, x =>
            {
                adjacentArray[x] = ramdom.Next(400000);
            });
            return adjacentArray;
            //return new int[] { 0, 3, 3, 7, 5, 3, 11, 1 };
        }

        public static int AdjacentMaxDistance(int[] adjacentArray)
        {
            var max = 0;
            Parallel.For(0, adjacentArray.Length - 1, x =>
            {
                Parallel.For(x + 1, adjacentArray.Length, y =>
                {
                    var aux = 0;
                    var p = adjacentArray[x];
                    var q = adjacentArray[y];
                    if (p > q)
                    {
                        aux = p;
                        p = q;
                        q = aux;
                    }
                    var v = adjacentArray
                        .Where(v => v > p && v < q)
                        .Select(x => x)
                        .ToList();
                    if (v.Count == 0)
                    {
                        var distance = Math.Abs(p - q);
                        max = Math.Max(max, distance);
                    }
                });
            });
            return max;
        }
    }
}