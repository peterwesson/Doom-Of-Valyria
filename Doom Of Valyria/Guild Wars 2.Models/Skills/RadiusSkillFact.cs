using Newtonsoft.Json;

namespace GuildWars2.Models.Skills
{
    public class RadiusSkillFact : SkillFact
    {
        [JsonProperty("distance")]
        public int Distance { get; set; }
    }
}