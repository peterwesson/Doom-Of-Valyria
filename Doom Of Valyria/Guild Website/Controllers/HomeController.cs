using System.Web.Mvc;
using System.Configuration;

namespace GuildWebsite.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Twitch()
        {
            var twitchChannel = ConfigurationManager.AppSettings["TwitchChannel"];
            return View("Twitch", null, twitchChannel);
        }
    }
}