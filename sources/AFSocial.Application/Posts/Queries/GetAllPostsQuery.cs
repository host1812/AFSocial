using AFSocial.Application.Models;
using AFSocial.Domain.Aggregates.PostAggregate;
using MediatR;

namespace AFSocial.Application.Posts.Queries;
public class GetAllPostsQuery : IRequest<OperationResult<List<Post>>>
{
}
