using AFSocial.Application.Models;
using AFSocial.Application.Posts.Queries;
using AFSocial.Data;
using AFSocial.Domain.Aggregates.PostAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFSocial.Application.Posts.QueryHandlers;
public class GetAllPostCommentsQueryHandler
    : IRequestHandler<GetAllPostCommentsQuery, OperationResult<IEnumerable<PostComment>>>
{
    private readonly DataContext ctx;

    public GetAllPostCommentsQueryHandler(DataContext ctx)
    {
        this.ctx = ctx;
    }

    public async Task<OperationResult<IEnumerable<PostComment>>> Handle(
        GetAllPostCommentsQuery request,
        CancellationToken cancellationToken)
    {
        var result = new OperationResult<IEnumerable<PostComment>>();
        var posts = await ctx.Posts
    }
}
