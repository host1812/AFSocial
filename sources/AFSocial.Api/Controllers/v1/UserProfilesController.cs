using AFSocial.Api.Contracts.UserProfiles.Requests;
using AFSocial.Domain.Aggregates.PostAggregate;
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
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserProfile([FromBody] UserProfileCreate profile)
    {

        return Ok();
    }
}
