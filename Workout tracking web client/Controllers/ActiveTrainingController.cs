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
using WorkoutTracking.Application.Dto.TrainingExtra;

namespace Workout_tracking_web_client.Controllers
{
    [Route("active-training")]
    public class ActiveTrainingController : RestClientController
    {
        IMapper mapper;
        public ActiveTrainingController(
            IMapper mapper,
            IHttpClientService httpClientService, 
            IHttpContextAccessor httpContext) 
            : base(httpClientService, httpContext)
        {
            this.mapper = mapper;
        }

        [HttpGet("start/{id}")]
        public async Task<IActionResult> ActiveTrainingStart(int id)
        {

            RestRequest requestTraining = new RestRequest("active-training/start", Method.POST);
            requestTraining.AddJsonBody(id);

            IRestResponse<ActiveTrainingDto> responseTraining =
                await httpClientService.NewInstance(token)
                .ExecuteWithTimeoutExceptionAsync<ActiveTrainingDto>(requestTraining);

            return Redirect("~/active-training");
        }

        [HttpGet("")]
        public async Task<IActionResult> ActiveTraining()
        {
            
            RestRequest requestTraining = new RestRequest("active-training/get", Method.GET);

            Task<IRestResponse<ActiveTrainingDto>> responseTraining =
                httpClientService.NewInstance(token)
                .ExecuteWithTimeoutExceptionAsync<ActiveTrainingDto>(requestTraining);

            RestRequest requestExercise = new RestRequest("active-training/exercise", Method.GET);

            Task<IRestResponse<ExerciseDto>> responseExercise =
                httpClientService.NewInstance(token)
                .ExecuteAsync<ExerciseDto>(requestExercise);

           await Task.WhenAll(responseExercise, responseTraining);

            ActiveTrainingViewModel model = 
                mapper.Map<ActiveTrainingDto, ActiveTrainingViewModel>(responseTraining.Result.Data);

            if(responseExercise.Result.IsSuccessful)
                model.Exercise = responseExercise.Result.Data;

            return View(model);
        }

        [HttpGet("exercise-done")]
        public async Task<IActionResult> ExerciseDone()
        {
            RestRequest requestTraining = new RestRequest("active-training/perform-exercise", Method.POST);

            IRestResponse<ActiveTrainingDto> responseTraining =
                await httpClientService.NewInstance(token)
                .ExecuteWithTimeoutExceptionAsync<ActiveTrainingDto>(requestTraining);

            return Redirect("~/active-training");
        }

        [HttpGet("end-training")]
        public async Task<IActionResult> EndTraining()
        {
            RestRequest requestTraining = new RestRequest("active-training/end", Method.DELETE);

            IRestResponse<bool> responseTraining =
                await httpClientService.NewInstance(token)
                .ExecuteWithTimeoutExceptionAsync<bool>(requestTraining);
            
            return View();
        }
    }
}
