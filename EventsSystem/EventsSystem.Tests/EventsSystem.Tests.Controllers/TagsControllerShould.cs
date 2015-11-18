namespace EventsSystem.Tests.Controllers
{
    using MyTested.WebApi;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Api.Controllers;
    using System;
    using System.Net.Http;

    [TestClass]
    public class TagsControllerShould
    {
        // http://localhost:58368/api/comments/35
        // public IHttpActionResult PostComment(int eventId, [FromBody]

        [TestMethod]
        public void ReturnMethodNotAllowed()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/comments/35")
                .WithHttpMethod(HttpMethod.Get)
                .ToNotAllowedMethod();
        }
    }
}
