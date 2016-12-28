using Newtonsoft.Json;

namespace GuildWars2.Models.Skills
{
    public class SkillGroup
    {
        [JsonProperty("pve")]
        public SkillSet PvE { get; set; }

        [JsonProperty("pvp")]
        public SkillSet PvP { get; set; }

        [JsonProperty("wvw")]
        public SkillSet WvW { get; set; }
    }
}