namespace EventsSystem.Api.Controllers
{
	using System.Web.Http;
	using EventsSystem.Data.Data.Repositories;
	using System.Linq;
	using Models;
	using Data.Models;

	public class CategoriesController : BaseController
	{
		public CategoriesController(IEventsSystemData data)
			: base(data)
		{
		}

		public IHttpActionResult Get()
		{
			// TODO: return in normal view categories: something like Name and events' names. 
			var categories = this.data.Categories.All();
			return this.Ok(categories);
		}

		public IHttpActionResult Get(int id)
		{
			var category = this.data.Categories.All().Where(c => c.Id == id).FirstOrDefault();

			if (category == null)
			{
				return this.NotFound();
			}

			var events = category.Events.Select(e => e.Name);
            return this.Ok(events);
		}

		public IHttpActionResult Post(CategoryModel model)
		{
			//TODO: Check if model is null? 
            if (!this.ModelState.IsValid)
			{
				return this.BadRequest(this.ModelState);
			}

			var user = this.data.Users.All().FirstOrDefault();

			var categoryToAdd = new Category
			{
				Name = model.Name,
				Author = user
			};

			this.data.Categories.Add(categoryToAdd);
			this.data.Savechanges();
			return this.Ok(categoryToAdd);
		}

		public IHttpActionResult Put(int id, CategoryModel model)
		{
			// TODO: check the current user is admin or user?

			// TODO: Is here the right place to update the events of the concrete category?
			// TODO: or just to update only the category's name
			var categoryToUpdate = this.data.Categories.All().Where(c => c.Id == id).FirstOrDefault();

			if (categoryToUpdate == null)
			{
				return this.NotFound();
			}

			categoryToUpdate.Name = model.Name;
			data.Savechanges();

			// TODO: return as normal way
			return this.Ok(categoryToUpdate);
		}

		public IHttpActionResult Delete(int id)
		{           
			// TODO: check the current user is admin or user?

			var categoryToDelete = this.data.Categories.All().Where(c => c.Id == id).FirstOrDefault();

			if (categoryToDelete == null)
			{
				return this.NotFound();
			}
			this.data.Categories.Delete(categoryToDelete);
			this.data.Savechanges();

			// TODO: return as normal way
			return this.Ok(categoryToDelete);
		}
	}
}