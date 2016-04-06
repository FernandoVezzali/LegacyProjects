using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(codesnippets.Startup))]
namespace codesnippets
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
