using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Blogger.UI.Web.Startup))]
namespace Blogger.UI.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
