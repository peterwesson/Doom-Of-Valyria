using Newtonsoft.Json;

namespace GuildWars2.Models.Skills
{
    public class UnblockableSkillFact : SkillFact
    {
        [JsonProperty("value")]
        public bool Value { get; set; }
    }
}