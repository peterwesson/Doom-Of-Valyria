using System.Collections.Generic;

using Newtonsoft.Json;

namespace GuildWars2.Models.Items
{
    public class Trinket : Item
    {
        [JsonProperty("subtype")]
        public TrinketType TrinketType { get; set; }

        [JsonProperty("infusion_slots")]
        public List<InfusionSlot> InfusionSlots { get; set; }

        [JsonProperty("infix_upgrade")]
        public InfixUpgrade InfixUgrade { get; set; }

        [JsonProperty("suffix_item_id")]
        public int? SuffixItemId { get; set; }

        [JsonProperty("secondary_suffix_item_id")]
        public string SecondarySuffixItemId { get; set; }

        [JsonProperty("stat_choices")]
        public List<string> StatChoices { get; set; }
    }
}