using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(GuildWebsite.Startup))]
namespace GuildWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}