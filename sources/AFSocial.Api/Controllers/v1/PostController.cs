using AFSocial.Domain.Aggregates.PostAggregate;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AFSocial.Api.Controllers.v1;

[ApiController]
[ApiVersion("1")]
[Route(ApiRoutes.BaseDefaultRoute)]
[Route(ApiRoutes.BaseVersionedRoute)]
public class PostController : ControllerBase
{
    private readonly IMediator mediator;

    public PostController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Post>), StatusCodes.Status200OK)]
    public IActionResult GetAllPosts()
    {
        return Ok();
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
