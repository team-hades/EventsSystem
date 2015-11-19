namespace EventsSystem.Api.Controllers
{
	using System.Linq;
	using System.Web.Http;

	using AutoMapper.QueryableExtensions;

	using EventsSystem.Data.Models;
	using EventsSystem.Data.Data.Repositories;
	using EventsSystem.Api.Models.Categories;
	using EventsSystem.Api.Models.Events;
	using System.Net;

    /// <summary>
    /// Categories controller
    /// </summary>
	public class CategoriesController : BaseController
	{
		public CategoriesController(IEventsSystemData data)
			: base(data)
		{
		}

        /// <summary>
        /// All categories  - public action
        /// </summary>
        /// <returns>all event categories by number of events</returns>
		[HttpGet]
		public IHttpActionResult Get()
		{
			
			var allCategories = this.data.Categories
				.All()
				.OrderBy(c => c.Events.Count)
				.ProjectTo<CategoryModel>();


			if (allCategories.Count() > 0)
			{
				return this.Ok(allCategories);
			}

			return this.NotFound();
		}

        /// <summary>
        /// Searches for category by Id - public action
        /// </summary>
        /// <param name="id">category Id</param>
        /// <returns>All events in specific category ordered by date</returns>
		[HttpGet]
		public IHttpActionResult Get(int id)
		{
			var category = this.data.Categories.All().Where(c => c.Id == id).FirstOrDefault();

			if (category == null)
			{
				return this.NotFound();
			}
			
			// TODO: this is trow, when i get events from the category i cannot map them to the EventResponseModel?!
			var events = data.Events
				.All()
				.Where(e => e.Category == category)
				.OrderByDescending(e => e.StartDate)
				.ProjectTo<EventResponseModel>();

			if (events.Count() > 0)
			{
				return this.Ok(events);
			}

			return this.NotFound();
		}

        /// <summary>
        /// Searches for category by its name - public action
        /// </summary>
        /// <param name="name">category name</param>
        /// <returns>All events in specific category ordered by date</returns>
		[HttpGet]
		public IHttpActionResult Get(string name)
		{
			var category = this.data.Categories.All().Where(c => c.Name == name).FirstOrDefault();

			if (category == null)
			{
				return this.NotFound();
			}

			var events = data.Events
				.All()
				.Where(e => e.Category == category)
				.OrderByDescending(e => e.StartDate)
				.ProjectTo<EventResponseModel>();

			if (events.Count() > 0)
			{
				return this.Ok(events);
			}

			return this.NotFound();
		}

        /// <summary>
        /// Creates new category - admin action
        /// </summary>
        /// <param name="id">Category id</param>
        /// <param name="model">New category with name</param>
        /// <returns>Added category</returns>
		[HttpPost]
		public IHttpActionResult Post(int id, CategoryModel model)
		{
			if (!this.User.IsInRole("Admin"))
			{
				return this.StatusCode(HttpStatusCode.Unauthorized);
			}

			//TODO: Check if model is null? 
			if (!this.ModelState.IsValid)
			{
				return this.BadRequest(this.ModelState);
			}

			var user = this.data.Users.All().FirstOrDefault();

			// TODO: add this.mappingService.Map<>
			var categoryToAdd = new Category
			{
				Name = model.Name,
				Author = user
			};

			this.data.Categories.Add(categoryToAdd);
			this.data.Savechanges();
			return this.Created("api/categories", new
            {
                CategoryId = categoryToAdd
            });
		}

        /// <summary>
        /// Changes selected category - admin action
        /// </summary>
        /// <param name="id">category Id</param>
        /// <param name="model">category model with cnages</param>
        /// <returns>Updated category details</returns>
		[HttpPut]
		public IHttpActionResult Put(int id, CategoryModel model)
		{
			// TODO: check the current user is admin or user?

			// TODO: Is here the right place to update the events of the concrete category?
			// TODO: or just to update only the category's name
			if (!this.User.IsInRole("Admin"))
			{
				return this.StatusCode(HttpStatusCode.Unauthorized);
			}

			var categoryToUpdate = this.data.Categories
											.All()
											.Where(c => c.Id == id)
											.FirstOrDefault();

			if (categoryToUpdate == null)
			{
				return this.NotFound();
			}
			// TODO: add this.mappingService.Map<>
			categoryToUpdate.Name = model.Name;
			data.Savechanges();

			// TODO: return as normal way
			return this.Ok(categoryToUpdate);
		}

        /// <summary>
        /// Changes selected category - admin action
        /// </summary>
        /// <param name="id">Category Id</param>
        /// <returns>Deleted category details</returns>
		[HttpDelete]
		public IHttpActionResult Delete(int id)
		{
			// TODO: check the current user is admin or user?

			if (!this.User.IsInRole("Admin"))
			{
				return this.StatusCode(HttpStatusCode.Unauthorized);
			}

			var categoryToDelete = this.data.Categories
											.All()
											.Where(c => c.Id == id)
											.FirstOrDefault();

			if (categoryToDelete == null)
			{
				return this.NotFound();
			}
			// TODO: add this.mappingService.Map<>
			this.data.Categories.Delete(categoryToDelete);
			this.data.Savechanges();

			// TODO: return as normal way
			return this.Ok(categoryToDelete);
		}
	}
}