using AFSocial.Application.Models;
using AFSocial.Application.Posts.Queries;
using AFSocial.Data;
using AFSocial.Domain.Aggregates.PostAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFSocial.Application.Posts.QueryHandlers;
public class GetAllPostCommentsQueryHandler
    : IRequestHandler<GetAllPostCommentsQuery, OperationResult<List<PostComment>>>
{
    private readonly DataContext ctx;

    public GetAllPostCommentsQueryHandler(DataContext ctx)
    {
        this.ctx = ctx;
    }

    public async Task<OperationResult<List<PostComment>>> Handle(
        GetAllPostCommentsQuery request,
        CancellationToken cancellationToken)
    {
        var result = new OperationResult<List<PostComment>>();
        try
        {
            var post = await ctx.Posts
                .Include(p => p.Comments)
                .FirstOrDefaultAsync(p => p.PostId == request.PostId);
            result.Value = post?.Comments.ToList();
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
