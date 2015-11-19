namespace EventsSystem.Api.Tests.ControllersTests
{
    using System.Net.Http;
    using Api.Controllers;
    using Models.Categories;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;

    [TestClass]
    public class CategoriesControllerTests
    {
        [TestMethod]
        public void TestGetCategoryShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/categories")
                .To<CategoriesController>(c => c.Get());
        }

        [TestMethod]
        public void TestGetCategoryByIdShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/categories/1")
                .To<CategoriesController>(c => c.Get());
        }

        [TestMethod]
        public void TestGetCategoryByNameShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/categories?name=fun")
                .To<CategoriesController>(c => c.Get("fun"));
        }

        [TestMethod]
        public void TestDeleteCategoryShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/categories/1")
                .WithHttpMethod(HttpMethod.Delete)
                .To<CategoriesController>(c => c.Delete(1));
        }

        [TestMethod]
        public void PostCategoryShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/categories/1")
                .WithHttpMethod(HttpMethod.Post)
                .WithJsonContent(@"{ ""Name"": ""Test"" }")
                .To<CategoriesController>(c => c.Post(1, new CategoryModel
                {
                    Name = "Test"
                }));
        }

        [TestMethod]
        public void PutCategoryShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/categories/1")
                .WithHttpMethod(HttpMethod.Put)
                .WithJsonContent(@"{ ""Name"": ""NewTest"" }")
                .To<CategoriesController>(c => c.Put(1, new CategoryModel
                {
                    Name = "NewTest"
                }));
        }
    }
}
