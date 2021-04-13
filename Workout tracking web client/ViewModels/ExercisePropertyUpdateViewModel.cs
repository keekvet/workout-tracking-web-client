using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracking.Application.Models.ExerciseProperty;

namespace Workout_tracking_web_client.ViewModels
{
    public class ExercisePropertyUpdateViewModel : ExercisePropertyUpdateModel
    {
        public int TrainingTemplateId { get; set; }
    }
}
