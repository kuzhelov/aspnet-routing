using Microsoft.AspNet.Mvc;

namespace RoutingTests.Controllers
{
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        [Route("{id}")]
        public string GetProductById(int id)
        {
            return $"Product with ID {id} has been requested";
        }
    }
}
