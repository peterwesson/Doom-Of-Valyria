using Newtonsoft.Json;

namespace GuildWars2.Models.Skills
{
    public class HealingAdjustSkillFact : SkillFact
    {
        [JsonProperty("hit_count")]
        public int HitCount { get; set; }
    }
}