using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PracticaMailMVC.Startup))]
namespace PracticaMailMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
