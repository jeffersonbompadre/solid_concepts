namespace CandiateTesting.JeffersonBompadre.CDNConvert.Domain.Dto
{
    public class AgoraDtoFormat
    {
        public AgoraDtoFormat()
        {
            Provider = "\"MINHA CDN\"";
        }

        public string Provider { get; set; }
        public string HttpMethod { get; set; }
        public string StatusCode { get; set; }
        public string UriPath { get; set; }
        public string TimeTaken { get; set; }
        public string ResponseSize { get; set; }
        public string CacheStatus { get; set; }
    }
}
