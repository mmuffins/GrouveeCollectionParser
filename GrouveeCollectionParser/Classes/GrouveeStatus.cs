using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrouveeCollectionParser
{
    public class GrouveeStatus
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("private")]
        public bool Private { get; set; }
    }
}
