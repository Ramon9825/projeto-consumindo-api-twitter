using Newtonsoft.Json;

namespace Twitter.Web.Models
{
    public class ItemViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "tweets")]
        public int? Tweets { get; set; }

    }
}
