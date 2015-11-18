namespace EventsSystem.Tests.Controllers
{
    using MyTested.WebApi;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Api.Controllers;
    using System.Net.Http;

    [TestClass]
    public class EventsControllerShould
    {

        [TestMethod]
        public void AllShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/events")
                .To<EventsController>(c => c.All());
        }
    }
}
