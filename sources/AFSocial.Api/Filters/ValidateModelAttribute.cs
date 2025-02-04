using AFSocial.Api.Contracts.Common;
using AFSocial.Application.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AFSocial.Api.Filters;

public class ValidateModelAttribute : ActionFilterAttribute
{
    public override void OnResultExecuting(ResultExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errorResponse = new ErrorResponse();
            errorResponse.StatusCode = 400;
            errorResponse.StatusMessage = "Bad Request";
            
            errorResponse.Timestamp = DateTime.UtcNow;
            var validationErrors = context.ModelState.AsEnumerable();
            foreach (var error in validationErrors)
            {
                foreach (var inner in error.Value.Errors)
                {
                    errorResponse.Errors.Add(inner.ErrorMessage);
                }
                
            }
            context.Result = new BadRequestObjectResult(errorResponse);
        }
    }
}
