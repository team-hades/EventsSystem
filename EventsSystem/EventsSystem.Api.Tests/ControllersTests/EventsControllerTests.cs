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

        [TestMethod]
        public void TestDeleteShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/events/1")
                .WithHttpMethod(HttpMethod.Delete)
                .To<EventsController>(c => c.Delete(1));
        }

        [TestMethod]
        public void TestJoinEventShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/events/join/1")
                .WithHttpMethod(HttpMethod.Post)
                .To<EventsController>(c => c.Join(1));
        }

        [TestMethod]
        public void TestLeaveEventShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/events/leave/1")
                .WithHttpMethod(HttpMethod.Put)
                .To<EventsController>(c => c.Leave(1));
        }

        [TestMethod]
        public void TestRateEventShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/events/rate/1/1")
                .WithHttpMethod(HttpMethod.Post)
                .To<EventsController>(c => c.Rate(1, 1));
        }

        [TestMethod]
        public void TestUpdateRateEventShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/events/rate/1/1")
                .WithHttpMethod(HttpMethod.Put)
                .To<EventsController>(c => c.UpdateRate(1, 1));
        }
    }
}
