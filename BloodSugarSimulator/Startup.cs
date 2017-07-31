using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BloodSugarSimulator.Startup))]
namespace BloodSugarSimulator
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
