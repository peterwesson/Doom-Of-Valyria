using Newtonsoft.Json;

namespace GuildWars2.Models.Skills
{
    public class NumberSkillFact : SkillFact
    {
        [JsonProperty("value")]
        public int Value { get; set; }
    }
}