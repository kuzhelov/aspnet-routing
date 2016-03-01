using Microsoft.AspNet.Routing;
using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;

namespace RoutingTests
{
    public class RouteHandler : IRouter
    {
        public RouteHandler(
            string response)
        {
            _response = response;
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            throw new NotImplementedException();
        }

        public async Task RouteAsync(RouteContext context)
        {
            await context.HttpContext.Response.WriteAsync(_response);
            context.IsHandled = true;
        }

        private readonly string _response;
    }
}
