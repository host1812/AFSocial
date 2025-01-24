﻿using AFSocial.Domain.Aggregates.PostAggregate;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace AFSocial.Api.Controllers.v1;

[ApiController]
[ApiVersion("1")]
[Route("api/[controller]")]
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
        return Ok(Post.CreatePost(Guid.NewGuid(), "Content"));
    }
}
