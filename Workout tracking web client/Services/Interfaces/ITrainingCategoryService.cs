using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracking.Application.Dto.TrainingExtra;

namespace Workout_tracking_web_client.Services.Interfaces
{
    public interface ITrainingCategoryService
    {
        Task<IEnumerable<TrainingCategoryDto>> GetTrainingCategoriesAsync(RestClient client);
    }
}
