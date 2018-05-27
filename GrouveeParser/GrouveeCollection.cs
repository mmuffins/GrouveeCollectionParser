using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrouveeParser
{
    public class GrouveeCollection
    {

        public List<GrouveeGame> Games { get; set; }

        public GrouveeGame this[int index]
        {
            get => Games[index];
            set => Games[index] = value;
        }

        public GrouveeCollection()
        {
            Games = new List<GrouveeGame>();
        }

        public void AddGame(GrouveeGame game)
        {
            Games.Add(game);
        }

        public async static Task<GrouveeCollection> ImportAsync(string FilePath)
        {
            var collection = new GrouveeCollection();
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
                    collection.AddGame(game);
                }

            }

            return collection;
        }
    }
}
