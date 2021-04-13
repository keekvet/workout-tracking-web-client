using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workout_tracking_web_client.ViewModels;
using WorkoutTracking.Application.Dto.Training;
using WorkoutTracking.Application.Models.ExerciseProperty;

namespace Workout_tracking_web_client.Mapping
{
    public class ExercisePropertyMapper : Profile
    {
        public ExercisePropertyMapper()
        {
            CreateMap<ExercisePropertyDto, ExercisePropertyUpdateModel>();
            CreateMap<ExercisePropertyDto, ExercisePropertyUpdateViewModel>();
        }
    }
}
