using Newtonsoft.Json;

namespace GuildWars2.Models.Skills
{
    public class TraitedFact
    {
        [JsonProperty("requires_trait")]
        public int RequiresTrait { get; set; }

        [JsonProperty("overrides")]
        public int? Overrides { get; set; }
    }
}