using Microsoft.AspNetCore.Mvc;

namespace dotNETControllersApp.Properties.Controllers
{
    public class HomeController
    {
        [Route("home")]
        public string homeMethod()
        {
            return "Hello! from homeMethod of HomeController.";
        }
    }
}
