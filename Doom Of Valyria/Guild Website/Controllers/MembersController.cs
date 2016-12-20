using System.Web.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

using GuildWars2.API;
using GuildWars2.Models.Guilds;
using GuildWars2.Models.Account;

using GuildWebsite.Models.ViewModels.Members;

namespace GuildWebsite.Controllers
{
    public class MembersController : BaseController
    {
        public MembersController() : base()
        {

        }

        public async Task<ActionResult> Index()
        {
            using (var api = new GuildWars2API(APIkey))
            {
                var guild = System.Web.HttpContext.Current.Session["Guild"] as Guild;
                
                var members = await api.GetGuildMembers(guild.Id);

                return View(members);
            }
        }

        public async Task<ActionResult> Member(string id, int? minLevel = null)
        {
            using (var api = new GuildWars2API(APIkey))
            {
                var accountInfoTask = api.GetAccount();
                var charactersTask = api.GetCharacters();

                await Task.WhenAll(new List<Task> { accountInfoTask, charactersTask });

                var viewModel = new MemberViewModel
                {
                    AccountInfo = accountInfoTask.Result,
                    Characters = charactersTask.Result.ToList()
                };

                foreach (var accountMastery in viewModel.AccountInfo.Masteries)
                {
                    accountMastery.Mastery = (GuildWebsite.Global.Masteries as Dictionary<int, Mastery>)[accountMastery.Id];
                }

                return View(viewModel);
            }
        }
    }
}