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
using Workout_tracking_web_client.ViewModels;
using WorkoutTracking.Application.Dto.Training;
using WorkoutTracking.Application.Models.ExerciseProperty;

namespace Workout_tracking_web_client.Controllers
{
    [Route("exercise-property")]
    public class ExercisePropertyController : RestClientController
    {
        private readonly IMapper mapper;
        public ExercisePropertyController(
            IMapper mapper,
            IHttpClientService httpClientService, 
            IHttpContextAccessor httpContext) 
            : base(httpClientService, httpContext)
        {
            this.mapper = mapper;
        }

        [HttpGet("add")]
        public IActionResult AddExerciseProperty(int exerciseId, int templateId)
        {
            ExercisePropertyViewModel model = new ExercisePropertyViewModel() 
            { ExerciseId = exerciseId, TrainingTemplateId = templateId };

            return View(model);
        }

        [HttpPost("add-model")]
        public async Task<IActionResult> AddExerciseProperty( ExercisePropertyViewModel model)
        {

            if (!ModelState.IsValid)
                return View(model);

            RestRequest request = new RestRequest("exercise-property/add", Method.POST);
            request.AddJsonBody(model as ExercisePropertyModel);

            IRestResponse<ExercisePropertyDto> response =
                await httpClientService.NewInstance(token)
                .ExecuteWithTimeoutExceptionAsync<ExercisePropertyDto>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                ViewData["Message"] = "invalid data";
                return View();
            }

            return Redirect("~/training/update/" + model.TrainingTemplateId);
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> DeleteExerciseProperty([FromRoute] int id, int templateId)
        {
            RestRequest request = new RestRequest("exercise-property/remove", Method.DELETE);
            request.AddJsonBody(id);

            IRestResponse<bool> response =
                await httpClientService.NewInstance(token)
                .ExecuteWithTimeoutExceptionAsync<bool>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                ViewData["Message"] = "invalid data";

            return Redirect("~/training/update/" + templateId);
        }

        [HttpGet("update/{id}")]
        public async Task<IActionResult> UpdateExerciseProperty(int id, int templateId)
        {
            RestRequest request = new RestRequest("exercise-property/" + id, Method.GET);

            IRestResponse<ExercisePropertyDto> response =
                await httpClientService.NewInstance(token)
                .ExecuteWithTimeoutExceptionAsync<ExercisePropertyDto>(request);


            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                ViewData["Message"] = "invalid data";
                return View();
            }
            
            ExercisePropertyUpdateViewModel model =
                mapper.Map<ExercisePropertyDto, ExercisePropertyUpdateViewModel>(response.Data);

            model.TrainingTemplateId = templateId;

            return View(model);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateExerciseProperty(ExercisePropertyUpdateViewModel model)
        {

            if (!ModelState.IsValid)
                return View(model);

            RestRequest request = new RestRequest("exercise-property/update", Method.PUT);
            request.AddJsonBody(model as ExercisePropertyUpdateModel);

            IRestResponse<ExercisePropertyDto> response =
                await httpClientService.NewInstance(token)
                .ExecuteWithTimeoutExceptionAsync<ExercisePropertyDto>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                ViewData["Message"] = "invalid data";
                return View();
            }

            return Redirect("~/training/update/" + model.TrainingTemplateId);

        }
    }
}
