using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsSystem.Data.Models;
using System.Data.Entity;

namespace EventsSystem.Data.Data.Repositories
{
	public class EventsSystemData : IEventsSystemData
	{
		private readonly DbContext context;
		private readonly IDictionary<Type, object> repositories;


		public EventsSystemData()
		{
			this.context = new EventsSystemDbContext();
			this.repositories = new Dictionary<Type, object>();
		}

		public IRepository<User> Users
		{
			get
			{
				return this.GetRepository<User>();
			}
		}

		public IRepository<Event> Events
		{
			get
			{
				return this.GetRepository<Event>();
			}
		}

		public IRepository<Category> Categories
		{
			get
			{
				return this.GetRepository<Category>();
			}
		}

		public IRepository<Town> Towns
		{
			get
			{
				return this.GetRepository<Town>();
			}
		}

		
		public IRepository<Comment> Comments
		{
			get
			{
				return this.GetRepository<Comment>();
			}
		}


		public IRepository<Picture> Pictures
		{
			get
			{
				return this.GetRepository<Picture>();
			}
		}

		public IRepository<Rating> Ratings
		{
			get
			{
				return this.GetRepository<Rating>();
			}
		}

		public IRepository<Tag> Tags
		{
			get
			{
				return this.GetRepository<Tag>();
			}
		}

		public IRepository<UserInfo> UserInfo
		{
			get
			{
				return this.GetRepository<UserInfo>();
			}
		}

		public int Savechanges()
		{
			return this.context.SaveChanges();
		}

		private IRepository<T> GetRepository<T>() where T : class
		{
			var typeOfRepository = typeof(T);

			if (!this.repositories.ContainsKey(typeOfRepository))
			{
				var newRepository = Activator.CreateInstance(typeof(EfRepository<T>), this.context);
				this.repositories.Add(typeOfRepository, newRepository);
			}

			return (IRepository<T>)this.repositories[typeOfRepository];
		}
	}
}
