namespace EventsSystem.Tests.Controllers
{
    using MyTested.WebApi;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Api.Controllers;
    using System;
    using System.Net.Http;

    [TestClass]
    public class TownsController
    {
        [TestMethod]
        public void ReturnValidModelState()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/towns")
                .WithHttpMethod(HttpMethod.Get)
                .ToValidModelState();
        }
    }
}
