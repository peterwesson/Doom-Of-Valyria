using System.Collections.Generic;

using Newtonsoft.Json;

using GuildWars2.Models.Items;

namespace GuildWars2.Models.Core
{
    public class ProfessionInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("icon_big")]
        public string IconBig { get; set; }

        [JsonProperty("specializations")]
        public List<int> Specializations{ get; set; }

        //ToDo: Training

        [JsonProperty("weapons")]
        public Dictionary<WeaponType, WeaponProfessionInfo> Weapons { get; set; }
    }
}