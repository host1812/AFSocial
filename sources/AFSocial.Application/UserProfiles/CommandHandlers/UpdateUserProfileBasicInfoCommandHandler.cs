using AFSocial.Application.Models;
using AFSocial.Application.UserProfiles.Commands;
using AFSocial.Data;
using AFSocial.Domain.Aggregates.UserProfileAggregate;
using AFSocial.Domain.Exceptions;
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
            result.Errors = [new OperationError
            {
                Code = ErrorCode.NOT_FOUND,
                Message = $"User profile not found. PostId: {request.UserProfileId}"
            }];
            return result;
        }
        try
        {
            var basicInfo = BasicInfo.CreateBasicInfo(
                request.FirstName,
                request.LastName,
                request.EmailAddress,
                request.PhoneNumber,
                request.DateOfBirth,
                request.CurrentCity);

            userProfile.UpdateBasicInfo(basicInfo);
            ctx.UserProfiles.Update(userProfile);
            await ctx.SaveChangesAsync(cancellationToken);
            result.Value = userProfile;
        }
        catch (UserProfileNotValidException ex)
        {
            result.IsError = true;
            ex.ValidationErrors.ForEach(e =>
            {
                var error = new OperationError { Code = ErrorCode.VALIDATION, Message = ex.Message };
                result.Errors.Add(error);
            });
        }
        catch (Exception)
        {
            result.Value = null;
            result.IsError = true;
            result.Errors.Add(new OperationError
            {
                Code = ErrorCode.INTERNAL,
                Message = "Something really bad happened!"
            });
        }

        return result;
    }
}
