using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StoryTeller.Startup))]
namespace StoryTeller
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
