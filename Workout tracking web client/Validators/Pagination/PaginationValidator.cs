using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracking.Application.Models.Pagination.Base;

namespace WorkoutTracking.Application.Validators.Pagination
{
    public class PaginationValidator<T> : AbstractValidator<T> where T : PaginationModel
    {
        public PaginationValidator()
        {
            RuleFor(p => p.Offset).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(p => p.Count).NotNull().GreaterThanOrEqualTo(1).LessThan(100);
        }
    }
}
