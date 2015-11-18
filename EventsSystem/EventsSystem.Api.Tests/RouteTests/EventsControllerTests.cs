namespace EventsSystem.Api.Tests.RouteTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;
    using Controllers;
    using System.Net.Http;
    using Models.Events;
    using Api.Controllers;

    [TestClass]
    public class EventsControllerTests
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
