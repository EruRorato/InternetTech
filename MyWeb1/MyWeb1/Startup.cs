using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyWeb1.Startup))]
namespace MyWeb1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
