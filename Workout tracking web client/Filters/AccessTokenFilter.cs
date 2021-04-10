using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workout_tracking_web_client.Filters
{
    public class AccessTokenFilter : Attribute, IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            string token = context.HttpContext.Session.GetString("token");
            if (token is null)
            {
                context.HttpContext.Response.StatusCode = 404;
                await context.HttpContext.Response.StartAsync();
            }
        }
    }
}
