using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracking.Application.Dto.Training;

namespace WorkoutTracking.Application.Dto.TrainingExtra
{
    public class PublicTrainingTemplateDto
    {
        public int PublicId { get; set; }
        public int TemplateId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CreatorId { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<ExerciseDto> Exercises { get; set; }
    }
}
