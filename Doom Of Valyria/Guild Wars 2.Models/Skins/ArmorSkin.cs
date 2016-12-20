using Newtonsoft.Json;

using GuildWars2.Models.Items;

namespace GuildWars2.Models.Skins
{
    public class ArmorSkin : Skin
    {
        [JsonProperty("subtype")]
        public ArmorType ArmorType { get; set; }

        [JsonProperty("weight_class")]
        public WeightClass WeightClass { get; set; }
    }
}