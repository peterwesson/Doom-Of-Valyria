using Newtonsoft.Json;

namespace GuildWars2.Models.Skills
{
    public class DamageSkillFact : SkillFact
    {
        [JsonProperty("hit_count")]
        public int HitCount { get; set; }

        [JsonProperty("dmg_multiplier")]
        public decimal DamageMultiplier { get; set; }
    }
}