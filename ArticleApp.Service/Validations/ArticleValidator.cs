using ArticleApp.Core.Models;
using FluentValidation;

namespace ArticleApp.Service.Validations
{
    public class ArticleValidator : AbstractValidator<Article>
    {
        public ArticleValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("{PropertyName} must max 100 character.");
            RuleFor(x => x.Summary).NotNull().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Summary).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Summary).MaximumLength(400).WithMessage("{PropertyName} must max 400 character.");
            RuleFor(x => x.ArticleText).NotNull().WithMessage("{PropertyName} is required");
            RuleFor(x => x.ArticleText).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.ArticleText).MaximumLength(3500).WithMessage("{PropertyName} must max 3500 character.");
        }
    }
}