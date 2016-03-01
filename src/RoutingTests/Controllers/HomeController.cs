using Microsoft.AspNet.Mvc;

namespace RoutingTests.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [Route("[action]")]
        public string Index()
        {
            return "Here is the result of the 'Index' action";
        }
    }
}
