using System.Collections.Generic;

using Newtonsoft.Json;

namespace GuildWars2.Models.Items
{
    public class Armor : Item
    {
        [JsonProperty("subtype")]
        public ArmorType ArmorType { get; set; }

        [JsonProperty("weight_class")]
        public WeightClass WeightClass { get; set; }

        [JsonProperty("defense")]
        public int Defense { get; set; }

        [JsonProperty("infusion_slots")]
        public List<InfusionSlot> InfusionSlots { get; set; }

        [JsonProperty("infix_upgrade")]
        public InfixUpgrade InfixUpgrade { get; set; }

        [JsonProperty("suffix_item_Id")]
        public int? SuffixItemId { get; set; }

        [JsonProperty("secondary_suffix_item_Id")]
        public int? SecondarySuffixItemId { get; set; }

        [JsonProperty("stat_choises")]
        public List<string> StatChoices { get; set; }
    }
}