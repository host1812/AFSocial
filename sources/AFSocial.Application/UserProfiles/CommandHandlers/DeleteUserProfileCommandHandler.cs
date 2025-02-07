using AFSocial.Application.Models;
using AFSocial.Application.UserProfiles.Commands;
using AFSocial.Data;
using AFSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AFSocial.Application.UserProfiles.CommandHandlers;
public class DeleteUserProfileCommandHandler
    : IRequestHandler<DeleteUserProfileCommand, OperationResult<UserProfile>>
{
    private DataContext ctx;

    public DeleteUserProfileCommandHandler(DataContext ctx)
    {
        this.ctx = ctx;
    }

    public async Task<OperationResult<UserProfile>> Handle(
        DeleteUserProfileCommand request,
        CancellationToken cancellationToken)
    {
        var response = new OperationResult<UserProfile>();
        var userProfile = await ctx.UserProfiles
            .FirstOrDefaultAsync(up => up.UserProfileId == request.UserProfileId);
        if (userProfile is null)
        {
            response.IsError = true;
            response.Errors.Add(new OperationError()
            {
                Code = ErrorCode.NOT_FOUND,
                Message = $"UserProfile not found. UserProfileId: {request.UserProfileId}",
            });
            return response;
        }
        ctx.Remove(userProfile);
        await ctx.SaveChangesAsync(cancellationToken);
        response.Value = userProfile;
        return response;
    }
}
