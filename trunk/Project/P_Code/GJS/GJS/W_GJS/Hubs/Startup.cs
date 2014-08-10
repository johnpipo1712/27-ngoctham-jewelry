using Owin;
using Microsoft.Owin;
[assembly: OwinStartup(typeof(W_GJS.Hubs.Startup))]

namespace W_GJS.Hubs
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}