using Microsoft.AspNet.Mvc;

namespace RoutingTests.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Here is the result of the 'Index' action";
        }

        public string About()
        {
            return "Here is the result of the 'About' action";
        }
    }
}
