using System.Collections.Generic;

using Newtonsoft.Json;

namespace GuildWars2.Models.Items
{
    public class InfusionSlot
    {
        [JsonProperty("flags")]
        public List<InfusionSlotFlag> Flags { get; set; }

        [JsonProperty("item_id")]
        public int? ItemId { get; set; }

    }
}