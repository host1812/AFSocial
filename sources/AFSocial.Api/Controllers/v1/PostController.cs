using AFSocial.Api.Contracts.Posts.Requests;
using AFSocial.Api.Contracts.Posts.Responses;
using AFSocial.Api.Filters;
using AFSocial.Api.Mappers;
using AFSocial.Application.Posts.Commands;
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
    [ProducesResponseType(typeof(List<PostResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(, StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllPosts()
    {
        var query = new GetAllPostsQuery();
        var result = await mediator.Send(query);
        return result.IsError ? HandleErrorResponse(result.Errors) :
            Ok(result.Value?.Select(p => p.ToPostResponse()).ToList());
    }

    [HttpGet]
    [Route(ApiRoutes.Posts.IdRoute)]
    [ProducesResponseType(typeof(PostResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(, StatusCodes.Status404NotFound)]
    [ProducesResponseType(, StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetPostById(Guid id)
    {
        var query = new GetPostByIdQuery()
        {
            PostId = id
        };
        var result = await mediator.Send(query);
        return result.IsError ? HandleErrorResponse(result.Errors) :
            Ok(result.Value?.ToPostResponse());
    }
    [HttpPost]
    [ValidateModel]
    public async Task<IActionResult> CreatePost([FromBody] PostCreateRequest newPost)
    {
        var command = new CreatePostCommand()
        {
            TextContent = newPost.TextContent,
            UserProfileId = newPost.UserProfileId,
        };
        var result = await mediator.Send(command);
        return result.IsError ? HandleErrorResponse(result.Errors) :
            Ok(result.Value?.ToPostResponse());
    }
}
