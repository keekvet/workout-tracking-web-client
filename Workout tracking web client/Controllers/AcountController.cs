using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Workout_tracking_web_client.Extension;
using Workout_tracking_web_client.Models.User;
using Workout_tracking_web_client.Services.Interfaces;
using WorkoutTracking.Application.Dto.User;

namespace Workout_tracking_web_client.Controllers
{
    [AllowAnonymous]
    public class AcountController : RestClientController
    {
        public AcountController(IHttpClientService httpClientService) : base(httpClientService){}

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginModel model)
        {
            RestRequest request = new RestRequest("login", Method.POST);
            request.AddJsonBody(model);

            IRestResponse<UserTokenDto> response = 
                await httpClientService.NewInstance(null).ExecuteAsync<UserTokenDto>(request);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                ViewData["Message"] = response.GetErrorMessage();
                return View();
            }

            ControllerContext.HttpContext.Session.SetString("token", response.Data.Jwt);
            ControllerContext.HttpContext.Session.SetString("userName", response.Data.Name);

            return Redirect($"~/user/{response.Data.Name}");
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterModel model)
        {
            RestRequest request = new RestRequest("register", Method.POST);
            request.AddJsonBody(model);

            IRestResponse<UserDto> response = 
                await httpClientService.NewInstance(null).ExecuteAsync<UserDto>(request);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                ViewBag["Message"] = response.GetErrorMessage();
                return View();
            }
            return Redirect("~/home/index");
        }
    }
}
