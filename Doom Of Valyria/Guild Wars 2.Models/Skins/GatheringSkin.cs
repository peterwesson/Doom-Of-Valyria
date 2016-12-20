using Newtonsoft.Json;

using GuildWars2.Models.Items;

namespace GuildWars2.Models.Skins
{
    public class GatheringSkin : Skin
    {
        [JsonProperty("subtype")]
        public GatheringToolsType GatheringType { get; set; }
    }
}