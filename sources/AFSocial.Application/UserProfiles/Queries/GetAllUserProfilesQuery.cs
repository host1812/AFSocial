using AFSocial.Application.Models;
using AFSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;

namespace AFSocial.Application.UserProfiles.Queries;
public class GetAllUserProfilesQuery : IRequest<OperationResult<IEnumerable<UserProfile>>>
{
}
