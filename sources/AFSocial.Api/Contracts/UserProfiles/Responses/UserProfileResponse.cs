using AFSocial.Domain.Aggregates.UserProfileAggregate;

namespace AFSocial.Api.Contracts.UserProfiles.Responses;

public record UserProfileResponse
{
    public Guid UserProfileId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime LastModified { get; private set; }
    public BasicInfoResponse BasicInfo { get; private set; }
}
