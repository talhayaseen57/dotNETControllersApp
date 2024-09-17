using dotNETControllersApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotNETControllersApp.Controllers
{
    public class AnimalController : Controller
    {
        [Route("animal")]
        public IActionResult AnimalMethod(Animal animal)
        {
            if (!ModelState.IsValid)
            {
                List<string> errorsList = new List<string>();
                foreach (var value in ModelState.Values)
                {
                    foreach (var err in value.Errors)
                    {
                        errorsList.Add(err.ErrorMessage);
                    }
                }
                string error = string.Join("\n", errorsList);
                return BadRequest(error);
            }

            return Content(animal.ToString());
        }
    }
}
