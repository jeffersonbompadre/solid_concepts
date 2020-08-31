using CandiateTesting.JeffersonBompadre.CDNConvert.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace CandiateTesting.JeffersonBompadre.CDNConvert.Domain.Handlers
{
    public class CDNConvertHandler : ICDNConvertHandler
    {
        readonly ICDNRequest _cdnRequest;
        readonly ICDNConvertStandard _cdnConvertStandard;
        readonly IFileContent _fileContent;

        public CDNConvertHandler(ICDNRequest cdnRequest, ICDNConvertStandard cdnConvertStandard, IFileContent fileContent)
        {
            _cdnRequest = cdnRequest;
            _cdnConvertStandard = cdnConvertStandard;
            _fileContent = fileContent;
        }

        public async Task<string> ConvertPattern(string cdnUrl, string outPutPath)
        {
            var cdnContent = await _cdnRequest.GetCDNContent(cdnUrl);
            if (string.IsNullOrEmpty(cdnContent))
                throw new Exception("Nenhum conteúdo retornado. Não possível gerar o arquivo");
            var cdnNewFile = await _fileContent.SaveFile(cdnContent, outPutPath);
            return cdnNewFile;
        }
    }
}
