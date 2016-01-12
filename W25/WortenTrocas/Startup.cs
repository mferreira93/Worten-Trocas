using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WortenTrocas.Startup))]
namespace WortenTrocas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
