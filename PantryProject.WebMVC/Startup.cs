using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PantryProject.WebMVC.Startup))]
namespace PantryProject.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
