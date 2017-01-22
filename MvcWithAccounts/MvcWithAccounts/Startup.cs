using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcWithAccounts.Startup))]
namespace MvcWithAccounts
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
