using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracking.Application.ValidationExtentions
{
    public static class ValidationExtention
    {
        public static IRuleBuilderOptions<T, string> PasswordTemplate<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            string digit = @"\d+";
            string lowerCase = @"[a-z]+";
            string upperCase = @"[A-Z]+";
            string whiteSpaces = @"^\w*$";

            return ruleBuilder
                .NotNull()
                .Length(8, 20)
                .Matches(digit)
                .Matches(lowerCase)
                .Matches(upperCase)
                .Matches(whiteSpaces);
        }

        public static IRuleBuilderOptions<T, string> UserNameTemplate<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotNull()
                .Length(4, 20)
                .Matches(@"^\w{4,20}$");

        }

        public static IRuleBuilderOptions<T, string> TimeTemplate<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotNull()
                .Matches(@"[0-2]\d:[0-5]\d");

        }
    }
}
