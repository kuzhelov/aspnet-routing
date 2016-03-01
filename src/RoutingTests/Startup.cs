using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace RoutingTests
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            // app.UseIISPlatformHandler();

            loggerFactory.AddDebug();
            loggerFactory.AddConsole();

            var routes = new RouteCollection();

            // this handler sends a response
            // but processing chain is not stopped due to the fact that handler has not indicated that request is processed
            routes.Add(new RouteHandler(
                shouldHandleRequest: false,
                response: "Response from handler that is not able to handle request\n"));

            // this handler should handle request
            routes.Add(new RouteHandler(
                shouldHandleRequest: true,
                response: "Response from the main handler\n"));

            // this handler should be even asked about request processing
            routes.Add(new RouteHandler(
                shouldHandleRequest: true,
                response: "Response from handler that should not be displayed\n"));

            app.UseRouter(routes);
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
