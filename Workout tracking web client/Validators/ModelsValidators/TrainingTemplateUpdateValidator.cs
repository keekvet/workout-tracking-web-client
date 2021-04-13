using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracking.Application.Models.TrainingTemplate;

namespace WorkoutTracking.Application.Validators
{
    public class TrainingTemplateUpdateValidator : AbstractValidator<TrainingTemplateUpdateModel>
    {
        public TrainingTemplateUpdateValidator()
        {
            RuleFor(t => t.Id)
                .NotNull()
                .NotEmpty();
            
            RuleFor(t => t.CategoryId)
                .NotNull()
                .NotEmpty();

            RuleFor(t => t.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
