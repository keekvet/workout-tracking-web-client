using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workout_tracking_web_client.Filters;
using Workout_tracking_web_client.Services.Interfaces;

namespace Workout_tracking_web_client.Controllers
{
    [AccessTokenFilter]
    public class UserController : RestClientController
    {
        public UserController(IHttpClientService httpClientService) : base(httpClientService)
        {
        }

        [HttpGet("user/{userName}")]
        public IActionResult Profile(string userName)
        {
            ViewData["profileUserName"] = userName;
            return View();
        }
    }
}
