using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracking.Application.Dto.TrainingHistory
{
    public class ExerciseHistoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EndDate { get; set; }
        public int TrainingTemplateId { get; set; }
        public IEnumerable<ExercisePropertyHistoryDto> Properties { get; set; }
    }
}
