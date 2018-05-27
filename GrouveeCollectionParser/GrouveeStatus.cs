using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrouveeCollectionParser
{
    /// <summary>
    /// A status update for a game.</summary>  
    public class GrouveeStatus : URLItem
    {
        public override string Name
        {
            get => Date.ToShortDateString();
        }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("private")]
        public bool Private { get; set; }
    }
}
