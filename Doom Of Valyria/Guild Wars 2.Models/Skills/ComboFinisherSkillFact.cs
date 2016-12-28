using Newtonsoft.Json;

using GuildWars2.Models.Core;

namespace GuildWars2.Models.Skills
{
    public class ComboFinisherSkillFact : SkillFact
    {
        [JsonProperty("percent")]
        public decimal Percent { get; set; }

        [JsonProperty("finisher_tpye")]
        public FinisherType FinisherType { get; set; }
    }
}