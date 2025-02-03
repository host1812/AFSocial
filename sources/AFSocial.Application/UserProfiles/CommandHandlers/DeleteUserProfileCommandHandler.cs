using AFSocial.Application.Models;
using AFSocial.Application.UserProfiles.Commands;
using AFSocial.Data;
using AFSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFSocial.Application.UserProfiles.CommandHandlers;
public class DeleteUserProfileCommandHandler
    : IRequestHandler<DeleteUserProfileCommand, OperationResult<UserProfile>>
{
    private DataContext ctx;

    public DeleteUserProfileCommandHandler(DataContext ctx)
    {
        this.ctx = ctx;
    }

    public async Task<OperationResult<UserProfile>> Handle(DeleteUserProfileCommand request, CancellationToken cancellationToken)
    {
        var userProfile = await ctx.UserProfiles
            .FirstOrDefaultAsync(up => up.UserProfileId == request.UserProfileId);
        ctx.Remove(userProfile);
        await ctx.SaveChangesAsync();
        return new OperationResult<UserProfile>();
    }
}
