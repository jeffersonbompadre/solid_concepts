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

            Console.WriteLine($"Iniciando o cálculo Maior vaor Adjacente {DateTime.Now}");
            AdjacentMaxDistanceFromBase();
            
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
    }
}