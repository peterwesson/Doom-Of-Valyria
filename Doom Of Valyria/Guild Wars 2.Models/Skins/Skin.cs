using System.Collections.Generic;

using Newtonsoft.Json;

using GuildWars2.Models.JSON;
using GuildWars2.Models.Core;

namespace GuildWars2.Models.Skins
{
    [JsonConverter(typeof(SkinConverter))]
    public class Skin
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public SkinType Type { get; set; }

        [JsonProperty("flags")]
        public List<SkinFlags> Flags { get; set; }

        [JsonProperty("restrictions")]
        public List<Restrictions> Restrictions { get; set; }

        [JsonProperty("icon")]
        public string IconUrl { get; set; }

        [JsonProperty("rarity")]
        public Rarity Rarity { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}