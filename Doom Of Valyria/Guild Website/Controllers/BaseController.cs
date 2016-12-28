using System.Web.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System.Configuration;

using GuildWars2.API;

using GuildWebsite.Global;

namespace GuildWebsite.Controllers
{
    public abstract class BaseController : Controller
    {
        protected string APIkey { get; set; }

        protected BaseController()
        {
            APIkey = ConfigurationManager.AppSettings["GuildLeaderApiKey"];
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["Guild"] == null)
            {
                using (var api = new GuildWars2API(APIkey))
                {
                    var guildId = ConfigurationManager.AppSettings["GuildId"];

                    var guild = Task.Run(async () => await api.GetGuild(guildId)).Result;

                    guild.Emblem.Background.ColorDetails = guild.Emblem.Background.Colors.Select(colorId => GlobalAssets.Colors[colorId]).Where(color => color != null).ToList();
                    guild.Emblem.Foreground.ColorDetails = guild.Emblem.Foreground.Colors.Select(colorId => GlobalAssets.Colors[colorId]).Where(color => color != null).ToList();

                    filterContext.HttpContext.Session["Guild"] = guild;
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}