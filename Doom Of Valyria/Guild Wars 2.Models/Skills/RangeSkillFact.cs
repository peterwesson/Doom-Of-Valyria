using Newtonsoft.Json;

namespace GuildWars2.Models.Skills
{
    public class RangeSkillFact : SkillFact
    {
        [JsonProperty("value")]
        public int Value { get; set; }
    }
}