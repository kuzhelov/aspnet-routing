using Microsoft.AspNet.Mvc;

namespace RoutingTests.Controllers
{
    [Route("[controller]")]
    public class ProductsController : Controller
    {   
        // in case if 'id' does not meet restrictions, 
        // request will end up with the 'Page Not Found' (404)
        [Route("{id:int}")]
        public IActionResult GetProductById(int id)
        {
            return Content($"Product with ID {id} has been requested");
        }
    }
}
