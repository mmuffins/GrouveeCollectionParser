﻿using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrouveeCollectionParser
{
    /// <summary>
    /// Represents a game and its properties.</summary>  
    public class GrouveeGame
    {
        public List<URLItem> Developers { get; set; }

        public List<URLItem> Franchises { get; set; }

        public List<URLItem> Genres { get; set; }

        public string GiantBombId { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public List<URLItem> Platforms { get; set; }

        public List<URLItem> Publishers { get; set; }

        public int? Rating { get; set; }

        public string ReleaseDate { get; set; }

        public string Review { get; set; }

        public List<Shelf> Shelves { get; set; }

        public string URL { get; set; }

        public List<Playthrough> Playthroughs { get; set; }

        public List<GrouveeStatus> Statuses { get; set; }
    }

    public class GrouveeGameMap : ClassMap<GrouveeGame>
    {
        public GrouveeGameMap()
        {
            Map(m => m.Id).Name("id");
            Map(m => m.GiantBombId).Name("giantbomb_id");
            Map(m => m.Name).Name("name");
            Map(m => m.Rating).Name("rating");
            Map(m => m.ReleaseDate).Name("release_date");
            Map(m => m.URL).Name("url");
            Map(m => m.Review).Name("review");


            Map(m => m.Genres).ConvertUsing(row =>
            {
                // The field is provided as list of properties in the format of
                // {[Key1] : {url: [value1]}, [KeyN] : {url: [valueN]}}
                // To get it, get the field contents as json string, deserialize
                // the string to an dictonary, and create items from the dictionary items
                string value = row.GetField("genres");

                return JsonConvert.DeserializeObject<Dictionary<string, JObject>>(value)
                    .Select(x => new URLItem() { Name = x.Key, Url = x.Value["url"].Value<string>() })
                    .ToList();
            });

            Map(m => m.Franchises).ConvertUsing(row =>
            {
                string value = row.GetField("franchises");
                return JsonConvert.DeserializeObject<Dictionary<string, JObject>>(value)
                    .Select(x => new URLItem() { Name = x.Key, Url = x.Value["url"].Value<string>() })
                    .ToList();
            });

            Map(m => m.Developers).ConvertUsing(row =>
            {
                string value = row.GetField("developers");
                return JsonConvert.DeserializeObject<Dictionary<string, JObject>>(value)
                    .Select(x => new URLItem() { Name = x.Key, Url = x.Value["url"].Value<string>() })
                    .ToList();
            });

            Map(m => m.Publishers).ConvertUsing(row =>
            {
                string value = row.GetField("publishers");
                return JsonConvert.DeserializeObject<Dictionary<string, JObject>>(value)
                    .Select(x => new URLItem() { Name = x.Key, Url = x.Value["url"].Value<string>() })
                    .ToList();
            });

            Map(m => m.Platforms).ConvertUsing(row =>
            {
                string value = row.GetField("platforms");
                return JsonConvert.DeserializeObject<Dictionary<string, JObject>>(value)
                    .Select(x => new URLItem() { Name = x.Key, Url = x.Value["url"].Value<string>() })
                    .ToList();
            });

            Map(m => m.Shelves).ConvertUsing(row =>
            {
                string value = row.GetField("shelves");
                IEnumerable<JToken> jTokens = JObject.Parse(value).Children();
                return jTokens.Select(x => 
                    {
                        var newShelf = x.First.ToObject<Shelf>();
                        newShelf.Name = x.Path;
                        return newShelf;
                    }).ToList();

            });

            Map(m => m.Playthroughs).ConvertUsing(row =>
            {
                string value = row.GetField("dates");
                if (value == "[]")
                {
                    return new List<Playthrough>();
                }

                var jTokens = JArray.Parse(value);

                var result = jTokens.Select(x =>
                {
                    return new Playthrough(x.Value<String>("level_of_completion"), x.Value<long>("seconds_played"), x.Value<String>("date_started"), x.Value<String>("date_finished"));
                }).ToList();

                return result;
            });

            Map(m => m.Statuses).ConvertUsing(row =>
            {
                string value = row.GetField("statuses");
                if (value == "[]")
                {
                    return new List<GrouveeStatus>();
                }

                var jTokens = JArray.Parse(value);

                return jTokens.Select(x => x.ToObject<GrouveeStatus>()).ToList();
            });
        }
    }
}
