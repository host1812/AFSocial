using AFSocial.Domain.Aggregates.PostAggregate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFSocial.Domain.Validators.PostValidators;
public class PostCommentValidator : AbstractValidator<PostComment>
{
    public PostCommentValidator()
    {
        RuleFor(pc => pc.Text)
            .NotNull().WithMessage("Text should not be null")
            .NotEmpty().WithMessage("Text should have some content")
            .MaximumLength(2048).WithMessage("Text should be less then 2048 chars.");
    }
}
