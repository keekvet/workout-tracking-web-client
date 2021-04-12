using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workout_tracking_web_client.Extension;
using Workout_tracking_web_client.Services.Interfaces;
using WorkoutTracking.Application.Dto.TrainingExtra;

namespace Workout_tracking_web_client.Services.Implementations
{
    public class TrainingCategoryService : ITrainingCategoryService
    {

        public async Task<IEnumerable<TrainingCategoryDto>> GetTrainingCategoriesAsync(RestClient client)
        {
            RestRequest request = new RestRequest("training-category/all", Method.GET);

            IRestResponse<IEnumerable<TrainingCategoryDto>> response =
                await client.ExecuteWithTimeoutExceptionAsync<IEnumerable<TrainingCategoryDto>>(request);

            return response.Data;
        }
    }
}
