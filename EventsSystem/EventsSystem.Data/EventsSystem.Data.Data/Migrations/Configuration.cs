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

			//TODO : Seed some hades admins :)
			var pesho = new User
			{
				UserName = "Pesho"
			};

			context.Users.Add(pesho);
			context.SaveChanges();	
		}
	}
}
