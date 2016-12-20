using System.Collections.Generic;

using Newtonsoft.Json;

namespace GuildWars2.Models.Items
{
    public class Equipment
    {
        [JsonProperty("equipment")]
        public List<EquipmentItem> EquipmentItems { get; set; }
    }
}