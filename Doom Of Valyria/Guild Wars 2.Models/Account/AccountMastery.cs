using Newtonsoft.Json;

namespace GuildWars2.Models.Account
{
    public class AccountMastery
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }

        public Mastery Mastery { get; set; }
    }
}