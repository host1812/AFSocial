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
public class AddCommentToPostCommandHandler
    : IRequestHandler<AddCommentToPostCommand, OperationResult<PostComment>>
{
    private readonly DataContext ctx;

    public AddCommentToPostCommandHandler(DataContext ctx)
    {
        this.ctx = ctx;
    }

    public async Task<OperationResult<PostComment>> Handle(
        AddCommentToPostCommand request,
        CancellationToken cancellationToken)
    {
        var result = new OperationResult<PostComment>();
        try
        {
            
            var post = await ctx.Posts
                .FirstOrDefaultAsync(p => p.PostId == request.PostId);
            if (post is null)
            {
                result.IsError = true;
                result.Errors.Add(new OperationError()
                {
                    Code = ErrorCode.NOT_FOUND,
                    Message = $"Failed to add comment to post. Post not found. PostId: {request.PostId}",
                });
            }
            else
            {
                var comment = PostComment.CreatePostComment(
                    request.PostId, request.CommentText, request.UserProfileId);
                post?.AddPostComment(comment);
                result.Value = comment;
            }
        }
        catch (PostCommentNotValidException ex)
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
            result.Errors.Add(new OperationError
            {
                Code = ErrorCode.INTERNAL,
                Message = ex.Message,
            });
        }
        return result;
    }
}
