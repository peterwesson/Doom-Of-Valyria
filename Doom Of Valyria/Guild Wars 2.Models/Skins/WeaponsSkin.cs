using Newtonsoft.Json;

using GuildWars2.Models.Items;
using GuildWars2.Models.Core;

namespace GuildWars2.Models.Skins
{
    public class WeaponSkin : Skin
    {
        [JsonProperty("subtype")]
        public WeaponType WeaponType { get; set; }

        [JsonProperty("damage_type")]
        public DamageType DamageType { get; set; }
    }
}