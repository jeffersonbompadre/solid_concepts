using System.Threading.Tasks;

namespace CandiateTesting.JeffersonBompadre.CDNConvert.Domain.Interfaces
{
    public interface ICDNConvertHandler
    {
        Task<string> ConvertPattern(string cdnUrl, string outPutPath);
    }
}
