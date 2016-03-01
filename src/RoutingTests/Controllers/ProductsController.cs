using Microsoft.AspNet.Mvc;

namespace RoutingTests.Controllers
{
    [Route("[controller]")]
    public class ProductsController : Controller
    {   
        [Route("{id:int?}")]
        public IActionResult GetProductById(int id = 100)
        {
            return Content($"Product with ID {id} has been requested");
        }

        // use ~ for omitting controller's route prefix
        [Route("~/my-products")]
        public string ListMyProducts()
        {
            return "Here all my products are listed";
        }
    }
}
