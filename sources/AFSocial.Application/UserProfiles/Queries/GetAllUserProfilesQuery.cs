using AFSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;

namespace AFSocial.Application.UserProfiles.Queries;
public class GetAllUserProfilesQuery : IRequest<IEnumerable<UserProfile>>
{
}
