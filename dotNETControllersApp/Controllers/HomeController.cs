using dotNETControllersApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotNETControllersApp.Controllers
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

            return Content("<h1>Welcome to ASP.NET Contollers App</h1><h2>Hi from Index</h2>", "text/html");
        }

        [Route("person")]
        public JsonResult Person()
        {
            Person person = new Person() { Id = 1, FirstName = "John", LastName = "Doe", Age = 25 };
            //return new JsonResult(person);
            return Json(person);
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
