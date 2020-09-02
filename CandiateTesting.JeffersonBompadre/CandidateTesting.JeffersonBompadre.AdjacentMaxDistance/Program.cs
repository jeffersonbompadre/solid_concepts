using CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Configuration;
using CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CandidateTesting.JeffersonBompadre.AdjacentMaxDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            //MountDataArray();
            AdjacentMaxDistanceFromBase();
            AdjacentMaxDistance(MountArray());
            Console.ReadKey();
        }

        static void MountDataArray()
        {
            var seedValues = BootstrapInjection.GetServiceCollection().GetService<ISeedValuesInArrayHandler>();
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var task = Task.Run(async () => await seedValues.SeedValues(8));
            var qtdeRecords = task.Result;
            stopWatch.Stop();
            var ts = stopWatch.Elapsed;
            var elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:000}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            Console.WriteLine($"Registros: {qtdeRecords}, Tempo: {elapsedTime}");
        }

        static void AdjacentMaxDistanceFromBase()
        {
            var calcAdjacent = BootstrapInjection.GetServiceCollection().GetService<ICalcAdjacentValueHandler>();
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var task = Task.Run(async () => await calcAdjacent.CalcAdjacentMaxDistance());
            var maxValue = task.Result;
            stopWatch.Stop();
            var ts = stopWatch.Elapsed;
            var elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:000}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            Console.WriteLine($"Maior distância (DB): {maxValue}, Tempo: {elapsedTime}");
        }

        #region Method Calc Adjacent Value From Array

        public static int[] MountArray()
        {
            return new int[] { 0, 3, 3, 7, 5, 3, 11, 1 };
        }

        public static int AdjacentMaxDistance(int[] adjacentArray)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
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
            stopWatch.Stop();
            var ts = stopWatch.Elapsed;
            var elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:000}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            Console.WriteLine($"Maior distância: {max}, Tempo: {elapsedTime}");
            return max;
        }

        #endregion
    }
}