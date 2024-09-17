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
                //List<string> errorsList = new List<string>();
                //foreach (var value in ModelState.Values)
                //{
                //    foreach (var err in value.Errors)
                //    {
                //        errorsList.Add(err.ErrorMessage);
                //    }
                //}
                //string error = string.Join("\n", errorsList);

                //List<string> errorsList = ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage).ToList();
                //string error = string.Join("\n", errorsList);

                string error = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage).ToList());

                return BadRequest(error);
            }

            return Content(animal.ToString());
        }
    }
}
