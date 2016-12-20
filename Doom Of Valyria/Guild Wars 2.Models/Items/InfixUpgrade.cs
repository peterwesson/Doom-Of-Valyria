using System.Collections.Generic;

using Newtonsoft.Json;

using GuildWars2.Models.Core;

namespace GuildWars2.Models.Items
{
    public class InfixUpgrade
    {
        [JsonProperty("attributes")]
        public List<Attribute> Attributes { get; set; }

        [JsonProperty("buff")]
        public UpgradeBuff Buff { get; set; }
    }
}