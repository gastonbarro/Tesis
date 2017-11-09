using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Scoring_MGDP.Startup))]
namespace Scoring_MGDP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
