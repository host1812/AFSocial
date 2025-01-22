using AFSocial.Domain.Models;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace AFSocial.Api.Controllers.v2;

[ApiController]
[ApiVersion("2")]
[Route("api/v{version:apiVersion}/[controller]")]
public class PostController : ControllerBase
{
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(Post), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public IActionResult GetById(string id)
    {
        var success = Guid.TryParse(id, out var guid);
        if (!success)
        {
            return UnprocessableEntity();
        }
        return Ok(new Post { Body = "New cool version of the post", Id = guid });
    }
}
