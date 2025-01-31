using AFSocial.Application.UserProfiles.Commands;
using AFSocial.Data;
using AFSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AFSocial.Application.UserProfiles.CommandHandlers;
public class UpdateUserProfileBasicInfoCommandHandler :
    IRequestHandler<UpdateUserProfileBasicInfoCommand>
{
    private readonly DataContext ctx;

    public UpdateUserProfileBasicInfoCommandHandler(DataContext ctx)
    {
        this.ctx = ctx;
    }

    public async Task Handle(
        UpdateUserProfileBasicInfoCommand request,
        CancellationToken cancellationToken)
    {
        var userProfile = await ctx.UserProfiles
            .FirstOrDefaultAsync(up => up.UserProfileId == request.UserProfileId);

        var basicInfo = BasicInfo.CreateBasicInfo(
            request.FirstName,
            request.LastName,
            request.EmailAddress,
            request.PhoneNumber,
            request.DateOfBirth,
            request.CurrentCity);

        userProfile.UpdateBasicInfo(basicInfo);

        ctx.UserProfiles.Update(userProfile);
        await ctx.SaveChangesAsync();
    }
}
