using Microsoft.AspNet.Http;
using Microsoft.AspNet.Routing;
using System;
using System.Threading.Tasks;

namespace RoutingTests
{
    public class MvcDiagnosticsHandler : IRouter
    {
        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            throw new NotImplementedException();
        }

        public async Task RouteAsync(RouteContext context)
        {
            var controller = context.RouteData.Values["controller"];
            var action = context.RouteData.Values["action"];

            await context.HttpContext.Response.WriteAsync(
                text: $"You've asked for action '{action}' of the '{controller}' controller");

            context.IsHandled = true;
        }
    }
}
