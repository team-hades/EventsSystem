namespace EventsSystem.Api.Controllers
{
	using System.Linq;
	using System.Web.Http;

	using Data.Data.Repositories;
	using Models;
	using Data.Models;

	[RoutePrefix("api/events")]
	public class EventsController :  BaseController
	{
		public EventsController(IEventsSystemData data)
			:base(data)
		{
		} 

		[HttpGet]
		public IHttpActionResult All()
		{
			// TODO: If current user is admin: get all events
			// TODO: Where it has to be returned the events which the user is tagged?!???
			var allVisibleEvents = this.data.Events.All().Where(ev => ev.IsPrivate == true);
			return this.Ok(allVisibleEvents);
		}

		[HttpGet]
		public IHttpActionResult All(int id)
		{
			var eventToReturn = this.data.Events.All().Where(ev => ev.Id == id);
			return this.Ok(eventToReturn);
		}

		[HttpPost]
		public IHttpActionResult Post(EventModel model)
		{
			return this.Ok("Some posted event");
		}

		[HttpPut]
		public IHttpActionResult Put(EventModel model)
		{
			return this.Ok("Some updated event");
		}

		[HttpDelete]
		public IHttpActionResult Delete(EventModel model)
		{
			return this.Ok("Some deleted event");
		}

		[HttpPost]
		[Route("join/{eventId}")]
		public IHttpActionResult Join(int eventId)
		{
			// check user?
			return this.Ok("Join");
		}

		[HttpPut]
		[Route("join/{id}")]
		public IHttpActionResult Leave(int id)
		{
			// check user?
			return this.Ok("Leave");
		}

	}
}