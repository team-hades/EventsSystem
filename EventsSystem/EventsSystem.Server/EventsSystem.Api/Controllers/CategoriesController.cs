namespace EventsSystem.Api.Controllers
{
	using System;
	using System.Linq;
	using System.Net;
	using System.Web.Http;

	using AutoMapper.QueryableExtensions;

	using EventsSystem.Data.Models;
	using EventsSystem.Data.Data.Repositories;
	using EventsSystem.Api.Models.Categories;
	using EventsSystem.Api.Models.Events;
	using EventsSystem.Api.Infrastructure.Validation;

	public class CategoriesController : BaseController
	{
		/// <summary>
		/// Initialize a new instance of the <see cref="CategoriesController"/> class with provided data.
		/// </summary>
		/// <param name="data">The data with the <see cref="CategoriesController"/> depends to.</param>7
		public CategoriesController(IEventsSystemData data)
			: base(data)
		{
		}

		/// <summary>
		/// Gets all categories from database.
		/// </summary>
		/// <returns>All found categories mapped to the response category model.</returns>
		[HttpGet]
		public IHttpActionResult Get()
		{

			var allCategories = this.data.Categories
				.All()
				.OrderBy(c => c.Events.Count)
				.ProjectTo<CategoryResponseModel>();


			if (allCategories.Count() > 0)
			{
				return this.Ok(allCategories);
			}

			return this.NotFound();
		}

		/// <summary>
		/// Gets all events which contain category with provided id. This action is not requiring authorisation.
		/// </summary>
		/// <param name="id">The id of the category to get events.</param>
		/// <returns>All found events with the provided category id.</returns>
		[HttpGet]
		public IHttpActionResult Get(int id)
		{
			var category = this.data
				.Categories
				.All()
				.Where(c => c.Id == id)
				.ProjectTo<CategoryResponseModel>()
				.FirstOrDefault();

			if (category == null)
			{
				return this.NotFound();
			}

			return this.Ok(category);
		}

		/// <summary>
		/// Gets all events which contain category with provided name. This action is not requiring authorisation.
		/// </summary>
		/// <param name="name">The name of the category to get events.</param>
		/// <returns>All found events with the provided category name.</returns>
		[HttpGet]
		public IHttpActionResult Get([FromUri]string name)
		{
			var category = this.data
				.Categories
				.All()
				.Where(c => c.Name == name)
				.ProjectTo<CategoryResponseModel>()
				.FirstOrDefault();

			if (category == null)
			{
				return this.NotFound();
			}

			return this.Ok(category);
		}

		/// <summary>
		/// Creates and saves a new category in the database.
		/// </summary>
		/// <param name="model">The category model which get from the user.</param>
		/// <returns>The id of the new category. If the category with the provided name is already exist - redirects to the existing town.</returns>
		[HttpPost]
		[ValidateModel]
		public IHttpActionResult Post(CategorySaveModel model)
		{
			if (!this.User.IsInRole("Admin"))
			{
				return this.StatusCode(HttpStatusCode.Unauthorized);
			}

			var category = this.data.Categories.All().FirstOrDefault(x => x.Name == model.Name);
			if (category != null)
			{
				var id = category.Id;
				var uri = new Uri($"http://localhost:58368/api/categories/{id}");
				return this.Redirect(uri);
			}

			var user = this.data.Users.All().FirstOrDefault();
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


		[HttpPut]
		[ValidateModel]
		public IHttpActionResult Put(int id, CategoryResponseModel model)
		{
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
			categoryToUpdate.Name = model.Name;
			data.Savechanges();

			return this.Ok(categoryToUpdate);
		}


		[HttpDelete]
		public IHttpActionResult Delete(int id)
		{
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

			this.data.Categories.Delete(categoryToDelete);
			this.data.Savechanges();

			return this.Ok(categoryToDelete);
		}
	}
}