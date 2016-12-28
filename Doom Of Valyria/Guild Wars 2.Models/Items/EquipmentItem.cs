using System.Collections.Generic;

using Newtonsoft.Json;

using GuildWars2.Models.Skins;

namespace GuildWars2.Models.Items
{
    public class EquipmentItem
    {
        [JsonProperty("id")]
        public int ItemId { get; set; }

        [JsonProperty("slot")]
        public EquipmentSlot Slot{ get; set; }

        [JsonProperty("infusions")]
        public List<int> InfusionIds { get; set; }

        [JsonProperty("skin")]
        public int? SkinId { get; set; }

        [JsonProperty("stats")]
        public EquipmentStats Stats { get; set; }

        [JsonProperty("upgrades")]
        public List<int> UpgradeIds { get; set; }

        [JsonProperty("binding")]
        public Binding Binding { get; set; }

        [JsonProperty("bound_to")]
        public string BoundTo { get; set; }

        public Item Item { get; set; }

        public Skin Skin{ get; set; }

        public List<UpgradeComponent> Upgrades { get; set; }

        public List<UpgradeComponent> Infusions { get; set; }
    }
}