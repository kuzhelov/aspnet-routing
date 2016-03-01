using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Routing;

namespace RoutingTests
{
    public class ProductsRouteHandler : IRouter
    {
        public async Task RouteAsync(RouteContext context)
        {
            var productCategory = context.RouteData.Values["category"];
            var productName = context.RouteData.Values["product"];

            await context.HttpContext.Response.WriteAsync(
                $"Are you asking about '{productName}' from the '{productCategory}' category?\n" +
                "Unfortunately, we cannot offer you something yet :(");

            context.IsHandled = true;
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
