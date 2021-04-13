using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracking.Application.Models.Exercise;

namespace WorkoutTracking.Application.Validators
{
    public class ExerciseValidator : AbstractValidator<ExerciseModel>
    {
        public ExerciseValidator()
        {
            RuleFor(e => e.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(e => e.Note)
                .MaximumLength(500);

            RuleFor(e => e.TrainingTemplateId)
                .NotEmpty()
                .NotNull();
        }
    }
}
