using dotNETControllersApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotNETControllersApp.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        [Route("home")]
        public IActionResult Index()
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

        [Route("book")]
        public IActionResult Book()
        {
            // bookid parameter isn't provided
            if (!Request.Query.ContainsKey("bookid"))
            {
                //Response.StatusCode = 400;
                //return Content("Alas! bookid parameter is not provided.");

                //return new BadRequestResult("Alas! bookid parameter is not provided.");
                return BadRequest("Alas! bookid parameter is not provided.");
            }

            // bookid parameter can't be empty
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                //Response.StatusCode = 400;
                //return Content("The provided bookid parameter can't be null or empty.");

                return BadRequest("The provided bookid parameter can't be null or empty.");
            }

            int bookid = Convert.ToInt16(ControllerContext.HttpContext.Request.Query["bookid"]);
            //int bookid = Convert.ToInt16(Request.Query["bookid"]);

            // bookid is not between 0 and 1000
            if (bookid <= 0)
            {
                //Response.StatusCode = 400;
                //return Content("The provided bookid can't be less than or equal to zero.");

                return BadRequest("The provided bookid can't be less than or equal to zero.");
            }
            else if (bookid > 1000)
            {
                //Response.StatusCode = 400;
                //return Content("The provided bookid can't be greater than 1000.");

                return NotFound("The provided bookid can't be greater than 1000.");
            }

            // isloggedin parameter is false
            if (Convert.ToBoolean(Request.Query["isloggedin"]) == false)
            {
                //Response.StatusCode = 401;
                //return Content("Authenticaltion Failed!");

                return Unauthorized("Authenticaltion Failed!");
            }

            //return Content("<h1>Welcome to ASP.NET Contollers App</h1><h2>Hi from Index</h2>", "text/html");
            //return File("Dummy Document.pdf", "application/pdf");

            // redirecting to a new url
            //return new RedirectToActionResult("Books", "Store", new {});
            return RedirectToAction("Books", "Store", new { id = bookid });

            //return new RedirectToActionResult("Books", "Store", new {}, true);
        }

        [Route("person")]
        public JsonResult Person()
        {
            Person person = new Person() { Id = 1, FirstName = "John", LastName = "Doe", Age = 25 };
            //return new JsonResult(person);
            return Json(person);
        }

        // method to downlaod pdf file only from `wwwroot` directory
        [Route("downloadfile1")]
        public VirtualFileResult VirtualFileDownload()
        {
            //return new VirtualFileResult("/Dummy Document.pdf", "application/pdf");
            return File("Dummy Document.pdf", "application/pdf");
        }

        // method to download pdf file from any directory
        [Route("downloadfile2")]
        public PhysicalFileResult PhysicalFileDownload()
        {
            //return new PhysicalFileResult(@"C:\\Users\\Zaib\\Downloads\\Zoro protocol.pdf", "application/pdf");
            return PhysicalFile(@"C:\\Users\\Zaib\\Downloads\\Zoro protocol.pdf", "application/pdf");
        }

        [Route("downloadfile3")]
        public FileContentResult FileContentDownload()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(@"C:\Users\Zaib\Pictures\My Posts\slack bot icon.png");
            //return new FileContentResult(fileBytes, "image/png");
            return File(fileBytes, "iamge/png");
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
