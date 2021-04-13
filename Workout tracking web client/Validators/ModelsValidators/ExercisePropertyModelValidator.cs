using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracking.Application.Models.ExerciseProperty;

namespace WorkoutTracking.Application.Validators
{
    public class ExercisePropertyModelValidator : AbstractValidator<ExercisePropertyModel>
    {
        public ExercisePropertyModelValidator()
        {
            RuleFor(e => e.Duration)
                .NotEmpty();

            RuleFor(e => e.DurationType)
                .NotNull();

            RuleFor(e => e.ExerciseId)
                .NotEmpty();
        }
    }
}
