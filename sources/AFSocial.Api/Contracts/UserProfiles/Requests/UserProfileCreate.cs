using AFSocial.Domain.Aggregates.UserProfileAggregate;

namespace AFSocial.Api.Contracts.UserProfiles.Requests;

public record UserProfileCreate
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string EmailAddress { get; private set; }
    public string PhoneNumber { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public string CurrentCity { get; private set; }
}
