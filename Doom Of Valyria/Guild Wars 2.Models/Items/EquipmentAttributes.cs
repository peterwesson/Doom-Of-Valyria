using Newtonsoft.Json;

namespace GuildWars2.Models.Items
{
    public class EquipmentAttributes
    {
        [JsonProperty("Power")]
        public int Power { get; set; }

        [JsonProperty("Precision")]
        public int Precision { get; set; }

        [JsonProperty("Toughness")]
        public int Toughness { get; set; }

        [JsonProperty("Vitality")]
        public int Vitality { get; set; }

        [JsonProperty("ConditionDamage")]
        public int ConditionDamage { get; set; }

        [JsonProperty("ConditionDuration")]
        public int ConditionDuration { get; set; }

        [JsonProperty("Healing")]
        public int HealingPower { get; set; }

        [JsonProperty("BoonDuration")]
        public int BoonDuration { get; set; }
    }
}