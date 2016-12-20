using System.Collections.Generic;

using Newtonsoft.Json;

namespace GuildWars2.Models.Guilds
{
    public class GuildEmblem
    {
        [JsonProperty("background")]
        public GuildEmblemBackground Background { get; set; }

        [JsonProperty("foreground")]
        public GuildEmblemForegroud Foreground { get; set; }

        [JsonProperty("flag")]
        public List<GuildEmblemFlags> Flags { get; set; }
    }
}