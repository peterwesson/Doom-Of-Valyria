using Newtonsoft.Json;

namespace GuildWars2.Models.Skills
{
    public class DistanceSkillFact : SkillFact
    {
        [JsonProperty("distance")]
        public int Distance{ get; set; }
    }
}