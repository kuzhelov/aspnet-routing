using Microsoft.AspNet.Mvc;

namespace RoutingTests.Controllers
{
    [Route("[controller]")]
    public class ProductsController : Controller
    {   
        // in case if 'id' is not provided by the URL, 
        // request will end up with the 'Page Not Found' (404)

        // when there is no restriction  
        [Route("{id}")]
        public IActionResult GetProductById(
            // in case of strong int typing, the id will be provided with the default int value
            // on failed conversion of value to int - i.e. with 0 value,
            // and it could lead to undesired effects

            // in case of Nullable typing - it would be possible to check if correct value is provided or not
            int? id)
        {
            if (id.HasValue)
            {
                return Content($"Product with ID {id} has been requested");
            }

            return HttpNotFound();
        }
    }
}
