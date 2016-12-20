using System.Web.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System.Configuration;

using GuildWars2.API;

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
            if (GuildWebsite.Global.Masteries.Count == 0)
            {
                using (var api = new GuildWars2API(APIkey))
                {
                    var masteries = Task.Run(async () => await api.GetMasteries()).Result;
                    GuildWebsite.Global.Masteries = masteries.ToDictionary(mastery => mastery.Id);
                }
            }

            if (GuildWebsite.Global.Colors.Count == 0)
            {
                using (var api = new GuildWars2API(APIkey))
                {
                    var colors = Task.Run(async () => await api.GetColors()).Result;
                    GuildWebsite.Global.Colors = colors.ToDictionary(color => color.Id);
                }
            }

            if (filterContext.HttpContext.Session["Guild"] == null)
            {
                using (var api = new GuildWars2API(APIkey))
                {
                    var guildId = ConfigurationManager.AppSettings["GuildId"];

                    var guild = Task.Run(async () => await api.GetGuild(guildId)).Result;

                    guild.Emblem.Background.ColorDetails = guild.Emblem.Background.Colors.Select(colorId => GuildWebsite.Global.Colors[colorId]).Where(color => color != null).ToList();
                    guild.Emblem.Foreground.ColorDetails = guild.Emblem.Foreground.Colors.Select(colorId => GuildWebsite.Global.Colors[colorId]).Where(color => color != null).ToList();

                    filterContext.HttpContext.Session["Guild"] = guild;
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}