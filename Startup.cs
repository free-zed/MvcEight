using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcEight.Startup))]
namespace MvcEight
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
