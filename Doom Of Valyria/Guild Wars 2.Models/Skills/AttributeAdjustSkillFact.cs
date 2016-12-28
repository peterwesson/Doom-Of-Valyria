using Newtonsoft.Json;

using GuildWars2.Models.Core;

namespace GuildWars2.Models.Skills
{
    public class AttributeAdjustSkillFact : SkillFact
    {
        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("target")]
        public AttributeType Target { get; set; }
    }
}