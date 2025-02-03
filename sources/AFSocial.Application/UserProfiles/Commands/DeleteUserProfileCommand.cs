using AFSocial.Application.Models;
using AFSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFSocial.Application.UserProfiles.Commands;
public class DeleteUserProfileCommand : IRequest<OperationResult<UserProfile>>
{
    public Guid UserProfileId { get; set; }
}
