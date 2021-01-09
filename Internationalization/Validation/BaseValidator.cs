using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Internationalization
{
    public class BaseValidator<TEntity> : AbstractValidator<TEntity> where TEntity : BaseEntity
    {
        public BaseValidator()
        {
            RuleFor(BaseEntity => BaseEntity.Id).NotEmpty().WithMessage("Id cannot be empty")
                                                .MaximumLength(20).WithMessage("Id cannot exceed 20 chars");
            RuleFor(BaseEntity => BaseEntity.RowId).NotEmpty().WithMessage("RowId cannot be empty");
            RuleFor(BaseEntity => BaseEntity.Name).NotEmpty().WithMessage("Name cannot be empty")
                                                .MaximumLength(200).WithMessage("Name cannot exceed 200 chars");
            RuleFor(BaseEntity => BaseEntity.NameSecondLanguage).NotEmpty().WithMessage("NameSecondLanguage cannot be empty")
                                                .MaximumLength(200).WithMessage("NameSecondLanguage cannot exceed 200 chars");
        }
    }
}
