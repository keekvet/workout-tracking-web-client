using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracking.Application.Models.Exercise;

namespace WorkoutTracking.Application.Validators
{
    public class ExerciseUpdateValidator : AbstractValidator<ExerciseUpdateModel>
    {
        public ExerciseUpdateValidator()
        {
            RuleFor(e => e.Id)
                .NotNull()
                .NotEmpty();

            RuleFor(e => e.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(e => e.Note)
                .NotEmpty()
                .MaximumLength(500);

        }
    }
}
