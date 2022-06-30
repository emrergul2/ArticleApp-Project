using ArticleApp.Core.Models;
using FluentValidation;

namespace ArticleApp.Service.Validations
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("{PropertyName} must max 100 character.");
            RuleFor(x => x.Description).MaximumLength(250).WithMessage("{PropertyName} must max 250 character.");
        }
    }
}