using Newtonsoft.Json;

namespace GuildWars2.Models.Guilds
{
    public class Guild
    {
        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("motd")]
        public string MessageOfTheDay { get; set; }

        [JsonProperty("influence")]
        public int Influence { get; set; }

        [JsonProperty("aetherium")]
        public string Aetherium { get; set; }

        [JsonProperty("favor")]
        public int Favor { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("emblem")]
        public GuildEmblem Emblem { get; set; }
    }
}