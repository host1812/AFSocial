namespace AFSocial.Api.Contracts.UserProfiles.Responses;

public record UserProfileResponse
{
    public Guid UserProfileId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastModified { get; set; }
    public BasicInfoResponse BasicInfo { get; set; }
}
