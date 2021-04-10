using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracking.Data.Enums;

namespace WorkoutTracking.Application.Dto.Training
{
    public class ExercisePropertyDto
    {
        public int Id { get; set; }
        public int Duration { get; set; }
        public ExerciseDurationType DurationType { get; set; }
        public int Weigth { get; set; }
    }
}
