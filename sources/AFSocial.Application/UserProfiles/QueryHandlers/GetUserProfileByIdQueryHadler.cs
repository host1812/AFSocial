using AFSocial.Application.UserProfiles.Queries;
using AFSocial.Data;
using AFSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AFSocial.Application.UserProfiles.QueryHandlers;
internal class GetUserProfileByIdQueryHadler : IRequestHandler<GetUserProfileByIdQuery, UserProfile>
{
    private readonly DataContext ctx;

    public GetUserProfileByIdQueryHadler(DataContext ctx)
    {
        this.ctx = ctx;
    }

    public async Task<UserProfile> Handle(GetUserProfileByIdQuery request, CancellationToken cancellationToken)
    {
        return await ctx.UserProfiles.FirstOrDefaultAsync(
            up => up.UserProfileId == request.UserProfileId,
            cancellationToken);
    }
}
