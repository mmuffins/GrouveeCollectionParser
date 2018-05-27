using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrouveeCollectionParser
{
    /// <summary>
    /// Generic class for items containing a name and url.</summary>  
    public class URLItem
    {
        public virtual string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
