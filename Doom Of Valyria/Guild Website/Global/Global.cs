using System.Threading.Tasks;

using GuildWars2.API;
using GuildWars2.Models.Core;
using GuildWars2.Models.Items;
using GuildWars2.Models.Skins;
using GuildWars2.Models.Account;
using GuildWars2.Models.Skills;

namespace GuildWebsite.Global
{
    public static class GlobalAssets
    {
        public static GenericCollection<int, Item> Items { get; set; }

        public static GenericCollection<int, Mastery> Masteries { get; set; }

        public static GenericCollection<int, Skin> Skins { get; set; }

        public static GenericCollection<int, Color> Colors { get; set; }

        public static GenericCollection<int, Skill> Skills { get; set; }

        public static GenericCollection<string, ProfessionInfo> Professions { get; set; }

        static GlobalAssets()
        {
            Items = new GenericCollection<int, Item>(id =>
            {
                using (var api = new GuildWars2API())
                {
                    return Task.Run(async () => await api.GetItem(id)).Result;
                }
            });

            Masteries = new GenericCollection<int, Mastery>(id =>
            {
                using (var api = new GuildWars2API())
                {
                    return Task.Run(async () => await api.GetMastery(id)).Result;
                }
            });

            Skins = new GenericCollection<int, Skin>(id =>
            {
                using (var api = new GuildWars2API())
                {
                    return Task.Run(async () => await api.GetSkin(id)).Result;
                }
            });

            Colors = new GenericCollection<int, Color>(id =>
            {
                using (var api = new GuildWars2API())
                {
                    return Task.Run(async () => await api.GetColor(id)).Result;
                }
            });

            Skills = new GenericCollection<int, Skill>(id =>
            {
                using (var api = new GuildWars2API())
                {
                    return Task.Run(async () => await api.GetSkill(id)).Result;
                }
            });

            Professions = new GenericCollection<string, ProfessionInfo>(id =>
            {
                using (var api = new GuildWars2API())
                {
                    return Task.Run(async () => await api.GetProfession(id)).Result;
                }
            });
        }
    }
}