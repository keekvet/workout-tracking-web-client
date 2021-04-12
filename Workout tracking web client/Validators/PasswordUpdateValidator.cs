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
    public class PasswordUpdateValidator : AbstractValidator<PasswordUpdateModel>
    {
        public PasswordUpdateValidator()
        {
            RuleFor(p => p.CurrentPassword)
                .NotNull();

            RuleFor(p => p.NewPassword)
                .PasswordTemplate()
                .Equal(p => p.ConfirmNewPassword);
        }
    }
}
