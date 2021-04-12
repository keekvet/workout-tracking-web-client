using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracking.Application.Models.User;

namespace WorkoutTracking.Application.Validators
{
    public class UserLoginValidator : AbstractValidator<UserLoginModel>
    {
        public UserLoginValidator()
        {
            RuleFor(u => u.Name).NotNull();
            RuleFor(u => u.Password).NotNull();
        }
    }
}
