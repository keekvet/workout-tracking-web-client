using AutoMapper;
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
        private readonly IMapper mapper;
        private readonly ITrainingCategoryService trainingCategoryService;

        public TrainingController(
            IMapper mapper,
            IHttpContextAccessor context,
            IHttpClientService httpClientService,
            ITrainingCategoryService trainingCategoryService)
            : base(httpClientService, context) 
        {
            this.mapper = mapper;
            this.trainingCategoryService = trainingCategoryService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> TrainingList(TrainingTemplatePaginationModel model)
        {
            RestRequest request = new RestRequest("training-template/all", Method.GET);
          
            foreach (var prop in model.GetType().GetProperties())
                request.AddParameter(prop.Name, prop.GetMethod.Invoke(model, null));

            IRestResponse<IEnumerable<TrainingTemplateDto>> response =
                await httpClientService.NewInstance(token)
                .ExecuteWithTimeoutExceptionAsync<IEnumerable<TrainingTemplateDto>>(request);

            return View(response.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> TrainingTemplate(int id)
        {
            RestRequest request = new RestRequest("training-template/id/" + id, Method.GET);

            IRestResponse<TrainingTemplateDto> response =
                await httpClientService.NewInstance(token)
                .ExecuteWithTimeoutExceptionAsync<TrainingTemplateDto>(request);

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
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await trainingCategoryService.GetTrainingCategoriesAsync(
                httpClientService.NewInstance(token));

                return View();
            }

            RestRequest request = new RestRequest("training-template/add", Method.POST);
            request.AddJsonBody(model);

            IRestResponse<TrainingTemplateDto> response =
                await httpClientService.NewInstance(token)
                .ExecuteWithTimeoutExceptionAsync<TrainingTemplateDto>(request);

            return Redirect(response.Data.Id.ToString());
        }

        [HttpGet("update/{id}")]
        public async Task<IActionResult> UpdateTraining(int id)
        {
            RestRequest request = new RestRequest("training-template/id/" + id, Method.GET);

            IRestResponse<TrainingTemplateDto> response =
                await httpClientService.NewInstance(token)
                .ExecuteWithTimeoutExceptionAsync<TrainingTemplateDto>(request);

            ViewBag.Categories = await trainingCategoryService.GetTrainingCategoriesAsync(
                httpClientService.NewInstance(token));

            ViewBag.Exercises = response.Data.Exercises;

            return View(mapper.Map<TrainingTemplateDto, TrainingTemplateUpdateModel>(response.Data));
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateTraining(TrainingTemplateUpdateModel model)
        {
            RestRequest request;
            IRestResponse<TrainingTemplateDto> response;

            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await trainingCategoryService.GetTrainingCategoriesAsync(
                httpClientService.NewInstance(token));

                request = new RestRequest("training-template/id/" + model.Id, Method.GET);

                response = await httpClientService.NewInstance(token)
                    .ExecuteWithTimeoutExceptionAsync<TrainingTemplateDto>(request);

                ViewBag.Exercises = response.Data.Exercises;

                return View(model);
            }

            request = new RestRequest("training-template/update", Method.PUT);
            request.AddJsonBody(model);

            response = await httpClientService.NewInstance(token)
                .ExecuteWithTimeoutExceptionAsync<TrainingTemplateDto>(request);

            return Redirect("update/" + response.Data.Id);

        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> DeleteTraining(int id)
        {
            RestRequest request = new RestRequest("training-template/remove", Method.DELETE);
            request.AddJsonBody(id);

            IRestResponse<bool> response =
                await httpClientService.NewInstance(token)
                .ExecuteWithTimeoutExceptionAsync<bool>(request);

            return Redirect("~/training/all");
        }


        [HttpGet("clone/{id}")]
        public async Task<IActionResult> CloneTraining(int id)
        {
            RestRequest request = new RestRequest("training-template/clone", Method.POST);
            request.AddJsonBody(id);

            IRestResponse<TrainingTemplateDto> response =
                await httpClientService.NewInstance(token)
                .ExecuteWithTimeoutExceptionAsync<TrainingTemplateDto>(request);

            return Redirect("~/training/all");
        }
    }
}
