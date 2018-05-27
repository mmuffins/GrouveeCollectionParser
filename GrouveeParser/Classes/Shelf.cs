using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrouveeParser
{
    public class Shelf
    {
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("date_added")]
        public DateTime DateAdded { get; set; }
    }

}
