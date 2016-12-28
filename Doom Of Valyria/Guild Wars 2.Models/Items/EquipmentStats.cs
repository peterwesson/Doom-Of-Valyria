using Newtonsoft.Json;

namespace GuildWars2.Models.Items
{
    public class EquipmentStats
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("attributes")]
        public EquipmentAttributes Attributes { get; set; }
    }
}