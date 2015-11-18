namespace EventsSystem.Services.Data.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using EventsSystem.Services.Data.Tests.TestObjects;
    using EventsSystem.Data.Models;
    using Api.Controllers;
    using EventsSystem.Data.Data.Repositories;

    [TestClass]
    public class EventsSystemServicesTest
    {
        private IEventsSystemData eventsService;

        private InMemoryRepository<Event> eventsRepo;
        private InMemoryRepository<User> userRepo;

        [TestInitialize]
        public void Init()
        {
            this.userRepo = TestObjectFactory.GetUsersRepository();
            this.eventsRepo = TestObjectFactory.GetEventRepository();
        }

        [TestMethod]
        public void TestMethod1()
        {
            //var usersRepository = TestObjectFactory.GetUsersRepository();



        }
    }
}
