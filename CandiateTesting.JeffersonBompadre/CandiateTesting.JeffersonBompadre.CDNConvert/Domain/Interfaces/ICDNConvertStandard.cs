using System.Threading.Tasks;

namespace CandiateTesting.JeffersonBompadre.CDNConvert.Domain.Interfaces
{
    public interface ICDNConvertStandard
    {
        Task<string> ConvertMinhaCDNToAgoraFormat(string cdnContent);
    }
}
