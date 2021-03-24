using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DrinkIt.Startup))]
namespace DrinkIt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
