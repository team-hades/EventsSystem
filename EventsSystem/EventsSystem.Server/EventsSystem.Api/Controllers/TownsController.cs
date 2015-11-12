namespace EventsSystem.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Models;
    using EventsSystem.Data.Data.Repositories;
    using AutoMapper.QueryableExtensions;

    public class TownsController : BaseController
	{
		public TownsController(IEventsSystemData data)
			: base(data)
		{
		}

		public IHttpActionResult Get()
		{
			var towns = this.data
                .Towns
                .All()
                .OrderByDescending(d => d.Name)
                .ProjectTo<TownResponseModel>();

			return this.Ok(towns);
		}

		public IHttpActionResult Get(int id)
		{
            var town = this.data
                .Towns
                .All()
                .Where(c => c.Id == id)
                .ProjectTo<TownResponseModel>()
                .FirstOrDefault();
                
			if (town == null)
			{
				return this.NotFound();
			}

			return this.Ok(town);
		}
	}
}