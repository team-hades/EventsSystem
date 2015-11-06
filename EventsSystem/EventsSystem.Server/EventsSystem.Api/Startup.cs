using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Ninject.Web.Common.OwinHost;
using Owin;
using System.Web.Http;
using Ninject.Web.WebApi.OwinHost;

[assembly: OwinStartup(typeof(EventsSystem.Api.Startup))]

namespace EventsSystem.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
			ConfigureAuth(app);

			// throw
			var httpConfig = new HttpConfiguration();
			WebApiConfig.Register(httpConfig);

			httpConfig.EnsureInitialized();

			app
				.UseNinjectMiddleware(NinjectConfig.CreateKernel)
				.UseNinjectWebApi(httpConfig);
		}
	}
}
