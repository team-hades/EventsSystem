namespace EventsSystem.Api.Controllers
{
	using System.Web.Http;

	using EventsSystem.Data.Data.Repositories;

	public class BaseController : ApiController
	{
		protected IEventsSystemData data;

		public BaseController(IEventsSystemData data)
		{
			this.data = data;
		}
	}
}