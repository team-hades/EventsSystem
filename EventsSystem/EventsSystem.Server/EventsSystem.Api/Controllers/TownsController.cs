namespace EventsSystem.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using AutoMapper.QueryableExtensions;

    using EventsSystem.Data.Data.Repositories;
    using EventsSystem.Api.Models.Towns;
    using Data.Models;
    using System;

    public class TownsController : BaseController
    {
        public TownsController(IEventsSystemData data)
            : base(data)
        {
        }

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

        [HttpPost]
        public IHttpActionResult Post(TownSaveModel model)
        {
            if (true)
            {
                // user is not admin
                // return this.Unauthorized();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

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

            return this.Created("api/towns}", new
            {
                TownId = townToAdd.Id
            });
        }
    }
}