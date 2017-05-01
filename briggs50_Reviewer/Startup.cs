using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(briggs50_Reviewer.Startup))]
namespace briggs50_Reviewer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
