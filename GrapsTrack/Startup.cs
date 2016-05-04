using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GrapsTrack.Startup))]
namespace GrapsTrack
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
