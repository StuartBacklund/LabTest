using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LabTest.Presentation.Web.Startup))]
namespace LabTest.Presentation.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
