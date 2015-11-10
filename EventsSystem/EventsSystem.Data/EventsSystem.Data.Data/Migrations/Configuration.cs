namespace EventsSystem.Data.Data.Migrations
{
	using System;
	using System.Linq;
	using System.Data.Entity.Migrations;
	using Models;
	using Microsoft.AspNet.Identity.EntityFramework;
	using System.Collections.Generic;
	using System.Security.Claims;
	using Microsoft.AspNet.Identity;

	public sealed class Configuration : DbMigrationsConfiguration<EventsSystemDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = true;
			AutomaticMigrationDataLossAllowed = true;
		}

		protected override void Seed(EventsSystemDbContext context)
		{
			this.SeedAdmins(context);
			this.SeedTowns(context);
			this.SeedCategories(context);
			this.SeedEvents(context);
		}

		private void SeedAdmins(EventsSystemDbContext context)
		{
			if (context.Users.Any())
			{
				return;
			}

			var pesho = new User()
			{
				Email = "pesho@gmail.com",
				UserName = "pesho@gmail.com",
				PasswordHash = new PasswordHasher().HashPassword("peshopesho")
			};

			var gosho = new User()
			{
				Email = "gosho@gmail.com",
				UserName = "gosho@gmail.com",
				PasswordHash = new PasswordHasher().HashPassword("goshogosho")
			};


			var stamat = new User()
			{
				Email = "stamat@gmail.com",
				UserName = "stamat@gmail.com",
				PasswordHash = new PasswordHasher().HashPassword("stamat")
			};

			context.Users.Add(pesho);
			context.Users.Add(gosho);
			context.Users.Add(stamat);
			context.SaveChanges();
		}

		private void SeedTowns(EventsSystemDbContext context)
		{
			if (context.Towns.Any())
			{
				return;
			}

			var sofia = new Town
			{
				Name = "Sofia"
			};

			var varna = new Town
			{
				Name = "Varna"
			};

			context.Towns.Add(sofia);
			context.Towns.Add(varna);
			context.SaveChanges();
		}

		private void SeedCategories(EventsSystemDbContext context)
		{
			if (context.Events.Any())
			{
				return;
			}

			var user = context.Users.FirstOrDefault();

			var category = new Category
			{
				Name = "Category Name",
				Author = user
			};

			var party = new Category
			{
				Name = "Party",
				Author = user
			};

			context.Categories.Add(category);
			context.Categories.Add(party);
			context.SaveChanges();
		}

		private void SeedEvents(EventsSystemDbContext context)
		{
			if (context.Events.Any())
			{
				return;
			}

			var user = context.Users.FirstOrDefault();
			var category = context.Categories.FirstOrDefault();
			var town = context.Towns.FirstOrDefault();

			var startDate = DateTime.Now.AddDays(20);
			var endDate = DateTime.Now.AddDays(22);

			var eventToAdd = new Event
			{
				Name = "Pesho's event",
				ShortDescrtiption = "Short description",
				LongDescrtiption = "Long description",
				Author = user,
				Town = town,
				Category = category,
				StartDate = startDate,
				EndDate = endDate,
			};

			eventToAdd.Users.Add(user);

            context.Events.Add(eventToAdd);
			context.SaveChanges();
		}
	}
}
