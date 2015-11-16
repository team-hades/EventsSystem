namespace EventsSystem.Api.Tests
{
    using Api.Controllers;
    using Data.Models;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class TestObjectFactory
    {
        private static IQueryable<Event> events = new List<Event>
        {
            new Event
            {
                Users = new HashSet<User>(),
                Pictures = new HashSet<Picture>(),
                Comments = new HashSet<Comment>(),
                Tags = new HashSet<Tag>()
            }
        }.AsQueryable();

        public static EventsController GetEventService()
        {
            var eventsService = new Mock<EventsController>();

            eventsService.Setup(pr => pr.All(
                    It.IsAny<int>(),
                    It.IsAny<int>()))
                .Returns(events);

            eventsService.Setup(pr => pr.ById(
                    It.Is<string>(s => s == "Invalid"),
                    It.IsAny<string>()))
                .Returns(new List<SoftwareProject>().AsQueryable());

            eventsService.Setup(pr => pr.ById(
                    It.Is<string>(s => s == "Valid"),
                    It.IsAny<string>()))
                .Returns(events);

            eventsService.Setup(pr => pr.Add(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<bool>()))
                .Returns(1);

            return eventsService.Object;
        }
    }
}
