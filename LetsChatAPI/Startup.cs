using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(LetsChatAPI.Startup))]

namespace LetsChatAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
