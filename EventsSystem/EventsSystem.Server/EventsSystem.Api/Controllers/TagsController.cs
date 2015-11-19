namespace EventsSystem.Api.Controllers
{
	using System.Linq;
	using System.Web.Http;

	using AutoMapper.QueryableExtensions;

	using EventsSystem.Api.Models.Tags;
	using EventsSystem.Data.Data.Repositories;

	public class TagsController : BaseController
	{
		/// <summary>
		/// Initialize a new instance of the <see cref="TagsController"/> class with provided data.
		/// </summary>
		/// <param name="data">The data with the <see cref="TagsController"/> depends to.</param>
		public TagsController(IEventsSystemData data)
			: base(data)
		{
		}

		/// <summary>
		/// Gets all tags from database.
		/// </summary>
		/// <returns>All found tags mapped to the response tag model.</returns>
		[HttpGet]
		public IHttpActionResult Get()
		{
			var tags = this.data.Tags.All().ProjectTo<TagResponseModel>()
;
			return this.Ok(tags);
		}

		/// <summary>
		/// Gets all events which contain tag with provided id. This action is not requiring authorisation.
		/// </summary>
		/// <param name="id">The id of the tag to get events.</param>
		/// <returns>All found events with the provided tag id.</returns>
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

		/// <summary>
		/// Gets all events which contain tag with provided name. This action is not requiring authorisation.
		/// </summary>
		/// <param name="name">The name of the tag to get events.</param>
		/// <returns>All found events with the provided tag name.</returns>
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
	}
}