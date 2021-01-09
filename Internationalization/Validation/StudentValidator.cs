using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Internationalization
{
    public class StudentValidator : BaseValidator<Student> //AbstractValidator<Student>
    {
        public StudentValidator()
        {
            //IStringLocalizer localizer
            //RuleFor(BaseEntity => BaseEntity.Age).NotEmpty().WithMessage(localizer["student_Age_cannot_be_empty"]);
            RuleFor(BaseEntity => BaseEntity.Age).NotEmpty().WithMessage("student_Age_cannot_be_empty");
            RuleFor(BaseEntity => BaseEntity.Age).NotEmpty().WithMessage("Student Age can't be empty");
            RuleFor(BaseEntity => BaseEntity.Email).EmailAddress().NotEmpty().WithMessage("Student EmailAddress Cannot be empty")
                                                    .MaximumLength(50).WithMessage("Student EmailAddress cannot exceed 50 chars");
            RuleFor(BaseEntity => BaseEntity.Mobile).NotEmpty().WithMessage("Student Mobile Cannot be empty")
                                                    .MaximumLength(11).WithMessage("Student Mobile cannot exceed 11 chars");
            RuleFor(BaseEntity => BaseEntity.JoiningDate).NotEmpty().WithMessage("Student JoiningDate can't be empty");
        }
    }
}
