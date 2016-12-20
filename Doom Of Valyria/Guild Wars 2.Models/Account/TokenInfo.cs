using System.Collections.Generic;

using Newtonsoft.Json;

namespace GuildWars2.Models.Account
{
    public class TokenInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("permissions")]
        public List<Permissions> Permission { get; set; }
    }
}
