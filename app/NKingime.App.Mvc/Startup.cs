using Owin;
using Microsoft.Owin;
using NKingime.Core.Dependency;
using NKingime.Core.Initialize;
using NKingime.Web.Mvc.Dependency;

[assembly: OwinStartupAttribute(typeof(NKingime.App.Mvc.Startup))]
namespace NKingime.App.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            IServiceBuilder builder = new ServiceBuilder();
            IServiceCollection services = builder.Build();

            IIocBuilder mvcIocBuilder = new MvcAutofacIocBuilder(services);
            IFrameworkInitializer initializer = new FrameworkInitializer();
            initializer.Initialize(mvcIocBuilder);

            ConfigureAuth(app);
        }
    }
}
