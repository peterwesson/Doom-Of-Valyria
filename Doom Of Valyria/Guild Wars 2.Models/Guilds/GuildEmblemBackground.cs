using System.Collections.Generic;

using Newtonsoft.Json;

using GuildWars2.Models.Core;

namespace GuildWars2.Models.Guilds
{
    public class GuildEmblemBackground
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("colors")]
        public List<int> Colors { get; set; }

        public List<Color> ColorDetails { get; set; }

        public GuildEmblemInfo BackgroundInfo { get; set; }
    }
}