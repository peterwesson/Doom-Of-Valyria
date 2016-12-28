using Newtonsoft.Json;

using GuildWars2.Models.JSON;

namespace GuildWars2.Models.Skills
{
    [JsonConverter(typeof(SkillFactConverter))]
    public class SkillFact
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("type")]
        public SkillFactType Type { get; set; }
    }
}