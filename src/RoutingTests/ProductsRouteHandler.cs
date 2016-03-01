using System;
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
            var productId = Convert.ToInt32(context.RouteData.Values["product"]);

            if (productId == LuckyProductId)
            {
                await context.HttpContext.Response.WriteAsync(
                     $"Are you asking about product with the ID '{productId}' from the '{productCategory}' category?\n" +
                     "You are lucky man - we have something for you!\n" + @"
   10010     00100      10010     
   00100    0010010    1001001    
    1001    01001001   00100100   
    0010   010  0010  001  1001   
    010    100   100  010   010   
    1001   00    001  10    100   
    001    01    010  00    001   
    010    1 0  0100  0 0  0010   
    10010   01001001   00100100   
  0100100   1001001    0100100    
   0010010   0100       0010    ");
            }
            else
            {
                await context.HttpContext.Response.WriteAsync(
                    $"Are you asking about product with the ID '{productId}' from the '{productCategory}' category?\n" +
                    "Unfortunately, we cannot offer you something yet :(");
            }
           
            context.IsHandled = true;
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            throw new System.NotImplementedException();
        }

        private const int LuckyProductId = 100;
    }
}
