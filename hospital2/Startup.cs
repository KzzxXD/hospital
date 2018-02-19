using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(hospital2.Startup))]
namespace hospital2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
