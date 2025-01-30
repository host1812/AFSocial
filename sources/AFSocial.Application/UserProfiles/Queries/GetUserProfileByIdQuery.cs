using AFSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;

namespace AFSocial.Application.UserProfiles.Queries;
public class GetUserProfileByIdQuery : IRequest<UserProfile>
{
    public Guid UserProfileId { get; set; }
}
