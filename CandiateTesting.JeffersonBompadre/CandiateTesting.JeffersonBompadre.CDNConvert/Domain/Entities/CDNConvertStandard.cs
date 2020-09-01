using CandiateTesting.JeffersonBompadre.CDNConvert.Domain.Dto;
using CandiateTesting.JeffersonBompadre.CDNConvert.Domain.Interfaces;
using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CandiateTesting.JeffersonBompadre.CDNConvert.Domain.Entities
{
    public class CDNConvertStandard : ICDNConvertStandard
    {
        public async Task<string> ConvertMinhaCDNToAgoraFormat(string cdnContent)
        {
            var toAgoraFormat = new StringBuilder(HeadOfFile());
            // Lê linha por linha do texto e converte para novo formato
            using var reader = new StringReader(cdnContent);
            var line = string.Empty;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                if (!string.IsNullOrEmpty(line))
                    toAgoraFormat.AppendLine(ConvertLineToAgoraFormat(line));
            }
            return toAgoraFormat.ToString();
        }

        string ConvertLineToAgoraFormat(string line)
        {
            // Faz Split da linha, separando:
            // 0 - Response-size
            // 1 - Status-code
            // 2 - Cache-status
            // 3 - String contendo: Http-Method, Uri-Path e Protocol
            // 4 - Time-taken
            var lineSplit = line.Split("|");
            var splitProtocol = SplitMethodUriAndProtocol(lineSplit[3]);
            var agoraDtoFormat = new AgoraDtoFormat()
            {
                ResponseSize = lineSplit[0],
                StatusCode = lineSplit[1],
                CacheStatus = lineSplit[2],
                TimeTaken = RoundTimeTaken(lineSplit[4]),
                HttpMethod = splitProtocol[0],
                UriPath = splitProtocol[1]
            };
            return MountResult(agoraDtoFormat);
        }

        string HeadOfFile()
        {
            var dateTimeFormated = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            var head = new StringBuilder();
            head.AppendLine("#Version: 1.0");
            head.AppendLine($"#Date: {dateTimeFormated}");
            head.AppendLine("#Fields: provider http-method status-code uri-path time-taken response-size cache-status");
            return head.ToString();
        }

        string[] SplitMethodUriAndProtocol(string str)
        {
            var strSplit = str.Split(" ");
            return new string[] { strSplit[0].Trim().Replace("\"", ""), strSplit[1].Trim() };
        }

        string RoundTimeTaken(string timeTaken)
        {
            decimal.TryParse(timeTaken.Trim(), NumberStyles.Any, new CultureInfo("en-US"),  out decimal roundTimeTaken);
            return decimal.Round(roundTimeTaken, 0).ToString();
        }

        string MountResult(AgoraDtoFormat agoraDtoFormat)
        {
            var lineResult = new StringBuilder();
            lineResult.Append($"{agoraDtoFormat.Provider} ");
            lineResult.Append($"{agoraDtoFormat.HttpMethod} ");
            lineResult.Append($"{agoraDtoFormat.StatusCode} ");
            lineResult.Append($"{agoraDtoFormat.UriPath} ");
            lineResult.Append($"{agoraDtoFormat.TimeTaken} ");
            lineResult.Append($"{agoraDtoFormat.ResponseSize} ");
            lineResult.Append($"{agoraDtoFormat.CacheStatus}");
            return lineResult.ToString();
        }
    }
}
