using System.Collections.Generic;

using Newtonsoft.Json;

namespace GuildWars2.Models.Core
{
    public class ColorDetails
    {
        [JsonProperty("brightness")]
        public float Brightness { get; set; }

        [JsonProperty("contrast")]
        public float Contrast { get; set; }

        [JsonProperty("hue")]
        public float Hue { get; set; }

        [JsonProperty("saturation")]
        public float Saturation { get; set; }

        [JsonProperty("lightness")]
        public float Lightness { get; set; }

        [JsonProperty("rgb")]
        public List<int> RGB { get; set; }

        public string HexColor
        {
            get
            {
                var color = System.Drawing.Color.FromArgb(RGB[0], RGB[1], RGB[2]);

                return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
            }
        }
    }
}