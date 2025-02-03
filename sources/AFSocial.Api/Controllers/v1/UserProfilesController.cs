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
public class UserProfilesController : BaseController
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
        var result = await mediator.Send(query);
        return result.IsError ? HandleErrorResponse(result.Errors) :
            Ok(result.Value?.Select(p => p.ToUserProfileResponse()).ToList());
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserProfile(UserProfileCreateUpdate profile)
    {
        var command = profile.ToUserProfileCommand();
        var result = await mediator.Send(command);
        return result.IsError ? HandleErrorResponse(result.Errors) :
            CreatedAtAction(
                nameof(GetUserProfileById),
                new {id = result.Value?.UserProfileId},
                result.Value?.ToUserProfileResponse());
    }

    [HttpGet]
    [Route(ApiRoutes.UserProfiles.IdRoute)]
    public async Task<IActionResult> GetUserProfileById(Guid id)
    {
        var query = new GetUserProfileByIdQuery { UserProfileId = id};
        var result = await mediator.Send(query);
        return result.IsError ? HandleErrorResponse(result.Errors) :
            Ok(result.Value?.ToUserProfileResponse());
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
        return result.IsError ? HandleErrorResponse(result.Errors) : NoContent();
    }

    [HttpDelete]
    [Route(ApiRoutes.UserProfiles.IdRoute)]
    public async Task<IActionResult> DeleteUserProfile(Guid id)
    {
        var command = new DeleteUserProfileCommand { UserProfileId = id };
        var result = await mediator.Send(command);
        return result.IsError ? HandleErrorResponse(result.Errors) : NoContent();
    }
}
