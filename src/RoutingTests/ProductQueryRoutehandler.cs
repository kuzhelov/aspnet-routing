using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Routing;

namespace RoutingTests
{
    public class ProductQueryRouteHandler : IRouter
    {
        public async Task RouteAsync(RouteContext context)
        {
            var category = context.RouteData.Values["category"];
            var productQuery = context.RouteData.Values["productQuery"];

            await context.HttpContext.Response.WriteAsync(
                $"Searching for the product in the {category} category with the following query: {productQuery} ..\n" +
                "Unfortunately, no results were found :(");

            context.IsHandled = true;
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            throw new NotImplementedException();
        }
    }
}
