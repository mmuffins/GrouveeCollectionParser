using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrouveeParser
{
    public enum LevelOfCompletion
    {
        NotSet,
        MainStory,
        MainStoryPlusExtras,
        FullyCompleted,
    }

    public class PlayedDate
    {
        [JsonProperty("level_of_completion", NullValueHandling = NullValueHandling.Ignore)]
        public LevelOfCompletion LevelofCompletion { get; set; }

        [JsonProperty("seconds_played")]
        public TimeSpan SecondsPlayed { get; set; }

        [JsonProperty("date_started")]
        [JsonConverter(typeof(GrouveeDateConverter))]
        public DateTime? DateStarted { get; set; }

        [JsonProperty("date_finished")]
        [JsonConverter(typeof(GrouveeDateConverter))]
        public DateTime? DateFinished { get; set; }

        public PlayedDate() { }

        public PlayedDate(string LevelofCompletion, long SecondsPlayed, string DateStarted, string DateFinished)
        {
            if (DateTime.TryParse(DateStarted, out DateTime dateStartedParsed))
            {
                this.DateStarted = dateStartedParsed;
            }

            if (DateTime.TryParse(DateFinished, out DateTime DateFinishedParsed))
            {
                this.DateFinished = DateFinishedParsed;
            }

            switch (LevelofCompletion)
            {
                case "100% Completion":
                    this.LevelofCompletion = LevelOfCompletion.FullyCompleted;
                    break;
                case "Main Story":
                    this.LevelofCompletion = LevelOfCompletion.MainStory;
                    break;
                case "Main Story + Extras":
                    this.LevelofCompletion = LevelOfCompletion.MainStoryPlusExtras;
                    break;
                case "null":
                default:
                    this.LevelofCompletion = LevelOfCompletion.NotSet;
                    break;
            }

            // Incorrect entries can result in playtimes higher than the int max, 
            // we therefore need to cast accordingly
            long hours = SecondsPlayed / 3600;
            long restSeconds = SecondsPlayed - (hours * 3600);
            this.SecondsPlayed = new TimeSpan((int)hours, 0, (int)restSeconds);
        }
    }

    // Converts the the provided string to datetime if the string has a valid format
    public class GrouveeDateConverter : JsonConverter
    {
        public override bool CanRead
        {
            get => true;
        }

        public override bool CanWrite
        {
            get => false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string value = serializer.Deserialize<string>(reader);

            if (DateTime.TryParse(value, out DateTime result))
            {
                return result;
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }

}
