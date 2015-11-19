namespace EventsSystem.Api.Tests.ControllersTests
{
    using System.Net.Http;
    using Api.Controllers;
    using Models.Categories;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;
    using Models.Comments;
    using System;

    [TestClass]
    public class CommentsControllerTests
    {
        [TestMethod]
        public void TestDeleteCommentsShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/comments/1?commentId=35")
                .WithHttpMethod(HttpMethod.Delete)
                .To<CommentsController>(c => c.DeleteCommment(1, 35));
        }

        [TestMethod]
        public void TestPostShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/comments/1")
                .WithHttpMethod(HttpMethod.Post)
                .WithJsonContent(@"{ ""Content"": ""Starcraft is so much fun"", ""UserName"": ""Crazy"", ""DateCreated"": ""2015-10-10"" }")
                .To<CommentsController>(c => c.PostComment(1, new CommmentsResponseModel
                {
                    Content = "Starcraft is so much fun",
                    DateCreated = new DateTime(2015,10,10),
                    UserName = "Crazy"
                }));
        }

        [TestMethod]
        public void TestPutShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/comments/1")
                .WithHttpMethod(HttpMethod.Put)
                .WithJsonContent(@"{ ""Content"": ""Kill all Zergs"", ""UserName"": ""Crazy"", ""DateCreated"": ""2015-10-10"" }")
                .To<CommentsController>(c => c.UpdateComment(1, new CommmentsResponseModel
                {
                    Content = "Kill all Zergs",
                    DateCreated = new DateTime(2015, 10, 10),
                    UserName = "Crazy"
                }));
        }
    }
}
