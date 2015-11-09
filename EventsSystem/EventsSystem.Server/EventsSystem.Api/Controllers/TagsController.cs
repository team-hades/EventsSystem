using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using EventsSystem.Data.Data.Repositories;

namespace EventsSystem.Api.Controllers
{
	public class TagsController : BaseController
	{
		public TagsController(IEventsSystemData data)
			: base(data)
		{
		}

		[HttpGet]
		public IHttpActionResult Get()
		{
			var tags = this.data.Tags.All().Select(t => new
			{
				Name = t.Name,
				Events = t.Events.Select(e => e.Name),
				EventsCount = t.Events.Count(),
			});

			return this.Ok(tags);
		}

		[HttpGet]
		public IHttpActionResult Get(int id)
		{
			var events = this.data.Tags.All().Where(t => t.Id == id).FirstOrDefault().Events.Select(e => e.Name);

			// TODO: return null or empty array if tag not found.

			// //selected the rang of the every event but not use yes. this logic might be go in the mapper class blah blah blah...
			//var events = data
			//	.Events
			//	.All()
			//	.Where(e => e.Tags.Contains(tag));

			//foreach (var ev in events.ToList())
			//{
			//	var ratings = this.data.Ratings.All().Where(r => r.Event == ev).AsQueryable();
			//	float allGivenRating = 0.0f;

			//	foreach (var rating in ratings)
			//	{
			//		
			//		allGivenRating += rating.Value;
			//	}
			//}
			return this.Ok(events);
		}
	}
}