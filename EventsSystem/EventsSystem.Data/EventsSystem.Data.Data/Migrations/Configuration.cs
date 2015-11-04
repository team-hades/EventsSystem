namespace EventsSystem.Data.Data.Migrations
{
	using System;
	using System.Linq;
	using System.Data.Entity.Migrations;
	using Models;
	using Microsoft.AspNet.Identity.EntityFramework;
	using System.Collections.Generic;
	using System.Security.Claims;

	internal sealed class Configuration : DbMigrationsConfiguration<EventsSystemDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = true;
			AutomaticMigrationDataLossAllowed = true;
		}

		protected override void Seed(EventsSystemDbContext context)
		{
			this.SeedAdmins(context);
		}

		private void SeedAdmins(EventsSystemDbContext context)
		{
			if (context.Users.Any())
			{
				return;
			}

			//TODO : Seed some hades admins :)
		}
	}
}
