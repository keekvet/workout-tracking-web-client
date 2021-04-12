using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workout_tracking_web_client.Exceptions;
using Workout_tracking_web_client.Extension;
using Workout_tracking_web_client.Services.Interfaces;
using WorkoutTracking.Application.Dto.Training;
using WorkoutTracking.Application.Dto.TrainingExtra;
using WorkoutTracking.Application.Models.Pagination;
using WorkoutTracking.Application.Models.TrainingTemplate;

namespace Workout_tracking_web_client.Controllers
{
    [Route("training")]
    public class TrainingController : RestClientController
    {
        private readonly ITrainingCategoryService trainingCategoryService;

        public TrainingController(
            IHttpContextAccessor context,
            IHttpClientService httpClientService,
            ITrainingCategoryService trainingCategoryService)
            : base(httpClientService, context) 
        {
            this.trainingCategoryService = trainingCategoryService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> TrainingList(TrainingTemplatePaginationModel model)
        {
            IEnumerable<TrainingCategoryDto> trainingCategories = 
                await trainingCategoryService.GetTrainingCategoriesAsync(httpClientService.NewInstance(token));

            RestRequest request = new RestRequest("training-template/all", Method.GET);
          
            foreach (var prop in model.GetType().GetProperties())
                request.AddParameter(prop.Name, prop.GetMethod.Invoke(model, null));

            IRestResponse<IEnumerable<TrainingTemplateDto>> response =
                await httpClientService.NewInstance(token)
                .ExecuteWithTimeoutExceptionAsync<IEnumerable<TrainingTemplateDto>>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                ViewData["Message"] = "training doesn't exist";
                return View();
            }

            return View(response.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> TrainingTemplate(int id)
        {
            RestRequest request = new RestRequest("training-template/id/" + id, Method.GET);

            IRestResponse<TrainingTemplateDto> response =
                await httpClientService.NewInstance(token)
                .ExecuteWithTimeoutExceptionAsync<TrainingTemplateDto>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                ViewData["Message"] = "training doesn't exist";
                return View();
            }

            return View(response.Data);
        }

        [HttpGet("add")]
        public async Task<IActionResult> AddTraining()
        {
            ViewBag.Categories = await trainingCategoryService.GetTrainingCategoriesAsync(
                httpClientService.NewInstance(token));

            return View();
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddTraining(TrainingTemplateModel model)
        {
            ViewBag.Categories = await trainingCategoryService.GetTrainingCategoriesAsync(
                httpClientService.NewInstance(token));

            if (!ModelState.IsValid)
                return View();

            RestRequest request = new RestRequest("training-template/add", Method.POST);
            request.AddJsonBody(model);

            IRestResponse<TrainingTemplateDto> response =
                await httpClientService.NewInstance(token)
                .ExecuteWithTimeoutExceptionAsync<TrainingTemplateDto>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                ViewBag.Message = "invalid data";
                return View();
            }

            return Redirect("~/training/" + response.Data.Id);
        }
    }
}
