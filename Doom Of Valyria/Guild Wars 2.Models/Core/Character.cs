using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using GuildWars2.Models.Items;

namespace GuildWars2.Models.Core
{
    public class Character
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("race")]
        public Race Race { get; set; }

        [JsonProperty("gender")]
        public Gender Gender { get; set; }

        [JsonProperty("profession")]
        public Profession Profession { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("guild")]
        public string Guild { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("created")]
        public DateTime DateCreated { get; set; }

        [JsonProperty("deaths")]
        public string Deaths { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        public List<EquipmentItem> Equipment { get; set; }
    }
}
