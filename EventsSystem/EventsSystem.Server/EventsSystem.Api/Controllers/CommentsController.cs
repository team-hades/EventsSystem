namespace EventsSystem.Api.Controllers
{
    using System.Web.Http;
    using Models.Comments;
    using EventsSystem.Data.Data.Repositories;

    [RoutePrefix("api/events/{eventId}")]
    public class CommentsController : BaseController
    {

        public CommentsController(IEventsSystemData data)
            : base(data)
        {
        }
        /*
        [HttpGet]
        public IHttpActionResult AllByEventId()
        {

        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] CommmentsResponseModel model)
        {

        }

        [HttpPut]
        public IHttpActionResult Put(int commentId)
        {

        }

        [HttpDelete]
        public IHttpActionResult AllByEventId(int commentId)
        {

        }
        */
    }
}