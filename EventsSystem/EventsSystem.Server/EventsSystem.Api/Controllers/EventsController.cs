namespace EventsSystem.Api.Controllers
{
	using Data.Data.Repositories;
	using System.Web.Http;

	public class EventsController : ApiController
	{
		private IEventsSystemData data;

		public EventsController(IEventsSystemData studentSystemData)
		{
			this.data = studentSystemData;
		}

		[HttpGet]
		public IHttpActionResult All()
		{
			return this.Ok(this.data.Events.All());
		}
	}
}