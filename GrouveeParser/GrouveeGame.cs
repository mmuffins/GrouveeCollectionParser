using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrouveeParser
{
    public class GrouveeGame
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int? Rating { get; set; }
        public string ReleaseDate { get; set; }
        public string URL { get; set; }
        public string GiantBombId { get; set; }

        //[JsonExtensionData]
        //public IDictionary<object, object> Genres { get; set; }
        public string Genres { get; set; }

    }

    public class GrouveeGameMap : ClassMap<GrouveeGame>
    {
        public GrouveeGameMap()
        {
            Map(m => m.Id).Name("id");
            Map(m => m.Name).Name("name");
            Map(m => m.Rating).Name("rating");
            Map(m => m.ReleaseDate).Name("release_date");
            Map(m => m.URL).Name("url");
            Map(m => m.GiantBombId).Name("giantbomb_id");
            Map(m => m.Genres).Name("genres");

            //Map(m => m.Genres).ConvertUsing(row =>
            //{
            //    IReaderRow a = row;
            //    var x = row.GetField("genres");

            //    return x ;

            //    //JsonConvert.DeserializeObject<IDictionary<object, object>>(m.Genres)
            //});
        }
    }
}
