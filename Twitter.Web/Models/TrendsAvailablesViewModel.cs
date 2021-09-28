using Newtonsoft.Json;
using Twitter.Web.Interfaces;

namespace Twitter.Web.Models
{
    public class TrendsAvailablesViewModel : ITrends
    {
        [JsonProperty(PropertyName = "country")]
        public string country { get; set; }

        [JsonProperty(PropertyName = "countryCode")]
        public string countryCode { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }

        [JsonProperty(PropertyName = "parentid")]
        public int parentid { get; set; }

        [JsonProperty(PropertyName = "placeType")]
        public TipoLugarViewModel placeType { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string url { get; set; }

        [JsonProperty(PropertyName = "woeid")]
        public int woeid { get; set; }
    }
}
