namespace EventsSystem.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using AutoMapper.QueryableExtensions;
    using EventsSystem.Api.Models;
    using EventsSystem.Data.Data.Repositories;

    public class TagsController : BaseController
	{
		public TagsController(IEventsSystemData data)
			: base(data)
		{
		}

		[HttpGet]
		public IHttpActionResult Get()
		{
            var tags = this.data.Tags.All().ProjectTo<TagResponseModel>()
;
			return this.Ok(tags);
		}

		[HttpGet]
		public IHttpActionResult Get(int id)
		{
			var tag = this.data.Tags.All().Where(t => t.Id == id).ProjectTo<TagResponseModel>().FirstOrDefault();

			if (tag == null)
			{
				return this.NotFound();
			}

            // var events = tag.Events.AsQueryable().ProjectTo<EventResponseModel>();
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
			return this.Ok(tag.Events);
		}
	}
}