namespace EventsSystem.Api.Tests.ControllersTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;
    using Api.Controllers;
    using System.Net.Http;
    using Models.Towns;

    [TestClass]
    public class TownControllerTests
    {
        [TestMethod]
        public void TestGetTownShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/towns")
                .To<TownsController>(c => c.Get());
        }

        [TestMethod]
        public void TestGetTownIdShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/towns/1")
                .To<TownsController>(c => c.Get(1));
        }

        [TestMethod]
        public void TestTownsPostShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/towns")
                .WithHttpMethod(HttpMethod.Post)
                .WithJsonContent(@"{ ""Name"": ""City"" }")
                .To<TownsController>(c => c.Post(new TownSaveModel
                {
                    Name = "City"                     
                }));
        }
    }
}
