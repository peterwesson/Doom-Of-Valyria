using System.Collections.Generic;

using Newtonsoft.Json;

namespace GuildWars2.Models.Core
{
    public class WeaponProfessionInfo
    {
        [JsonProperty("specialization")]
        public int? Specialization { get; set; }

        [JsonProperty("skills")]
        public List<WeaponSkill> Skills { get; set; }
    }
}