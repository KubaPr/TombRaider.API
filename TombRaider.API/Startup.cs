using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(TombRaider.API.Startup))]

namespace TombRaider.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
