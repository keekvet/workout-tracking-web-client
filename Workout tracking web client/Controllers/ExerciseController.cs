using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workout_tracking_web_client.Extension;
using Workout_tracking_web_client.Services.Interfaces;
using WorkoutTracking.Application.Dto.Training;
using WorkoutTracking.Application.Models.Exercise;

namespace Workout_tracking_web_client.Controllers
{
    [Route("exercise")]
    public class ExerciseController : RestClientController
    {
        private readonly IMapper mapper;
        public ExerciseController(
            IMapper mapper,
            IHttpClientService httpClientService, 
            IHttpContextAccessor httpContext) 
            : base(httpClientService, httpContext)
        {
            this.mapper = mapper;
        }

        [HttpGet("add")]
        public IActionResult AddExercise(int templateId)
        {
            ExerciseModel model = new ExerciseModel() { TrainingTemplateId = templateId };
            return View(model);
        }

        [HttpPost("add-model")]
        public async Task<IActionResult> AddExercise(ExerciseModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            RestRequest request = new RestRequest("exercise/add", Method.POST);
            request.AddJsonBody(model);

            IRestResponse<ExerciseDto> response =
                await httpClientService.NewInstance(token)
                .ExecuteWithTimeoutExceptionAsync<ExerciseDto>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                ViewData["Message"] = "invalid data";
                return View();
            }

            return Redirect("~/training/update/" + model.TrainingTemplateId);
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> DeleteExercise([FromRoute] int id, int templateId)
        {
            RestRequest request = new RestRequest("exercise/remove", Method.DELETE);
            request.AddJsonBody(id);

            IRestResponse<bool> response =
                await httpClientService.NewInstance(token)
                .ExecuteWithTimeoutExceptionAsync<bool>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                ViewData["Message"] = "invalid data";

            return Redirect("~/training/update/" + templateId);
        }

        [HttpGet("update/{id}")]
        public async Task<IActionResult> UpdateExercise(int id)
        {
            RestRequest request = new RestRequest("exercise/" + id, Method.GET);

            IRestResponse<ExerciseDto> response =
                await httpClientService.NewInstance(token)
                .ExecuteWithTimeoutExceptionAsync<ExerciseDto>(request);


            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                ViewData["Message"] = "invalid data";
                return View();
            }

            return View(mapper.Map<ExerciseDto, ExerciseUpdateModel>(response.Data));
        }


        [HttpPost("update")]
        public async Task<IActionResult> UpdateExercise(ExerciseUpdateModel model)
        {

            if (!ModelState.IsValid)
                return View(model);

            RestRequest request = new RestRequest("exercise/update", Method.PUT);
            request.AddJsonBody(model);

            IRestResponse<ExerciseDto> response =
                await httpClientService.NewInstance(token)
                .ExecuteWithTimeoutExceptionAsync<ExerciseDto>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                ViewData["Message"] = "invalid data";
                return View();
            }

            return Redirect("~/training/update/" + response.Data.TrainingTemplateId);

        }
    }
}
