using Newtonsoft.Json;

namespace GuildWars2.Models.Core
{
    public class Attribute
    {
        [JsonProperty("attribute")]
        public AttributeType Type { get; set; }

        [JsonProperty("modifier")]
        public int Modifier { get; set; }
    }
}