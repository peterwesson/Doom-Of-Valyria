using System.Collections.Generic;

using Newtonsoft.Json;

namespace GuildWars2.Models.Guilds
{
    public class GuildEmblemInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("layers")]
        public List<string> Layers { get; set; }
    }
}