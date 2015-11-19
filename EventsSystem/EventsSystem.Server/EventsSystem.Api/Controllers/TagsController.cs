namespace EventsSystem.Api.Controllers
{
	using System.Linq;
	using System.Web.Http;

	using AutoMapper.QueryableExtensions;

	using EventsSystem.Api.Models.Tags;
	using EventsSystem.Data.Data.Repositories;

    /// <summary>
    /// Tags(event) controller
    /// </summary>
    public class TagsController : BaseController
    {
        public TagsController(IEventsSystemData data)
            : base(data)
        {
        }

        /// <summary>
        /// All tags - public action
        /// </summary>
        /// <returns>All tags</returns>
        [HttpGet]
        public IHttpActionResult Get()
        {
            var tags = this.data.Tags.All().ProjectTo<TagResponseModel>()
;
            return this.Ok(tags);
        }

        /// <summary>
        /// All events by tag name - public action
        /// </summary>
        /// <param name="name">Tag name</param>
        /// <returns>All tagged events</returns>
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

        /// <summary>
        /// All tags by id - oublic action
        /// </summary>
        /// <param name="id">Tag Id</param>
        /// <returns>All tagged events</returns>
        [HttpGet]
        [Route("api/tags/{id}")]
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