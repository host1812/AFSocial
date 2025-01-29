using AFSocial.Application.UserProfiles.Commands;
using AFSocial.Data;
using AFSocial.Domain.Aggregates.UserProfileAggregate;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFSocial.Application.UserProfiles.CommandHandlers;
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserProfile>
{
    private readonly DataContext ctx;

    public CreateUserCommandHandler(DataContext ctx)
    {
        this.ctx = ctx;
    }

    public async Task<UserProfile> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var basicInfo = BasicInfo.CreateBasicInfo(
            request.FirstName,
            request.LastName,
            request.EmailAddress,
            request.PhoneNumber,
            request.DateOfBirth,
            request.CurrentCity);

        var userProfile = UserProfile.CreateUserProfile(Guid.NewGuid(), basicInfo);
        ctx.UserProfiles.Add(userProfile);
        await ctx.SaveChangesAsync();
        
        return userProfile;
    }
}
