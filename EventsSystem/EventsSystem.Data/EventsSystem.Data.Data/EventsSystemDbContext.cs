using EventsSystem.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EventsSystem.Data.Data
{
	public class EventsSystemDbContext : IdentityDbContext<User>, IEventsSystemDbContext
	{
		public EventsSystemDbContext()
			: base("EventsSystem")
		{
		}

		public virtual IDbSet<Event> Events { get; set; }

		public virtual IDbSet<Category> Categories { get; set; }

		public virtual IDbSet<Comment> Comments { get; set; }

		public virtual IDbSet<Tag> Tags { get; set; }

		public virtual IDbSet<Rating> Ratings { get; set; }

		public virtual IDbSet<Picture> Pictures { get; set; }

		public virtual IDbSet<Town> Towns { get; set; }

		public static EventsSystemDbContext Create()
		{
			return new EventsSystemDbContext();
		}
	}
}
