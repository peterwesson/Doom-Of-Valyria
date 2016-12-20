using System.Collections.Generic;

using Newtonsoft.Json;

using GuildWars2.Models.JSON;
using GuildWars2.Models.Core;

namespace GuildWars2.Models.Items
{
    [JsonConverter(typeof(ItemConverter))]
    public class Item
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("chat_link")]
        public string ChatLink { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon")]
        public string IconUrl { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("type")]
        public ItemType Type { get; set; }

        [JsonProperty("rarity")]
        public Rarity Rarity { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("vendor_value")]
        public int VendorValue { get; set; }

        [JsonProperty("default_skin")]
        public int? DefaultSkinId { get; set; }

        [JsonProperty("flags")]
        public List<ItemFlag> Flags { get; set; }

        [JsonProperty("game_types")]
        public List<GameType> GameTypes { get; set; }

        [JsonProperty("restrictions")]
        public List<Restrictions> Restrictions { get; set; }
    }
}