using CandiateTesting.JeffersonBompadre.CDNConvert.Domain.Interfaces;
using System.IO;
using System.Threading.Tasks;

namespace CandiateTesting.JeffersonBompadre.CDNConvert.Domain.Entities
{
    public class FileContent : IFileContent
    {
        public async Task<string> SaveFile(string contentFile, string outPutPath)
        {
            var fullFilePath = ValidatePath(outPutPath);
            ValidatePathExists(fullFilePath);
            await File.WriteAllTextAsync(fullFilePath, contentFile);
            return fullFilePath;
        }

        string ValidatePath(string outPutPath)
        {
            var path = Path.GetDirectoryName(outPutPath);
            var fileName = Path.GetFileName(outPutPath);
            if (string.IsNullOrEmpty(fileName))
                outPutPath = Path.Combine(path, "AgoraCDNStandard.txt");
            return outPutPath;
        }

        void ValidatePathExists(string outPutPath)
        {
            var path = Path.GetDirectoryName(outPutPath);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }
    }
}
