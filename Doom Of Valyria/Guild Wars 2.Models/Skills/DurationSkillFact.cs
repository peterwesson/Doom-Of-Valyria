using Newtonsoft.Json;

namespace GuildWars2.Models.Skills
{
    public class DurationSkillFact : SkillFact
    {
        [JsonProperty("duration")]
        public int Duration{ get; set; }
    }
}