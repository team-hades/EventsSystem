namespace EventsSystem.Data.Data.Migrations
{
	using System;
	using System.Linq;
	using System.Data.Entity.Migrations;
	using Models;
	using Microsoft.AspNet.Identity.EntityFramework;
	using System.Collections.Generic;
	using System.Security.Claims;

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
			this.SeedEvents(context);
		}

		private void SeedEvents(EventsSystemDbContext context)
		{
			if (context.Events.Any())
			{
				return;
			}

			var user = context.Users.FirstOrDefault();

			var party = new Event
			{
				Name = "Party",
				ShortDescrtiption = "Some Party",
				Author = user
			};

			var exam = new Event
			{
				Name = "Exam",
				ShortDescrtiption = "Some Exam",
				Author = user
			};

			context.Events.Add(party);
			context.Events.Add(exam);
			context.SaveChanges();
		}

		private void SeedTowns(EventsSystemDbContext context)
		{
			if (context.Towns.Any())
			{
				return;
			}

			var sofiaTown = new Town
			{
				Name = "Sofia"
			};

			var burgasTown = new Town
			{
				Name = "Burgas"
			};

			var varnaTown = new Town
			{
				Name = "Varna"
			};

			context.Towns.Add(sofiaTown);
			context.Towns.Add(burgasTown);
			context.Towns.Add(varnaTown);

			context.SaveChanges();
		}

		private void SeedAdmins(EventsSystemDbContext context)
		{
			if (context.Users.Any())
			{
				return;
			}

			var pesho = new User
			{
				FirstName = "Pesho",
				UserName = "Peshkata"
			};

			var gosho = new User
			{
				FirstName = "Gosho",
				UserName = "Gogata"
			};

			var tosho = new User
			{
				FirstName = "Tosho",
				UserName = "Tosheto"
			};

			context.Users.Add(pesho);
			context.Users.Add(gosho);
			context.Users.Add(tosho);
			context.SaveChanges();	
		}
	}
}
