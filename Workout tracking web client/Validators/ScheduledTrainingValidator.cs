using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracking.Application.Models.ScheduledTraining;
using WorkoutTracking.Application.ValidationExtentions;

namespace WorkoutTracking.Application.Validators
{
    public class ScheduledTrainingValidator : AbstractValidator<ScheduledTrainingModel>
    {
        public ScheduledTrainingValidator()
        {
            RuleFor(s => s.TemplateId)
                .NotEmpty();

            RuleFor(s => s.Day)
                .NotEmpty();

            RuleFor(s => s.StartTime)
                .TimeTemplate();
        }
    }
}
