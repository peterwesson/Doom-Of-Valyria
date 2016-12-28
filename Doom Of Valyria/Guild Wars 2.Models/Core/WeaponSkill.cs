using Newtonsoft.Json;

using GuildWars2.Models.Items;
using GuildWars2.Models.Skills;

namespace GuildWars2.Models.Core
{
    public class WeaponSkill
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("slot")]
        public SlotType Slot { get; set; }

        [JsonProperty("offhand")]
        public WeaponType Offhand { get; set; }

        [JsonProperty("attunement")]
        public AttunementType Attunement { get; set; }

        public Skill Skill { get; set; }
    }
}