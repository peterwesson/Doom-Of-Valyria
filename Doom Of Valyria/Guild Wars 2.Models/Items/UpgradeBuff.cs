using Newtonsoft.Json;

namespace GuildWars2.Models.Items
{
    public class UpgradeBuff
    {
        [JsonProperty("skill_id")]
        public int SkillId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}