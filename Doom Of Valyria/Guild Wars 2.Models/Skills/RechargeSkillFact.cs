using Newtonsoft.Json;

namespace GuildWars2.Models.Skills
{
    public class RechargeSkillFact : SkillFact
    {
        [JsonProperty("value")]
        public int Value { get; set; }
    }
}
