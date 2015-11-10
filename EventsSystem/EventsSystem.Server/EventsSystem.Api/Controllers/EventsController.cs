namespace EventsSystem.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Data.Data.Repositories;
    using Models;

    using AutoMapper.QueryableExtensions;
    using Data.Models;
    using Infrastructure.Mapping;

    [RoutePrefix("api/events")]
    public class EventsController : BaseController
    {
        IMappingService mapservices;

        public EventsController(IEventsSystemData data, IMappingService mapservices)
            : base(data)
        {
            this.mapservices = mapservices;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            // TODO: If current user is admin: get all events
            if (this.User.IsInRole("Admin"))
            {
                var allAdminEvents = this.data.Events
                                .All()
                                .OrderByDescending(d => d.StartDate)
                                .ProjectTo<EventResponseModel>();

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
                .ProjectTo<EventResponseModel>();

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
                .ProjectTo<EventResponseModel>();

            return this.Ok(allVisibleEvents);
        }

        [HttpGet]
        public IHttpActionResult All(int id)
        {
            var eventToReturn = this.data.Events.All().Where(ev => ev.Id == id).ProjectTo<EventResponseModel>();

            if (eventToReturn == null)
            {
                // TODO Add some message
                return this.BadRequest();
            }

            // TODO we neeed to include a collection ofcomments in the model to work
            return this.Ok(eventToReturn);
        }
        
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
                .ProjectTo<EventResponseModel>();

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
                .ProjectTo<EventResponseModel>();

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
                .ProjectTo<EventResponseModel>();

            if (eventsFromCategory == null)
            {
                return this.BadRequest();
            }

            return this.Ok(eventsFromCategory);
        }

        [HttpPost]
        public IHttpActionResult Post(EventResponseModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var eventToAdd = this.mapservices.Map<Event>(model);
            var town = this.data.Towns.All().Where(id => id.Name == model.Town).FirstOrDefault();
            var category = this.data.Categories.All().Where(id => id.Name == model.Category).FirstOrDefault();
            eventToAdd.CategoryId = category.Id;
            eventToAdd.TownId = town.Id;

            this.data.Events.Add(eventToAdd);
            this.data.Savechanges();

            return this.Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(int id, EventResponseModel model)
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

            var town = this.data.Towns.All().Where(t => t.Name == model.Town).FirstOrDefault();
            var category = this.data.Categories.All().Where(x => x.Name == model.Category).FirstOrDefault();

            eventToUpdate.Name = model.Name ?? eventToUpdate.Name;
            eventToUpdate.IsPrivate = model.IsPrivate;
            eventToUpdate.StartDate = model.StartDate;
            eventToUpdate.EndDate = model.EndDate;
            eventToUpdate.TownId = town.Id;
            eventToUpdate.CategoryId = category.Id;

            this.data.Events.Update(eventToUpdate);
            this.data.Savechanges();

            return this.Ok("Some updated event");
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id, EventResponseModel model)
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

            return this.Ok("Join");
        }

        [HttpPut]
        [Route("leave/{eventId}")]
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
           
            return this.Ok("Leave");
        }

        [HttpPost]
        [Route("rate/{eventId}/{rating}")]
        public IHttpActionResult Rate(int eventId, int rating)
        {
            if (rating < 0 || rating  > 5)
            {
                return this.BadRequest();
            }

            var eventWithRating = this.data.Events.All().Where(ev => ev.Id == eventId).FirstOrDefault();

            if (eventWithRating == null)
            {
                return this.BadRequest();
            }

            var currentUserName = this.User.Identity.Name;
            var currentUser = this.data.Users.All().Where(u => u.UserName == currentUserName).FirstOrDefault();

            var ratingToAdd = new Rating
            {
                EventId = eventWithRating.Id,
                UserId = currentUser.Id,
                Value = rating
            };

            this.data.Ratings.Add(ratingToAdd);
            this.data.Savechanges();

            return this.Ok("Rate: " + rating);
        }

        [HttpPut]
        [Route("rate/{eventId}/{rating}")]
        public IHttpActionResult UpdateRate(int eventId, int rating)
        {
            if (rating < 0 || rating  > 5)
            {
                return this.BadRequest();
            }

            var eventWithRating = this.data.Events.All().Where(ev => ev.Id == eventId).FirstOrDefault();

            if (eventWithRating == null)
            {
                return this.BadRequest();
            }
                        
            return this.Ok("Update Rate: " + rating);
        }
    }
}