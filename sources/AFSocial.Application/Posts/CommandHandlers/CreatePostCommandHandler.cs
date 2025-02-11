using AFSocial.Application.Models;
using AFSocial.Application.Posts.Commands;
using AFSocial.Data;
using AFSocial.Domain.Aggregates.PostAggregate;
using AFSocial.Domain.Exceptions;
using Azure.Core;
using MediatR;
using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFSocial.Application.Posts.CommandHandlers;
/// <summary>
/// Handles the creation of a new post.
/// </summary>
public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, OperationResult<Post>>
{
    private readonly DataContext ctx;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreatePostCommandHandler"/> class.
    /// </summary>
    /// <param name="ctx">The data context.</param>
    public CreatePostCommandHandler(DataContext ctx)
    {
        this.ctx = ctx;
    }

    /// <summary>
    /// Handles the creation of a new post.
    /// </summary>
    /// <param name="request">The create post command.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The result of the operation.</returns>
    public async Task<OperationResult<Post>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var result = new OperationResult<Post>();
        try
        {
            var post = Post.CreatePost(request.UserProfileId, request.TextContent);
            ctx.Posts.Add(post);
            await ctx.SaveChangesAsync();
            result.Value = post;
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
            result.Errors.Add(new OperationError { Message = ex.Message, Code = ErrorCode.INTERNAL });
        }

        return result;
    }
}
