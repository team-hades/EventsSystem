namespace EventsSystem.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Data.Data.Repositories;
    using Models;

    using AutoMapper.QueryableExtensions;

    [RoutePrefix("api/events")]
    public class EventsController : BaseController
    {
        public EventsController(IEventsSystemData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            // .ProjectTo<EventResponceModel>()
            // TODO: If current user is admin: get all events
            // TODO: Where it has to be returned the events which the user is tagged?!???
            if (this.User.IsInRole("Admin"))
            {
                var allAdminEvents = this.data.Events
                                .All()
                                .OrderByDescending(d => d.StartDate)
                                .ProjectTo<EventResponceModel>();

                return this.Ok(allAdminEvents);
            }

            if (this.User.Identity.IsAuthenticated)
            {
                var currentUserName = this.User.Identity.Name;
                var currentUserID = this.data.Users.All().Where(u => u.UserName == currentUserName).FirstOrDefault();

                var allEventsWithTagedUser = this.data.Events
                .All()
                .Where(ev => ev.Users.Contains(currentUserID))
                .OrderByDescending(d => d.StartDate)
                .ProjectTo<EventResponceModel>();

                if (allEventsWithTagedUser.Count() > 0)
                {
                    return this.Ok(allEventsWithTagedUser);
                }

                return this.BadRequest();
            }

            // Non Registered users will see only top 10 non priavate events
            var allVisibleEvents = this.data.Events
                .All()
                .Where(ev => ev.IsPrivate != true)
                .OrderBy(d => d.StartDate)
                .Take(10)
                .ProjectTo<EventResponceModel>();

            return this.Ok(allVisibleEvents);
        }

        [HttpGet]
        public IHttpActionResult All(int id)
        {
            var eventToReturn = this.data.Events.All().Where(ev => ev.Id == id).ProjectTo<EventResponceModel>();

            if (eventToReturn == null)
            {
                // TODO Add some message
                return this.BadRequest();
            }

            // TODO we neeed to include a collection ofcomments in the model to work
            return this.Ok(eventToReturn);
        }

        // TODO see if custom routing is needed
        [HttpGet]
        public IHttpActionResult AllByPage(string page)
        {
            int pageSize = int.Parse(page);
            int defaultPageSize = 10;

            // TODO check if skip and take work
            var eventToReturn = this.data.Events.All()
                .OrderByDescending(e => e.StartDate)
                .Skip(defaultPageSize * pageSize)
                .Take(defaultPageSize)
                .ProjectTo<EventResponceModel>();

            if (eventToReturn == null)
            {
                // TODO Add some message
                return this.BadRequest();
            }

            return this.Ok(eventToReturn);
        }

        [HttpGet]
        public IHttpActionResult AllByCategory(string category)
        {
            var eventsFromCategory = this.data.Events.All()
                .Where(e => e.Category.Name == category)
                .OrderByDescending(x => x.StartDate)
                .Take(10)
                .ProjectTo<EventResponceModel>();

            if (eventsFromCategory == null)
            {
                return this.BadRequest();
            }

            return this.Ok(eventsFromCategory);
        }

        [HttpGet]
        public IHttpActionResult AllByCategoryAndTown(string category, string town)
        {
            var eventsFromCategory = this.data.Events.All()
                .Where(e => e.Category.Name == category && e.Town.Name == town)
                .OrderByDescending(x => x.StartDate)
                .ProjectTo<EventResponceModel>();

            if (eventsFromCategory == null)
            {
                return this.BadRequest();
            }

            return this.Ok(eventsFromCategory);
        }

        [HttpPost]
        public IHttpActionResult Post(EventResponceModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var townId = this.data.Towns.All().Where(id => id.Name == model.Town).FirstOrDefault();
            // TODO Create data model
            /*
            var eventToAdd = EventDataModel.FromModelToData(model, townId.Id);
            this.data.Events.Add(eventToAdd);
            this.data.Savechanges();

            return this.Created(this.Url.ToString(), eventToAdd);
            */

            return this.Created(this.Url.ToString(), townId);
        }

        [HttpPut]
        public IHttpActionResult Put(int id, EventResponceModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var eventToUpdate = this.data.Events.All().Where(ev => ev.Id == id).FirstOrDefault();

            if (eventToUpdate == null)
            {
                return this.BadRequest();
            }

            var townId = this.data.Towns.All().Where(t => t.Name == model.Town).FirstOrDefault();

            eventToUpdate.Name = model.Name ?? eventToUpdate.Name;
            eventToUpdate.IsPrivate = model.IsPrivate;
            eventToUpdate.StartDate = model.StartDate;
            eventToUpdate.EndDate = model.EndDate;
            eventToUpdate.TownId = townId.Id;

            this.data.Events.Update(eventToUpdate);
            this.data.Savechanges();

            return this.Ok("Some updated event");
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id, EventResponceModel model)
        {
            var eventToDelete = this.data.Events.All().Where(ev => ev.Id == id).FirstOrDefault();

            if (eventToDelete == null)
            {
                return this.BadRequest();
            }

            this.data.Events.Delete(eventToDelete);
            this.data.Savechanges();

            return this.Ok("Some deleted event");
        }

        [HttpPost]
        [Route("join/{eventId}")]
        public IHttpActionResult Join(int eventId)
        {
            var eventToJoin = this.data.Events.All().Where(ev => ev.Id == eventId).FirstOrDefault();

            if (eventToJoin == null)
            {
                return this.BadRequest();
            }

            var currentUserName = this.User.Identity.Name;
            var currentUser = this.data.Users.All().Where(u => u.UserName == currentUserName).FirstOrDefault();

            eventToJoin.Users.Add(currentUser);
            this.data.Events.Update(eventToJoin);
            this.data.Savechanges();
            // check user?
            return this.Ok("Join");
        }

        [HttpPut]
        [Route("join/{eventId}")]
        public IHttpActionResult Leave(int eventId)
        {
            var eventToLeave = this.data.Events.All().Where(ev => ev.Id == eventId).FirstOrDefault();

            if (eventToLeave == null)
            {
                return this.BadRequest();
            }

            var currentUserName = this.User.Identity.Name;
            var currentUser = this.data.Users.All().Where(u => u.UserName == currentUserName).FirstOrDefault();

            eventToLeave.Users.Remove(currentUser);
            this.data.Events.Update(eventToLeave);
            this.data.Savechanges();
            // check user?
            return this.Ok("Leave");
        }

        [HttpPost]
        [Route("rate/{eventId}/{rating}")]
        public IHttpActionResult Rate(int eventId, int rating)
        {
            // check user?
            return this.Ok("Rate: " + rating);
        }

        [HttpPut]
        [Route("rate/{eventId}/{rating}")]
        public IHttpActionResult UpdateRate(int eventId, int rating)
        {
            // check user?
            return this.Ok("Update Rate: " + rating);
        }
    }
}