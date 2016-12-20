using System.Collections.Generic;

using Newtonsoft.Json;

namespace GuildWars2.Models.Items
{
    public class UpgradeComponent : Item
    {
        [JsonProperty("subtype")]
        public UpgradeComponentType UpgradeComponentType { get; set; }

        [JsonProperty("subflags")]
        public List<UpgradeComponentFlags> UpgradeComponentFlags { get; set; }

        [JsonProperty("infusion_upgrade_flags")]
        public List<InfusionUpgradeFlags> InfusionUpgradeFlags { get; set; }

        [JsonProperty("suffix")]
        public string Suffix { get; set; }

        [JsonProperty("infix_upgrade")]
        public InfixUpgrade InfixUgrade { get; set; }

        [JsonProperty("bonuses")]
        public List<string> Bonuses { get; set; }
    }
}