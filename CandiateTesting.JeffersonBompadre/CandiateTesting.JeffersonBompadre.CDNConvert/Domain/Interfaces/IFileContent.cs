using System.Threading.Tasks;

namespace CandiateTesting.JeffersonBompadre.CDNConvert.Domain.Interfaces
{
    public interface IFileContent
    {
        Task<string> SaveFile(string contentFile, string outPutPath);
    }
}
