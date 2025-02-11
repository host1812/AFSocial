using AFSocial.Application.Models;
using AFSocial.Application.Posts.Commands;
using AFSocial.Data;
using AFSocial.Domain.Aggregates.PostAggregate;
using AFSocial.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFSocial.Application.Posts.CommandHandlers;
public class UpdatePostCommandHandler : IRequestHandler<UpdatePostTextCommand, OperationResult<Post>>
{
    private readonly DataContext ctx;

    public UpdatePostCommandHandler(DataContext ctx)
    {
        this.ctx = ctx;
    }

    public async Task<OperationResult<Post>> Handle(
        UpdatePostTextCommand request,
        CancellationToken cancellationToken)
    {
        var result = new OperationResult<Post>();
        try
        {
            var post = await ctx.Posts.FirstOrDefaultAsync(p => p.PostId == request.PostId, cancellationToken);
            if (post is null)
            {
                result.IsError = true;
                result.Errors.Add(new OperationError()
                {
                    Code = ErrorCode.NOT_FOUND,
                    Message = $"Post not found. PostId: {request.PostId}",
                });
            }
            else
            {
                post.UpdatePostText(request.TextContent);
                await ctx.SaveChangesAsync(cancellationToken);
                result.Value = post;
            }
        }
        catch (PostNotValidException ex)
        {
            result.IsError = true;
            ex.ValidationErrors.ForEach(e =>
            {
                var error = new OperationError()
                {
                    Code = ErrorCode.VALIDATION,
                    Message = ex.Message,
                };
                result.Errors.Add(error);
            });
        }
        catch (Exception ex)
        {
            result.IsError = true;
            var error = new OperationError()
            {
                Code = ErrorCode.INTERNAL,
                Message = ex.Message,
            };
        }
        
        return result;
    }
}
