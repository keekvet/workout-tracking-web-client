using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracking.Application.Dto.TrainingExtra
{
    public class ScheduledTrainingDto
    {
        public int Id { get; set; }
        public DayOfWeek Day { get; set; }
        public string StartTime { get; set; }
        public int TemplateId { get; set; }
    }
}
