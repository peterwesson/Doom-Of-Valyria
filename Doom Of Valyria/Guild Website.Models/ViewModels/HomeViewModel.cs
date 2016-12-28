using System.Collections.Generic;

using GuildWars2.Models.Guilds;

namespace GuildWebsite.Models
{
    public class HomeViewModel
    {
        public List<GuildMember> GuildMembers { get; set; }

        public Guild Guild { get; set; }
    }
}