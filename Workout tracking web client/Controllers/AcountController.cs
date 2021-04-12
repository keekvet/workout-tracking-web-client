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
using Workout_tracking_web_client.Exceptions;
using Workout_tracking_web_client.Extension;
using Workout_tracking_web_client.Services.Interfaces;
using WorkoutTracking.Application.Dto.User;
using WorkoutTracking.Application.Models.User;

namespace Workout_tracking_web_client.Controllers
{
    [AllowAnonymous]
    public class AcountController : RestClientController
    {
        public AcountController(IHttpClientService httpClientService, IHttpContextAccessor context) 
            : base(httpClientService, context){}

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(UserLoginModel model)
        {
            if (!ModelState.IsValid)
                return View();

            RestRequest request = new RestRequest("login", Method.POST);
            request.AddJsonBody(model);

            IRestResponse<UserTokenDto> response = 
                await httpClientService.NewInstance(null).ExecuteWithTimeoutExceptionAsync<UserTokenDto>(request);

            if (!response.IsSuccessful)
                throw new ApiConnectionException();

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    ControllerContext.HttpContext.Session.SetString("token", response.Data.Jwt);
                    ControllerContext.HttpContext.Session.SetString("userName", response.Data.Name);

                    return Redirect($"~/user/{response.Data.Name}");
                case HttpStatusCode.Unauthorized:
                case HttpStatusCode.BadRequest:
                    ViewData["Message"] = "wrong credentials";
                    break;
                default:
                    break;
            }

            return View();
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(UserRegisterModel model)
        {
            if (!ModelState.IsValid)
                return View();

            RestRequest request = new RestRequest("register", Method.POST);
            request.AddJsonBody(model);

            IRestResponse<UserDto> response = 
                await httpClientService.NewInstance(null).ExecuteWithTimeoutExceptionAsync<UserDto>(request);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                ViewBag["Message"] = response.GetErrorMessage();
                return View();
            }
            return Redirect("~/home/index");
        }
    }
}
