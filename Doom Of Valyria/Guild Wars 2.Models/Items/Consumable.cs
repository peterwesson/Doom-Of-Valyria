using Newtonsoft.Json;

namespace GuildWars2.Models.Items
{
    public class Consumable : Item
    {
        [JsonProperty("subtype")]
        public ConsumableType ConsumableType { get; set; }

        [JsonProperty("subdescription")]
        public string ConsumableDescription { get; set; }

        [JsonProperty("duration_ms")]
        public int? Duration { get; set; }

        [JsonProperty("unlock_type")]
        public ConsumableUnlockType UnlockType { get; set; }

        [JsonProperty("color_id")]
        public int? ColorId { get; set; }

        [JsonProperty("recipe_id")]
        public int? RecipeId { get; set; }

        [JsonProperty("apply_count")]
        public int? ApplyCount { get; set; }

        [JsonProperty("subname")]
        public string ConsumableName { get; set; }
    }
}