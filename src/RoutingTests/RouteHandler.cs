using Microsoft.AspNet.Routing;
using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;

namespace RoutingTests
{
    public class RouteHandler : IRouter
    {
        public RouteHandler(
            bool shouldHandleRequest, 
            string response)
        {
            _shouldHandleRequest = shouldHandleRequest;
            _response = response;
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            throw new NotImplementedException();
        }

        public async Task RouteAsync(RouteContext context)
        {
            if (_response != null)
            {
                await context.HttpContext.Response.WriteAsync(_response);
            }

            context.IsHandled = _shouldHandleRequest;
        }

        private readonly bool _shouldHandleRequest;
        private readonly string _response;
    }
}
