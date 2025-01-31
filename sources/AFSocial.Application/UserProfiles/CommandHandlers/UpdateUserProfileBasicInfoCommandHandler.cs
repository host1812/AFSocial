using AFSocial.Application.Models;
using AFSocial.Application.UserProfiles.Commands;
using AFSocial.Data;
using AFSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AFSocial.Application.UserProfiles.CommandHandlers;
public class UpdateUserProfileBasicInfoCommandHandler :
    IRequestHandler<UpdateUserProfileBasicInfoCommand, OperationResult<UserProfile>>
{
    private readonly DataContext ctx;

    public UpdateUserProfileBasicInfoCommandHandler(DataContext ctx)
    {
        this.ctx = ctx;
    }

    public async Task<OperationResult<UserProfile>> Handle(
        UpdateUserProfileBasicInfoCommand request,
        CancellationToken cancellationToken)
    {
        var result = new OperationResult<UserProfile>();
        var userProfile = await ctx.UserProfiles
            .FirstOrDefaultAsync(up => up.UserProfileId == request.UserProfileId);

        if (userProfile is null)
        {
            result.Value = null;
            result.IsError = true;
            result.Errors = [$"User profile not found. Id: {request.UserProfileId}"];
            return result;
        }

        var basicInfo = BasicInfo.CreateBasicInfo(
            request.FirstName,
            request.LastName,
            request.EmailAddress,
            request.PhoneNumber,
            request.DateOfBirth,
            request.CurrentCity);

        userProfile.UpdateBasicInfo(basicInfo);
        ctx.UserProfiles.Update(userProfile);
        
        try
        {
            await ctx.SaveChangesAsync(cancellationToken);
            result.Value = userProfile;
            result.IsError = false;
        }
        catch (Exception)
        {
            result.Value = null;
            result.IsError = true;
            result.Errors = ["Failed to save UserProfile in the database"];
        }

        return result;
    }
}
