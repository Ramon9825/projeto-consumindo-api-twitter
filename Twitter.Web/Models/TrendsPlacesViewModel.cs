using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Twitter.Web.Models
{
    public class TrendsPlacesViewModel
    {
        [JsonProperty(PropertyName = "trends")]
        public IEnumerable<TrendsViewModel> trends { get; set; }

        [JsonProperty(PropertyName = "as_of")]
        public DateTime as_of { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public DateTime created_at { get; set; }

        [JsonProperty(PropertyName = "locations")]
        public IEnumerable<LocalizacaoViewModel> locations { get; set; }
    }
}
