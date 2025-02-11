using AFSocial.Application.Models;
using AFSocial.Application.Posts.Commands;
using AFSocial.Data;
using AFSocial.Domain.Aggregates.PostAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFSocial.Application.Posts.CommandHandlers;
public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, OperationResult<Post>>
{
    private readonly DataContext ctx;

    public DeletePostCommandHandler(DataContext ctx)
    {
        this.ctx = ctx;
    }

    public async Task<OperationResult<Post>> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var result = new OperationResult<Post>();
        try
        {
            var post = await ctx.Posts
                .FirstOrDefaultAsync(p => p.PostId == request.PostId, cancellationToken);
            if (post is null)
            {
                result.IsError = true;
                result.Errors.Add(new OperationError()
                {
                    Code = ErrorCode.NOT_FOUND,
                    Message = $"Failed delete post, post not found. PostId: {request.PostId}",
                });
            }
            else
            {
                ctx.Posts.Remove(post);
                await ctx.SaveChangesAsync(cancellationToken);
                result.Value = post;
            }
        }
        catch (Exception ex)
        {
            result.IsError = true;
            result.Errors.Add(new OperationError()
            {
                Code = ErrorCode.INTERNAL,
                Message = ex.Message,
            });
        }
        
        return result;
    }
}
