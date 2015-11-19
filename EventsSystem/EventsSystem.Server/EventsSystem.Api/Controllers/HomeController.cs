namespace EventsSystem.Api.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// Default home page controller
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
