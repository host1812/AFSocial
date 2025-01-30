using AFSocial.Api.Contracts.UserProfiles.Requests;
using AFSocial.Api.Mappers;
using AFSocial.Application.UserProfiles.Queries;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AFSocial.Api.Controllers.v1;

[ApiController]
[ApiVersion("1")]
[Route(ApiRoutes.BaseDefaultRoute)]
[Route(ApiRoutes.BaseVersionedRoute)]
public class UserProfilesController : ControllerBase
{
    private readonly IMediator mediator;
    public UserProfilesController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProfiles()
    {
        var query = new GetAllUserProfilesQuery();
        var profiles = await mediator.Send(query);
        var response = profiles.Select(p => p.ToUserProfileResponse()).ToList();
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserProfile([FromBody] UserProfileCreate profile)
    {
        var command = profile.ToUserProfileCommand();
        var userProfile = await mediator.Send(command);
        var response = userProfile.ToUserProfileResponse();
        return CreatedAtAction(
            nameof(GetUserProfileById),
            new { id = response.UserProfileId, userProfile });
    }
    [HttpGet]
    [Route(ApiRoutes.UserProfiles.IdRoute)]
    public async Task<IActionResult> GetUserProfileById(string id)
    {
        var query = new GetUserProfileByIdQuery { UserProfileId = Guid.Parse(id)};
        var userProfile = await mediator.Send(query);
        var response = userProfile.ToUserProfileResponse();
        return Ok(response);
    }
}
