using AFSocial.Domain.Aggregates.UserProfileAggregate;
using FluentValidation;

namespace AFSocial.Domain.Validators.UserProfileValidators;
public class BasicInfoValidator : AbstractValidator<BasicInfo>
{
    public BasicInfoValidator()
    {
        RuleFor(profile => profile.FirstName)
            .NotNull().WithMessage("First name is required.")
            .MinimumLength(3).WithMessage("First name length should be more then 3 chars.")
            .MaximumLength(50).WithMessage("First name length should be less then 50 chars.");

        RuleFor(profile => profile.LastName)
            .NotNull().WithMessage("Last name is required.")
            .MinimumLength(3).WithMessage("Last name length should be more then 3 chars.")
            .MaximumLength(50).WithMessage("Last name length should be less then 50 chars.");

        RuleFor(profile => profile.EmailAddress)
            .NotNull().WithMessage("Email address is required.")
            .EmailAddress().WithMessage("Email address should be a valid email address.");

        RuleFor(profile => profile.DateOfBirth)
            .NotNull().WithMessage("Date of birth is required.")
            .InclusiveBetween(
                new DateTime(DateTime.Now.AddYears(-125).Ticks),
                new DateTime(DateTime.Now.AddYears(-15).Ticks))
            .WithMessage($"Date of birth should be between "
                         + $"{new DateTime(DateTime.Now.AddYears(-125).Ticks)}"
                         + $"and {new DateTime(DateTime.Now.AddYears(-15).Ticks)}.");
    }
}
