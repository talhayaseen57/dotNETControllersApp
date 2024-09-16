using Microsoft.AspNetCore.Mvc;

namespace dotNETControllersApp.Properties.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        [Route("home")]
        public ContentResult Index()
        {
            //return "Hello! from Index method of HomeController.";     -> for string type return

            //return new ContentResult()
            //{
            //    Content = "Hello! from Index method of HomeController.",
            //    ContentType = "text/plain"
            //};

            //return Content("Hello! from Index method of HomeController.", "text/plain");

            return Content("<h1>Welcome</h1><h2>Hi from Index</h2>", "text/html");
        }

        // ^??$ -> template for regex expression
        // //d  -> for digits only
        // {{??}} -> for number of characters
        [Route("contact/{mobile:regex(^\\d{{10}}$)}")]
        public string Contact()
        {
            return "Hello! from Contact method of HomeController.";
        }
    }
}
