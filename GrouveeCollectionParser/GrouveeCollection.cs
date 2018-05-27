using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrouveeCollectionParser
{
    /// <summary>
    /// Imports and parses a grouvee collection .csv file.</summary>  
    public static class GrouveeCollection
    {
        /// <summary>
        /// Imports and parses a grouvee collection .csv file.</summary>  
        public async static Task<List<GrouveeGame>> ImportAsync(string FilePath)
        {
            var collection = new List<GrouveeGame>();
            using (var fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var streamReader = new StreamReader(fileStream))
            {
                var csv = new CsvReader(streamReader);
                csv.Configuration.Delimiter = ",";
                csv.Configuration.Encoding = Encoding.UTF8;
                csv.Configuration.RegisterClassMap<GrouveeGameMap>();

                await csv.ReadAsync();
                csv.ReadHeader();
                //var field = csv.GetField(0);
                while(await csv.ReadAsync()){
                    var game = csv.GetRecord<GrouveeGame>();
                    collection.Add(game);
                }
            }

            return collection;
        }
    }
}
