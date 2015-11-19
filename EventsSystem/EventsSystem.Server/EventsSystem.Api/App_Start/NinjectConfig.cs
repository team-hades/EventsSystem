namespace EventsSystem.Api
{
	using System;
	using System.Data.Entity;
	using System.Reflection;
	using System.Web;

	using Ninject;
	using Ninject.Web.Common;

	using Data.Data.Repositories;
	using Data.Data;
	using Infrastructure.Mapping;
	using Infrastructure;

	public static class NinjectConfig
	{
		public static IKernel CreateKernel()
		{
			var kernel = new StandardKernel();
			
			try
			{
				kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
				kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

				ObjectFactory.Initialize(kernel);
				RegisterServices(kernel);
				return kernel;
			}
			catch
			{
				kernel.Dispose();
				throw;
			}
		}

		private static void RegisterServices(KernelBase kernel)
		{
			kernel.Bind(typeof(IRepository<>)).To(typeof(EfRepository<>));
            kernel.Bind<IMappingService>().To<MappingService>();
            kernel.Bind<IEventsSystemData>().To<EventsSystemData>().InRequestScope();
		}
	}
}