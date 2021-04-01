using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LAB06___Travis_Thaxter.Startup))]
namespace LAB06___Travis_Thaxter
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
