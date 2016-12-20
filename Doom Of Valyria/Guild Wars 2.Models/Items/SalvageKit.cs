using Newtonsoft.Json;

namespace GuildWars2.Models.Items
{
    public class SalvageKit : Item
    {
        [JsonProperty("subtype")]
        public SalvageKitType SalvageKitType { get; set; }

        [JsonProperty("charges")]
        public int Charges { get; set; }
    }
}