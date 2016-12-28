using System.Collections.Generic;

using Newtonsoft.Json;

using GuildWars2.Models.Items;
using GuildWars2.Models.Core;

namespace GuildWars2.Models.Skills
{
    public class Skill
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("chat_link")]
        public string ChatLink { get; set; }

        [JsonProperty("type")]
        public SkillType Type { get; set; }

        [JsonProperty("weapon_type")]
        public WeaponType WeaponType { get; set; }

        [JsonProperty("professions")]
        public List<Profession> Professions { get; set; }

        [JsonProperty("slot")]
        public SlotType Slot { get; set; }

        [JsonProperty("facts")]
        public List<SkillFact> Facts { get; set; }

        [JsonProperty("traited_facts")]
        public List<TraitedFact> TraitedFacts { get; set; }

        [JsonProperty("categories")]
        public List<SkillCategories> Categories { get; set; }

        [JsonProperty("attunement")]
        public AttunementType Attunement { get; set; }

        [JsonProperty("cost")]
        public int Cost { get; set; }

        [JsonProperty("dual_wield")]
        public WeaponType? DualWield { get; set; }

        [JsonProperty("flip_skill")]
        public int? FlipSkill { get; set; }

        [JsonProperty("initiative")]
        public int? Initiative { get; set; }

        [JsonProperty("next_chain")]
        public int? NextChain { get; set; }

        [JsonProperty("prev_chain")]
        public int? PrevChain { get; set; }

        [JsonProperty("transform_skills")]
        public List<int> TransformSkills{ get; set; }

        [JsonProperty("bundle_skills")]
        public List<int> BundleSkills { get; set; }

        [JsonProperty("toolbelt_skills")]
        public List<int> ToolbeltSkills { get; set; }
    }
}