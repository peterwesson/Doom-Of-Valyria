using Newtonsoft.Json;

using GuildWars2.Models.Core;

namespace GuildWars2.Models.Skills
{
    public class ComboFieldSkillFact : SkillFact
    {
        [JsonProperty("field_type")]
        public FieldType Fieldtype { get; set; }
    }
}