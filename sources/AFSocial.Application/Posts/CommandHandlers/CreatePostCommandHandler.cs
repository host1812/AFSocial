﻿using AFSocial.Application.Models;
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
public class CreatePostCommandHandler :
    IRequestHandler<CreatePostCommand, OperationResult<Post>>
{
    private readonly DataContext ctx;

    public CreatePostCommandHandler(DataContext cxt)
    {
        this.ctx = cxt;
    }

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
            result.Errors.Add(new OperationError { Message = ex.Message, Code = ErrorCode.INTERNAL});
        }
        
        return result;
    }
}
