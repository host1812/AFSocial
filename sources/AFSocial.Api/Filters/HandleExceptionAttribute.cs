using AFSocial.Api.Contracts.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AFSocial.Api.Filters;

public class HandleExceptionAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var errorResponse = new ErrorResponse();
        errorResponse.StatusCode = 500;
        errorResponse.StatusMessage = "Internal Server Error";
        errorResponse.Timestamp = DateTime.UtcNow;
        errorResponse.Errors.Add(context.Exception.Message);
        context.Result = new ObjectResult(errorResponse) { StatusCode = 500 }; ;
    }
}
