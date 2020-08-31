using System.Threading.Tasks;

namespace CandiateTesting.JeffersonBompadre.CDNConvert.Domain.Interfaces
{
    public interface ICDNRequest
    {
        Task<string> GetCDNContent(string cdnURL);
    }
}
