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
