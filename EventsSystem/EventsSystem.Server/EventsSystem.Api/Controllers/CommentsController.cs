namespace EventsSystem.Api.Controllers
{
    using System;
    using System.Web.Http;
    using Models.Comments;
    using EventsSystem.Data.Data.Repositories;
    using Data.Models;
    using System.Linq;

    [RoutePrefix("api/comments")]
    public class CommentsController : BaseController
    {

        public CommentsController(IEventsSystemData data)
            : base(data)
        {
        }

        [HttpPost]
        [Route("{eventId}")]
        // http://localhost:58368/api/comments/35
        public IHttpActionResult PostComment(int eventId, [FromBody] CommmentsResponseModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var eventToJoin = this.data.Events.All().Where(ev => ev.Id == eventId).FirstOrDefault();

            if (eventToJoin == null)
            {
                return this.BadRequest();
            }

            var currentUserName = this.User.Identity.Name;
            var currentUser = this.data.Users.All().Where(u => u.UserName == currentUserName).FirstOrDefault();

            var commentToAdd = new Comment
            {
                Content = model.Content,
                DateCreated = DateTime.UtcNow,
                EventId = eventToJoin.Id,
                AuthorId = currentUser.Id
            };

            this.data.Comments.Add(commentToAdd);
            this.data.Savechanges();

            return this.Ok(commentToAdd.Id);
        }

        [HttpPut]
        [Route("{commentId}")]
        // http://localhost:58368/api/comments/35
        public IHttpActionResult UpdateComment(int commentId, [FromBody] CommmentsResponseModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var commentToUpdate = this.data.Comments.All().Where(c => c.Id == commentId).FirstOrDefault();

            if (commentToUpdate == null)
            {
                return this.BadRequest();
            }

            commentToUpdate.Content = model.Content;

            this.data.Comments.Update(commentToUpdate);
            this.data.Savechanges();

            return this.Ok(commentToUpdate.Id);
        }

        [HttpDelete]
        [Route("{eventId}")]
        // http://localhost:58368/api/comments/7?commentId=35
        public IHttpActionResult DeleteCommment(int eventId, [FromUri] int commentId)
        {
            var commentToDelete = this.data.Comments.All().Where(ev => ev.Id == commentId).FirstOrDefault();

            if (commentToDelete == null)
            {
                return this.BadRequest();
            }

            this.data.Comments.Delete(commentToDelete);
            this.data.Savechanges();

            return this.Ok("This comment was deleted");
        }       
    }
}