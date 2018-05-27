using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrouveeCollectionParser
{
    public class URLItem
    {
        public virtual string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
