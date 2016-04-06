using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodeSnippets3.Startup))]
namespace CodeSnippets3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
