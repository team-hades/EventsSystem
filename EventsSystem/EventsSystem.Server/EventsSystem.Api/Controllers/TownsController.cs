namespace EventsSystem.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using AutoMapper.QueryableExtensions;

    using EventsSystem.Data.Data.Repositories;
    using EventsSystem.Api.Models.Towns;
    using Data.Models;
    using System;
    using Infrastructure.Validation;

    public class TownsController : BaseController
	{
        /// <summary>
		/// Initialize a new instance of the <see cref="TownsController"/> class with provided data.
		/// </summary>
		/// <param name="data">The data with the <see cref="TownsController"/> depends to.</param>
		public TownsController(IEventsSystemData data)
            : base(data)
        {
        }

		/// <summary>
		/// Gets all towns from database.
		/// </summary>
		/// <returns>All found towns mapped to the response town model.</returns>
		[HttpGet]
        public IHttpActionResult Get()
        {
            var towns = this.data
                .Towns
                .All()
                .OrderByDescending(d => d.Name)
                .ProjectTo<TownResponseModel>();

            return this.Ok(towns);
        }

		/// <summary>
		/// Gets all events which contain town with provided id. This action is not requiring authorisation.
		/// </summary>
		/// <param name="id">The id of the town to get events.</param>
		/// <returns>All found events with the provided town id.</returns>
		[HttpGet]
        public IHttpActionResult Get(int id)
        {
            var town = this.data
                .Towns
                .All()
                .Where(t => t.Id == id)
                .ProjectTo<TownResponseModel>()
                .FirstOrDefault();

            if (town == null)
            {
                return this.NotFound();
            }

            return this.Ok(town);
        }

		/// <summary>
		/// Gets all events which contain town with provided name. This action is not requiring authorisation.
		/// </summary>
		/// <param name="name">The name of the town to get events.</param>
		/// <returns>All found events with the provided town name.</returns>
		[HttpGet]
        public IHttpActionResult Get([FromUri]string name)
        {
            var town = this.data
                .Towns
                .All()
                .Where(t => t.Name == name)
                .ProjectTo<TownResponseModel>()
                .FirstOrDefault();

            if (town == null)
            {
                return this.NotFound();
            }

            return this.Ok(town);
        }

		/// <summary>
		/// Creates and saves a new town in the database.
		/// </summary>
		/// <param name="model">The town model which get from the user.</param>
		/// <returns>The id of the new town. If the town with the provided name is already exist - redirects to the existing town.</returns>
        [HttpPost]
        [ValidateModel]
        public IHttpActionResult Post(TownSaveModel model)
        {
            var town = this.data.Towns.All().FirstOrDefault(x => x.Name == model.Name);
            if (town != null)
            {
                var id = town.Id;
                var uri = new Uri($"http://localhost:58368/api/towns/{id}");
                return this.Redirect(uri);
            }

            var townToAdd = new Town
            {
                Name = model.Name
            };

            this.data.Towns.Add(townToAdd);
            this.data.Savechanges();

            return this.Created("api/towns", new
            {
                TownId = townToAdd.Id
            });
        }
    }
}