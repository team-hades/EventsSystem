namespace EventsSystem.Services.Data.Tests.TestObjects
{
    using EventsSystem.Data.Models;

    public static class TestObjectFactory
    {
        public static InMemoryRepository<User> GetUser()
        {

            return new InMemoryRepository<User>();
        }
    }
}
