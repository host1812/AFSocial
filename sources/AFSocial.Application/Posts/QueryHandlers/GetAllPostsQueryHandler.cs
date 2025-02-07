using AFSocial.Application.Models;
using AFSocial.Application.Posts.Queries;
using AFSocial.Data;
using AFSocial.Domain.Aggregates.PostAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFSocial.Application.Posts.QueryHandlers;
public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, OperationResult<List<Post>>>
{
    private readonly DataContext ctx;

    public GetAllPostsQueryHandler(DataContext ctx)
    {
        this.ctx = ctx;
    }

    public async Task<OperationResult<List<Post>>> Handle(
        GetAllPostsQuery request,
        CancellationToken cancellationToken)
    {
        var result = new OperationResult<List<Post>>();
        try
        {
            var posts = await ctx.Posts.ToListAsync();
            result.Value = posts;
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
