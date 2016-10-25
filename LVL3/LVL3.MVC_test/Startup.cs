using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LVL3.MVC_test.Startup))]
namespace LVL3.MVC_test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
