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
            // Caso tenha sido passado a quantidade de registros a serem inseridas
            // irá montar um arquivo com o Array e Valores a serem utilizados
            // para o cálculo do maior valo adjascente.
            if (args.Count() == 1)
                MountDataArray(int.Parse(args[0]));
            AdjacentMaxDistanceFromBase();
            
            //Usado apenas para teste de lógica montada para cálculo da distância adjacente
            //AdjacentMaxDistance(MountArray(1000));
            Console.ReadKey();
        }

        /// <summary>
        /// Método faz chamada para SeedValues onde monta um arquivo SQLite com N Elements no array
        /// </summary>
        /// <param name="countElements"></param>
        static void MountDataArray(int countElements)
        {
            var seedValues = BootstrapInjection.GetServiceCollection().GetService<ISeedValuesInArrayHandler>();
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var task = Task.Run(async () => await seedValues.SeedValues(countElements));
            var qtdeRecords = task.Result;
            stopWatch.Stop();
            var ts = stopWatch.Elapsed;
            var elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:000}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            Console.WriteLine($"Registros: {qtdeRecords}, Tempo: {elapsedTime}");
        }

        /// <summary>
        /// Método faz chamada para Calcular maior distância adjacente do arquivo SQLite
        /// </summary>
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

        /// <summary>
        /// Monta um array local, para teste de lógica de cálculo distância adjacente (somente local)
        /// </summary>
        /// <param name="countElements"></param>
        /// <returns></returns>
        public static int[] MountArray(int countElements)
        {
            var random = new Random();
            var adjacentArray = new int[countElements];
            Parallel.For(0, countElements, i =>
            {
                adjacentArray[i] = random.Next(1, 40000);
            });
            return adjacentArray;
            //return new int[] { 0, 3, 3, 7, 5, 3, 11, 1 };
            //                   1  2  2  3  4  2  5   6
        }

        /// <summary>
        /// Faz cálculo da maior distância adjacente de um array teste de lógica (somente local)
        /// </summary>
        /// <param name="adjacentArray"></param>
        /// <returns></returns>
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