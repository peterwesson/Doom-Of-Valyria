using Newtonsoft.Json;

namespace GuildWars2.Models.Skills
{
    public class PercentSkillFact : SkillFact
    {
        [JsonProperty("percent")]
        public int Percent { get; set; }
    }
}