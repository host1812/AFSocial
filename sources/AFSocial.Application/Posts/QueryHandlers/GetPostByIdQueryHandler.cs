using AFSocial.Application.Models;
using AFSocial.Application.Posts.Queries;
using AFSocial.Data;
using AFSocial.Domain.Aggregates.PostAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AFSocial.Application.Posts.QueryHandlers;
public class GetPostByIdQueryHandler :
    IRequestHandler<GetPostByIdQuery, OperationResult<Post>>
{
    private readonly DataContext ctx;

    public GetPostByIdQueryHandler(DataContext ctx)
    {
        this.ctx = ctx;
    }

    public async Task<OperationResult<Post>> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
    {
        var result = new OperationResult<Post>();
        var post = await ctx.Posts.FirstOrDefaultAsync(
            p => p.PostId == request.PostId,
            cancellationToken);
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
            result.Value = post;
        }
        return result;
    }
}
