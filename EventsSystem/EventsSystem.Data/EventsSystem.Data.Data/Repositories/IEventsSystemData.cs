using EventsSystem.Data.Models;

namespace EventsSystem.Data.Data.Repositories
{
	public interface IEventsSystemData
	{
		IRepository<Event> Events { get; }

		IRepository<User> Users { get; }

		IRepository<Category> Categories { get; }

		IRepository<Comment> Comments { get; }

		IRepository<Picture> Pictures { get; }

		IRepository<Rating> Ratings { get; }

		IRepository<Tag> Tags { get; }

		IRepository<Town> Towns { get; }

		int Savechanges();
	}
}
