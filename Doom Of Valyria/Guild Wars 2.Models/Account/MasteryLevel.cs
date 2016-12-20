using Newtonsoft.Json;

namespace GuildWars2.Models.Account
{
    public class MasteryLevel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description{ get; set; }

        [JsonProperty("instruction")]
        public string Instruction { get; set; }

        [JsonProperty("icon")]
        public string IconUrl { get; set; }

        [JsonProperty("point_cost")]
        public int PointCost { get; set; }

        [JsonProperty("exp_cost")]
        public int ExpCost { get; set; }
    }
}