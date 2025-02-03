using AFSocial.Api.Contracts.UserProfiles.Requests;
using AFSocial.Api.Mappers;
using AFSocial.Application.UserProfiles.Commands;
using AFSocial.Application.UserProfiles.Queries;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AFSocial.Application.Models;
using AFSocial.Api.Contracts.Common;

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
    public async Task<IActionResult> CreateUserProfile(UserProfileCreateUpdate profile)
    {
        var command = profile.ToUserProfileCommand();
        var userProfile = await mediator.Send(command);
        var response = userProfile.ToUserProfileResponse();
        return CreatedAtAction(
            nameof(GetUserProfileById),
            new { id = response.UserProfileId }, response );
    }
    [HttpGet]
    [Route(ApiRoutes.UserProfiles.IdRoute)]
    public async Task<IActionResult> GetUserProfileById(Guid id)
    {
        var query = new GetUserProfileByIdQuery { UserProfileId = id};
        var userProfile = await mediator.Send(query);
        var response = userProfile.ToUserProfileResponse();
        return Ok(response);
    }

    [HttpPatch]
    [Route(ApiRoutes.UserProfiles.IdRoute)]
    public async Task<IActionResult> UpdateUserProfile(
        Guid id,
        UserProfileCreateUpdate updatedProfile)
    {
        var command = updatedProfile.ToUpdateUserProfileBasicInfoCommand();
        command.UserProfileId = id;
        var result = await mediator.Send(command);
        if (result.IsError)
        {
            if (result.Errors.Any(e => e.Code == ErrorCode.NOT_FOUND))
            {
                var error = result.Errors.FirstOrDefault(e => e.Code == ErrorCode.NOT_FOUND);
                if (error is null)
                {
                    return StatusCode(500);
                }
                var errorResponse = new ErrorResponse()
                {
                    StatusCode = (int)error.Code,
                    StatusMessage = error.Message,
                };
                errorResponse.Errors.Add(error.Message);
                return NotFound(errorResponse);
            }
            else if (result.Errors.Any(e => e.Code == ErrorCode.INTERNAL))
            {
                return StatusCode(500);
            }
        }
        var userProfile = result.Value;
        return NoContent();
    }

    [HttpDelete]
    [Route(ApiRoutes.UserProfiles.IdRoute)]
    public async Task<IActionResult> DeleteUserProfile(Guid id)
    {
        var command = new DeleteUserProfileCommand { UserProfileId = id };
        await mediator.Send(command);
        return NoContent();
    }
}
