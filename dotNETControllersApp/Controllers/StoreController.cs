using dotNETControllersApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotNETControllersApp.Controllers
{
    public class StoreController : Controller
    {
        [Route("bookstore/{bookId?}/{isloggedin?}")]
        //public IActionResult Index(int? bookId, bool? isloggedin)
        public IActionResult Index([FromQuery] int? bookid, [FromRoute] bool? isloggedin, Book book)
        {
            // bookid parameter isn't provided
            //if (!Request.Query.ContainsKey("bookid"))
            if (bookid.HasValue == false)
            {
                //Response.StatusCode = 400;
                //return Content("Alas! bookid parameter is not provided.");

                //return new BadRequestResult("Alas! bookid parameter is not provided.");
                return BadRequest("Alas! bookid parameter is not provided or is empty.");
            }

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
            if (isloggedin == false)
            {
                //Response.StatusCode = 401;
                //return Content("Authenticaltion Failed!");

                //return Unauthorized("Authenticaltion Failed!");
                return StatusCode(401);
            }

            return Content($"Book id: {bookid}, {book}", "text/plain");
        }

        [Route("/store/books/{id}")]
        public IActionResult Books()
        {
            int id = Convert.ToInt32(Request.RouteValues["id"]);
            return Content($"<h1>Book Number: {id}</h1>", "text/html");
        }
    }
}
