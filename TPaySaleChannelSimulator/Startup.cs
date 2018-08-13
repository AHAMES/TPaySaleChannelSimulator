using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TPaySaleChannelSimulator.Startup))]
namespace TPaySaleChannelSimulator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
