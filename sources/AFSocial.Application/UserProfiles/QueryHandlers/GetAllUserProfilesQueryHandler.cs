using AFSocial.Application.Models;
using AFSocial.Application.UserProfiles.Queries;
using AFSocial.Data;
using AFSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AFSocial.Application.UserProfiles.QueryHandlers;
internal class GetAllUserProfilesQueryHandler :
    IRequestHandler<GetAllUserProfilesQuery, OperationResult<IEnumerable<UserProfile>>>
{
    private readonly DataContext ctx;

    public GetAllUserProfilesQueryHandler(DataContext ctx)
    {
        this.ctx = ctx;
    }

    public async Task<OperationResult<IEnumerable<UserProfile>>> Handle(GetAllUserProfilesQuery request, CancellationToken cancellationToken)
    {
        var userProfiles = await ctx.UserProfiles.ToListAsync();
        return new OperationResult<IEnumerable<UserProfile>>
        {
            Value = userProfiles,
        };
    }
}
