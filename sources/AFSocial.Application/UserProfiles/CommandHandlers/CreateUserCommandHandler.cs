using AFSocial.Application.Models;
using AFSocial.Application.UserProfiles.Commands;
using AFSocial.Data;
using AFSocial.Domain.Aggregates.UserProfileAggregate;
using AFSocial.Domain.Exceptions;
using MediatR;

namespace AFSocial.Application.UserProfiles.CommandHandlers;
public class CreateUserCommandHandler :
    IRequestHandler<CreateUserCommand, OperationResult<UserProfile>>
{
    private readonly DataContext ctx;

    public CreateUserCommandHandler(DataContext ctx)
    {
        this.ctx = ctx;
    }

    public async Task<OperationResult<UserProfile>> Handle(
        CreateUserCommand request,
        CancellationToken cancellationToken)
    {
        var result = new OperationResult<UserProfile>();
        try
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
        catch (Exception ex)
        {
            result.IsError = true;
            var error = new OperationError
            {
                Code = ErrorCode.UNKNOWN,
                Message = ex.Message,
            };
            result.Errors.Add(error);
        }
        return result;
    }
}
