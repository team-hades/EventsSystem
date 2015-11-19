namespace EventsSystem.Api.Controllers
{
    using System;
    using System.Web.Http;
    using Models.Comments;
    using Data.Data.Repositories;
    using Data.Models;
    using System.Linq;
    using Infrastructure.Validation;

    /// <summary>
    /// Responsible for comments actions
    /// </summary>
    [RoutePrefix("api/comments")]
    public class CommentsController : BaseController
    {

        public CommentsController(IEventsSystemData data)
            : base(data)
        {
        }

        /// <summary>
        /// Post new comment in specific event
        /// http://localhost:58368/api/comments/35
        /// </summary>
        /// <param name="eventId">The event Id</param>
        /// <param name="model">Comment model (requires comment content)</param>
        /// <returns>New comment id</returns>
        [HttpPost]
        [Route("{eventId}")]
        [ValidateModel]
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

            return this.Created("api/commets/{eventId}", new
            {
                CommentId = commentToAdd.Id
            });
        }

        /// <summary>
        /// Change comment in specific event
        /// http://localhost:58368/api/comments/35
        /// </summary>
        /// <param name="eventId">The event Id</param>
        /// <param name="model">Comment model (requires comment content)</param>
        /// <returns>Updated comment id</returns>
        [HttpPut]
        [Route("{commentId}")]
        [ValidateModel]
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

        /// <summary>
        /// Deletes comment in specific event
        /// </summary>
        /// <param name="eventId">The event Id</param>
        /// <param name="model">Comment Id</param>
        /// <returns>Deleted comment confirmation</returns>
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