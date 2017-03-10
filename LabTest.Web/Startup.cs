using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LabTest.Web.Startup))]
namespace LabTest.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
