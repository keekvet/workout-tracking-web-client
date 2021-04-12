using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracking.Application.Models.Pagination;

namespace WorkoutTracking.Application.Validators.Pagination
{
    public class UserSearchValidator : SortedPaginationValidator<UserSearchPaginationModel>
    {
        public UserSearchValidator(){}
    }
}
