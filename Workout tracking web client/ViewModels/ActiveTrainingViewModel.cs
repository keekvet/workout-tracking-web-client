using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracking.Application.Dto.Training;
using WorkoutTracking.Application.Dto.TrainingExtra;

namespace Workout_tracking_web_client.ViewModels
{
    public class ActiveTrainingViewModel : ActiveTrainingDto
    {
        public ExerciseDto Exercise { get; set; }
    }
}
