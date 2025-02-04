using AFSocial.Api.Contracts.Common;
using AFSocial.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace AFSocial.Api.Controllers.v1;

public class BaseController : ControllerBase
{
    protected IActionResult HandleErrorResponse(List<OperationError> errors)
    {
        var errorResponse = new ErrorResponse();
        if (errors.Any(e => e.Code == ErrorCode.NOT_FOUND))
        {
            var error = errors.FirstOrDefault(e => e.Code == ErrorCode.NOT_FOUND);
            if (error is null)
            {
                return StatusCode(500);
            }
            errorResponse.StatusCode = 404;
            errorResponse.StatusMessage = error.Message;
            errorResponse.Errors.Add(error.Message);
            errorResponse.Timestamp = DateTime.UtcNow;
            return NotFound(errorResponse);
        }

        // Default error
        errorResponse.StatusCode = 500;
        errorResponse.StatusMessage = "Unknown Error";
        errorResponse.Errors.Add("Unknown Error");
        errorResponse.Timestamp = DateTime.UtcNow;
        return StatusCode(500, errorResponse);
    }
}
