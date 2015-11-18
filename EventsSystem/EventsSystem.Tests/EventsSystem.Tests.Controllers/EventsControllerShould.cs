namespace EventsSystem.Tests.Controllers
{
    using MyTested.WebApi;

    using Api.Controllers;
    using NUnit.Framework;
    using System.Net.Http;

    [TestFixture]
    public class EventsControllerShould
    {
        [Test]
        public void ReturnOkWhenCallingGetAction()
        {
            MyWebApi
               .Routes()
               .ShouldMap("api/events")
               .WithHttpMethod(HttpMethod.Get)
               .ToValidModelState();
        }
    }
}
