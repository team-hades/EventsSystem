namespace EventsSystem.Tests.Controllers
{
    using System.Reflection;
    using System.Web.Http;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;
    using Api.App_Start;
    using Common.Constants;
    using Api;

    [TestClass]
    public class TestInit
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            AutoMapperConfig.RegisterMappings(Assembly.Load(Assemblies.WebApi));

            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            MyWebApi.IsUsing(config);
        }
    }
}
