using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Routing;
using Microsoft.AspNet.Routing.Template;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.OptionsModel;

namespace RoutingTests
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(
                configureOptions: routeOptions => { });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            // app.UseIISPlatformHandler();

            loggerFactory.AddDebug();
            loggerFactory.AddConsole();

            var inlineConstraintsResolver = new DefaultInlineConstraintResolver(
                routeOptions: app.ApplicationServices.GetService<IOptions<RouteOptions>>());

            var routes = new RouteCollection();

            routes.Add(new TemplateRoute(
                target: new ProductsRouteHandler(), 
                routeTemplate: "{category:alpha:minlength(3)}/{product:int=100}",
                inlineConstraintResolver: inlineConstraintsResolver));

            routes.Add(new TemplateRoute(
                target: new RouteHandler("It seems that some variable in the URL does not satisfy restrictions of the Product route"),
                routeTemplate: "{category}/{product}",
                inlineConstraintResolver: inlineConstraintsResolver));

            routes.Add(new RouteHandler("Hello fron the fallback route handler!"));

            app.UseRouter(routes);
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
