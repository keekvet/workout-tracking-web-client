using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracking.Application.Dto.TrainingHistory
{
    public class TrainingHistoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public string Start { get; set; }
        public IEnumerable<ExerciseHistoryDto> ExerciseHistory { get; set; }

    }
}
