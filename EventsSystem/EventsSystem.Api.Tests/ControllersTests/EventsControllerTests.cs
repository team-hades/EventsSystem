namespace EventsSystem.Api.Tests.Controllers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;
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

        [TestMethod]
        public void AllWithIdShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/events/1")
                .To<EventsController>(c => c.All(1));
        }

        [TestMethod]
        public void AllByPageShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/events?page=2")
                .To<EventsController>(c => c.AllByPage("2"));
        }

        [TestMethod]
        public void AllByCategoryByCategoryShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/events?category=SomeCategory")
                .To<EventsController>(c => c.AllByCategoryByCategory("SomeCategory"));
        }

        [TestMethod]
        public void AllByCategoryAndTownShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/events?category=SomeCategory&town=SomeCity")
                .To<EventsController>(c => c.AllByCategoryAndTown("SomeCategory", "SomeCity"));
        }

        [TestMethod]
        public void PostShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/events")
                .WithHttpMethod(HttpMethod.Post)
                .WithJsonContent(@"{ ""Name"": ""Test"", ""IsPrivate"": true }")
                .To<EventsController>(c => c.Post(new EventSaveModel
                {
                    Name = "Test",
                    IsPrivate = true
                }));
        }
    }
}
