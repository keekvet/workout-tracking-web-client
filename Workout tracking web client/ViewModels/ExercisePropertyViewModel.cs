using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracking.Application.Models.ExerciseProperty;

namespace Workout_tracking_web_client.ViewModels
{
    public class ExercisePropertyViewModel : ExercisePropertyModel
    {
        public int TrainingTemplateId { get; set; }
    }
}
