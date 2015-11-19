namespace EventsSystem.Api.Tests.ControllersTests
{
    using MyTested.WebApi;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Api.Controllers;
    using System.Net.Http;

    [TestClass]
    public class TagControllerTests
    {
        [TestMethod]
        public void CorrectlyMapTagsController()
        {
            MyWebApi
                  .Routes()
                  .ShouldMap("api/tags")
                  .To<TagsController>(c => c.Get());
        }

        [TestMethod]
        public void ReturnValidModelState()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/tags")
                .WithHttpMethod(HttpMethod.Get)
                .ToValidModelState();
        }

        [TestMethod]
        public void ReturnOkWhenProvidedParamWithStringInUrl()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/tags?name=red")
                .To<TagsController>(c => c.Get("red"));
        }

        [TestMethod]
        public void ReturnNullWhenProvidedParamWithStringInUrl()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/tags?name=")
                .To<TagsController>(c => c.Get(null))
                .ToInvalidModelState();
        }

        [TestMethod]
        public void ReturnOkWhenProvidedIdOfTag()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/tags/35")
                .To<TagsController>(c => c.Get(35));
        }
    }
}
