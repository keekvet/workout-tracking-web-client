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
using WorkoutTracking.Application.Dto.TrainingExtra;
using WorkoutTracking.Application.Models.ScheduledTraining;

namespace Workout_tracking_web_client.Controllers
{
    [Route("schedule")]
    public class ScheduleController : RestClientController
    {
        public ScheduleController(
            IHttpClientService httpClientService, 
            IHttpContextAccessor httpContext) 
            : base(httpClientService, httpContext)
        {
        }

        [HttpGet("")]
        public async Task<IActionResult> GetSchedule()
        {
            RestRequest request = new RestRequest("training-schedule/all", Method.GET);

            IRestResponse<IEnumerable<ScheduledTrainingDto>> response =
                await httpClientService.NewInstance(token)
                .ExecuteWithTimeoutExceptionAsync<IEnumerable<ScheduledTrainingDto>>(request);

            return View("Schedule", response.Data);
        }

        [HttpGet("add/{trainingId}")]
        public IActionResult AddScheduledTraining(int trainingId)
        {
            ScheduledTrainingModel model = new ScheduledTrainingModel() { TemplateId = trainingId };

            return View(model);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddScheduledTraining(ScheduledTrainingModel model)
        {
            if (!ModelState.IsValid)
                return View();

            RestRequest request = new RestRequest("training-schedule/add", Method.POST);
            request.AddJsonBody(model);

            IRestResponse<IEnumerable<ScheduledTrainingDto>> response =
                await httpClientService.NewInstance(token)
                .ExecuteWithTimeoutExceptionAsync<IEnumerable<ScheduledTrainingDto>>(request);

            return Redirect("~/schedule");
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> DeleteScheduledTraining(int id)
        {
            RestRequest request = new RestRequest("training-schedule/remove", Method.DELETE);
            request.AddJsonBody(id);

            IRestResponse<bool> response =
                await httpClientService.NewInstance(token)
                .ExecuteWithTimeoutExceptionAsync<bool>(request);

            return Redirect("~/schedule");
        }
    }
}
