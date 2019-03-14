using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Manhonga.WebUI.Startup))]
namespace Manhonga.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
