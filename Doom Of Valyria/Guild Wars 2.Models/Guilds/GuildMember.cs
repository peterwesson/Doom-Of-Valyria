using System;

using Newtonsoft.Json;

namespace GuildWars2.Models.Guilds
{
    public class GuildMember
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("rank")]
        public string Rank { get; set; }

        [JsonProperty("joined")]
        public DateTime Joined { get; set; }
    }
}