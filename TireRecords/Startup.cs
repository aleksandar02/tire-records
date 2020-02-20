using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TireRecords.Startup))]
namespace TireRecords
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
