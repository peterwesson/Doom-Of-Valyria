using System.Collections.Generic;

using Newtonsoft.Json;

namespace GuildWars2.Models.Core
{
    public class Color
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("base_rgb")]
        public List<int> BaseRGB { get; set; }

        [JsonProperty("cloth")]
        public ColorDetails Cloth { get; set; }

        [JsonProperty("leather")]
        public ColorDetails Leather { get; set; }

        [JsonProperty("metal")]
        public ColorDetails Metal { get; set; }

        [JsonProperty("item")]
        public int Item { get; set; }

        [JsonProperty("categories")]
        public List<ColorCategories> Categories { get; set; }

        public string HexColor
        {
            get
            {
                var color =  System.Drawing.Color.FromArgb(BaseRGB[0], BaseRGB[1], BaseRGB[2]);

                return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
            }
        }
    }
}