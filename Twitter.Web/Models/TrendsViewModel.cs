using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twitter.Web.Interfaces;

namespace Twitter.Web.Models
{
    public class TrendsViewModel : ITrends
    {
        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string url { get; set; }

        [JsonProperty(PropertyName = "promoted_content")]
        public string promoted_content { get; set; }

        [JsonProperty(PropertyName = "query")]
        public string query { get; set; }

        [JsonProperty(PropertyName = "tweet_volume")]
        public int? tweet_volume { get; set; }
    }
}
