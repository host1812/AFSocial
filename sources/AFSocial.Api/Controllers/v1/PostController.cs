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

    /// <summary>
    /// Retrieves all posts.
    /// </summary>
    /// <returns>A list of posts.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<PostResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllPosts()
    {
        var query = new GetAllPostsQuery();
        var result = await mediator.Send(query);
        return result.IsError ? HandleErrorResponse(result.Errors) :
            Ok(result.Value?.Select(p => p.ToPostResponse()).ToList());
    }

    /// <summary>
    /// Retrieves a post by its ID.
    /// </summary>
    /// <param name="id">The ID of the post.</param>
    /// <returns>The post with the specified ID.</returns>
    [HttpGet]
    [Route(ApiRoutes.Posts.IdRoute)]
    [ProducesResponseType(typeof(PostResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

    /// <summary>
    /// Creates a new post.
    /// </summary>
    /// <param name="newPost">The details of the new post.</param>
    /// <returns>The created post.</returns>
    [HttpPost]
    [ValidateModel]
    [ProducesResponseType(typeof(PostResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreatePost([FromBody] PostCreateRequest newPost)
    {
        var command = new CreatePostCommand()
        {
            TextContent = newPost.TextContent,
            UserProfileId = newPost.UserProfileId,
        };
        var result = await mediator.Send(command);
        return result.IsError ? HandleErrorResponse(result.Errors) :
            CreatedAtAction(
                nameof(GetPostById),
                new { id = result.Value?.PostId },
                result.Value?.ToPostResponse());
    }

    [HttpPatch]
    [Route(ApiRoutes.Posts.IdRoute)]
    [ValidateModel]
    public async Task<IActionResult> UpdatePost(
        [FromBody] PostUpdateRequest Post,
        [FromQuery] Guid id)
    {
        var command = new UpdatePostTextCommand()
        {
            PostId = id,
            TextContent = Post.Text,
        };

        var result = await mediator.Send(command);
        return result.IsError ? HandleErrorResponse(result.Errors) : NoContent();
    }

    [HttpDelete]
    [Route(ApiRoutes.Posts.IdRoute)]
    public async Task<IActionResult> DeletePost(Guid id)
    {
        var command = new DeletePostCommand()
        {
            PostId = id,
        };
        var result = await mediator.Send(command);
        return result.IsError ? HandleErrorResponse(result.Errors) : NoContent();
    }

    [HttpGet]
    [Route(ApiRoutes.Posts.PostCommentIdRoute)]
    public async Task<IActionResult> GetCommentsByPostId(Guid postId)
    {
        var query = new GetAllPostCommentsQuery()
        {
            PostId = postId,
        };
        var result = await mediator.Send(query);
        return result.IsError ? HandleErrorResponse(result.Errors) : Ok(result.Value);
    }
}
