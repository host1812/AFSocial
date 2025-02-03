using AFSocial.Application.Models;
using AFSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;

namespace AFSocial.Application.UserProfiles.Commands;
public class UpdateUserProfileBasicInfoCommand : IRequest<OperationResult<UserProfile>>
{
    public Guid UserProfileId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string CurrentCity { get; set; } = string.Empty;
}
