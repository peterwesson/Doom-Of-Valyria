using Newtonsoft.Json;

namespace GuildWars2.Models.Items
{
    public class Bag : Item
    {
        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("no_sell_or_sort")]
        public bool NoSellOrSort { get; set; }
    }
}