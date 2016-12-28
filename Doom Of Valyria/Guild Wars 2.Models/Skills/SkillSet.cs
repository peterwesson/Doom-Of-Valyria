using System.Collections.Generic;

using Newtonsoft.Json;

namespace GuildWars2.Models.Skills
{
    public class SkillSet
    {
        [JsonProperty("heal")]
        public int? Heal { get; set; }

        [JsonProperty("utilities")]
        public List<int?> Utilities { get; set; }

        [JsonProperty("elite")]
        public int? Elite { get; set; }

        public Skill HealSkill { get; set; }

        public Skill UtilitySkill1 { get; set; }

        public Skill UtilitySkill2 { get; set; }

        public Skill UtilitySkill3 { get; set; }

        public Skill EliteSkill { get; set; }
    }
}