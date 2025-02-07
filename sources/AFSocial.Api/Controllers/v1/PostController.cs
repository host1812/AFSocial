using AFSocial.Api.Mappers;
using AFSocial.Application.Posts.Queries;
using AFSocial.Domain.Aggregates.PostAggregate;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AFSocial.Api.Controllers.v1;

[ApiController]
[ApiVersion("1")]
[Route(ApiRoutes.BaseDefaultRoute)]
[Route(ApiRoutes.BaseVersionedRoute)]
public class PostController : BaseController
{
    private readonly IMediator mediator;

    public PostController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Post>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllPosts()
    {
        var query = new GetAllPostsQuery();
        var result = await mediator.Send(query);
        return result.IsError ? HandleErrorResponse(result.Errors) :
            Ok(result.Value?.Select(p => p.ToPostResponse()).ToList());
    }

    [HttpGet]
    [Route(ApiRoutes.Posts.IdRoute)]
    [ProducesResponseType(typeof(Post), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public IActionResult GetById(string id)
    {
        var success = Guid.TryParse(id, out var guid);
        if (!success)
        {
            return UnprocessableEntity();
        }
        return Ok(Post.CreatePost(Guid.NewGuid(), "Content"));
    }
}
