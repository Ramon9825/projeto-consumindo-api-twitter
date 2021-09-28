using Newtonsoft.Json;

namespace Twitter.Web.Models
{
    public class TipoLugarViewModel
    {
        [JsonProperty(PropertyName = "code")]
        public int code { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }
    }
}
