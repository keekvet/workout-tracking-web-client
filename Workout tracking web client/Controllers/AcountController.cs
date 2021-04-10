using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workout_tracking_web_client.Models.User;
using Workout_tracking_web_client.Services.Interfaces;
using WorkoutTracking.Application.Dto.User;

namespace Workout_tracking_web_client.Controllers
{
    [AllowAnonymous]
    public class AcountController : RestClientController
    {
        public AcountController(IHttpClientService httpClientService) : base(httpClientService){}

        [HttpGet]
        public async Task<IActionResult> LoginAsync()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginModel model)
        {
            RestRequest request = new RestRequest("api/login");

            request.AddJsonBody(model);

            UserTokenDto userTokenDto = await httpClientService.NewInstance(null).PostAsync<UserTokenDto>(request);

            if(userTokenDto is null)
                return View();

            ControllerContext.HttpContext.Session.SetString("token", userTokenDto.Jwt);

            return Redirect("~/home/index");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(LoginModel model)
        {
            return Redirect("~/home/index");
        }
    }
}
