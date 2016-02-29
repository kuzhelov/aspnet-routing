using Microsoft.AspNet.Routing;
using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;

namespace RoutingTests
{
    public class RouteHandler : IRouter
    {
        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            throw new NotImplementedException();
        }

        public async Task RouteAsync(RouteContext context)
        {
            await context.HttpContext.Response.WriteAsync("Hello from the Route Handler!");
            context.IsHandled = true;
        }
    }
}
