using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspMVCWithIndividualAccounts.Startup))]
namespace AspMVCWithIndividualAccounts
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
