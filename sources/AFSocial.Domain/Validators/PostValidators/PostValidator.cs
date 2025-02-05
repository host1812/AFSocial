using AFSocial.Domain.Aggregates.PostAggregate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFSocial.Domain.Validators.PostValidators;
public class PostValidator : AbstractValidator<Post>
{
    public PostValidator()
    {
        RuleFor(p => p.TextContent)
            .NotNull().WithMessage("Text content should not be null")
            .NotEmpty().WithMessage("Text content should have some content")
            .MaximumLength(4096).WithMessage("Text content should be less then 2048 chars.");
    }
}
