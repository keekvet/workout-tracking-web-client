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
    public class UserRegisterValidator : AbstractValidator<UserRegisterModel>
    {
        public UserRegisterValidator()
        {
            RuleFor(u => u.Name)
                .UserNameTemplate()
                .NotEqual(u => u.Password);
            
            RuleFor(u => u.Password)
                .PasswordTemplate()
                .Equal(u => u.PasswordConfirmation);
        }
    }
}
