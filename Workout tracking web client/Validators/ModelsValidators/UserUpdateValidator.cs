using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracking.Application.Models.User;
using WorkoutTracking.Application.ValidationExtentions;

namespace WorkoutTracking.Application.Validators
{
    public class UserUpdateValidator : AbstractValidator<UserUpdateModel>
    {
        public UserUpdateValidator()
        {
            RuleFor(u => u.Name)
                .UserNameTemplate();

            RuleFor(u => u.About)
                .MaximumLength(500);

            RuleFor(u => u.Access)
                .NotNull();
        }
    }
}
