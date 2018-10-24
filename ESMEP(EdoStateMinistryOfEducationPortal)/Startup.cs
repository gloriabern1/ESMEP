using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ESMEP_EdoStateMinistryOfEducationPortal_.Startup))]
namespace ESMEP_EdoStateMinistryOfEducationPortal_
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
