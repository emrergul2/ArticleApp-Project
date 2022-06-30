using ArticleApp.Core.Models;
using FluentValidation;

namespace ArticleApp.Service.Validations
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("{PropertyName} must max 100 character.");
            RuleFor(x => x.Email).NotNull().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid email address.");
            RuleFor(x => x.Email).MaximumLength(100).WithMessage("{PropertyName} must max 100 character.");
        }
    }
}