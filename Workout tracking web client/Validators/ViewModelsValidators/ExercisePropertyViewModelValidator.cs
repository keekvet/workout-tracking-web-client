using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workout_tracking_web_client.ViewModels;

namespace Workout_tracking_web_client.Validators.ViewModelsValidators
{
    public class ExercisePropertyViewModelValidator : AbstractValidator<ExercisePropertyViewModel>
    {
        public ExercisePropertyViewModelValidator()
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
