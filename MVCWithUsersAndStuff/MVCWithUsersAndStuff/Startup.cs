using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCWithUsersAndStuff.Startup))]
namespace MVCWithUsersAndStuff
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
