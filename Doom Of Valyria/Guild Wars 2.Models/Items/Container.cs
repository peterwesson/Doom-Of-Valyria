using Newtonsoft.Json;

namespace GuildWars2.Models.Items
{
    public class Container : Item
    {
        [JsonProperty("subtype")]
        public ContainerType ContainerType { get; set; }
    }
}