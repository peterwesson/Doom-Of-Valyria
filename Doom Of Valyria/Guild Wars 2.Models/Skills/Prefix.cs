using Newtonsoft.Json;

namespace GuildWars2.Models.Skills
{
    public class Prefix
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}