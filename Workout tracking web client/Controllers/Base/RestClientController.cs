using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workout_tracking_web_client.Services.Interfaces;

namespace Workout_tracking_web_client.Controllers
{
    public class RestClientController : Controller
    {
        protected readonly IHttpClientService httpClientService;
        protected readonly string token;

        public RestClientController(IHttpClientService httpClientService, IHttpContextAccessor httpContext)
        {
            this.httpClientService = httpClientService;
            token = httpContext.HttpContext.Session.GetString("token");
        }
    }
}
