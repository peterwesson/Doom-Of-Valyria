using Newtonsoft.Json;

namespace GuildWars2.Models.Skills
{
    public class TimeSkillFact : SkillFact
    {
        [JsonProperty("duration")]
        public int Duration{ get; set; }
    }
}