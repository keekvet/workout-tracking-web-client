using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracking.Application.Dto.Training;
using WorkoutTracking.Application.Models.Exercise;

namespace Workout_tracking_web_client.Mapping
{
    public class ExerciseMapper : Profile
    {
        public ExerciseMapper()
        {
            CreateMap<ExerciseDto, ExerciseUpdateModel>();
        }
    }
}
