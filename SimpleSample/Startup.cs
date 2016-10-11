using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleSample.Startup))]
namespace SimpleSample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
