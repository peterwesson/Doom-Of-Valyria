using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace GuildWars2.Models.Account
{
    public class AccountInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("world")]
        public int World { get; set; }

        [JsonProperty("commander")]
        public bool IsCommander { get; set; }

        [JsonProperty("guilds")]
        public List<string> Guilds { get; set; }

        [JsonProperty("created")]
        public DateTime DateCreated { get; set; }

        [JsonProperty("access")]
        public Access Access { get; set; }

        [JsonProperty("fractal_level")]
        public int FractalLevel { get; set; }

        [JsonProperty("daily_ap")]
        public int DailyAchievementPoints { get; set; }

        [JsonProperty("monthly_ap")]
        public int MonthlyAchievementPoints { get; set; }

        public List<AccountMastery> Masteries { get; set; }
    }
}