using System.Collections.Generic;

using Newtonsoft.Json;

namespace GuildWars2.Models.Account
{
    public class Mastery
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("requirement")]
        public string Requirement { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("background")]
        public string Background { get; set; }

        [JsonProperty("regions")]
        public string Regions{ get; set; }

        [JsonProperty("levels")]
        public List<MasteryLevel> Levels { get; set; }
    }
}