namespace EventsSystem.Services.Data.Tests.TestObjects
{
    using EventsSystem.Data.Models;
    using System.Collections.Generic;

    public static class TestObjectFactory
    {
        public static InMemoryRepository<User> GetUsersRepository()
        {
            var users = new InMemoryRepository<User>();

            for (int i = 0; i < 20; i++)
            {
                users.Add(new User
                {
                    FirstName = "First name " + i,
                    LastName = "Last name" + i,
                    Comments = new List<Comment>(),
                    Events = new List<Event>(),
                    UserRole = UserRole.Administrator,
                    ShortBio = "Short Biography " + i
                });
            }

            return users;
        }

        public static InMemoryRepository<Event> GetEventRepository()
        {
            var events = new InMemoryRepository<Event>();

            for (int i = 0; i < 20; i++)
            {
                events.Add(new Event
                {
                    Users = new List<User>(),
                    Author = new User(),
                    Category = new Category()
                });
            }

            return events;
        }

        public static InMemoryRepository<Town> GetTownsRepository()
        {
            var towns = new InMemoryRepository<Town>();

            for (int i = 0; i < 20; i++)
            {
                towns.Add(new Town
                {
                    
                });
            }

            return towns;
        }
    }
}
