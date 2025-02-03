using AFSocial.Application.Models;
using AFSocial.Application.UserProfiles.Queries;
using AFSocial.Data;
using AFSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AFSocial.Application.UserProfiles.QueryHandlers;
internal class GetUserProfileByIdQueryHadler :
    IRequestHandler<GetUserProfileByIdQuery, OperationResult<UserProfile>>
{
    private readonly DataContext ctx;

    public GetUserProfileByIdQueryHadler(DataContext ctx)
    {
        this.ctx = ctx;
    }

    public async Task<OperationResult<UserProfile>> Handle(GetUserProfileByIdQuery request, CancellationToken cancellationToken)
    {
        var response = new OperationResult<UserProfile>();
        var userProfile = await ctx.UserProfiles.FirstOrDefaultAsync(
            up => up.UserProfileId == request.UserProfileId,
            cancellationToken);
        if (userProfile is not null)
        {
            response.Value = userProfile;
        }
        else
        {
            response.IsError = true;
            response.Errors.Add(new OperationError()
            {
                Code = ErrorCode.NOT_FOUND,
                Message = $"UserProfile not found. UserProfileId: {request.UserProfileId}",
            });
        }
        return response;
    }
}
