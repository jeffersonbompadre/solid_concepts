using CandiateTesting.JeffersonBompadre.CDNConvert.Domain.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace CandiateTesting.JeffersonBompadre.CDNConvert.Domain.Entities
{
    public class CDNRequest : ICDNRequest
    {
        /// <summary>
        /// Faz uma requisição HTTP para CDN e retorna seu conteúdo
        /// </summary>
        /// <param name="cdnURL"></param>
        /// <returns></returns>
        public async Task<string> GetCDNContent(string cdnURL)
        {
            using var httpClient = new HttpClient();
            //httpClient.BaseAddress = new Uri();
            var response = await httpClient.GetAsync(cdnURL);
            return (response.StatusCode == System.Net.HttpStatusCode.OK)
                ? await response.Content.ReadAsStringAsync()
                : string.Empty;
        }
    }
}
