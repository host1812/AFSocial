using AFSocial.Application.UserProfiles.Queries;
using AFSocial.Data;
using AFSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AFSocial.Application.UserProfiles.QueryHandlers;
internal class GetAllUserProfilesQueryHandler : IRequestHandler<GetAllUserProfilesQuery, IEnumerable<UserProfile>>
{
    private readonly DataContext ctx;

    public GetAllUserProfilesQueryHandler(DataContext ctx)
    {
        this.ctx = ctx;
    }

    public async Task<IEnumerable<UserProfile>> Handle(GetAllUserProfilesQuery request, CancellationToken cancellationToken)
    {
        return await ctx.UserProfiles.ToListAsync();
    }
}
