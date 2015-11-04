namespace EventsSystem.Api
{
	using Ninject;
	using System.Reflection;

	public static class NinjectConfig
	{
		public static IKernel CreateKernel()
		{
			var kernel = new StandardKernel();
			kernel.Load(Assembly.GetExecutingAssembly());

			RegisterServices(kernel);

			return kernel;
		}

		private static void RegisterServices(IKernel kernel)
		{
			// kernel.Bind<ISomething>().To<Something>();
		}
	}
}