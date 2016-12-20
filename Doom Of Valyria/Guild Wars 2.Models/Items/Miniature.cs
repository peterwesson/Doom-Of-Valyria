using Newtonsoft.Json;

namespace GuildWars2.Models.Items
{
    public class Miniature : Item
    {
        [JsonProperty("minipet_id")]
        public int MinipetId { get; set; }
    }
}