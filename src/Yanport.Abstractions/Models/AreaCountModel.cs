using Newtonsoft.Json;

namespace Devpro.Yanport.Abstractions.Models
{
    public class AreaCountModel
    {
        [JsonProperty("TERRACE")]
        public int Terrace { get; set; }
    }
}
