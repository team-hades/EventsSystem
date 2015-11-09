namespace EventsSystem.Api.Controllers
{
	using System.Linq;
	using System.Web.Http;
	using EventsSystem.Data.Data.Repositories;

	public class TownsController : BaseController
	{
		public TownsController(IEventsSystemData data)
			: base(data)
		{
		}

		public IHttpActionResult Get()
		{
			var towns = this.data.Towns.All();
			return this.Ok(towns);
		}

		public IHttpActionResult Get(int id)
		{
			var town = this.data.Towns.All().Where(c => c.Id == id).FirstOrDefault();

			if (town == null)
			{
				return this.NotFound();
			}

			var events = town.Events.Select(e => e.Name);

			return this.Ok(events);
		}
	}
}