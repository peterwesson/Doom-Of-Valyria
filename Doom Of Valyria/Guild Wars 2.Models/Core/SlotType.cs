using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GuildWars2.Models.Core
{
    public enum SlotType
    {
        [JsonProperty("Downed_1")]
        Downed1,

        [JsonProperty("Downed_2")]
        Downed2,

        [JsonProperty("Downed_3")]
        Downed3,

        [JsonProperty("Downed_4")]
        Downed4,

        [JsonProperty("Profession_1")]
        Profession1,

        [JsonProperty("Profession_2")]
        Profession2,

        [JsonProperty("Profession_3")]
        Profession3,

        [JsonProperty("Profession_4")]
        Profession4,

        [JsonProperty("Profession_5")]
        Profession5,

        [JsonProperty("Utility")]
        Utility,

        [JsonProperty("Weapon_1")]
        Weapon_1,

        [JsonProperty("Weapon_2")]
        Weapon_2,

        [JsonProperty("Weapon_3")]
        Weapon_3,

        [JsonProperty("Weapon_4")]
        Weapon_4,

        [JsonProperty("Weapon_5")]
        Weapon_5,

        [JsonProperty("Heal")]
        Heal,

        [JsonProperty("Elite")]
        Elite
    }
}