using Newtonsoft.Json;

namespace TrainingSQL.Models
{
    public class OfficialLanguage
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("IsOfficial")]
        public bool IsOfficial { get; set; }
    }
}