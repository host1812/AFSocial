using AFSocial.Application.Models;
using AFSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;

namespace AFSocial.Application.UserProfiles.Queries;
public class GetUserProfileByIdQuery : IRequest<OperationResult<UserProfile>>
{
    public Guid UserProfileId { get; set; }
}
