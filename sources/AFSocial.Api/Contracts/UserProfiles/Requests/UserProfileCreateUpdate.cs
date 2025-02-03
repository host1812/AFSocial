namespace AFSocial.Api.Contracts.UserProfiles.Requests;

public record UserProfileCreateUpdate
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string CurrentCity { get; set; } = string.Empty;
}
