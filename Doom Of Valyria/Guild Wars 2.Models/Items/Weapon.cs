using System.Collections.Generic;

using Newtonsoft.Json;

using GuildWars2.Models.Core;

namespace GuildWars2.Models.Items
{
    public class Weapon : Item, IInfixUpgradeable
    {
        [JsonProperty("subtype")]
        public WeaponType WeaponType { get; set; }

        [JsonProperty("damage_type")]
        public DamageType DamageType { get; set; }

        [JsonProperty("min_power")]
        public int MinPower { get; set; }

        [JsonProperty("max_power")]
        public int MaxPower { get; set; }

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

        [JsonProperty("stat_choices")]
        public List<string> StatChoices { get; set; }
    }
}