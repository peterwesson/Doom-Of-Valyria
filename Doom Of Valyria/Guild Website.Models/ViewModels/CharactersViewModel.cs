using System.Collections.Generic;

using GuildWars2.Models.Core;
using GuildWars2.Models.Guilds;

namespace GuildWebsite.Models
{
    public class CharactersViewModel
    {
        public List<Character> Characters { get; set; }

        public Guild Guild { get; set; }
    }
}