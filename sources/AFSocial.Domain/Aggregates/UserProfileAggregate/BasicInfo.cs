using AFSocial.Domain.Validators.UserProfileValidators;
using AFSocial.Domain.Exceptions;

namespace AFSocial.Domain.Aggregates.UserProfileAggregate;
public class BasicInfo
{
    private BasicInfo()
    {
    }

    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string EmailAddress { get; private set; } = string.Empty;
    public string PhoneNumber { get; private set; } = string.Empty;
    public DateTime DateOfBirth { get; private set; }
    public string CurrentCity { get; private set; } = string.Empty;

    public static BasicInfo CreateBasicInfo(
        string firstName,
        string lastName,
        string emailAddress,
        string phoneNumber,
        DateTime dateOfBirth,
        string currentCity)
    {
        var validator = new BasicInfoValidator();

        var objToValidate = new BasicInfo()
        {
            FirstName = firstName,
            LastName = lastName,
            EmailAddress = emailAddress,
            PhoneNumber = phoneNumber,
            DateOfBirth = dateOfBirth,
            CurrentCity = currentCity,
        };

        var validationResult = validator.Validate(objToValidate);

        if (!validationResult.IsValid)
        {
            var exception = new UserProfileNotValidException("The user profile is not valid");
            foreach (var error in validationResult.Errors)
            {
                exception.ValidationErrors.Add(error.ErrorMessage);
            }

            throw exception;
        }

        return objToValidate;
    }
}
