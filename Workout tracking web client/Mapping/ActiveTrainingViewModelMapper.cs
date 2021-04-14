using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workout_tracking_web_client.ViewModels;
using WorkoutTracking.Application.Dto.TrainingExtra;

namespace Workout_tracking_web_client.Mapping
{
    public class ActiveTrainingViewModelMapper : Profile
    {
        public ActiveTrainingViewModelMapper()
        {
            CreateMap<ActiveTrainingDto, ActiveTrainingViewModel>();
        }
    }
}
