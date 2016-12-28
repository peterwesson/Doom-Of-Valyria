﻿using Newtonsoft.Json;

namespace GuildWars2.Models.Skills
{
    public class PrefixedBuffOrConditionSkillFact : SkillFact
    {
        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("status")]
        public BuffOrConditionType Status { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("apply_count")]
        public int ApplyCount { get; set; }

        [JsonProperty("prefix")]
        public Prefix Prefix { get; set; }
    }
}