using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracking.Application.Dto.Training;
using WorkoutTracking.Application.Models.TrainingTemplate;

namespace Workout_tracking_web_client.Mapping
{
    public class TrainingTemplateMapper : Profile
    {
        public TrainingTemplateMapper()
        {
            CreateMap<TrainingTemplateDto, TrainingTemplateUpdateModel>().ReverseMap();
        }
    }
}
