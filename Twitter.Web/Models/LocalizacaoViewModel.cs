using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Twitter.Web.Models
{
    public class LocalizacaoViewModel
    {
        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }

        [JsonProperty(PropertyName = "woeid")]
        public int woeid { get; set; }
    }
}
