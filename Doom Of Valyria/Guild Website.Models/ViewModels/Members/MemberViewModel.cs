using System.Collections.Generic;

using GuildWars2.Models.Account;
using GuildWars2.Models.Core;

namespace GuildWebsite.Models.ViewModels.Members
{
    public class MemberViewModel
    {
        public AccountInfo AccountInfo { get; set; }

        public List<Character> Characters { get; set; }
    }
}