using Newtonsoft.Json;

namespace GuildWars2.Models.Items
{
    public class GatheringTools : Item
    {
        [JsonProperty("subtype")]
        public GatheringToolsType GatheringToolsType { get; set; }
    }
}