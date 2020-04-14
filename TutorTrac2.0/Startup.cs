using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TutorTrac2._0.Startup))]
namespace TutorTrac2._0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
