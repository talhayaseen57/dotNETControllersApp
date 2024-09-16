using Microsoft.AspNetCore.Mvc;

namespace dotNETControllersApp.Properties.Controllers
{
    public class HomeController
    {
        [Route("home")]
        [Route("/")]
        public string Index()
        {
            return "Hello! from Index method of HomeController.";
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
