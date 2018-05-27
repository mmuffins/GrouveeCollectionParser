using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrouveeCollectionParser
{
    /// <summary>
    /// Represents a game shelf in a collection.</summary>  
    public class Shelf : URLItem
    {
        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("date_added")]
        public DateTime DateAdded { get; set; }
    }

}
