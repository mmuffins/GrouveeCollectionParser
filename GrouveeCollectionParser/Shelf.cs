using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrouveeCollectionParser
{
    public class Shelf : URLItem
    {
        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("date_added")]
        public DateTime DateAdded { get; set; }
    }

}
