using EventsSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsSystem.Data.Data
{
	public interface IEventsSystemDbContext
	{
		IDbSet<Event> Events { get; set; }

		IDbSet<Category> Categories { get; set; }

		IDbSet<Comment> Comments { get; set; }

		IDbSet<Tag> Tags { get; set; }

		IDbSet<Like> Likes { get; set; }

		DbSet<TEntity> Set<TEntity>() where TEntity : class;

		DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
			where TEntity : class;

		void Dispose();

		int SaveChanges();
	}
}
