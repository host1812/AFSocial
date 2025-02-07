using AFSocial.Application.Models;
using AFSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;

namespace AFSocial.Application.UserProfiles.Commands;
public class DeleteUserProfileCommand : IRequest<OperationResult<UserProfile>>
{
    public Guid UserProfileId { get; set; }
}
