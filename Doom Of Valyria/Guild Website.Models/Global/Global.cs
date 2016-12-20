using System.Collections.Generic;

using GuildWars2.Models.Account;
using GuildWars2.Models.Core;

namespace GuildWebsite.Models.Global
{
    public class Global
    {
        public Dictionary<int, Mastery> Masteries { get; set; }

        public Dictionary<int, Color> Colors { get; set; }

        public Global()
        {
            Masteries = new Dictionary<int, Mastery>();

            Colors = new Dictionary<int, Color>();
        }
    }
}