using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_70325_Dolbik_Vorobei.Startup))]
namespace _70325_Dolbik_Vorobei
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
