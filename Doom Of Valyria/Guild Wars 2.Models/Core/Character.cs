using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using GuildWars2.Models.Items;
using GuildWars2.Models.Skills;

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

        [JsonProperty("equipment")]
        public List<EquipmentItem> Equipment { get; set; }

        [JsonProperty("skills")]
        public SkillGroup Skills { get; set; }


        public EquipmentItem WeaponA1 { get; set; }

        public EquipmentItem WeaponA2 { get; set; }

        public EquipmentItem WeaponB1 { get; set; }

        public EquipmentItem WeaponB2 { get; set; }


        public EquipmentItem Helm { get; set; }

        public EquipmentItem Shoulders { get; set; }

        public EquipmentItem Coat { get; set; }

        public EquipmentItem Gloves { get; set; }

        public EquipmentItem Leggings { get; set; }

        public EquipmentItem Boots { get; set; }


        public EquipmentItem Backpiece { get; set; }

        public EquipmentItem Accessory1 { get; set; }

        public EquipmentItem Accessory2 { get; set; }

        public EquipmentItem Amulet { get; set; }

        public EquipmentItem Ring1 { get; set; }

        public EquipmentItem Ring2 { get; set; }


        public ProfessionInfo ProfessionInfo { get; set; }
    }
}