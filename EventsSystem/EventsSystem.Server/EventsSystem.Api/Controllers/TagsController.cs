namespace EventsSystem.Api.Controllers
{
	using System.Linq;
	using System.Web.Http;

	using AutoMapper.QueryableExtensions;

	using EventsSystem.Api.Models.Tags;
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

        // this way you can insert in this method :)
        // http://localhost:58368/api/tags?name=red
        [HttpGet]
        public IHttpActionResult Get([FromUri]string name)
        {
            var tag = this.data.Tags.All().Where(t => t.Name == name).ProjectTo<TagResponseModel>().FirstOrDefault();

            if (tag == null)
            {
                return this.NotFound();
            }

            return this.Ok(tag.Events);
        }

        [HttpGet]
        [Route("api/tags/id")]
		public IHttpActionResult Get(int id)
		{
			var tag = this.data.Tags.All().Where(t => t.Id == id).ProjectTo<TagResponseModel>().FirstOrDefault();

			if (tag == null)
			{
				return this.NotFound();
			}

			return this.Ok(tag.Events);
		}
	}
}