using CandiateTesting.JeffersonBompadre.CDNConvert.Domain.Configuration;
using CandiateTesting.JeffersonBompadre.CDNConvert.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CandiateTesting.JeffersonBompadre.CDNConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            var cdnURL = "https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt";
            var outPutPath = Path.Combine(Environment.CurrentDirectory, @"outputCDN\newCDN.txt");
            if (args.Count() == 1 && !string.IsNullOrEmpty(args[0]))
                cdnURL = args[0];
            if (args.Count() > 1 && !string.IsNullOrEmpty(args[1]))
                outPutPath = args[1];

            try
            {
                // Inicializa o Handler de Conversão e executa o processo
                var cdnConvert = BootstrapInjection.GetServiceCollection().GetService<ICDNConvertHandler>();
                var task = Task.Run(async () => await cdnConvert.ConvertPattern(cdnURL, outPutPath));
                var content = task.Result;
                Console.WriteLine($"Arquivo gerado em {content}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Algum erro inesperado ocorreu. {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}
