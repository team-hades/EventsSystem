namespace EventsSystem.Api.Controllers
{
	using System.Web.Http;
	using Data.Data.Repositories;

	public class BaseController : ApiController
	{
		protected IEventsSystemData data;

		public BaseController(IEventsSystemData data)
		{
			this.data = data;
		}
	}
}