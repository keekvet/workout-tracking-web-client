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
        IHttpClientService httpClientService;

        public RestClientController(IHttpClientService httpClientService)
        {
            this.httpClientService = httpClientService;
        }
    }
}
