using CandiateTesting.JeffersonBompadre.CDNConvert.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace CandiateTesting.JeffersonBompadre.CDNConvert.Domain.Entities
{
    public class CDNConvertStandard : ICDNConvertStandard
    {
        public Task<string> ConvertMinhaCDNToAgoraFormat(string cdnContent)
        {
            throw new NotImplementedException();
        }
    }
}
