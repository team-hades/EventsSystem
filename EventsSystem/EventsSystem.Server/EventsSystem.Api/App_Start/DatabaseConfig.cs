namespace EventsSystem.Api
{
	using System.Data.Entity;
=	using EventsSystem.Data.Data;
	using Data.Data.Migrations;

	public static class DatabaseConfig
	{
		public static void Initialize()
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<EventsSystemDbContext, Configuration>());
			EventsSystemDbContext.Create().Database.Initialize(true);
		}
	}
}