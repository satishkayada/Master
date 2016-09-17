using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(master.Startup))]
namespace master
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
