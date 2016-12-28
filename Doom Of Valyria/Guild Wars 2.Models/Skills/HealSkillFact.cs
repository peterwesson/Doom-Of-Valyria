using Newtonsoft.Json;

namespace GuildWars2.Models.Skills
{
    public class HealSkillFact : SkillFact
    {
        [JsonProperty("hit_count")]
        public int HitCount { get; set; }
    }
}