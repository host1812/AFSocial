using AFSocial.Domain.Aggregates.PostAggregate;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace AFSocial.Api.Controllers.v1;

[ApiController]
[ApiVersion("1")]
[Route(ApiRoutes.BaseDefaultRoute)]
[Route(ApiRoutes.BaseVersionedRoute)]
public class UserProfilesController : ControllerBase
{
    public UserProfilesController()
    {
    }

    public async Task<IActionResult> GetAllProfiles()
    {
        return Ok();
    }

    public async Task<IActionResult> CreateUserProfile()
    {
        return Ok();
    }
}
