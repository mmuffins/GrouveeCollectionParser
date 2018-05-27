using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrouveeParser.Classes
{
    public class Genre
    {
        [JsonProperty("Action")]
        public Action Action { get; set; }

        [JsonProperty("Platformer")]
        public Action Platformer { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

}
