using Newtonsoft.Json;

namespace TrainingSQL.Models
{
    public class ValueIndicator
    {
        [JsonProperty("max")]
        public int Max { get; set; }

        [JsonProperty("min")]
        public int Min { get; set; }

        [JsonProperty("avg")]
        public int Avg { get; set; }
    }
}